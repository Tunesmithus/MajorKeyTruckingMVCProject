using MajorKeyTruckingMVCProject.Data.DTOs;
using MajorKeyTruckingMVCProject.DataLayer.ExtensionMethods;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MajorKeyTruckingMVCProject.DataLayer.Grid
{
    public class GridBuilder
    {
        private const string RouteKey = "currentroute";
        private ISession session { get; set; }

        private RouteDictionary routes { get; set; }

        public GridBuilder(ISession sess)
        {
            session = sess;
            routes = session.GetObject<RouteDictionary>(RouteKey);

        }

        public GridBuilder(ISession sess, GridDTO values)
        {
            routes = new RouteDictionary();
            routes.PageNumber = values.PageNumber;
            routes.PageSize = values.PageSize;

            SaveRouteSegments();
        }

        private void SaveRouteSegments()
        {
            session.SetObject<RouteDictionary>(RouteKey, routes);
        }

        public int GetTotalPages(int count)
        {
            int size = routes.PageSize;
            return (count + size - 1) / size;
        }

        public RouteDictionary CurrentRoute => routes;
    }
}
