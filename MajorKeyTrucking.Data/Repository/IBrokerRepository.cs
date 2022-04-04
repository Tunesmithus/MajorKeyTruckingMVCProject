using MajorKeyTrucking.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorKeyTrucking.Data.Repository
{
    public interface IBrokerRepository
    {
        IEnumerable<Broker> GetAll();

        Broker Get(int id);

        void Add(Broker broker);

        void Update(Broker broker);

        void Delete(int id);
    }
}
