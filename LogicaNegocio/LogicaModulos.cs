using Dato;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio
{
   public class LogicaModulos
    {
        DatoModulos datoModulo = new DatoModulos();

        public Modulo Agregar(Modulo modulo)
        {
            return datoModulo.Agregar(modulo);

        }

        public Modulo Actulizar(Modulo modulo)
        {
            return datoModulo.Actualizar(modulo);

        }

        public List<Modulo> Listar()
        {
            return datoModulo.Listar();
        }

        public Modulo Buscar(long id)
        {
            return datoModulo.Buscar(id);
        }

        public bool Eliminar(long id)
        {
            return datoModulo.Eliminar(id);
        }
    }
}
