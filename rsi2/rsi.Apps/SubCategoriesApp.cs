using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rsi.Entities;

namespace rsi.Apps
{
    public class SubCategoriesApp
    {
        Context _context = new Context();

        public SubCategory Save(SubCategory __obj)
        {
            if (__obj.Id == 0) // se não tem id é pq é um registro novo
            {
                __obj = Add(__obj);
            }

            else
                __obj = Update(__obj);

            return __obj;
        }

        public SubCategory Add(SubCategory __obj)
        {
            using (var _context = new Context())
            {
                _context.SubCategories.Add(__obj);
                _context.SaveChanges();
            }
            return __obj;
        }

        public SubCategory Update(SubCategory __objUpdate)
        {
            using (var _context = new Context())
            {
                //fonte: http://stackoverflow.com/questions/15336248/entity-framework-5-updating-a-record

                SubCategory _objOriginal = _context.SubCategories.Find(__objUpdate.Id);

                if (_objOriginal != null)
                {
                    _context.Entry(_objOriginal).CurrentValues.SetValues(__objUpdate);

                    _context.SaveChanges();
                }

            }

            return __objUpdate;
        }

        public IEnumerable<SubCategory> ListAll(string __mode = "lazy")
        {
            using (var _context = new Context())
            {
                var _retorno = _context.SubCategories.ToList();

                if (__mode == "full")
                {
                    List<SubCategory> _subCategoryListNew = new List<Entities.SubCategory>();
                    foreach (var _item in _retorno)
                    {
                        SubCategory _subCategoryTemp = FillFields(_item.Id, "full");
                        //if (_subCategoryTemp.St == status.on && _subCategoryTemp.Id > 1)
                        if (_subCategoryTemp.St == status.on)
                            _subCategoryListNew.Add(_subCategoryTemp);
                    }
                    _retorno = _subCategoryListNew;
                }

                return _retorno;
            }
        }

        public SubCategory SearchById(int __id, string __mode = "lazy")
        {
            using (var _context = new Context())
            {
                return FillFields(__id, __mode);
            }
        }

        public void Delete(SubCategory __obj)
        {
            using (var _context = new Context())
            {
                SubCategory _objToDelete = _context.SubCategories.Find(__obj.Id);

                if (_objToDelete != null)
                {
                    _context.SubCategories.Remove(_objToDelete);

                    _context.SaveChanges();
                }
            }
        }

        public List<SubCategory> FillList(List<SubCategory> __list)
        {
            #region listFull
            int _contaRegisters = 0;
            List<Advertiser> _advertisersList = new List<Advertiser>();

            foreach (var _item in __list)
            {
                _item.CategoryObj = _context.Categories.Find(_item.CategoryId);

                _contaRegisters++;
                _item.RegisterCount = _contaRegisters;
            }

            #endregion
            return __list;
        }
        
        private SubCategory FillFields(int __id, string __mode = "lazy")
        {
            SubCategory __obj = _context.SubCategories.FirstOrDefault(x => x.Id == __id);

            if (__obj != null && __mode == "full")
            {
                __obj.CategoryObj = _context.Categories.FirstOrDefault(x => x.Id == __obj.CategoryId);
                __obj.LinkedRecords = _context.Advertisers_SubCategories.Where(x => x.SubCategoryId == __obj.Id).Count();
            }


            else if (__obj == null)
                __obj = new SubCategory();

            return __obj;
        }

        public SubCategory Fix(SubCategory __obj)
        {
            __obj.AddUserId = 1;
            __obj.UpdateUserId = 1;
            __obj.UpdateDate = System.DateTime.Now;
            __obj.AddDate = __obj.Id > 0 ? __obj.AddDate : System.DateTime.Now;

            return __obj;
        }
    }
}
