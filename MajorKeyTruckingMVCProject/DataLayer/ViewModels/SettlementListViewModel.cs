using MajorKeyTrucking.Data;
using MajorKeyTruckingMVCProject.DataLayer.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MajorKeyTruckingMVCProject.DataLayer.ViewModels
{
    public class SettlementListViewModel
    {
        public IEnumerable<Driver> Drivers { get; set; }
        public RouteDictionary CurrentRoute { get; set; }

        public int TotalPages { get; set; }
    }
}
