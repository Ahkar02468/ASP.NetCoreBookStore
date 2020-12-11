using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AKSB.BookStore.Enum
{
    public enum LanguageEnum
    {
        [Display(Name ="English Language")]
        English,
        Chinese,
        Myanmar,
        Korean,
        Japenese
    }
}
