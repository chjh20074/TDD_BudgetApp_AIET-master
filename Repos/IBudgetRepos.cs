using System.Collections.Generic;

namespace TDD_BudgetApp.Repos
{
    public interface IBudgetRepos<T>
    {
        List<T> GetAll();
    }
}