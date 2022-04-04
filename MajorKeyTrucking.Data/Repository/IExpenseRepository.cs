using MajorKeyTrucking.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorKeyTrucking.Data.Repository
{
    public interface IExpenseRepository
    {
        IEnumerable<Expense> GetAll();

        Expense Get(int id);

        void Add(Expense expense);

        void Update(Expense expense);

        void Delete(int id);


    }
}
