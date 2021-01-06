using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace volvo.Models
{
    [Table("Caminhao")]
    public class Caminhao
    {
        [Display(Name = "Codigo")]
        public int id { get; set; }

        [Display(Name = "Modelo")]
        public string modelo { get; set; }

        [Display(Name = "Ano de Fabricação")]
        public DateTime AnoFabricacao { get; set; }

        [Display(Name = "Ando do Modelo")]
        public DateTime AnoModelo { get; set; }
    }
    
}
