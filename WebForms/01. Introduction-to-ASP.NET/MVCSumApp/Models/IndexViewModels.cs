using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCSumApp.Models
{
    public class CalcViewModel
    {
        [Required]
        [Display(Name = "First Number")]
        [DataType(DataType.Text)]
        public string FirstNumber { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Second Number")]
        public string SecondNumber { get; set; }
    }
}