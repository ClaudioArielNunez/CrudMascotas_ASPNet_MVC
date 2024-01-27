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
        private MascotasConnection BD;
        public MascotaController()
        {
            BD = new MascotasConnection();
        }
        

        // GET: Mascota
        public ActionResult Index()
        {
            var listado = BD.Mascota.ToList();
            return View(listado);
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
            BD.Mascota.Add(mascota);
            BD.SaveChanges();
            //Redireccionamos a la vista index para chequear q se agrego
            return RedirectToAction("Index");
        }

        //1ºmetodo Actualizar, pinta la pagina y recibe el objeto
        [HttpGet]
        public ActionResult Actualizar(int id)
        {            
            var mascota = BD.Mascota.FirstOrDefault(x => x.Id == id);
            return View(mascota);
        }
        //2ºmetodo Actualizar, postea los cambios del objeto modificado
        [HttpPost]
        public ActionResult Actualizar(Mascota mascota)
        {            
            var mascotaActual = BD.Mascota.FirstOrDefault(x => x.Id == mascota.Id);
            mascotaActual.Edad = mascota.Edad;
            mascotaActual.Nombre = mascota.Nombre;
            mascotaActual.Raza = mascota.Raza;
            mascotaActual.NombreDueno = mascota.NombreDueno;
            BD.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            var mascotaAEliminar = BD.Mascota.FirstOrDefault(x=>x.Id==id);
            BD.Mascota.Remove(mascotaAEliminar);
            BD.SaveChanges();
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