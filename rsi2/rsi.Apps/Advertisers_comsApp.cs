using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rsi.Entities;

namespace rsi.Apps
{
    public class Advertisers_comsApp
    {
        Context _context = new Context();

        public Advertiser_com Save(Advertiser_com __obj)
        {
            Fix(__obj);

            if (__obj.Id == 0) // se não tem id é pq é um registro novo            
                __obj = Add(__obj);

            else
                __obj = Update(__obj);

            return __obj;
        }

        public Advertiser_com Add(Advertiser_com __obj)
        {
            using (var _context = new Context())
            {                
                _context.Advertisers_coms.Add(__obj);
                _context.SaveChanges();
            }

            return __obj;
        }

        public Advertiser_com Update(Advertiser_com __objUpdate)
        {
            using (var _context = new Context())
            {
                //fonte: http://stackoverflow.com/questions/15336248/entity-framework-5-updating-a-record

                Advertiser_com _objOriginal = _context.Advertisers_coms.Find(__objUpdate.Id);

                if (_objOriginal != null)
                {
                    _context.Entry(_objOriginal).CurrentValues.SetValues(__objUpdate);
                    _context.SaveChanges();
                }
            }

            return __objUpdate;
        }

        public IEnumerable<Advertiser_com> ListAll(string __op = "lazy")
        {
            using (var _context = new Context())
            {
                var _Advertisers_comsList = _context.Advertisers_coms.ToList();

                if (__op == "full")
                {
                    List<Advertiser_com> _Advertisers_comsListTemp = new List<Advertiser_com>();
                    foreach (var _item in _Advertisers_comsList)
                        _Advertisers_comsListTemp.Add(FillAllFields(_item));

                    _Advertisers_comsList = _Advertisers_comsListTemp;
                }

                return _Advertisers_comsList;
            }
        }

        public Advertiser_com SearchById(int __id, string __op = "lazy")
        {
            using (var _context = new Context())
            {
                var _obj = _context.Advertisers_coms.FirstOrDefault(c => c.Id == __id);

                if (__op == "full")
                    _obj = FillAllFields(_obj);

                return _obj;
            }
        }
       
        //public void Delete(Advertiser_com __obj)
        //{
        //    using (var _context = new Context())
        //    {
        //        Advertiser_com _objToDelete = _context.Advertisers_coms.Find(__obj.Id);

        //        if (_objToDelete != null)
        //        {
        //            _context.Advertisers_coms.Remove(_objToDelete);

        //            _context.SaveChanges();
        //        }

        //    }
        //}

        public void Delete(int __id)
        {
            using (var _context = new Context())
            {
                Advertiser_com _objToDelete = _context.Advertisers_coms.Find(__id);

                if (_objToDelete != null)
                {
                    _context.Advertisers_coms.Remove(_objToDelete);

                    _context.SaveChanges();
                }

            }
        }

        public Advertiser_com Fix(Advertiser_com __obj)
        {
            __obj.AddUserId = 1;
            __obj.UpdateUserId = 1;
            __obj.UpdateDate = System.DateTime.Now;
            __obj.AddDate = __obj.Id > 0 ? __obj.AddDate : System.DateTime.Now;

            return __obj;
        }

        public Advertiser_com FillAllFields(Advertiser_com __obj)
        {           
            return __obj;
        }
    }
}
