﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using EfSqlAe.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace EfSqlAe.Models
{
    public partial interface IContosoHRContextProcedures
    {
        Task<List<usp_GetSalaryResult>> usp_GetSalaryAsync(decimal? MinSalary, decimal? MaxSalary, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}
