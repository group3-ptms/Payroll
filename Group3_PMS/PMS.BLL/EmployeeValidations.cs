using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Exception;
using PMS.Entities;
using PMS.DAL;
using System.Data;


namespace PMS.BLL
{
    /// <summary>
    /// Author: Group 3
    /// Date: 22 June 2018
    /// Client: CG, SIPCOT
    /// </summary>
    
 //EmployeeValidation Class for validating Login,Leaves and Emplyees etc.
    public class EmployeeValidations
    {
        public static bool ValidLoginBLL(int id, string pwd)
        {
            bool isLoginValid = true;
            StringBuilder sm = new StringBuilder();
            try
            {
                if (id == 0)
                {
                    isLoginValid = false;
                    sm.Append("Employee Id is empty");
                }
                if (pwd.Equals(string.Empty))
                {
                    isLoginValid = false;
                    sm.Append("password is empty");
                }
                if (!isLoginValid)
                {
                    throw new PayrollException(sm.ToString());
                }
                return isLoginValid;
            }
            catch (PayrollException)
            {
                
                throw;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public static string LoginCheckBLL(int id, string pwd)
        {
            string username=null;
            bool isLoginValid;
            try
            {
                isLoginValid=ValidLoginBLL(id,pwd);
                if(isLoginValid)
                {
                    username = EmployeeOperations.LoginCheckDAL(id,pwd);
                    return username;
                }
                else
                {
                    throw new PayrollException("Error");
                }
                
            }
            catch (PayrollException)
            {
                
                throw;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public static List<string> LoginSecurityBLL(int id)
        {
            List<string> qa = new List<string>();
            try
            {
                qa = EmployeeOperations.LoginSecurityDAL(id);
                return qa;
            }
            catch (PayrollException)
            {
                
                throw;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public static bool AddLeavesBLL(Leave_Details leave)
        {
            bool isLeaveAdded = false;
            
            try
            {
                isLeaveAdded = EmployeeOperations.AddLeavesDAL(leave);
                return isLeaveAdded;
            }
            catch (PayrollException)
            {
                
                throw;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public static bool ValidateEmployeeBLL(Employee emp, Employee_Security empsec, string desig, string grade)
        {
            bool isEmployeeValidated = true;
            StringBuilder sm = new StringBuilder();
            try
            {
                if (emp.Employee_Id == 0)
                {
                    isEmployeeValidated = false;
                    sm.Append("Employee Id should not be empty");
                }
                if (emp.Employee_Password == null)
                {
                    isEmployeeValidated = false;
                    sm.Append("Employee Password should not be empty");
                }
                if (emp.Employee_FirstName.Equals(string.Empty))
                {
                    isEmployeeValidated = false;
                    sm.Append("Employee First name should not be empty");
                }
                if (emp.Employee_LastName.Equals(string.Empty))
                {
                    isEmployeeValidated = false;
                    sm.Append("Employee Last name should not be empty");
                }
                if (emp.Employee_Address.Equals(string.Empty))
                {
                    isEmployeeValidated = false;
                    sm.Append("Employee Address name should not be empty");
                }
                if (emp.DOJ<DateTime.Now)
                {
                    isEmployeeValidated = false;
                    sm.Append("Employee DOJ cannot be in past");
                }
                if (empsec.Security_Question.Equals(string.Empty))
                {
                    isEmployeeValidated = false;
                    sm.Append("Security Question should not be empty");
                }
                if (empsec.Security_Answer.Equals(string.Empty))
                {
                    isEmployeeValidated = false;
                    sm.Append("Security Answer should not be empty");
                }
                if (desig.Equals(string.Empty))
                {
                    isEmployeeValidated = false;
                    sm.Append("Employee Designation should not be empty");
                }
                if (grade.Equals(string.Empty))
                {
                    isEmployeeValidated = false;
                    sm.Append("Employee Grade should not be empty");
                }

                if (!isEmployeeValidated)
                {
                    throw new PayrollException(sm.ToString());
                }
                return isEmployeeValidated;
            }
            catch (PayrollException)
            {
                
                throw;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public static bool AddEmployeesBLL(Employee emp, Employee_Security empsec, string desig, string grade)
        {
            bool isEmployeeAdded = false;
            bool isEmployeeValidated = false;
            try
            {
                isEmployeeValidated = ValidateEmployeeBLL(emp,empsec,desig,grade);
                if (isEmployeeValidated)
                {
                    isEmployeeAdded = EmployeeOperations.AddEmployeesDAL(emp,empsec,desig,grade);
                    return isEmployeeAdded;
                }
                else
                {
                    throw new PayrollException("Error");
                }
            }
            catch (PayrollException)
            {
                
                throw;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public static DataTable SearchEmpById(int id)
        {
            DataTable eList = new DataTable();
            try
            {
                eList = EmployeeOperations.SearchEmpById(id);
                return eList;
            }
            catch (PayrollException)
            {
                
                throw;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public static int GetLeaveBalanceBLL(int empid)
        {
            try
            {
                int balance;

                balance = EmployeeOperations.GetLeaveBalanceDAL(empid);

                return balance;
            }
            catch (PayrollException)
            {
                
                throw;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public static bool UpdateDetailsBLL(int empid,string fname,string lname,string address)
        {
            try
            {
                bool isUpdated = false;

                isUpdated = EmployeeOperations.UpdateDetailsDAL(empid, fname, lname, address);

                return isUpdated;
            }
            catch (PayrollException)
            {
                
                throw;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public static bool UpdateEmployeedetailsDAL(int empid, string fname, string lname, string desig, string grade)
        {
            try
            {
                bool isUpdated = false;

                isUpdated = EmployeeOperations.UpdateEmployeedetailsDAL(empid, fname, lname, desig, grade);

                return isUpdated;
            }
            catch (PayrollException)
            {
                
                throw;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
