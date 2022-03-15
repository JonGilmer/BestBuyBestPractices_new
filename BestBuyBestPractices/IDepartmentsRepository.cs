using System;
using System.Collections.Generic;

namespace BestBuyBestPractices
{
    public interface IDepartmentsRepository
    {
        IEnumerable<departments> GetAllDepartments();
    }
}
