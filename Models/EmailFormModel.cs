using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDuctDesigner.Models
{
    public class EmailFormModel
    {
        [Required (ErrorMessage ="Imię jest wymagane"), Display(Name = "Imię")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email jest wymagany"), Display(Name = "Email"), EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Temat jest wymagany"), Display(Name = "Temat")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Treść wiadomości jest wymagana"), Display(Name = "Wiadomość")]
        public string Message { get; set; }
    }
}