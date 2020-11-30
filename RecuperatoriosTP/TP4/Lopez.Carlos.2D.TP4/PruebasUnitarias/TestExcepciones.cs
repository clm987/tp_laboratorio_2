using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Entidades;
using Excepciones;

namespace PruebasUnitarias
{
    /// <summary>
    /// Clase de métodos de pruebas unitarias (Tema UniTest)
    /// </summary>

    [TestClass]
    public class TestExcepciones
    {
        /// <summary>
        /// Método de test unitario que evalúa que se arroje una ImputException al cargar un cantidad Invalida
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ImputException))]
        public void TestValidarCantidad()
        {
            Validaciones.validarEntradaCantidad("");
        }

        /// <summary>
        /// Método de test unitario que evalúa que se arroje una StockException al cargar un cantidad superior al stock
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(StockException))]
        public void TestValidarStockInsuficiente()
        {
            //  Arrange
            ArticuloComputacion auxArticulo = new ArticuloComputacion("teclado", 125, 0, 5);
            List<Articulo> auxListaProducto = new List<Articulo>();
            Distribuidora.listaDeArticulos.Add(auxArticulo);

            //Act
            Distribuidora.ConfirmarStock(5, 1000);

        }
    }
}
