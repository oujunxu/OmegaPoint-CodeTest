using OmegaPointSimpleAPI.Data.DataAccess;
using OmegaPointSimpleAPI.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OmegaPointSimpleAPI.Data.BusinessLogic
{
    /**
     * A sql data processor, that sends sql queries to sqlDataAccess.
     * Class by Oujun Anders Xu
     */
    public class DataProcessor
    {
        // adds products to the database only if the new data doesn't exist.
        public static int AddProducts(int id, string title, float price, string description,
          string category, string image, float rate, int count, string connectionString)
        {
            SingleProduct data = new SingleProduct()
            {
                Id = id,
                Title = title,
                Price = price,
                Description = description,
                Category = category,
                Image = image,
                Rate = rate,
                Count = count
                
            };

            string sql = @"If Not Exists(Select*from dbo.SingleProductTable where Id = @Id)
                           begin
                           insert into dbo.SingleProductTable (Id, Title, Price, Description, Category, Image, Rate, Count)
                           values (@Id, @Title, @Price, @Description, @Category, @Image, @Rate, @Count)
                           end;";

            return SqlDataAccess.SaveData(sql, data, connectionString);

        }

        // get all data with all the available information.
        public static List<T> GetAllProducts<T>(string connectionString)
        {
            string sql = @"select * from dbo.SingleProductTable;";

            return SqlDataAccess.LoadData<T>(sql, connectionString);
        }

        //get item based on its id
        public static List<T> GetProduct<T>(int id, string connectionString)
        {
            string sql = @"select * from dbo.SingleProductTable Where id="+id;

            return SqlDataAccess.LoadData<T>(sql, connectionString);
        }


        // delete rows in SqlServer based on its Id
        public static List<T> DeleteProduct<T>(int id, string connectionString)
        {
            string sql = @"Delete from dbo.SingleProductTable Where Id =" + id;

            return SqlDataAccess.LoadData<T>(sql, connectionString);
        }

        public static void UpdateProduct(int id, string title, float price, string description, string category, string image, float rate, int count, string connectionString)
        {
            /*
            string sql = "Update table dbo.SingleProductTable" +
                          $" set Title = {title}, Price = {price}, Description = '{description}', Category = {category}, Image = {image}, Rate = {rate}, Count = {count}" +
                          $" where Id = {id};";
            */

            SingleProduct data = new SingleProduct()
            {
                Id = id,
                Title = title,
                Price = price,
                Description = description,
                Category = category,
                Image = image,
                Rate = rate,
                Count = count

            };

            string sql = @"Update dbo.SingleProductTable Set Title = @Title, Price = @Price, Description = @Description, Category = @Category, Image = @Image, Rate = @Rate, Count = @Count Where Id = @Id;";

            SqlDataAccess.UpdateData(sql, data, connectionString);
        }


    }
}
