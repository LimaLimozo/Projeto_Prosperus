using AgoraVai2.ViewModel;
using Entidade.Models;
using Entidade;
using Microsoft.AspNetCore.Mvc;
using Negocio.Cadastro;
using DnsClient;

namespace AgoraVai2.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IIndicadoDbSettings _settings;

        public LoginController(ILogger<HomeController> logger, IIndicadoDbSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        public IActionResult Login()
        {
            return View("Login");
        }

        public IActionResult Logar(LogarViewModel model)
        {
            if (model.login =="adm" && model.senha == "adm")
            {
      
                return RedirectToAction("Index", "home");
            }


            return RedirectToAction("Login", "Login");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
