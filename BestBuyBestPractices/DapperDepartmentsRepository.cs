using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace BestBuyBestPractices
{
    public class DapperDepartmentsRepository : IDepartmentsRepository
    {
        private readonly IDbConnection _connection;

        public DapperDepartmentsRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<departments> GetAllDepartments()
        {
            return _connection.Query<departments>("SELECT * FROM departments;");
        }

        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (NAME) VALUES (@departmentName);",
                new { departmentName = newDepartmentName });
        }
    }
}
