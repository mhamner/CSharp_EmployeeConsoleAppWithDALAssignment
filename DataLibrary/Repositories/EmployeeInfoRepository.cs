using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using DataLibrary.DataAccessLayer;
using DataLibrary.DTOs;

namespace DataLibrary.Repositories
{
    public class EmployeeInfoRepository
    {
        public List<EmployeeInfoDTO> GetAllEmployeeInfo()
        {
            List<EmployeeInfoDTO> employeeInfoList = new List<EmployeeInfoDTO>();

            //Create a new instance of our DAL, passing in the connection string
            DataAccess dal = new DataAccess(ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString);

            //Create an empty param dictionary since our method call needs it
            Dictionary<string, object> paramDictionary = new Dictionary<string, object>();

            //Call our DAL method to get all of our employee info.
            DataTable employeeInfoTable = dal.PopulateDataTableViaStoredProcedure("spGetAllEmployeeInfo", paramDictionary);

            //Load up our data table fields into a List<> of Employee DTOs
            return LoadEmployeeDTOList(employeeInfoTable);
        }

        public List<EmployeeInfoDTO> GetEmployeeInfoByState(string state)
        {
            List<EmployeeInfoDTO> employeeInfoList = new List<EmployeeInfoDTO>();

            //Create a new instance of our DAL, passing in the connection string
            DataAccess dal = new DataAccess(ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString);

            //Create a param dictionary with the parameters for the stored proc
            Dictionary<string, object> paramDictionary = new Dictionary<string, object>();
            paramDictionary.Add("@State", state);

            //Call our DAL method to get our employee info. by state
            DataTable employeeInfoTable = dal.PopulateDataTableViaStoredProcedure("spGetEmployeeInfoByState", paramDictionary);

            //Load up our data table fields into a List<> of Employee DTOs
            return LoadEmployeeDTOList(employeeInfoTable);
        }

        public List<EmployeeInfoDTO> GetEmployeeInfoByStartDate(string startDate)
        {
            List<EmployeeInfoDTO> employeeInfoList = new List<EmployeeInfoDTO>();

            //Create a new instance of our DAL, passing in the connection string
            DataAccess dal = new DataAccess(ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString);

            //Create a param dictionary with the parameters for the stored proc
            Dictionary<string, object> paramDictionary = new Dictionary<string, object>();
            paramDictionary.Add("@StartDate", startDate);

            //Call our DAL method to get our employee info. by start date
            DataTable employeeInfoTable = dal.PopulateDataTableViaStoredProcedure("spGetEmployeeInfoAfterStartDate", paramDictionary);

            //Load up our data table fields into a List<> of Employee DTOs
            return LoadEmployeeDTOList(employeeInfoTable);            
        }

        private List<EmployeeInfoDTO> LoadEmployeeDTOList(DataTable dataTable)
        {
            List<EmployeeInfoDTO> employeeInfoList = new List<EmployeeInfoDTO>();

            //Loop through and put the fields from the returned data table into our DTO
            foreach (DataRow row in dataTable.Rows)
            {
                EmployeeInfoDTO employeeInfoDTO = new EmployeeInfoDTO();
                employeeInfoDTO.FirstName = row["FirstName"].ToString();
                employeeInfoDTO.LastName = row["LastName"].ToString();
                employeeInfoDTO.DateOfBirth = row["DateOfBirth"].ToString();
                employeeInfoDTO.EmploymentStartDate = row["EmploymentStartDate"].ToString();
                employeeInfoDTO.EmploymentEndDate = row["EmploymentEndDate"].ToString();
                employeeInfoDTO.StreetAddress = row["StreetAddress"].ToString();
                employeeInfoDTO.City = row["City"].ToString();
                employeeInfoDTO.State = row["State"].ToString();
                employeeInfoDTO.Zip = row["Zip"].ToString();

                //Add this employee to the List<>
                employeeInfoList.Add(employeeInfoDTO);
            }

            return employeeInfoList;
        }
    }

    
}

