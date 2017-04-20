using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rsi.Entities;

namespace rsi.Apps
{
    public class CitiesApp
    {
        public IList<City> ListAll()
        {
            using (var _context = new Context())
            {
                return _context.Cities.ToList();
            }
        }

        public City SearchById(int __id)
        {
            using (var _context = new Context())
            {
                var _retorno = _context.Cities.FirstOrDefault(c => c.Id == __id);                

                return _retorno;
            }
        }

        public City SearchByUf(string __uf)
        {
            using (var _context = new Context())
            {
                var _retorno = _context.Cities.FirstOrDefault(c => c.UF == __uf.ToLower().Trim());

                return _retorno;
            }
        }
    }
}
