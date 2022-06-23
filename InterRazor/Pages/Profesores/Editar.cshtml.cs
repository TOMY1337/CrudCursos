using InterRazor.Datos;
using InterRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InterRazor.Pages.Profesores
{
    public class EditarModel : PageModel
    {

        private readonly InterRazorDbContext _contexto;
        public EditarModel(InterRazorDbContext contexto)
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

                var ProfeDesdeBD = await _contexto.Profesor.FindAsync(Profesor.IdProf);

                ProfeDesdeBD.Nombre = Profesor.Nombre;
                ProfeDesdeBD.Apellido = Profesor.Apellido;
                ProfeDesdeBD.esp = Profesor.esp;
                ProfeDesdeBD.FechaDeIngreso = Profesor.FechaDeIngreso;
                ProfeDesdeBD.Fechanac = Profesor.Fechanac;

                _contexto.SaveChangesAsync();
                mensaje = "Profesor editado correctamente";
                return RedirectToPage("Index");

            }

            return RedirectToPage();



        }
        
    }
}
