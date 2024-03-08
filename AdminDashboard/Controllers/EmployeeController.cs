using AdminDashboardBLL.Feature.Interface;
using AdminDashboardBLL.ViewModels;
using AdminDashboardDAL.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminDashboard.Controllers
{
    public class EmployeeController : Controller
    {
        readonly IEmployeeRepository _employeeRepository;
        readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            //var employeeVMs = await _employeeRepository.GetAllAsync();
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            var employeeVm = _mapper.Map<EmployeeViewModel>(employee);
            return View(employeeVm);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel employeeViewModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var employee = _mapper.Map<Employee>(employeeViewModel);   
                    await _employeeRepository.CreateAsync(employee);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(employeeViewModel);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            var employeeViewModel = _mapper.Map<EmployeeViewModel>(employee);
            return View(employeeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeViewModel employeeViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var employee = _mapper.Map<Employee>(employeeViewModel);
                    await _employeeRepository.UpdateAsync(employee);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(employeeViewModel);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var employee = _employeeRepository.GetByIdAsync(id);
            var employeeViewModel = _mapper.Map<EmployeeViewModel>(employee);
            return View(employeeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(EmployeeViewModel employeeViewModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var employee = _mapper.Map<Employee>(employeeViewModel);
                    await _employeeRepository.DeleteById(employee.Id);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(employeeViewModel);
            }
        }
    }
}
