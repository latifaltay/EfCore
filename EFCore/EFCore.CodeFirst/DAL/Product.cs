using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.DAL
{
    // DB Table Name Change With Data Anotation
    //[Table("ProductTable"), Schema = "products"]
    public class Product
    {
        //[Key] // Key atribute ile ef core'un default davranışlarına uymayan isimli primary keyleri belirtebiliriz
        public int Id { get; set; }

        // Data Anotation ile kolon adı değişikliği, db'deki veri tipini ve db'de kolonun sırasını değiştirebiliriz (Not: order özelliği sıfırdan tablo oluşturulduğunda çalışır)
        //[Column("Name2", TypeName ="char", Order =2)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Barcode { get; set; }
        public DateTime? CreatedDate { get; set; }

        public int CategoryId { get; set; }

        //// Navigation Property
        // one to many relation with attribute
        // attribute ile ilişki kurulduğunda hem int CategoryId hem de Category tipinde category property'sine ihtiyacımız var
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public ProductFeature ProductFeature { get; set; }
    }
}
