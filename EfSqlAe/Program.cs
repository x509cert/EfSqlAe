using Azure.Core;
using EfSqlAe.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Azure.Identity;
using Microsoft.Data.SqlClient.AlwaysEncrypted.AzureKeyVaultProvider;

static void RegisterAkvForAe(TokenCredential cred)
{
    var akvAeProvider = new SqlColumnEncryptionAzureKeyVaultProvider(cred);
    SqlConnection.RegisterColumnEncryptionKeyStoreProviders(
        customProviders: new Dictionary<string, SqlColumnEncryptionKeyStoreProvider>() {
                { SqlColumnEncryptionAzureKeyVaultProvider.ProviderName, akvAeProvider }
        });
}

static (TokenCredential? tok, string? oauth2Sql) LoginToAure()
{
    try
    {
        var credential = new AzureCliCredential();
        var oauth2TokenSql = credential.GetToken(
                new TokenRequestContext(
                    ["https://database.windows.net/.default"])).Token;
        return (credential, oauth2TokenSql);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        return (null, null);
    }
}

(TokenCredential? credential, string? oauth2TokenSql) = LoginToAure();
RegisterAkvForAe(credential);

using (var db = new ContosoHRContext())
{
    var salaryThreshold = 55000;
    var ssnSpecial = "6%";
    var emps =  from employee in db.Employees
                where employee.Salary > salaryThreshold
                    && EF.Functions.Like(employee.SSN, ssnSpecial)
                orderby employee.SSN descending
                select employee;

    foreach (var emp in emps) {
        Console.WriteLine($"{emp.SSN}, {emp.FirstName}, {emp.LastName}, {emp.Salary}");
    }
}

