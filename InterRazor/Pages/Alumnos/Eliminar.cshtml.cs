using InterRazor.Datos;
using InterRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InterRazor.Pages.Alumnos
{
    public class EliminarModel : PageModel
    {
        private readonly InterRazorDbContext _contexto;
        public EliminarModel(InterRazorDbContext contexto)
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

                var AlumnoEliminar = await _contexto.Alumno.FindAsync(Alumno.IdAlumno);

                if (AlumnoEliminar == null)
                {
                    return NotFound();
                }

                _contexto.Alumno.Remove(AlumnoEliminar);
                await _contexto.SaveChangesAsync();
                _contexto.SaveChangesAsync();
                mensaje = "Alumno eliminado correctamente";
                return RedirectToPage("Index");

            }

            return RedirectToPage();



        }
    }
}
