﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public string Correo { get; set; }

        public int IdRol { get; set; }

        public bool Estado { get; set; }

        public string Sexo{ get; set; }

        public string Username { get; set; }

        public string Contraseña { get; set; }

        public DateTime FechaCreacion { get; set; }

    }
}
