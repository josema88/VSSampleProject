using Arango.fastJSON;
using ArangoDB.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Xpedia2.Models;

namespace Xpedia2.Controllers
{
    public class ThingToDoController : Controller
    {
        // GET: ThingToDo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            Session["user"] = "yolita2402@gmail.com";
            Session["userKey"] = 185263600829;

            using (ArangoDatabase db = new ArangoDatabase(url: "http://52.32.98.159:8529", database: "Expedia"))
            {
                IList<ThingsToDo> data = db.Query<ThingsToDo>().ToList();

                return View("List", data);
            }
            
        }
        public ActionResult Create()
        {
            ThingsToDo thingsToDo= new ThingsToDo();
            return View("Create");
        }
        public ActionResult Save(String nombre, String descripcion, String lugar, DateTime fechaDeInicio, DateTime fechaDeFin, Double precio)
        {

            using (ArangoDB.Client.ArangoDatabase db = new ArangoDatabase(url: "http://52.32.98.159:8529", database: "Expedia"))
            {

                var thingsToDo = new ThingsToDo { Nombre = nombre, Descripcion=descripcion, Lugar=lugar, FechaDeFin=fechaDeFin, FechaDeInicio = fechaDeInicio, Precio= precio };
                db.Insert<ThingsToDo>(thingsToDo);
                return View("Detail", thingsToDo);

            }
           
        }

        public ActionResult AddThingsToDo(Int64 key)
        {

            if (Session["userKey"] != null)
            {
                using (ArangoDatabase db = new ArangoDatabase(url: "http://52.32.98.159:8529", database: "Expedia"))
                {
                var query = from thingsToDo in db.Query<ThingsToDo>()
                            where thingsToDo._key == key
                            select new { thingsToDo.FechaDeFin, thingsToDo.FechaDeInicio };
                    // ViewData["FechaDeFin"] = query.First().FechaDeFin;
                  
                }
                using (WebClient wc = new WebClient())
                {
                    //TTD
                    var jsonttd = wc.DownloadString("http://52.32.98.159:8529/_db/Expedia/_api/document/ThingsToDo/"+key);
                    System.Web.Script.Serialization.JavaScriptSerializer jsSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    ThingsToDo thingsToDo = jsSerializer.Deserialize<ThingsToDo>(jsonttd);
                    //Usuario
                    var jsonU = wc.DownloadString("http://52.32.98.159:8529/_db/Expedia/_api/document/ThingsToDo/" + key);
                    System.Web.Script.Serialization.JavaScriptSerializer jsSerializerU = new System.Web.Script.Serialization.JavaScriptSerializer();
                    ThingsToDo thingsTo = jsSerializerU.Deserialize<ThingsToDo>(jsonU);

                }

                // usuario.thingsToDo.Add(thingToDo);
                // db.Update<Usuarios>(usuario);

            }
            return null;
        }
    }
}