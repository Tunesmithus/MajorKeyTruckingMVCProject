using MajorKeyTrucking.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorKeyTrucking.Data.MockUpData
{
    public interface ILoadRepository
    {
        IEnumerable<Load> GetAll();

        Load Get(int id);

        void Add(Load load);

        void Update(Load load);

        void Delete(int id);
    }
}
