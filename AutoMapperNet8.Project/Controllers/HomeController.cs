using AutoMapperNet8.Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoMapper;
using AutoMapperNet8.Project.DTOs;

namespace AutoMapperNet8.Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IMapper _mapper;
        public HomeController(ILogger<HomeController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee() { Id = 1, FirstName = "Erkan", LastName = "Salihoğlu", Address = "Beşiktaş", Email = "es@test.com" });
            employees.Add(new Employee() { Id = 1, FirstName = "Burak", LastName = "Junior", Address = "Üsküdar", Email = "jb@test.com" });
            List<Employee> result = employees.ToList();
            List<EmployeeDTO> employeeDto = _mapper.Map<List<EmployeeDTO>>(result);
            return View(employeeDto);
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
