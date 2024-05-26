using System;
using System.IO;
using System.Linq;

namespace EmployeeSortFile

{
    //Author: Ahmet Aydogan (000792453)
    //File Date: 09-27-2020
    //Purpose: To read and sort an external data file

    /**
     * I, Ahmet Aydogan, 000792453 certify that this material is my original work.No other person's work has been used without due acknowledgement.
     **/
    class Program
    {
        //Initializing an array of employees along with option and counter variables
        static Employee[] employees = new Employee[100];
        // Counter is set at 0 so that it can read the first line within the data table and move up by 1 incriment to read the entire table of given data. 
        static int counter = 0; 
        static double option;
        static void Main(string[] args)
        {
            //This while loop allows for the menu to keep looping each time
            //the user makes an input. If the user presses '6', the program exits.
            Read();
            while (true)
            {
                //this try catch loop is here to make sure that a faulty or inocrrect input will not be accepted.
                //wihtin the loop you see that if the input is false it will rerun it until it is correct.
                try
                {
                    //Runs the read method, has a foreach loop to print out every single employee within the array of Employee objects. 

                    Console.Write(  "\n 1.) Sort by Employee Name (ascending)" +
                                    "\n 2.) Sort by Employee Number(ascending)" +
                                    "\n 3.) Sort by Employee Pay Rate(descending)" +
                                    "\n 4.) Sort by Employee Hours(descending)" +
                                    "\n 5.) Sort by Employee Gross Pay(descending)" +
                                    "\n 6.) Exit");
                    Console.Write("\nEnter Option: \n");
                    option = Convert.ToDouble(Console.ReadLine());

                    if (option == 1) {
                       
                        employeesSort(employees);
                        foreach (Employee e in employees)
                        {
                            if (e != null)
                                Console.WriteLine(e);
                        }
                    }


                    if (option == 2)
                    {
                        
                        employeesSortByID(employees);
                        foreach (Employee e in employees)
                        {
                            if (e != null)
                                Console.WriteLine(e);
                        }
                    }


                    if (option == 3)
                    {
                        
                        insertionSort(employees);
                        foreach (Employee e in employees)
                        {
                            if (e != null)
                                Console.WriteLine(e);
                        }
                    }

                    if (option == 6) {
                        Console.WriteLine("Exiting");
                        Environment.Exit(0);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
        }

        static void Read() {
            try
            {
                //These two lines allow for the program to access and read the CSV file within the project
                FileStream file = new FileStream("employees.csv", FileMode.Open, FileAccess.Read);
                StreamReader data = new StreamReader(file);

                string line;
                //Format that is printed everytime with the list of employees to display which row is for which variable
                Console.WriteLine("NAME \t\tID \t  RATE \t\tHOURS \t\tGROSS PAY" + "\n============" + "\t=======" +"\t  ===== \t===== \t\t=========");
                //This while loop reads every line of data within the table so long as it is not completely empty
                while ((line = data.ReadLine()) != null)
                {
                    //These variables allow for the lines of data for each employee to be split into their own variable by the commas that seperate each of them.
                    //The "Convert" in front of some of the variables allows for the program to convert the original data, which is a string, 
                    //to be converted into the proper data form for this project.
                    string name = (line.Split(',')[0]);
                    int number = Convert.ToInt32((line.Split(',')[1]));
                    decimal rate = Convert.ToDecimal((line.Split(',')[2]));
                    double hours = Convert.ToDouble((line.Split(',')[3]));
                    employees[counter] = new Employee(name, number, rate, hours);
                    counter++;
                    
                }
                //Even though the program creates an array of Employees, with the size of 100,
                //there are a bunch of blank empty lines, this line of code allows for the program to delete them so is to make the Array cleaner.
     
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

       
        //The 2 methods you see below use a bubble sort to sort the data accordingly
        //using a double for loop, the system iterates and compares the first element with the second element within the array
        //it compares their values with string comparison, and if the first object(in this case the name) is greater in value than the second object
        //the objects are swapped with their respective indexes and placed accordingly within the array until the comparison coniditons are no longer met then the array is now sorted.
        static void employeesSort(Employee[] employees) {
            int n = employees.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (employees[j] != null && employees[j+1] != null)
                    {
                        if (string.Compare(employees[j].GetName(), employees[j + 1].GetName(), StringComparison.OrdinalIgnoreCase) > 0)
                        {
                            Employee temp = employees[j];
                            employees[j] = employees[j + 1];
                            employees[j + 1] = temp;
                        }
                    }
                }
            }

        }

        static void employeesSortByID(Employee[] employees)
        {
            int n = employees.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (employees[j] != null && employees[j + 1] != null)
                    {
                        if (employees[j].GetNumber().CompareTo(employees[j + 1].GetNumber()) > 0)
                        {
                            Employee temp = employees[j];
                            employees[j] = employees[j + 1];
                            employees[j + 1] = temp;
                        }
                    }
                }
            }

        }

        // The method below uses an insertion sort to sort the data accordingly.
        // Using a for loop, the system iterates through the array starting from the second element.
        // It compares each element with the elements before it in the array.
        // If an element (in this case, the rate) is greater in value than the preceding element,
        // the elements are swapped, and this continues until the correct position for the element is found.
        // This process is repeated until the entire array is sorted.
        static void insertionSort(Employee[] employees) {
            int n = employees.Length;

            for (int i = 1; i < n; i++) {
                if (employees[i] != null)
                {
                    if (employees[i].GetRate().CompareTo(employees[i - 1].GetRate()) > 0)
                    {
                        Employee temp = employees[i];
                        employees[i] = employees[i - 1];
                        employees[i - 1] = temp;
                    }

                    int j = i - 1;
                    while (j > 0 && employees[j].GetRate().CompareTo(employees[j - 1].GetRate()) > 0)
                    {
                        Employee temp2 = employees[j];
                        employees[j] = employees[j - 1];
                        employees[j - 1] = temp2;
                        j--;
                    }
                }
            }
        }
    }
}
