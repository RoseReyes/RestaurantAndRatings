using System.ComponentModel.DataAnnotations;
using System;

namespace restauranter.Models {

    public class Review {
    
        [Key] //force it if you opt to make your username different from the name of your model
        public int userid { get; set; }
        
        [Required(ErrorMessage="Reviewer name field is required")]
        [Display(Name = "Reviewer Name")]
        public string reviewer_name { get; set; }
        
        [Required(ErrorMessage="Review for - field is required")]
        [Display(Name = "Reviewer For")]
        public string reviewer_for { get; set; }
         
        [Required(ErrorMessage="Review is required and cannot be less than 10 characters")]
        [Display(Name = "Review")]
        [MinLength(10)]
        public string review { get; set; }
        
        [Required]
        [Display(Name = "Date of Visit")]
        [DataType(DataType.DateTime)]
        public DateTime dov { get; set; }

        [Required(ErrorMessage="Rating is required")]
        [Display(Name = "Stars")]
        public int rating { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime created_at { get; set; }

        public Review() {
            this.created_at = DateTime.Now;
        }

        //need to apply changing created_at time
    }

}