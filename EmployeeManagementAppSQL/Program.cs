// See https://aka.ms/new-console-template for more information
using EmployeeManagementAppSQL;

Console.WriteLine("Welcome to Employee Management");

Console.WriteLine("Press Enter to continue");
Console.ReadLine();

Console.WriteLine("1. Add New Employee");
Console.WriteLine("2. Delete Employee");
Console.WriteLine("3. Update Employee");
Console.WriteLine("4. View Employee Detail");
Console.WriteLine("5. View All Employee");

int choice  = Convert.ToInt32(Console.ReadLine());
Employee empObj = new Employee();

switch (choice)
{
    case 1:
        Console.WriteLine("Enter Employee Number");
        int no = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Employee Name");
        string name  = Console.ReadLine();

        Console.WriteLine("Enter Employee Designation");
        string desg = Console.ReadLine();

        Console.WriteLine("Enter Employee Salary");
        double salary = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter id employee is permanent");
        bool perm = Convert.ToBoolean(Console.ReadLine());

        string result = empObj.AddNewEmployee(no, name, desg, salary, perm);
        Console.WriteLine(result);
        break;
    case 2:
        Console.WriteLine("Please enter employee number");
        int eNo = Convert.ToInt32(Console.ReadLine());

        string resp=empObj.DeleteEmployee(eNo);
        Console.WriteLine(resp);
        break;

    case 3:
        Console.WriteLine("Please enter empployee number");
        int empNo = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("please Enter the name to be updated");
        string empName = Console.ReadLine();

        Console.WriteLine("Please enter new designation");
        string empDesg = Console.ReadLine();

        Console.WriteLine("please enter updated salary");
        double empSal = Convert.ToDouble(Console.ReadLine());

        string response = empObj.UpdateEmployee(empNo, empName, empDesg, empSal);
        Console.WriteLine(response);
        break;

    case 4:
        Console.WriteLine("Please enter employee number");
        int empN = Convert.ToInt32(Console.ReadLine());
        try
        {
            Employee details = empObj.GetEmployeeById(empN);
            Console.WriteLine("Employee Number "+details.empNo);
            Console.WriteLine("Employee Name " + details.empName);
            Console.WriteLine("Employee Designation " + details.empDesignation);
            Console.WriteLine("Employee Salary " + details.empSalary);
            Console.WriteLine("Employee Is Permanent " + details.empIsPerm);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        break;
    case 5:
        List<Employee> allDetails = new List<Employee>();
        allDetails = empObj.GetAllEmployee();
        foreach(var item in allDetails)
        {
            Console.WriteLine("Employee Number " + item.empNo);
            Console.WriteLine("Employee Name " + item.empName);
            Console.WriteLine("Employee Designation " + item.empDesignation);
            Console.WriteLine("Employee Salary " + item.empSalary);
            Console.WriteLine("Employee Is Permanent " + item.empIsPerm);
            Console.WriteLine("`----------------------------------------------------");
        }
        break;

    default:
        break;
}
