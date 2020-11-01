﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException: Exception
    {
        /// <summary>
        /// Clase de excepción para manejo de archivos
        /// </summary>
        public ArchivosException()
        {

        }

        public ArchivosException(string message): base(message)
        {
                
        }

        public ArchivosException(string message, Exception innerException): base(message, innerException)
        {
                
        }
    }
}
