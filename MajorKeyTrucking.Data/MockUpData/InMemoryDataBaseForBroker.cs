using MajorKeyTrucking.Data.Models;
using MajorKeyTrucking.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorKeyTrucking.Data.MockUpData
{
    public class InMemoryDataBaseForBroker:IBrokerRepository
    {
        List<Broker> brokers;
        public InMemoryDataBaseForBroker()
        {
            
            brokers = new List<Broker>()
            {
                new Broker{BrokerId = 1, BrokerCompanyName = "JB Hunt", BrokerEmail="info@jbhunt.com", BrokerPhoneNumber = "984-987-9876"},
                new Broker{BrokerId = 2, BrokerCompanyName = "Acme Solutions", BrokerEmail="info@jbhunt.com", BrokerPhoneNumber = "984-987-9876"},
                new Broker{BrokerId = 3, BrokerCompanyName = "Landstar", BrokerEmail="info@jbhunt.com", BrokerPhoneNumber = "984-987-9876"}
            };
        }

        public void Add(Broker broker)
        {
            brokers.Add(broker);
        }

        public void Delete(int id)
        {
            var broker = Get(id);
            if (broker != null)
            {
                brokers.Remove(broker);
            }
        }

        public Broker Get(int id)
        {
            return brokers.FirstOrDefault(b => b.BrokerId == id);
        }

        public IEnumerable<Broker> GetAll()
        {
            var broker = brokers.OrderBy(b => b.BrokerId);
            return broker;
        }

        public void Update(Broker broker)
        {
            var existing = Get(broker.BrokerId);
            if (existing != null)
            {
                existing.BrokerCompanyName = broker.BrokerCompanyName;
                existing.BrokerPhoneNumber = broker.BrokerPhoneNumber;
                existing.BrokerEmail = broker.BrokerEmail;

            }
        }
    }
}
