using Dato;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio
{
    public class LogicaOpciones
    {
        DatoOpciones DatoOpciones = new DatoOpciones();
        public List<Opcion> listado()
        {
            return DatoOpciones.Listar();
        }

        public  Opcion Agregar(Opcion opcion)
        {
            return DatoOpciones.Agregar(opcion);
        }
        public Opcion Actualizar(Opcion opcion)
        {
            return DatoOpciones.Actualizar(opcion);
        }
        public bool Eliminar(long id)
        {
            return DatoOpciones.Eliminar(id);
        }
        public Opcion Buscar(long id)
        {
            return DatoOpciones.Buscar(id);
        }

        public List<Opcion> listadoPorModulo(long id)
        {
            return DatoOpciones.ListarPorModulo(id);
        }



    }
}
