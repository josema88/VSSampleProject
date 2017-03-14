using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Xpedia2.Models
{
    public class Usuarios
    {
        public string _key { get; set; }
        [Required]
        public string usuario { get; set; }

        [Required]
        public string nombre { get; set; }

        [Required]
        public string contrasenia { get; set; }
        public string estado { get;set; }
        public List<ThingsToDo> thingsToDo { get; set; }
    }
}