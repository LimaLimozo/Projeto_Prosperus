using AgoraVai2.ViewModel;
using Entidade;
using Entidade.Models;
using Microsoft.AspNetCore.Mvc;
using Negocio.Cadastro;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime;

namespace AgoraVai2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IIndicadoDbSettings _settings;

        public HomeController(ILogger<HomeController> logger, IIndicadoDbSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        public IActionResult Index()
        {

            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public PartialViewResult ViewAddTelefone(string qtdIndicados)
        {
            @ViewBag.c = qtdIndicados;
            return PartialView("../Home/_IndicadoPartial");
        }

        [HttpPost]
        public IActionResult Create(IndicadorViewModel model)
        {

            List<Indicado> indicados = new List<Indicado>();

            foreach (var item in model.indicadoList)
            {
                Indicado indicado = new Indicado
                {
                    nome = item.nome,
                    numeroTelefone = Convert.ToInt64(item.numeroTelefone),
                    observacoes = item.observacoes,
                    telefoneIndicador = Convert.ToInt64(model.telefoneIndicador)
                };

                indicados.Add(indicado);
            }

            Indicador indicador = new Indicador
            {
                nomeIndicador = model.nomeIndicador,
                telefoneIndicador = Convert.ToInt64(model.telefoneIndicador),
                indicadoList = indicados
            };


            NegIndicado negIndicado = new NegIndicado(_settings);
            negIndicado.Create(indicador);
            return RedirectToAction("Index", "Home");
        }
    }
}