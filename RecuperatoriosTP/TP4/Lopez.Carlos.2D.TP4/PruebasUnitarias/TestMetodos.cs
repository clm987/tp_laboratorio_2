using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Entidades;
using Excepciones;

namespace PruebasUnitarias
{
    [TestClass]
    public class TestMetodos
    {
        /// <summary>
        /// Método de prueba para validar que el método buscarArticuloPorId devuelve un Articulo existente en la lista de manera correcta
        /// </summary>
        [TestMethod]
        public void TestBuscarArticuloPorId()
        {
            //Arrange
            ArticuloComputacion auxArticulo = new ArticuloComputacion("teclado", 125, 0, 5);
            Distribuidora.listaDeArticulos.Add(auxArticulo);

            //Act
            Articulo unArticulo = Distribuidora.buscarArticuloPorId(5);

            //Assert
            Assert.IsNotNull(unArticulo);
        }
        /// <summary>
        /// Método de prueba para validar que el método BuscarTiendaPorId devuelve un Tienda existente en la lista de manera correcta
        /// </summary>
        [TestMethod]
        public void TestBuscarClientePorDni()
        {
            //Arrange
            Tienda auxTienda = new Tienda(5, "Prueba", "direccion de prueba", "1553793508");
            Distribuidora.listaDeTiendas.Add(auxTienda);
            //Act
            Tienda unaTienda = Distribuidora.BuscarTiendaPorId(5);

            //Assert
            Assert.IsNotNull(unaTienda);
        }
    }
}
