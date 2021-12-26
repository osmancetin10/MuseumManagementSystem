using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuseumManagementSystem.Models
{
    public class Muze
    {
        public int MuzeId { get; set; }
        [Display(Name ="Müze Adı")]
        [Required(ErrorMessage ="Müze Adı Girilmelidir")]
        public string MuzeAdi { get; set; }
        [Display(Name = "Müze Adresi")]
        [Required(ErrorMessage = "Müze Adresi Girilmelidir")]
        public string MuzeAdresi { get; set; }
        [Display(Name = "Ziyaretçi Sayısı (Yıllık)")]
        [Required(ErrorMessage = "Ziyaretçi Sayısı Girilmelidir")]
        public int ZiyaretciSayisi { get; set; }
        public string Foto { get; set; }

        public virtual List<Eser> Eserler { get; set; }
    }
}
