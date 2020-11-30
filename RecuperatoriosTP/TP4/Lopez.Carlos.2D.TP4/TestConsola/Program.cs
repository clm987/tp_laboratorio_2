using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using Entidades;
using Archivos;
using Excepciones;

namespace TestConsola
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                //Consultas a la base de datos para cargar listas (tema Bases de Datos)
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Probando traer la lista de Tiendas de la Base de Datos");
                Distribuidora.listaDeTiendas = HelperBD.TraerTiendas();
                foreach (Tienda item in Distribuidora.listaDeTiendas)
                {
                    Console.WriteLine("DATOS DE LA TIENDA");
                    Console.WriteLine(item.Mostrar());
                    Console.WriteLine("----------------------");
                }
                Console.WriteLine("Se han mostrado todas las tiendas en la base de datos");
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();

                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Probando traer la lista de Articulos de la Base de Datos");
                Distribuidora.listaDeArticulos = HelperBD.TraerArticulos();
                foreach (Articulo item in Distribuidora.listaDeArticulos)
                {
                    Console.WriteLine("DATOS DEl ARTICULO");
                    Console.WriteLine(item.Mostrar());
                    Console.WriteLine("----------------------");
                }
                Console.WriteLine("Se han mostrado todas las Articulos en la base de datos");
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();

                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Probando traer la lista de Ventas de la Base de Datos");
                Distribuidora.listaDeVentas = HelperBD.TraerVentas();
                foreach (Venta item in Distribuidora.listaDeVentas)
                {
                    Console.WriteLine("DATOS DE LA VENTA");
                    Console.WriteLine(item.Mostrar(item));
                    Console.WriteLine("----------------------");
                }
                Console.WriteLine("Se han mostrado todas las Ventas en la base de datos");
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();


                //Prueba de la funcionalidad de agregar productos
                Console.WriteLine("Probando el alta de un nuevo articulo!!");
                Articulo articulo1 = HelperBD.GenerarArticulo("Mouse inalambrico", 10, 800, Articulo.ETipoDeArticulo.Computacion.ToString());
                Console.WriteLine("Articulo Cargado con exito");
                Console.WriteLine(articulo1.Mostrar());
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();

                Console.WriteLine("Probando la creacion de una nueva venta con el articulo generado en el paso anterior");
                int auxCantidad = 2;

                //Actualiza la lista de Articulos 
                Distribuidora.listaDeArticulos = HelperBD.TraerArticulos();

                //Confirma el stock en caso de ser insuficiente lanzará una excepcion del tipo StockException (Tema Excepciones)
                Distribuidora.ConfirmarStock(articulo1.IdArticulo, auxCantidad);
                Venta nuevaVenta = HelperBD.GenerarVenta(1, 1, auxCantidad, 30000, Venta.EEstadoVenta.Conforme.ToString());
                Console.WriteLine("Nueva venta cargada con exito");
                Console.WriteLine(nuevaVenta.Mostrar(nuevaVenta));
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();

                //Prueba de Lectura de archivo xml (tema Deserializacion)
                Console.WriteLine("Probando leer el archivo Xlm con las ordenes de compra");
                if (Distribuidora.Leer())
                {
                    Distribuidora.GenerarVentasPendientes(Distribuidora.listaDeOrdenesDeCompra);
                    Distribuidora.listaDeVentas = HelperBD.TraerVentas();
                    Distribuidora.EncolarVentasPendientes();
                    foreach (Venta item in Distribuidora.colaVentasPendientes)
                    {
                        Console.WriteLine(String.Concat(item.Mostrar(item), item.EstadoVenta.ToString(), "\n"));
                    }
                    Console.WriteLine("Se han mostrado todas las ventas pendientes cargadas a partir del arxhivo xlm");
                    Console.WriteLine("Presione una tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("No hay ventas externas para procesar");
                    Console.WriteLine("Presione una tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                }

                //Prueba de manejo de ventas mediante Hilo que genera un evento. En caso de resultar en venta rechazada (Temas hilos, delegados y eventos)
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Probando el procesamiento de ventas pendientes mediante un hilo");
                Console.WriteLine("Se procesaran las ventas pendientes cargadas en el paso anterior");
                Console.WriteLine("El procesamiento tomara unos segundos dado el volumen de ventas. Presione cualquier tecla para comenzar el procesamiento");
                Console.ReadKey();
                Thread hiloDeVentas;
                hiloDeVentas = new Thread(Distribuidora.ProcesarVentasConsola);
                hiloDeVentas.Start();
                Console.WriteLine("Empieza procesamiento!");
                while (hiloDeVentas.IsAlive && Distribuidora.colaVentasPendientes.Count != 0)
                {
                    Console.WriteLine("Cantidad de ventas pendientes: " + Distribuidora.colaVentasPendientes.Count.ToString() + " --- Cantidad de ventas procesadas: " + Distribuidora.colaVentasProcesadas.Count.ToString());
                }
                Console.WriteLine("Cantidad de ventas pendientes: " + Distribuidora.colaVentasPendientes.Count.ToString() + " --- Cantidad de ventas procesadas: " + Distribuidora.colaVentasProcesadas.Count.ToString());
                Console.WriteLine("Procesamiento Finalizado!");

                //Uso de metodo de extensión para el calculo de monto total de ventas procesadas (tema metodos de extension)
                Console.WriteLine("Se genera al monto total de ventas procesadas usando el metodo de extensión");
                Console.WriteLine("Monto de ventas procesadas: ");
                Console.WriteLine(Distribuidora.colaVentasProcesadas.CalcularTotalVentasProcesadas().ToString());
                Console.WriteLine("Ingrese una tecla para continuar");
                Console.ReadKey();
                Console.Clear();

                //Se comprueba la creacion y se lee el archivo de log de ventas rechazadas (tema Archivos y se comprueba con esto el funcionamiento del evento ventarechazada)
                Console.WriteLine("----------------------------------------------------------");
                string path = String.Format("{0}\\logVentasRechazadas.txt", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                if (File.Exists(path))
                {
                    Console.WriteLine("Se comprobo la creacion del archivo de texto con el log de ventas rechazadas generado por el evento ventaRechazada");
                    Console.WriteLine("Desea leer el contenido del archivo? Presione 'y' para ver el contenido del archivo");
                    if (Console.ReadKey().KeyChar == 'y')
                    {
                        string datos = "";
                        Texto texto = new Texto();
                        texto.Leer(path, out datos);
                        Console.WriteLine(datos);
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Se cancelo la lectura del archivo.");
                        Console.WriteLine("Presiona una tecla para finalizar");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Archivo inexistente");
                }
                Console.WriteLine("Se han concluido las pruebas. Presione cualquier tecla para finalizar");
                Console.ReadKey();
            }
            catch (StockException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }



        }
    }
}
