using AdminDashboardBLL.Feature.Interface;
using AdminDashboardBLL.ViewModels;
using AdminDashboardDAL.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AdminDashboard.Controllers
{
    public class EmployeeController : Controller
    {
        readonly IUnitOfWork _genericRepository;

        readonly IMapper _mapper;

        public EmployeeController(IMapper mapper,
            IUnitOfWork genericRepository)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
        }

        public async Task<IActionResult> Index(string SearchValue)
        {
            if(SearchValue != null)
            {
                var employees = await _genericRepository.Employee.FindAllAsync(e => e.FirstName.Contains(SearchValue) || e.LastName.Contains(SearchValue) && e.IsDeleted == false, new[] { "Department" });
                var employeeViewModels = _mapper.Map<IEnumerable<EmployeeViewModel>>(employees);
                return View(employeeViewModels);
            }
            else
            {
                var employees = await _genericRepository.Employee.FindAllAsync(e => e.IsDeleted == false, new [] {"Department"});
                var employeeViewModels = _mapper.Map<IEnumerable<EmployeeViewModel>>(employees);
                return View(employeeViewModels);
            }
           
        }


        public async Task<IActionResult> Details(int id)
        {
            var employee = await _genericRepository.Employee.FindByAsync(e => e.Id == id  && e.IsDeleted == false, new[] {"Department"});
            var employeeVm = _mapper.Map<EmployeeViewModel>(employee);
            return View(employeeVm);
        }

  
        public async Task<IActionResult> Create()
        {
            var employeeVM = new EmployeeViewModel()
            {
                DepartmentsList = await _genericRepository.Department.GetAll()          
            };
            return View(employeeVM);
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
                    await _genericRepository.Employee.Add(employee);
                    await _genericRepository.Commit();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                employeeViewModel.DepartmentsList = await _genericRepository.Department.GetAll();
                return View(employeeViewModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _genericRepository.Employee.FindByAsync(e => e.Id == id && e.IsDeleted == false, new[] { "Department" });
            var employeeViewModel = _mapper.Map<EmployeeViewModel>(employee);
            employeeViewModel.DepartmentsList = await _genericRepository.Department.GetAll();
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
                    employee.IsUpdated = true;
                    employee.LastUpdatedDate = DateTime.Now;
                    await _genericRepository.Employee.Update(employee);
                    await _genericRepository.Commit();

                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                employeeViewModel.DepartmentsList = await _genericRepository.Department.GetAll();
                return View(employeeViewModel);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _genericRepository.Employee.FindByAsync(e => e.Id == id && e.IsDeleted == false, new[] {"Department"});
            var employeeViewModel = _mapper.Map<EmployeeViewModel>(employee);

            employeeViewModel.DepartmentsList = await _genericRepository.Department.GetAll();
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
                    employee.DeletedDate = DateTime.Now;
                    employee.IsActive = false;
                    employee.IsDeleted = true;
                    
                    await _genericRepository.Employee.Delete(employee);
                    await _genericRepository.Commit();

                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                employeeViewModel.DepartmentsList = await _genericRepository.Department.GetAll();

                return View(employeeViewModel);
            }
        }

    }
}
