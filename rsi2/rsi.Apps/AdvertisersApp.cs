using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rsi.Entities;

namespace rsi.Apps
{
    public class AdvertisersApp
    {
        Context _context = new Context();

        public Advertiser Save(Advertiser __obj)
        {
            Fix(__obj);

            if (__obj.Id == 0) // se não tem id é pq é um registro novo            
                __obj = Add(__obj);

            else
                __obj = Update(__obj);

            return __obj;
        }

        public Advertiser Add(Advertiser __obj)
        {
            using (var _context = new Context())
            {                
                _context.Advertisers.Add(__obj);
                _context.SaveChanges();
            }

            return __obj;
        }

        public Advertiser Update(Advertiser __objUpdate)
        {
            using (var _context = new Context())
            {
                //fonte: http://stackoverflow.com/questions/15336248/entity-framework-5-updating-a-record

                Advertiser _objOriginal = _context.Advertisers.Find(__objUpdate.Id);

                if (_objOriginal != null)
                {
                    _context.Entry(_objOriginal).CurrentValues.SetValues(__objUpdate);
                    _context.SaveChanges();
                }
            }

            return __objUpdate;
        }

        public IEnumerable<Advertiser> ListAll(string __op = "lazy")
        {
            using (var _context = new Context())
            {
                var _advertisersList = _context.Advertisers.ToList();

                if (__op == "full")
                {
                    List<Advertiser> _advertisersListTemp = new List<Advertiser>();
                    foreach (var _item in _advertisersList)
                        _advertisersListTemp.Add(FillAllFields(_item));

                    _advertisersList = _advertisersListTemp;
                }

                return _advertisersList;
            }
        }

        public Advertiser SearchById(int __id, string __op = "lazy")
        {
            using (var _context = new Context())
            {
                var _obj = _context.Advertisers.FirstOrDefault(c => c.Id == __id);

                if (__op == "full")
                    _obj = FillAllFields(_obj);

                return _obj;
            }
        }
       
        public void Delete(Advertiser __obj)
        {
            using (var _context = new Context())
            {
                Advertiser _objToDelete = _context.Advertisers.Find(__obj.Id);

                if (_objToDelete != null)
                {
                    _context.Advertisers.Remove(_objToDelete);

                    _context.SaveChanges();
                }

            }
        }

        public Advertiser Fix(Advertiser __obj)
        {
            __obj.AddUserId = 1;
            __obj.UpdateUserId = 1;
            __obj.UpdateDate = System.DateTime.Now;
            __obj.AddDate = __obj.Id > 0 ? __obj.AddDate : System.DateTime.Now;

            return __obj;
        }

        public Advertiser FillAllFields(Advertiser __obj)
        {
           
            return __obj;
        }
    }
}
