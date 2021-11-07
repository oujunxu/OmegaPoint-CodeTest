using OmegaPointSimpleAPI.Data.DataAccess;
using OmegaPointSimpleAPI.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OmegaPointSimpleAPI.Data.BusinessLogic
{
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

        // gets list of data with limited of information
        public static List<T> GetOverviewProducts<T>(string connectionString)
        {
            string sql = @"select Title, Price, Image from dbo.SingleProductTable;";

            return SqlDataAccess.LoadData<T>(sql, connectionString);
        }

        // delete rows in SqlServer based on its Id
        public static List<T> DeleteProduct<T>(int id, string connectionString)
        {
            string sql = @"Delete from dbo.SingleProductTable Where Id =" + id;

            return SqlDataAccess.LoadData<T>(sql, connectionString);
        }


    }
}
