using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.ViewModels
{
    public class MobileViewModel 
    {
       
        [Display(Name = "Mobile Name")]
        public  string? Name { get; set; }

       
        public  string? Color { get; set; }

        
        public  string? Description { get; set; }

       
        public  decimal Price { get; set; }

        public int Id { get; set; }
        public string? ExistingImage { get; set; }

        
        public IFormFile? MobilePicture { get; set; }
    }
}