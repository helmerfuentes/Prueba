﻿using System;
using System.Collections.Generic;
using System.Text;
using Dato;
using Entidades;

namespace LogicaNegocio
{
    public class LogicaUsuario
    {

        private readonly DatoUsuario DatoUsuario = new DatoUsuario();

        public List<Usuario> Listar(int pag)
        {
            //si la pagina es 0, empezara desde el registro 0
            return DatoUsuario.Listar(pag*10);
        }

        public int TotalUsuarios()
        {
            return DatoUsuario.TotalUsuarios();
        }

        public Usuario Ingresar(string user, string clave)
        {
            return DatoUsuario.Login(user,clave);
        }

        public Usuario Buscar(long id)
        {
            return DatoUsuario.Buscarusuario(id);
        }

        public Usuario Actualizar(long id)
        {
            return DatoUsuario.Actualizar(id);
        }

        public bool Eliminar(long id)
        {
            return DatoUsuario.Eliminar(id);
        }

        public Usuario Agregar(Usuario usuario)
        {
            return DatoUsuario.Agregar(usuario);
        }


        



    }
}
