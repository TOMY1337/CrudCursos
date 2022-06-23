using InterRazor.Datos;
using InterRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InterRazor.Pages.Profesores
{
    public class CrearModel : PageModel
    {

        private readonly InterRazorDbContext _contexto;
        public CrearModel(InterRazorDbContext contexto)
        {
            _contexto = contexto;

        }
        [BindProperty]
        public Profesor Profesor { get; set; }

        [TempData]
        public string mensaje { get; set; }

        public async Task<IActionResult> OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }


            _contexto.Add(Profesor);
            await _contexto.SaveChangesAsync();
            mensaje = "Profesor creado correctamente";
            return RedirectToPage("Index");

        }
        public void OnGet()
        {
        }
    }
}
