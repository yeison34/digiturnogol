using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace digiturno.Data.Usuarios
{
    public class Usuarios
    {

        public int Id { get; set; }

        public string Usuario { get; set; }

        public string Contrasena { get; set; }


        public Usuarios() { }   

        public Usuarios(int p_id, string p_usuario,string p_contrasena) { 
            Id = p_id;
            Usuario= p_usuario;
            Contrasena= p_contrasena;
        }
    }
}