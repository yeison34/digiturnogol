using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace digiturno.Data.Sucursal
{
    public class Sucursal
    {

        public int Id { get; set; }

        public string Nombre { get; set; }

        public bool Esactiva { get; set; }

        public string Codigo { get; set; }
        public Sucursal(int p_id,string p_nombre, bool p_esactiva, string p_codigo)
        {
            Id = p_id;
            Nombre = p_nombre;
            Esactiva = p_esactiva;
            Codigo = p_codigo;
        }

        public Sucursal() { }
    }
}