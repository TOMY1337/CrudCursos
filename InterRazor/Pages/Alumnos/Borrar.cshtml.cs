using InterRazor.Datos;
using InterRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InterRazor.Pages.Alumnos
{
    public class BorrarModel : PageModel
    {
        private readonly InterRazorDbContext _contexto;
        public BorrarModel(InterRazorDbContext contexto)
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

                var AlumnoBorrar = await _contexto.Alumno.FindAsync(Alumno.IdAlumno);

               if (AlumnoBorrar == null)
                {
                    return NotFound();
                }

                AlumnoBorrar.Eliminado = true;
                _contexto.SaveChangesAsync();             
                return RedirectToPage("Index");

            }

            return RedirectToPage();



        }
    }
}

