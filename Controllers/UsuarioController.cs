using Biblioteca.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;


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

        // // Visualização da página 
        // public IActionResult Excluir(int id)
        // {
        //     UsuarioService userServ = new UsuarioService();
        //     Usuario usuario = userServ.GetPostDetail(id);
        //     return View(usuario);
        // }

        // // Exclusão
        // [HttpPost]
        // public IActionResult Excluir(int id, string decisao)
        // {
        //     if(decisao == "s")
        //     {
        //         UsuarioService userServ = new UsuarioService();
        //         userServ.DeletePost(id);
        //     }
        //     return RedirectToAction("Listagem");
        // }

        public IActionResult Listagem() 
        {
            UsuarioService usuarioService = new UsuarioService();
            return View(usuarioService.ListarTodos());
        }
    }
}