using System.Collections.Generic;

namespace TDD_BudgetApp.Repository
{
    public interface IRepo<T>
    {
        List<T> GetAll();
    }
}