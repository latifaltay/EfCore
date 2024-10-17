using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.DAL
{
    public class ProductFeature
    {
        // attribute yöntemi ile id property'sini product için bir foreign key olarak tanımlayabiliyoruz
        //[ForeignKey("Product")]
        public int Id { get; set; }
        public int Widht { get; set; }
        public int Height { get; set; }
        public string Color { get; set; }

        // one to one relation with attribute
        // attribute ile ilişki kurulduğunda int productId'ye gerek yok sadece product tipinde bir product geçsek yeterli oluyor
        //[ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int ProductId { get; set; }

    }
}
