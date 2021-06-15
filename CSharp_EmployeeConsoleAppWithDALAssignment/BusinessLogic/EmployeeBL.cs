using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Repositories;
using DataLibrary.DTOs;
using CSharp_EmployeeConsoleAppWithDALAssignment.Models;

namespace CSharp_EmployeeConsoleAppWithDALAssignment.BusinessLogic
{
    public class EmployeeBL
    {
        public List<EmployeeModel> GetAllEmployees()
        {
            //First, get the List<> of Employee DTOs by calling the repository
            EmployeeInfoRepository employeeInfoRepository = new EmployeeInfoRepository();
            List<EmployeeInfoDTO> employeeInfoDTOs = employeeInfoRepository.GetAllEmployeeInfo();

            //Now convert it to the domain model and return the List<> of employee models
            return CreateEmployeeModelFromDto(employeeInfoDTOs);
        }

        public List<EmployeeModel> GetEmployeesByState(string state)
        {
            //First, get the List<> of Employee DTOs by calling the repository
            EmployeeInfoRepository employeeInfoRepository = new EmployeeInfoRepository();
            List<EmployeeInfoDTO> employeeInfoDTOs = employeeInfoRepository.GetEmployeeInfoByState(state);

            //Now convert it to the domain model and return the List<> of employee models
            return CreateEmployeeModelFromDto(employeeInfoDTOs);
        }

        public List<EmployeeModel> GetEmployeesByStartDate(string startDate)
        {
            //First, get the List<> of Employee DTOs by calling the repository
            EmployeeInfoRepository employeeInfoRepository = new EmployeeInfoRepository();
            List<EmployeeInfoDTO> employeeInfoDTOs = employeeInfoRepository.GetEmployeeInfoByStartDate(startDate);

            //Now convert it to the domain model and return the List<> of employee models
            return CreateEmployeeModelFromDto(employeeInfoDTOs);
        }

        private List<EmployeeModel> CreateEmployeeModelFromDto(List<EmployeeInfoDTO> employeeInfoDTOs)
        {
            List<EmployeeModel> employeeModelList = new List<EmployeeModel>();
            foreach (EmployeeInfoDTO edto in employeeInfoDTOs)
            {
                EmployeeModel employeeModel = new EmployeeModel();
                employeeModel.Name = edto.FirstName + " " + edto.LastName;
                employeeModel.DateOfBirth = edto.DateOfBirth;
                employeeModel.EmploymentStartDate = edto.EmploymentStartDate;
                employeeModel.EmploymentEndDate = edto.EmploymentEndDate;
                employeeModel.StreetAddress = edto.StreetAddress;
                employeeModel.City = edto.City;
                employeeModel.State = edto.State;
                employeeModel.Zip = edto.Zip;

                employeeModelList.Add(employeeModel);
            }

            return employeeModelList;
        }
    }
}
