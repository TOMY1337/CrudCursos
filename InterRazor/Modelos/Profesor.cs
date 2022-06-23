using System.ComponentModel.DataAnnotations;

namespace InterRazor.Modelos
{
    public class Profesor
    {
        [Key]
        [Required]
        [Display(Name = "Clave")]
        public int IdProf { get; set; }
        [StringLength(100)]
        [Required]
        public string Nombre { get; set; }
        [StringLength(50)]
        [Required]
        public string Apellido { get; set; }
        [Required]
        [Display(Name = "Especializacion")]
        public int esp { get; set; }
        [Required]
        [Display(Name = "Fecha de Ingreso")]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime FechaDeIngreso { get; set; }
        [Required]
        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime Fechanac  { get; set; }

        

    }
}
