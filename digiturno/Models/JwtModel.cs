using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace digiturno.Models
{
    public class JwtModel
    {
        public JwtModel() { }   

        public string Key { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }
    }
}