using Dato;
using Entidades;
using LogicaNegocio;
using NUnit.Framework;

namespace TEst
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {



            Modulo modulos = new Modulo
            {
                Nombre = "Permiso",
                Descripcion = "NINGUNA",
                Estado = ModulosEnum.Activo,
                Id = 1

            };

            Opcion opcion = new Opcion
            {
                Nombre = "opcion 1",
                Descripcion = "descripcion prueba",
                Estado = OpcionEnum.Activo,
                modulo = modulos

            };

            Rol rol = new Rol
            {
                Nombre = "Admnistrador",
                Descripcion = "Todo los permisos",
                Estado = RolEstado.Activo

            };

            DatoRol Drol = new DatoRol();
            DatoModulos datoModulos = new DatoModulos();
            DatoOpciones datoOpciones = new DatoOpciones();
            DatoUsuario datoUsuario = new DatoUsuario();
            DatoRol datoRol = new DatoRol();
            LogicaUsuario logicaUsuario = new LogicaUsuario();
            Assert.IsNotNull(logicaUsuario.Ingresar("helmerfa", "123456"));
        }
    }
}