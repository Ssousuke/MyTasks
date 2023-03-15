using Microsoft.AspNetCore.Mvc;
using MyTasks.Dto.Dto;
using MyTasks.Infra.Interface;

namespace Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IBaseCrudRepository<ClientDto> _clientRepository;

        public HomeController(IBaseCrudRepository<ClientDto> clientRepository)
        {
            // _logger = logger;
            _clientRepository = clientRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _clientRepository.GetAll());
        }

        public async Task<IActionResult> Create(ClientDto dto)
        {
            var createClient = await _clientRepository.Create(dto);
            return View(createClient);
        }

        public IActionResult ChangeLog()
        {
            return View();
        }
    }
}