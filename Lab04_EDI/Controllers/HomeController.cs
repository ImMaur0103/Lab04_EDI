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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
