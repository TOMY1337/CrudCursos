using InterRazor.Datos;
using InterRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InterRazor.Pages.Cursos
{
    public class IndexModel : PageModel
    {
        private readonly InterRazorDbContext _contexto;
        public IndexModel(InterRazorDbContext contexto)
        {
            _contexto = contexto;

        }
        public IEnumerable<Curso> Cursos { get; set; }

        [TempData]
        public string mensaje { get; set; }

        public async Task OnGet()
        {
            Cursos = await _contexto.Curso.ToListAsync();
        }

        public async Task<IActionResult> OnPostEliminar(int id)
        {

            if (ModelState.IsValid)
            {

                var CursoEliminar = await _contexto.Curso.FindAsync(id);

               if (CursoEliminar == null)
                {
                    return NotFound();
                }

               _contexto.Curso.Remove(CursoEliminar);
               await _contexto.SaveChangesAsync();
                mensaje = "Curso eliminado correctamente";
                return RedirectToPage("Index");

            }
            return RedirectToPage("");
        }
    }
}
