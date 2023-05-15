using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace shappingCardInMVC.Models
{
    public class DtoProduct
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "please Enter Product Name")]
        public string ProductName { get; set; }


        [Required(ErrorMessage = "please Enter Product Price ")]

        public Double ProductPrice { get; set; }

        [Required(ErrorMessage = "please Enter Product Description ")]
        public string ProductDescription { get; set; }


        [Required(ErrorMessage = "please Enter Product Quantity")]
        public int ProductQuantity { get; set; }


     
        [DisplayName("Product Image")]
        public string ProductImage { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }


        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}