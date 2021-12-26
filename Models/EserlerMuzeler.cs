using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuseumManagementSystem.Models
{
    public class EserlerMuzeler
    {
        public List<Eser> Eserler { get; set; }
        public List<Muze> Muzeler { get; set; }
    }
}
