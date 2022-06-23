using InterRazor.Datos;
using InterRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InterRazor.Pages.Cursos
{
    public class CrearModel : PageModel
    {
        private readonly InterRazorDbContext _contexto;
        public CrearModel(InterRazorDbContext contexto)
        {
            _contexto = contexto;

        }
        [BindProperty]
        public Curso Curso { get; set; }

        [TempData]
        public string mensaje { get; set; }

        public async Task<IActionResult> OnPost()
        {

            if(!ModelState.IsValid)
            {
                return Page();
            }

            Curso.FechaCreacion = DateTime.Now;

            _contexto.Add(Curso);
            await _contexto.SaveChangesAsync();
            mensaje = "Curso creado correctamente";
            return RedirectToPage("Index");

        }
        public void OnGet()
        {
        }
    }
}
