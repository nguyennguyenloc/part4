using part4.data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part4.data.DAL
{
    public class CustomerDAL
    {
        private DefaultDbcontenxt context;    /*defaultDbcontext ở mục 3.data */

        public CustomerDAL()
        {
            context = new DefaultDbcontenxt();
        }

        public Customer GetById(long id)
        {
            //Get from database
            //SELECT TOP 1 Username, Password... FROM Customer WHERE Id = id AND IsDelete = false
            var customer = context.Customers /*vào Nuget packages add EntityFramework*/
                .Where(i => i.Id == id && i.IsDeleted == false)
                .FirstOrDefault();
            return customer;
        }

        public bool Update(Customer model)
        {
            try
            {
                //Get item user with Id from database
                var item = context.Customers.Where(i => i.Id == model.Id).FirstOrDefault();

                //Set value item with value from model
                item.Username = model.Username;
                item.Address = model.Address;
                item.CreatedBy = model.CreatedBy;
                item.CreatedTime = model.CreatedTime;
                item.DeletedBy = model.DeletedBy;
                item.DeletedTime = model.DeletedTime;
                item.Email = model.Email;
                item.FirstName = model.FirstName;
                item.Id = model.Id;
                item.IsDeleted = model.IsDeleted;
                item.LastName = model.LastName;
                item.ModifiedBy = model.ModifiedBy;
                item.ModifiedTime = model.ModifiedTime;
                item.PasswordEncrypted = model.PasswordEncrypted;
                item.PasswordSalt = model.PasswordSalt;
                item.PhoneNumber = model.PhoneNumber;


                //Save change to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Create(Customer model)
        {
            try
            {
                //Initialization empty item
                var item = new Customer();

                //Set value for item with value from model
                item.Username = model.Username;
                item.Address = model.Address;
                item.CreatedBy = model.CreatedBy;
                item.CreatedTime = model.CreatedTime;
                item.DeletedBy = model.DeletedBy;
                item.DeletedTime = model.DeletedTime;
                item.Email = model.Email;
                item.FirstName = model.FirstName;
                item.Id = model.Id;
                item.IsDeleted = model.IsDeleted;
                item.LastName = model.LastName;
                item.ModifiedBy = model.ModifiedBy;
                item.ModifiedTime = model.ModifiedTime;
                item.PasswordEncrypted = model.PasswordEncrypted;
                item.PasswordSalt = model.PasswordSalt;
                item.PhoneNumber = model.PhoneNumber;

                //Add item to entity
                context.Customers.Add(item);
                //Save to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(long id)
        {
            try
            {
                //Tương tự update
                var item = context.Customers.SingleOrDefault(i => i.Id == id);

                //Remove item.
                context.Customers.Remove(item);

                //Change database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

}
