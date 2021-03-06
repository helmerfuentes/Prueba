﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades;
using LogicaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Filters;

namespace Web.Controllers
{
    public class AccesoController : Controller
    {
        private LogicaUsuario logica = new LogicaUsuario();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string user, string pass)
        {
         
             var usuario= logica.Ingresar(user, pass);
            if (usuario!= null)
            {
                HttpContext.Session.SetString("User", usuario.Rol.Nombre);
               
                return RedirectToAction("Index","Home");       
            }
            ViewBag.Error = "Usuario o contraseña invalida";
            return RedirectToAction("Login","Home");
        }

        [HttpPost]
        [ValidateSession]
        public  IActionResult Registrar(Usuario user)
        {
            var OneUser = logica.Agregar(user);
            
            if (user != null)
            {
                return RedirectToAction("Home");
            }

            return View();

        }
        [ValidateSession]
        public IActionResult Salir()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login","Home");
        }


    }
}