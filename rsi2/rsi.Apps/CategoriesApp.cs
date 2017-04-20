using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rsi.Entities;

namespace rsi.Apps
{
    public class CategoriesApp
    {
        Context _context = new Context();

        public Category Save(Category __obj)
        {
            Fix(__obj);

            if (__obj.Id == 0) // se não tem id é pq é um registro novo            
                __obj = Add(__obj);

            else
                __obj = Update(__obj);

            return __obj;
        }

        public Category Add(Category __obj)
        {
            using (var _context = new Context())
            {                
                _context.Categories.Add(__obj);
                _context.SaveChanges();
            }

            return __obj;
        }

        public Category Update(Category __objUpdate)
        {
            using (var _context = new Context())
            {
                //fonte: http://stackoverflow.com/questions/15336248/entity-framework-5-updating-a-record

                Category _objOriginal = _context.Categories.Find(__objUpdate.Id);

                if (_objOriginal != null)
                {
                    _context.Entry(_objOriginal).CurrentValues.SetValues(__objUpdate);
                    _context.SaveChanges();
                }
            }

            return __objUpdate;
        }

        public IEnumerable<Category> ListAll(string __op = "lazy")
        {
            using (var _context = new Context())
            {
                var _categoriesList = _context.Categories.ToList();

                if (__op == "full")
                {
                    List<Category> _categoriesListTemp = new List<Category>();
                    foreach (var _item in _categoriesList)
                        _categoriesListTemp.Add(FillAllFields(_item));

                    _categoriesList = _categoriesListTemp;
                }

                return _categoriesList;
            }
        }

        public Category SearchById(int __id, string __op = "lazy")
        {
            using (var _context = new Context())
            {
                var _obj = _context.Categories.FirstOrDefault(c => c.Id == __id);

                if (__op == "full")
                    _obj = FillAllFields(_obj);

                return _obj;
            }
        }
       
        public void Delete(Category __obj)
        {
            using (var _context = new Context())
            {
                Category _objToDelete = _context.Categories.Find(__obj.Id);

                if (_objToDelete != null)
                {
                    _context.Categories.Remove(_objToDelete);

                    _context.SaveChanges();
                }

            }
        }

        public Category Fix(Category __obj)
        {
            __obj.AddUserId = 1;
            __obj.UpdateUserId = 1;
            __obj.UpdateDate = System.DateTime.Now;
            __obj.AddDate = __obj.Id > 0 ? __obj.AddDate : System.DateTime.Now;

            return __obj;
        }

        public Category FillAllFields(Category __obj)
        {
            __obj.SubCategoryList = _context.SubCategories.Where(x => x.CategoryId == __obj.Id).ToList();
            __obj.LinkedRecords = _context.Advertisers_SubCategories.Where(x => x.CategoryId == __obj.Id).Count();

            return __obj;
        }
    }
}
