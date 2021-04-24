using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lab04_EDI.Models;
using Microsoft.AspNetCore.Hosting;
using Pruebas_MVC_3.Models;
using System.IO;
using System.Globalization;
using CsvHelper;
using ListaDobleEnlace;
using Lab04_EDI.Extra;
using Arbol;

namespace Lab04_EDI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string direccion, string password, [FromServices] IHostingEnvironment hostingenvironment)
        {
            if (password != null && direccion != null)
            {
                ListaDoble<UsersPassword> Usuarios = new ListaDoble<UsersPassword>();
                UsersPassword Login = new UsersPassword();
                Login.Password = password;
                Login.User = direccion;
                string FileName = "Users";
                var fileName = $"{hostingenvironment.WebRootPath}\\files\\{FileName}.csv";
                using (var reader = new StreamReader(fileName))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Read();
                    csv.ReadHeader();
                    while (csv.Read())
                    {
                        var Usuario = csv.GetRecord<UsersPassword>();
                        Usuarios.InsertarFinal(Usuario);
                        if (Usuario.Password == Login.Password && Usuario.User == Login.User)
                        {
                            return View("");
                        }
                    }
                }
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Developer(string Titulo, string Descripcion, string Proyecto, string Prioridad, string Fecha)
        {
            InfoTarea NuevaTarea = new InfoTarea();
            Tarea PrioridadT = new Tarea();
            Singleton.Instance.HeapSort = null;

            // Recibe información y la almacena dentro de la tabla hash
            NuevaTarea.Titulo = Titulo;
            NuevaTarea.Descripcion = Descripcion;
            NuevaTarea.Proyecto = Proyecto;
            NuevaTarea.FechaEntrega = Fecha;
            NuevaTarea.Prioridad = Convert.ToInt32(Prioridad);

            Singleton.Instance.Thash.Insertar(NuevaTarea, NuevaTarea.Titulo);

            //Se agrega información dentro del heap
            PrioridadT.Titulo = Titulo;
            PrioridadT.Prioridad = Convert.ToInt32(Prioridad);

            Singleton.Instance.THeap.Insertar(PrioridadT);

            //Se insertan los elementos del árbol dentro de una lista

            return View(Singleton.Instance.HeapSort);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
