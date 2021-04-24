using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lab04_EDI.Models
{
    public class InfoTarea
    {
        [Display(Name ="Título")]
        [Required(ErrorMessage ="Ingrese Título de la tarea", AllowEmptyStrings =false)]
        public string Titulo { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Display(Name = "Proyecto")]
        public string Proyecto { get; set; }
        [Display(Name = "Prioridad")]
        public int Prioridad { get; set; }
       // [Display(Name = "Fecha de Entrega")]
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        //public DateTime FechaEntrega { get; set; }
        public string FechaEntrega { get; set; }

    }
}
