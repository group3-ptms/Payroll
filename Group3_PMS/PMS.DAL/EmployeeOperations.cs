using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Entities;
using PMS.Exception;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace PMS.DAL
{
    /// <summary>
    /// Author: Group 3
    /// Date: 22 June 2018
    /// Client: CG, SIPCOT
    /// </summary>

    public class EmployeeOperations
    {
        public static SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings.Get("ConnectionString"));

        public static string LoginCheckDAL(int id,string pwd)
        {
            string username = null;
            try
            {
                SqlCommand command= new SqlCommand("Group3_Payroll.usp_LoginCheck", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter empid = new SqlParameter("@EmpId", id);
                SqlParameter pass = new SqlParameter("@pwd", pwd);

                command.Parameters.Add(empid);
                command.Parameters.Add(pass);

                if (connection.State != ConnectionState.Open)
                { connection.Open(); }

                username = command.ExecuteScalar().ToString();

                if (connection.State == ConnectionState.Open)
                { connection.Close(); }

                return username;
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

        public static List<string> LoginSecurityDAL(int id)
        {
            List<string> qa = new List<string>();
            try
            {
                SqlCommand command = new SqlCommand("Group3_Payroll.usp_SecurityQuestion", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter empid = new SqlParameter("@EmpId", id);
                

                command.Parameters.Add(empid);
                

                if (connection.State != ConnectionState.Open)
                { connection.Open(); }

                SqlDataReader dr = command.ExecuteReader();
                dr.Read();

                qa.Add(dr[0].ToString());
                qa.Add(dr[1].ToString());

                if (connection.State == ConnectionState.Open)
                { connection.Close(); }

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

        public static bool AddLeavesDAL(Leave_Details leave)
        {
            bool isLeaveadded = false;
            try
            {
                SqlCommand command = new SqlCommand("Group3_Payroll.usp_LeaveDetails", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter empid = new SqlParameter("@EmpId",leave.Employee_Id);
                SqlParameter sdate = new SqlParameter("@Startdate",leave.Leave_From);
                SqlParameter edate = new SqlParameter("@EndDate",leave.Leave_To);
                SqlParameter noofday = new SqlParameter("@NoOfDays",leave.No_Of_Days);
                SqlParameter applydate = new SqlParameter("@ApplyDate",leave.Apply_Date);
                SqlParameter reason = new SqlParameter("@Reason",leave.Leave_Reason);
                SqlParameter desc = new SqlParameter("@Description", leave.Leave_Description);

                command.Parameters.Add(empid);
                command.Parameters.Add(sdate);
                command.Parameters.Add(edate);
                command.Parameters.Add(noofday);
                command.Parameters.Add(applydate);
                command.Parameters.Add(reason);
                command.Parameters.Add(desc);

                if (connection.State != ConnectionState.Open)
                { connection.Open(); }

                command.ExecuteNonQuery();
                isLeaveadded = true;

                if (connection.State == ConnectionState.Open)
                { connection.Close(); }

                return isLeaveadded;
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

        public static bool AddEmployeesDAL(Employee emp,Employee_Security empsec,string desig,string grade)
        {
            bool isEmployeeAdded = false;
            try
            {
                SqlCommand command = new SqlCommand("Group3_Payroll.usp_AddEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter empid = new SqlParameter("@EmpId",emp.Employee_Id);
                SqlParameter pwd = new SqlParameter("@Password",emp.Employee_Password);
                SqlParameter doj = new SqlParameter("@doj",emp.DOJ);
                SqlParameter fname = new SqlParameter("@Firstname",emp.Employee_FirstName);
                SqlParameter lname = new SqlParameter("@Lastname",emp.Employee_LastName);
                SqlParameter address = new SqlParameter("@Address",emp.Employee_Address);
                SqlParameter squestion = new SqlParameter("@SecurityQuestion",empsec.Security_Question);
                SqlParameter sanswer = new SqlParameter("@SecurityAnswer",empsec.Security_Answer);
                SqlParameter dsig = new SqlParameter("@Designation",desig);
                SqlParameter grd = new SqlParameter("@Grade",grade);

                command.Parameters.Add(empid);
                command.Parameters.Add(pwd);
                command.Parameters.Add(doj);
                command.Parameters.Add(fname);
                command.Parameters.Add(lname);
                command.Parameters.Add(address);
                command.Parameters.Add(squestion);
                command.Parameters.Add(sanswer);
                command.Parameters.Add(dsig);
                command.Parameters.Add(grd);

                if (connection.State != ConnectionState.Open)
                { connection.Open(); }

                command.ExecuteNonQuery();
                isEmployeeAdded = true;

                if (connection.State == ConnectionState.Open)
                { connection.Close(); }

                return isEmployeeAdded;
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
            DataTable eList= new DataTable();
            try
            {
                SqlCommand command = new SqlCommand("Group3_Payroll.SearchByEmpId", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter empid = new SqlParameter("@EmpId",id);

                command.Parameters.Add(empid);

                if (connection.State != ConnectionState.Open)
                { connection.Open(); }

                
                SqlDataAdapter da = new SqlDataAdapter(command);

                da.Fill(eList);

                //foreach (DataRow item in dt.Rows)
                //{
                //    Employee emp = new Employee();
                //    emp.Employee_Id = Convert.ToInt32(item["Employee_Id"]);
                //    emp.DOJ = Convert.ToDateTime(item["Employee_Doj"]);
                //    emp.Employee_FirstName = item["Employee_FirstName"].ToString();
                //    emp.Employee_LastName = item["Employee_Lastname"].ToString();
                //    emp.Employee_Address = item["Employee_Address"].ToString();
                //    eList.Add(emp);

                //}

               

                if (connection.State == ConnectionState.Open)
                { connection.Close(); }

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

        public static int GetLeaveBalanceDAL(int empid)
        {
            int balance;
            SqlCommand command = new SqlCommand("Group3_Payroll.GetLeaveBalance", connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter emp = new SqlParameter("@EmpId", empid);

            command.Parameters.Add(emp);

            if (connection.State != ConnectionState.Open)
            { connection.Open(); }

            balance = Convert.ToInt32(command.ExecuteScalar());
            

            if (connection.State == ConnectionState.Open)
            { connection.Close(); }

            return balance;
        }

        public static bool UpdateDetailsDAL(int empid, string fname, string lname, string address)
        {
            try
            {
                bool isUpdated = false;

                SqlCommand command = new SqlCommand("Group3_Payroll.usp_UpdateDetails", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter emp = new SqlParameter("@EmpId", empid);
                SqlParameter fn = new SqlParameter("@FirstName", fname);
                SqlParameter ln = new SqlParameter("@lastName", lname);
                SqlParameter ads = new SqlParameter("@Address", address);

                command.Parameters.Add(emp);
                command.Parameters.Add(fn);
                command.Parameters.Add(ln);
                command.Parameters.Add(ads);


                if (connection.State != ConnectionState.Open)
                { connection.Open(); }

                command.ExecuteNonQuery();
                isUpdated = true;

                if (connection.State == ConnectionState.Open)
                { connection.Close(); }

                return isUpdated;
            }
            catch (PayrollException)
            {

                throw;
            }
            catch (SqlException)
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

                SqlCommand command = new SqlCommand("Group3_Payroll.usp_UpdateEmployeeDetails", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter emp = new SqlParameter("@EmpId", empid);
                SqlParameter fn = new SqlParameter("@FirstName", fname);
                SqlParameter ln = new SqlParameter("@lastName", lname);
                SqlParameter dsg = new SqlParameter("@Designation", desig);
                SqlParameter grd = new SqlParameter("@Grade", grade);

                command.Parameters.Add(emp);
                command.Parameters.Add(fn);
                command.Parameters.Add(ln);
                command.Parameters.Add(dsg);
                command.Parameters.Add(grd);


                if (connection.State != ConnectionState.Open)
                { connection.Open(); }

                command.ExecuteNonQuery();
                isUpdated = true;

                if (connection.State == ConnectionState.Open)
                { connection.Close(); }

                return isUpdated;
            }
            catch (PayrollException)
            {
                
                throw;
            }
            catch (SqlException)
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
