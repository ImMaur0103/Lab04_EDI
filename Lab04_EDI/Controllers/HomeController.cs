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
using THash;

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
                            return View("Developer");
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
            Arbol<Tarea> HeapTarea;
            InfoTarea NuevaTarea = new InfoTarea();
            Tarea PrioridadT = new Tarea();
            //Singleton.Instance.HeapSort;

            if (Verificar(Titulo))
            {
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


                //.Instance.HeapSort.Vaciar();
                HeapTarea = new Arbol<Tarea>();
                HeapTarea = Singleton.Instance.THeap;

                Singleton.Instance.HeapSort.InsertarFinal(HeapTarea.Eliminar().valor);

                return View(Singleton.Instance.HeapSort);
            }
            else
            {
                ViewBag.Mensaje = "Título incorrecto, intente de nuevo";
                return View();
            } 
        }

        public IActionResult Eliminar()
        {
            //Falta implementar
            return View("Developer");
        }

        private bool Verificar(string titulo)
        {
            titulo = titulo.ToLower();
            titulo = titulo.Replace(" ", "");
            string valor;

            if(Singleton.Instance.Titulos.contador > 0)
            {
                for (int i = 0; i < Singleton.Instance.Titulos.contador; i++)
                {
                    valor = Singleton.Instance.Titulos.ObtenerValor(i);
                    if(valor == titulo)
                    {
                        return false;
                    }
                    else
                    {
                        Singleton.Instance.Titulos.InsertarInicio(titulo);
                        return true;
                    }
                }
            }
            else
            {
                Singleton.Instance.Titulos.InsertarInicio(titulo);
                return true;
            }

            return false;
        }

        private InfoTarea ObtenerValor(string Titulo)
        {
            THash<InfoTarea> hash = new THash<InfoTarea>();
            hash = Singleton.Instance.Thash;
            int llave = hash.Llave(Titulo);
            InfoTarea valor = new InfoTarea();

            switch (llave)
            {
                case 0:
                    for(int i = 0; i < hash.Lista0.contador; i++)
                    {
                        if(hash.ObtenerValor(i).Titulo == Titulo)
                        {
                            valor = hash.ObtenerValor(i);
                        }
                    }
                    break;
                case 1:
                    for (int i = 0; i < hash.Lista1.contador; i++)
                    {
                        if (hash.ObtenerValor(i).Titulo == Titulo)
                        {
                            valor = hash.ObtenerValor(i);
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < hash.Lista2.contador; i++)
                    {
                        if (hash.ObtenerValor(i).Titulo == Titulo)
                        {
                            valor = hash.ObtenerValor(i);
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < hash.Lista3.contador; i++)
                    {
                        if (hash.ObtenerValor(i).Titulo == Titulo)
                        {
                            valor = hash.ObtenerValor(i);
                        }
                    }
                    break;
                case 4:
                    for (int i = 0; i < hash.Lista4.contador; i++)
                    {
                        if (hash.ObtenerValor(i).Titulo == Titulo)
                        {
                            valor = hash.ObtenerValor(i);
                        }
                    }
                    break;
                case 5:
                    for (int i = 0; i < hash.Lista5.contador; i++)
                    {
                        if (hash.ObtenerValor(i).Titulo == Titulo)
                        {
                            valor = hash.ObtenerValor(i);
                        }
                    }
                    break;
                case 6:
                    for (int i = 0; i < hash.Lista6.contador; i++)
                    {
                        if (hash.ObtenerValor(i).Titulo == Titulo)
                        {
                            valor = hash.ObtenerValor(i);
                        }
                    }
                    break;
                case 7:
                    for (int i = 0; i < hash.Lista7.contador; i++)
                    {
                        if (hash.ObtenerValor(i).Titulo == Titulo)
                        {
                            valor = hash.ObtenerValor(i);
                        }
                    }
                    break;
                case 8:
                    for (int i = 0; i < hash.Lista8.contador; i++)
                    {
                        if (hash.ObtenerValor(i).Titulo == Titulo)
                        {
                            valor = hash.ObtenerValor(i);
                        }
                    }
                    break;
                case 9:
                    for (int i = 0; i < hash.Lista9.contador; i++)
                    {
                        if (hash.ObtenerValor(i).Titulo == Titulo)
                        {
                            valor = hash.ObtenerValor(i);
                        }
                    }
                    break;
            }
            return valor;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
