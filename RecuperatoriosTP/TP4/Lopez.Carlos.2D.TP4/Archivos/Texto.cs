using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    //Metodos que habilitan el uso de archivos. Tema Archivos
    public class Texto : IArchivos<string>
    {
        /// <summary>
        /// Implementación del método Guardar para guardar un archivo de Texto
        /// </summary>
        /// <param name="archivo">String que representa el nombre y ruta del archivo a guardar</param>
        /// <param name="datos">String para recibir los datos a guardar</param>
        /// <returns>Booleao de control de ejecución true si guardo ok false si hubo error</returns>
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter escritor = null;
            try
            {
                escritor = new StreamWriter(archivo);
                escritor.Write(datos);
            }
            catch (Exception)
            {

                throw new ArchivosException();
            }
            finally
            {
                escritor.Close();
            }

            return true;
        }

        /// <summary>
        /// Implementación del método Leer para un archivo 
        /// </summary>
        /// <param name="archivo">String que representa el nombre y ruta del archivo a Leer</param>
        /// <param name="datos">String para recibir los datos a Leer</param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            StreamReader lector = null;
            datos = "";
            try
            {
                lector = new StreamReader(archivo);
                datos = lector.ReadToEnd();
            }
            catch (Exception)
            {

                throw new ArchivosException();
            }
            finally
            {
                lector.Close();
            }

            return true;
        }
        /// <summary>
        /// Método que permite ir cargando datos al final del archivo log de ventas rechazadas
        /// </summary>
        /// <param name="archivo">string que representa el nombre y ruta del archivo</param>
        /// <param name="datos"> string que representa los datos a guardar</param>
        /// <returns></returns>
        public bool GuardarLog(string archivo, string datos)
        {
            StreamWriter escritor = null;
            try
            {
                if (!File.Exists(archivo))
                {
                    using (escritor = File.CreateText(archivo))
                    {
                        escritor.Write(datos);
                    }

                }
                else
                {
                    using (escritor = File.AppendText(archivo))
                    {
                        escritor.Write(datos);
                    }
                }
            }
            catch (Exception)
            {

                throw new ArchivosException();
            }
            finally
            {
                escritor.Close();
            }

            return true;
        }
    }
}
