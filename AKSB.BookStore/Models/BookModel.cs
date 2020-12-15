using AKSB.BookStore.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AKSB.BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter the title.")]
        [StringLength(100,MinimumLength =2)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter the author name.")]
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int LanguageId { get; set; }
        public string Language { get; set; }
        [Required(ErrorMessage = "Please enter the total pages.")]
        [Display(Name ="Total Pages of book")]
        public int? TotalPages { get; set; }

    }
}
