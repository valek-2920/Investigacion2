using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Investigacion2.Models
{
    public class Data
    {
        public Dictionary<String, Dictionary<String, String>> respuesta;
        public string input_tcc { get; set; }
        public string input_tcv { get; set; }
        public string value_tcc { get; set; }
        public string value_tcv { get; set; }
    }
}