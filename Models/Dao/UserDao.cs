using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;


namespace Models.Dao
{
    public class UserDao
    {
        CoffeeDbContext db = null;
        public UserDao()
        {
            db = new CoffeeDbContext();//Khởi tạo db
        }

        public long Insert(USER entity) //Thêm mới user
        {
            db.USERs.Add(entity);
            db.SaveChanges();
            return entity.UserId;
        }
        public long Inserts(CUSTOMER customer) //Thêm mới customer
        {
            db.CUSTOMERs.Add(customer);
            db.SaveChanges();
            return customer.CustomerID;
        }
        public long Insertss(PRODUCT product)   //add product
        {
            db.PRODUCTs.Add(product);
            db.SaveChanges();
            return product.ProductID;
        }
        public long Insertsss(CATEGORY catelogy)    //add catelogy
        {
            db.CATEGORies.Add(catelogy);
            db.SaveChanges();
            return catelogy.CategoryID;
        }

        public USER GetbyID(string userName)
        {
            return db.USERs.SingleOrDefault(x=>x.UserName == userName);
        }
        public bool Login (string userName, string passWord)
        {
            var result = db.USERs.Count(x => x.UserName == userName && x.UserPassword == passWord);
            if (result > 0)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
