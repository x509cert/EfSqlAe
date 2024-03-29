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
    public partial class ContosoHRContext
    {
        private IContosoHRContextProcedures _procedures;

        public virtual IContosoHRContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new ContosoHRContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public IContosoHRContextProcedures GetProcedures()
        {
            return Procedures;
        }

        protected void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<usp_GetSalaryResult>().HasNoKey().ToView(null);
        }
    }

    public partial class ContosoHRContextProcedures : IContosoHRContextProcedures
    {
        private readonly ContosoHRContext _context;

        public ContosoHRContextProcedures(ContosoHRContext context)
        {
            _context = context;
        }

        public virtual async Task<List<usp_GetSalaryResult>> usp_GetSalaryAsync(decimal? MinSalary, decimal? MaxSalary, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "MinSalary",
                    Precision = 19,
                    Scale = 4,
                    Value = MinSalary ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Money,
                },
                new SqlParameter
                {
                    ParameterName = "MaxSalary",
                    Precision = 19,
                    Scale = 4,
                    Value = MaxSalary ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Money,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<usp_GetSalaryResult>("EXEC @returnValue = [dbo].[usp_GetSalary] @MinSalary, @MaxSalary", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}
