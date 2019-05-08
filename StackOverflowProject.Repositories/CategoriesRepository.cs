using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using StackOverflowProject.DomainModels;

namespace StackOverflowProject.Repositories
{
    public interface ICategoriesRepository
    {

        void InsertCategory(Category c);
        void UpdateCategory(Category c);
        void DeleteCategory(int cid);
        List<Category> GetCategories();
        List<Category> GetCategoryByCategoryID(int cid);


    }


    public class CategoriesRepository:ICategoriesRepository
    {
        StackOverflowDbContext db;


        public CategoriesRepository()
        {
            db = new StackOverflowDbContext();
        }

       public void InsertCategory(Category c)
        {
            db.Categories.Add(c);
            db.SaveChanges();

        }

       public void UpdateCategory(Category c)
        {
            Category cn = db.Categories.Where(temp => temp.CategoryID == c.CategoryID).FirstOrDefault();

            if(cn!=null)
            {
                cn.CategoryName = c.CategoryName;
                db.SaveChanges();
                
            }
        }

        public void DeleteCategory(int cid)
        {
            Category cn = db.Categories.Where(temp => temp.CategoryID == cid).FirstOrDefault();

            if (cn != null)
            {
                db.Categories.Remove(cn);
                db.SaveChanges();

            }
        }



        public List<Category> GetCategories()
        {
            List<Category> cn = db.Categories.ToList();
            return cn;

            
        }

        public List<Category> GetCategoryByCategoryID(int cid)
        {
            List<Category> cn = db.Categories.Where(temp=>temp.CategoryID == cid).ToList();
            return cn;


        }

    }
}
