using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Cadastro() 
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Cadastro(Usuario l)
        {
            UsuarioService usuarioService = new UsuarioService();

            if(l.Id == 0)
            {
               usuarioService.Inserir(l);
            }
            else
            {
               usuarioService.Atualizar(l);
            }

            return RedirectToAction("Listagem");
        }


        public IActionResult Edicao(int id)
        {
            UsuarioService us = new UsuarioService();
            Usuario u = us.ObterPorId(id);
            return View(u);
        }

        public IActionResult Listagem() 
        {
            UsuarioService usuarioService = new UsuarioService();
            return View(usuarioService.ListarTodos());
        }
    }
}