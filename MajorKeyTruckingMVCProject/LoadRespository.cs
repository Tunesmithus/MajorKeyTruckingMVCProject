using MajorKeyTrucking.Data;
using MajorKeyTrucking.Data.Models;
using MajorKeyTruckingMVCProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MajorKeyTruckingMVCProject
{
    public class LoadRespository: GenericRepository<Load>
    {
        public LoadRespository(ApplicationDbContext db):base(db)
        {

        }

        public override void Update(Load entity)
        {
            base.Update(entity);
        }

        public override void Add(Load entity)
        {
            base.Add(entity);
        }
    }
}
