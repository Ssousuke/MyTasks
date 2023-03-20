using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyTasks.Dto.Dto;
using MyTasks.Infra.Interface;
using MyTasks.Web.ViewModels;

namespace MyTasks.Web.Controllers
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
            var project = await _MyProjectRepository.GetAll();
            return View(project);
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> CreateNewTask(MyTasksDto dto)
        {
            var method = HttpContext.Request.Method;
            if (method == "GET")
            {
                ViewBag.ProjectId = new SelectList(await _MyProjectRepository.GetAll(), "Id", "ProjectName");
                return View();
            }
            else if (method == "POST")
            {
                await _MyTasksRepository.Create(dto);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet("projectId/{id}")]
        public async Task<IActionResult> GetProjectById(Guid id)
        {
            var viewModel = new TaskProjectViewModel()
            {
                Projects = await _MyProjectRepository.GetById(id),
                MyTasksDtos = await _MyTasksRepository.GetByForProjectId(id),
            };
            return View(viewModel);
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> CreateNewProject(ProjectDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _MyProjectRepository.Create(dto);
            return RedirectToAction("Index");

        }
    }
}