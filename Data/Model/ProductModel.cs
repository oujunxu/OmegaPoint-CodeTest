using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OmegaPointSimpleAPI.Data.Model
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Desciption { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public RatingModel Rating { get; set; }
    }
}
