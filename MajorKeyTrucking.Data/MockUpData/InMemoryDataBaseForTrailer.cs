using MajorKeyTrucking.Data.Models;
using MajorKeyTrucking.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorKeyTrucking.Data.MockUpData
{
    public class InMemoryDataBaseForTrailer:ITrailerRepository
    {
        List<Trailer> trailers;


        public InMemoryDataBaseForTrailer()
        {
            trailers = new List<Trailer>()
            {
                new Trailer{TrailerId = 1, VinNumber = "1234567890123456", Year = 2013, Make = "Great Dane", Model = "53' Van", TrailerNumber = "7047"},
                new Trailer{TrailerId = 2, VinNumber = "1234567890123456", Year = 2008, Make = "Great Dane", Model = "53' Van", TrailerNumber = "7047"}
            };


        }

        public void Add(Trailer trailer)
        {
            trailers.Add(trailer);
            trailer.TrailerId = trailers.Max(t => t.TrailerId) + 1;
        }

        public void Delete(int id)
        {
            var trailer = Get(id);
            if (trailer != null)
            {
                trailers.Remove(trailer);
            }
        }

        public Trailer Get(int id)
        {
            var trailer = trailers.FirstOrDefault(t => t.TrailerId == id);
            return trailer;
        }

        public IEnumerable<Trailer> GetAll()
        {
            var trailer = trailers.OrderBy(t => t.TrailerId);
            return trailer;
        }

        public void Update(Trailer trailer)
        {
            var existing = Get(trailer.TrailerId);
            if (existing != null)
            {
                existing.VinNumber = trailer.VinNumber;
                existing.Year = trailer.Year;
                existing.Make = trailer.Make;
                existing.Model = trailer.Model;
                existing.TrailerNumber = trailer.TrailerNumber;
                
            }
        }
    }
}
