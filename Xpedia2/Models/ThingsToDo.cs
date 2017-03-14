using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Xpedia2.Models
{
    public class ThingsToDo
    {
       
        public Int64  _key { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        
        [Required]
        public string Lugar { get; set; }
        [Required]
        public DateTime FechaDeInicio  { get; set; }
        [Required]
        public DateTime FechaDeFin { get; set; }
        [Required]
        public Double Precio { get; set; }
    }
}