using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyTasks.Dto.Dto;
using MyTasks.Infra.Interface;

namespace Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IBaseCrudRepository<MyTasksDto> _MyTasksRepository;
        private readonly IBaseCrudRepository<ProjectDto> _MyProjectRepository;
        private readonly ILogErrorRepository _log;

        public HomeController(IBaseCrudRepository<MyTasksDto> MyTasksRepository, IBaseCrudRepository<ProjectDto> myProjectRepository, ILogErrorRepository log)
        {
            // _logger = logger;
            _MyTasksRepository = MyTasksRepository;
            _MyProjectRepository = myProjectRepository;
            _log = log;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _MyTasksRepository.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> CreateNewTask()
        {
            ViewBag.ProjectId = new SelectList(await _MyProjectRepository.GetAll(), "Id", "ProjectName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewTask(MyTasksDto dto)
        {
            try
            {
                var createMyTasks = await _MyTasksRepository.Create(dto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                await _log.Create(ex.Message, ex.StackTrace, ex.Source);
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreateNewProject()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewProject(ProjectDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var newProect = await _MyProjectRepository.Create(dto);
            return RedirectToAction("Index");

        }
        public IActionResult ChangeLog()
        {
            return View();
        }
    }
}