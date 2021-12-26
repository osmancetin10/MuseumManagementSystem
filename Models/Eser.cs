using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuseumManagementSystem.Models
{
    public class Eser
    {
        public int EserId { get; set; }
        [Display(Name ="Eser Adı")]
        [Required(ErrorMessage ="Eser Adı Girilmelidir")]
        public string EserAdi { get; set; }
        [Display(Name = "Eser Yılı")]
        [Required(ErrorMessage = "Eser Yılı Girilmelidir")]
        public int EserYili { get; set; }
        public string Foto { get; set; }

        public virtual Muze Muze { get; set; }
    }
}
