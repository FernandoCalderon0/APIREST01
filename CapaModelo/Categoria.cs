using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Categoria
    {
        public int IdCategoria { get; set; }

        public string Descripcion { get; set; }

        public bool Estado { get; set; }

       public DateTime  FechaCreacion  { get; set; }
}
}
