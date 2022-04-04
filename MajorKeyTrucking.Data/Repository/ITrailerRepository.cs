using MajorKeyTrucking.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorKeyTrucking.Data.Repository
{
    public interface ITrailerRepository
    {
        IEnumerable<Trailer> GetAll();

        Trailer Get(int id);

        void Add(Trailer trailer);
        void Update(Trailer trailer);

        void Delete(int id);
    }
}
