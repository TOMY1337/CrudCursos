using InterRazor.Datos;
using InterRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InterRazor.Pages.Profesores
{
    public class EliminarModel : PageModel
    {
        private readonly InterRazorDbContext _contexto;
        public EliminarModel(InterRazorDbContext contexto)
        {
            _contexto = contexto;

        }
        [BindProperty]
        public Profesor Profesor { get; set; }

        [TempData]
        public string mensaje { get; set; }
        public async Task OnGet(int id)
        {
            Profesor = await _contexto.Profesor.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {

            if (ModelState.IsValid)
            {

                var ProfeEliminar = await _contexto.Profesor.FindAsync(Profesor.IdProf);
                if (ProfeEliminar == null)
                {
                    return NotFound();
                }

                _contexto.Profesor.Remove(ProfeEliminar);
                _contexto.SaveChangesAsync();
                mensaje = "Profesor eliminado correctamente";
                return RedirectToPage("Index");

            }

            return RedirectToPage();



        }

    }

}

