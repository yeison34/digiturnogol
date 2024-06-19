using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using digiturno.Data.Sucursal;

namespace digiturno.Data.ModulosData
{
    public class Modulos
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int? Idsucursal { get; set; }

        public int Esactivo { get; set; }

        public Sucursal.Sucursal sucursal {
            get {
                return SucursalData.ObtenerPorId(Idsucursal??0);
            }
        }
        

    }
}