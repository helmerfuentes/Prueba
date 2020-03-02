using Dato;
using Entidades;
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

            Rol rol = new Rol { 
            Nombre="dsdsd",
            Descripcion="todo los temas contables",
            Estado= RolEstado.Activo,
            Id=1
            
            
            };
            
            DatoRol Drol = new DatoRol();
            Assert.IsNotNull(Drol.Eliminar(5));
        }
    }
}