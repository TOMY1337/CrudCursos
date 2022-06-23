using System.ComponentModel.DataAnnotations;

namespace InterRazor.Modelos
{
    public class Alumno
    {
        [Key]     
        [Display(Name = "Clave")]
        public int IdAlumno { get; set; }
        [StringLength(100)]
        [Required]
        public string Nombre { get; set; }
        [StringLength(50)]
        [Required]
        public string Apellido { get; set; }
        [Required]
        [Display(Name = "Fecha de Ingreso")]
        [DisplayFormat(DataFormatString = "{0: yyyy-MM-dd}")]
        public DateTime FechaIngreso { get; set; }
        [Required]
        [Display(Name = "Hora de Ingreso")]
        [DisplayFormat(DataFormatString = "{0: hh:mm:ss}")]
        public DateTime Hora_ingreso { get; set; }
        [Required]
        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        [Display(Name = "Cantidad de Cursos")]
        public int Cant_cursos { get; set; }
        [Display(Name = "Fecha de Egreso")]
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
        public DateTime Fecha_egreso { get; set; }
        [Required]
        public bool Eliminado { get; set; }

    }

}
