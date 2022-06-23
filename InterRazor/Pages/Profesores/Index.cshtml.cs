using InterRazor.Datos;
using InterRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InterRazor.Pages.Profesores
{
    public class IndexModel : PageModel
    {
        private readonly InterRazorDbContext _contexto;
        public IndexModel(InterRazorDbContext contexto)
        {
            _contexto = contexto;

        }
        public IEnumerable<Profesor> Profesores { get; set; }

        [TempData]
        public string mensaje { get; set; }

        public async Task OnGet()
        {
            Profesores = await _contexto.Profesor.ToListAsync();
        }
    }
}
