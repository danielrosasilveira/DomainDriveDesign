using Entities.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Entities
{
    public class Base : Notifies
    {
        [Display(Name ="Código")]
        [Key]
        public int ID { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }
    }
}
