using Ejemplo_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ejemplo_1.Controllers
{
    public class MascotaController : Controller
    {
        //Establemos la constante para Session, para no tener errores de nombre
        const string nombreSesion = "ListadoMascota";

        // GET: Mascota
        public ActionResult Index()
        {
            if (Session[nombreSesion] == null) //Se valida si es la primera vez
            {
                var lista = obtenerMascotas();
                Session[nombreSesion] = lista;
                return View(lista);
            }
            else
            {
                var lista = (List<Mascota>)Session[nombreSesion];
                return View(lista);
            }
            
            
        }
        //Este metodo me envia a la vista nuevo(formulario)
        public ActionResult Nuevo()
        {
            
            return View();
        }

        //Este metodo se usa cuando se envia una nueva mascota(POST)
        [HttpPost]
        public ActionResult Nuevo(Mascota mascota)
        {
            var listado = (List<Mascota>)Session[nombreSesion];
            listado.Add(mascota);
            Session[nombreSesion] = listado;
            //Redireccionamos a la vista index para chequear q se agrego
            return RedirectToAction("Index");
        }
        private List<Mascota> obtenerMascotas()
        {
            var listaMascotas = new List<Mascota>();
            listaMascotas.Add(new Mascota { Id = 1, Nombre="Felipe",Raza="Perro",Edad=3,NombreDueno="Leo"});
            listaMascotas.Add(new Mascota { Id = 2, Nombre = "Paco", Raza = "Loro", Edad = 4, NombreDueno = "Cristian" });
            listaMascotas.Add(new Mascota { Id = 3, Nombre = "Michi", Raza = "Gato", Edad = 2, NombreDueno = "Claudio" });
            listaMascotas.Add(new Mascota { Id = 4, Nombre="Vitto", Raza="Perro", Edad=4, NombreDueno="Mauro"});
            listaMascotas.Add(new Mascota { Id = 5, Nombre="Raffael", Raza="Tortuga", Edad=7, NombreDueno="Guille" });
            return listaMascotas;
        }
    }
}