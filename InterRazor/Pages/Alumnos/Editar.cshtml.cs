using InterRazor.Datos;
using InterRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InterRazor.Pages.Alumnos
{
    public class EditarModel : PageModel
    {

        private readonly InterRazorDbContext _contexto;
        public EditarModel(InterRazorDbContext contexto)
        {
            _contexto = contexto;

        }
        [BindProperty]
        public Alumno Alumno { get; set; }

        [TempData]
        public string mensaje { get; set; }
        public async Task OnGet(int id)
        {
            Alumno = await _contexto.Alumno.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {

            if (ModelState.IsValid)
            {

                var AlumnoDesdeBD = await _contexto.Alumno.FindAsync(Alumno.IdAlumno);

                AlumnoDesdeBD.Nombre = Alumno.Nombre;
                AlumnoDesdeBD.Apellido = Alumno.Apellido;
                AlumnoDesdeBD.FechaIngreso = Alumno.FechaIngreso;
                AlumnoDesdeBD.Hora_ingreso = Alumno.Hora_ingreso;
                AlumnoDesdeBD.FechaNacimiento = Alumno.FechaNacimiento;
                AlumnoDesdeBD.Cant_cursos = Alumno.Cant_cursos;
                AlumnoDesdeBD.Fecha_egreso = Alumno.Fecha_egreso;

                _contexto.SaveChangesAsync();
                mensaje = "Alumno creado correctamente";
                return RedirectToPage("Index");

            }

            return RedirectToPage();



        }
    }
    
}

