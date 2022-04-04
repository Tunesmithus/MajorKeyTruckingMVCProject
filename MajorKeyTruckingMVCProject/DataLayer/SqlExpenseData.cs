using MajorKeyTrucking.Data.Models;
using MajorKeyTrucking.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MajorKeyTruckingMVCProject.Data
{
    public class SqlExpenseData : IExpenseRepository
    {
        private ApplicationDbContext db;

        public SqlExpenseData(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(Expense expense)
        {
            db.Expenses.Add(expense);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var expenses = db.Expenses.Find(id);
            db.Expenses.Remove(expenses);
            db.SaveChanges();
        }

        public Expense Get(int id)
        {
            var entity = db.Expenses.FirstOrDefault(e => e.ExpenseId == id);
            return entity;
        }

        public IEnumerable<Expense> GetAll()
        {
            return from e in db.Expenses
                   orderby e.ExpenseId
                   select e;

        }

        public void Update(Expense expense)
        {
            /* Update syntax without optomistic concurrency
            var d = Get(expense.ExpenseId);
            d.FirstName = "";
            d.LastName = ""; */

            //Update syntax with optomistic concurrency
            var entry = db.Entry(expense);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
