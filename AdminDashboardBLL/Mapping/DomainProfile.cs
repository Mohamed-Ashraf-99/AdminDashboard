using AutoMapper;
using AdminDashboardBLL.ViewModels;
using AdminDashboardDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardBLL.Mapping
{
    public class DomainProfile : Profile
    {

        public DomainProfile() 
        {
            // From Entity To View Model (Retrieve)
            CreateMap<Department, DepartmentVM>();

            // From View Model To Entity (Create - Edit - Delete) 
            CreateMap<DepartmentVM, Department>();

            // From Entity To View Model (Retrieve)
            CreateMap<Employee, EmployeeViewModel>();

            // From View Model To Entity (Create - Edit - Delete) 
            CreateMap<EmployeeViewModel, Employee>();
        }
    }
}
