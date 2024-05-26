using System;

namespace EmployeeSortFile
{
    //Author: Ahmet Aydogan
    //Purpose: Employee class to setup Getters and Setters along with the Employee object contructor

    /**
     * I, Ahmet Aydogan, certify that this material is my original work.No other person's work has been used without due acknowledgement.
     **/
    class Employee
    {
        private string name;
        private int number;
        private decimal rate;
        private double hours;
        private decimal gross;

        public Employee(string name, int number, decimal rate, double hours)
        {
            this.name = name;
            this.number = number;
            this.rate = rate;
            this.hours = hours;
        }

        public decimal GetGross() {
            gross = Convert.ToInt32(rate) * Convert.ToInt32(hours); 
            return gross;
        }

        public double GetHours() {
            return hours;
        }

        public String GetName() {
            return name;
        }

        public int GetNumber() {
            return number;
        }

        public decimal GetRate() {
            return rate;
        }

        public override string ToString()
        {
            return (GetName() + ",\t" + GetNumber() + ",\t  " + GetRate() + ",\t" + GetHours() + ",\t\t" + GetGross());
        }

        public void SetHours(double hours) { 
            
        }

        public void SetName(string name) { 
        
        }

        public void SetNumber(int number) { 
        
        }

        public void SetRate(decimal rate) { 
        
        }
    }
}
