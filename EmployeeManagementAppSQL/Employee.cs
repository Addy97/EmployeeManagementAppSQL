using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAppSQL
{
    internal class Employee
    {
        SqlConnection con = new SqlConnection("server=41148E0FF02E50D;database=EmployeeManagement;integrated security=true");

        public string AddNewEmployee(int p_empNo, string p_empname, string p_empDesignation, double p_empSalary, bool p_isPerm)
        {
            SqlCommand cmd_insert = new SqlCommand("insert into EmployeeDetails values(@empNo, @empName, @empDesignation, @empSalary, @empIsPerm)", con);
            cmd_insert.Parameters.AddWithValue("empNo", p_empNo);
            cmd_insert.Parameters.AddWithValue("empName", p_empname);
            cmd_insert.Parameters.AddWithValue("empDesignation", p_empDesignation);
            cmd_insert.Parameters.AddWithValue("empSalary", p_empSalary);
            cmd_insert.Parameters.AddWithValue("empIsPerm", p_isPerm);

            try
            {
                con.Open();
                int result = cmd_insert.ExecuteNonQuery(); //methods returns number of rows affected in database
                if(result == 1)
                {
                    con.Close();
                    return "Employee Added to database";
                }
                else
                {
                    con.Close();
                    return "Could not insert Please check with admin";
                }
            }
            catch(Exception ex)
            {
                con.Close();
                return ex.Message;
            }
        }

        public string DeleteEmployee(int p_empNo)
        {
            SqlCommand cmd_delete = new SqlCommand("delete from EmployeeDetails where empNo=@empNo", con);
            cmd_delete.Parameters.AddWithValue("empNo", p_empNo);

            try
            {
                con.Open();
                int result = cmd_delete.ExecuteNonQuery();
                if(result == 1)
                {
                    con.Close();
                    return "Employee Deleted successfully";
                }
                else
                {
                    con.Close();
                    return "Could not delete Employee, please check again";
                }
            }
            catch(Exception ex)
            {
                con.Close();
                return ex.Message;
            }
        }

        public string UpdateEmployee(int p_empNo, string p_empname, string p_empDesignation, double p_empSalary)
        {
            SqlCommand cmd_update = new SqlCommand("update EmployeeDetails set empName=@empName, empDesignation=@empDesignation, empSalary=@empSalary where empNo=@empNo", con);
            cmd_update.Parameters.AddWithValue("empName", p_empname);
            cmd_update.Parameters.AddWithValue("empDesignation", p_empDesignation);
            cmd_update.Parameters.AddWithValue("empSalary", p_empSalary);
            cmd_update.Parameters.AddWithValue("empNo", p_empNo);

            try
            {
                con.Open();
                int result = cmd_update.ExecuteNonQuery();
                if(result == 1)
                {
                    con.Close();
                    return "Employee details updated successfully";
                }
                else
                {
                    con.Close();
                    return "Could not update detail Please check again";
                }
            }
            catch(Exception ex)
            {
                con.Close();
                return ex.Message;
            }
        }
    }
}
