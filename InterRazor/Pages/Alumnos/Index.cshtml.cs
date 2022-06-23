using InterRazor.Datos;
using InterRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InterRazor.Pages.Alumnos
{
    public class IndexModel : PageModel
    {
        private readonly InterRazorDbContext _contexto;
        public IndexModel(InterRazorDbContext contexto)
        {
            _contexto = contexto;

        }
        public IEnumerable<Alumno> Alumnos { get; set; }

        [TempData]
        public string mensaje { get; set; }

        public async Task OnGet()
        {
            Alumnos = await _contexto.Alumno.ToListAsync();
        }
    }
}
