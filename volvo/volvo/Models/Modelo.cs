using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace volvo.Models
{
    [Table("Modelo")]
    public class Modelo
    {
        [Display(Name = "Codigo")]
        public int Id { get; set; }

        [Display(Name = "Descricao")]
        public string Descricao { get; set; }
    }
}
