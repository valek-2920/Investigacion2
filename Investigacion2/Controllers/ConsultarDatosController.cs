using Investigacion2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Investigacion2.Controllers
{
    public class ConsultarDatosController : Controller
    {
        public ActionResult ConsultaDatos(Data data)
        {
            if (!String.IsNullOrEmpty(data.input_tcv) || !String.IsNullOrEmpty(data.input_tcc)) 
            {
                using (var client = new HttpClient())
                {
                    //string ruta = ConfigurationManager.AppSettings[""].ToString();
                    string ruta = "https://api.hacienda.go.cr/indicadores/tc/dolar";

                    HttpResponseMessage respuesta = client.GetAsync(ruta).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        var datos = respuesta.Content.ReadAsStringAsync().Result;
                        var values = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(datos);
                        data.respuesta = values;

                        data.value_tcv = (Convert.ToDouble(data.respuesta["compra"]["valor"]) * Convert.ToDouble(data.input_tcc)).ToString();
                        data.value_tcc = (Convert.ToDouble(data.respuesta["venta"]["valor"]) * Convert.ToDouble(data.input_tcv)).ToString();
                    }
                }
            }
            return View(data);
        }
    }
}