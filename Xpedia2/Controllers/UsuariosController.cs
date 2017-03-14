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
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            Usuarios usuarios = new Usuarios();
            return View("Create");
        }
        public ActionResult Save(String nombre, String usuario, String contrasenia)
        {

            using (ArangoDB.Client.ArangoDatabase db = new ArangoDatabase(url: "http://52.32.98.159:8529", database: "Expedia"))
            {
                string id = Guid.NewGuid().ToString();

                var usuarios = new Usuarios { _key = id, nombre = nombre, usuario = usuario, contrasenia = contrasenia };

                var query = (from User in db.Query<Usuarios>()
                            where User.usuario == usuario
                            select new { User.usuario }).ToList();

                if (query.Count==0)
                {
                   
                    db.Insert<Usuarios>(usuarios);

                    return View("Detail", usuarios);
                }
                else
                    return View("Create",usuarios);
                
            }

        }
    }
}