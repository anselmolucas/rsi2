using rsi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rsi.Apps
{
    public class Advertisers_adressesApp
    {
        Context _context = new Context();

        public Advertiser_address Save(Advertiser_address __obj)
        {
            Fix(__obj);

            if (__obj.Id == 0) // se não tem id é pq é um registro novo            
                __obj = Add(__obj);

            else
                __obj = Update(__obj);

            return __obj;
        }

        public Advertiser_address Add(Advertiser_address __obj)
        {
            using (var _context = new Context())
            {
                _context.Advertisers_adresses.Add(__obj);
                _context.SaveChanges();
            }

            return __obj;
        }

        public Advertiser_address Update(Advertiser_address __objUpdate)
        {
            using (var _context = new Context())
            {
                //fonte: http://stackoverflow.com/questions/15336248/entity-framework-5-updating-a-record

                Advertiser_address _objOriginal = _context.Advertisers_adresses.Find(__objUpdate.Id);

                if (_objOriginal != null)
                {
                    _context.Entry(_objOriginal).CurrentValues.SetValues(__objUpdate);
                    _context.SaveChanges();
                }
            }

            return __objUpdate;
        }

        public IEnumerable<Advertiser_address> ListAll(string __op = "lazy")
        {
            using (var _context = new Context())
            {
                var _categoriesList = _context.Advertisers_adresses.ToList();

                if (__op == "full")
                {
                    List<Advertiser_address> _categoriesListTemp = new List<Advertiser_address>();
                    foreach (var _item in _categoriesList)
                        _categoriesListTemp.Add(FillAllFields(_item));

                    _categoriesList = _categoriesListTemp;
                }

                return _categoriesList;
            }
        }

        public Advertiser_address SearchById(int __id, string __op = "lazy")
        {
            using (var _context = new Context())
            {
                var _obj = _context.Advertisers_adresses.FirstOrDefault(c => c.Id == __id);

                if (__op == "full")
                    _obj = FillAllFields(_obj);

                return _obj;
            }
        }
        
        public void Delete(int __id)
        {
            using (var _context = new Context())
            {
                Advertiser_address _objToDelete = _context.Advertisers_adresses.Find(__id);

                if (_objToDelete != null)
                {
                    _context.Advertisers_adresses.Remove(_objToDelete);

                    _context.SaveChanges();
                }
            }
        }

        public Advertiser_address Fix(Advertiser_address __obj)
        {
            __obj.AddUserId = 1;
            __obj.UpdateUserId = 1;
            __obj.UpdateDate = System.DateTime.Now;
            __obj.AddDate = __obj.Id > 0 ? __obj.AddDate : System.DateTime.Now;

            return __obj;
        }

        public Advertiser_address FillAllFields(Advertiser_address __obj)
        {
            if (__obj.CityId > 0)
            __obj.CityName = _context.Cities.Find(__obj.CityId).Name;

            return __obj;
        }
    }
}
