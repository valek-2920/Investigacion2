using Investigacion2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Investigacion2.Controllers
{
    public class ConsultarDatosController : Controller
    {

        Data res = new Data();

        public ActionResult ConsultaDatos()
        {
            res.fecha = DateTime.Now;
            res.valor = 640.00F;
            res.respuesta = "test";

            using (var client = new HttpClient())
            {
              //string ruta = ConfigurationManager.AppSettings[""].ToString();
              string ruta = "https://api.hacienda.go.cr/indicadores/tc/dolar";

                HttpResponseMessage respuesta = client.GetAsync(ruta).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    var datos = respuesta.Content.ReadAsStringAsync().Result.ToString();
                   // res = JsonConvert.DeserializeObject<Data>(datos);
                   res.respuesta = datos;
                }
                ViewBag.res = res;
                return View();
            }
        }
    }
}