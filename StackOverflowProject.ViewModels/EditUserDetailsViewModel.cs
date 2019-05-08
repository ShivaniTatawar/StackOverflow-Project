using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowProject.ViewModels
{
    public class EditUserDetailsViewModel
    {
        [Required]
        //[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Mobile { get; set; }
    }
}
