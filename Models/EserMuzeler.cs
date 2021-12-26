using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuseumManagementSystem.Models
{
    public class EserMuzeler
    {
        public Eser Eser { get; set; }
        public List<Muze> Muzeler { get; set; }
    }
}
