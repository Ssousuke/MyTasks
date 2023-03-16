using Microsoft.AspNetCore.Mvc;
using MyTasks.Dto.Dto;
using MyTasks.Infra.Interface;

namespace Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IBaseCrudRepository<MyTasksDto> _MyTasksRepository;

        public HomeController(IBaseCrudRepository<MyTasksDto> MyTasksRepository)
        {
            // _logger = logger;
            _MyTasksRepository = MyTasksRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _MyTasksRepository.GetAll());
        }

        public async Task<IActionResult> Create(MyTasksDto dto)
        {
            var createMyTasks = await _MyTasksRepository.Create(dto);
            return View(createMyTasks);
        }

        public IActionResult ChangeLog()
        {
            return View();
        }
    }
}