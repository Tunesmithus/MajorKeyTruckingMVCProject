using MajorKeyTrucking.Data.Models;
using MajorKeyTrucking.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorKeyTrucking.Data.MockUpData
{
    public class InMemoryDataBaseForExpense : IExpenseRepository
    {
        

        List<Expense> expenses;
        public InMemoryDataBaseForExpense()
        {
            

            expenses = new List<Expense>()
            {
                new Expense{ExpenseId = 1, ExpenseDate=DateTime.Parse("1/21/2022"), ExpenseName = "Tire Replacement", ExpenseCost = 250.00M, ExpenseDescription ="Tire replaced at Loves" },
                new Expense{ExpenseId = 2, ExpenseDate=DateTime.Parse("1/21/2022"), ExpenseName = "Cash Advance", ExpenseCost = 100.00M, ExpenseDescription ="Driver extracted 100 dollars from comdata fuel card" },
                new Expense{ExpenseId = 3, ExpenseDate=DateTime.Parse("1/21/2022"), ExpenseName = "Trailer Maintenance", ExpenseCost = 50.00M, ExpenseDescription ="Marker Light replaced on trailer" },
                new Expense{ExpenseId = 4, ExpenseDate=DateTime.Parse("1/21/2022"), ExpenseName = "Truck Fluids", ExpenseCost = 250.00M, ExpenseDescription ="Antifreeze and Oil purchased" },
            };
        }
        public void Add(Expense expense)
        {
            expenses.Add(expense);
            expense.ExpenseId = expenses.Max(e => e.ExpenseId) + 1;
            
        }

        public void Delete(int id)
        {
            var expense = Get(id);
            if (expense != null)
            {
                expenses.Remove(expense);
            }  
            
        }

        public Expense Get(int id)
        {
            return expenses.FirstOrDefault(e => e.ExpenseId == id);
        }

        public IEnumerable<Expense> GetAll()
        {
            return expenses.OrderBy(e => e.ExpenseId);
        }

        public void Update(Expense expense)
        {
            var existing = Get(expense.ExpenseId);
            if (existing != null)
            {
                existing.ExpenseName = expense.ExpenseName;
                existing.ExpenseDate = expense.ExpenseDate;
                existing.ExpenseCost = expense.ExpenseCost;
                existing.ExpenseDescription = expense.ExpenseDescription;
            }
        }
    }
}
