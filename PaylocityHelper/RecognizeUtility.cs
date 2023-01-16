using PaylocityToRecognize.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityHelper
{
    public static class RecognizeUtility
    {
        public static RecognizeEmployee Map(PaylocityEmployeeDetail e) 
        {
            var recognizeEmployee = new RecognizeEmployee();
            if(e != null)
            {
                recognizeEmployee.EmployeeId = e.EmployeeId;
                if(e.WorkAddress!=null)
                {
                    if (!string.IsNullOrWhiteSpace(e.WorkAddress.EmailAddress))
                    {
                        recognizeEmployee.Email = e.WorkAddress.EmailAddress;
                    }
                    else
                    {
                        recognizeEmployee.Email = e.HomeAddress.EmailAddress;
                    }
                    recognizeEmployee.Team = StringUtility.GetTeamNameFromLocation(e.WorkAddress.Location);
                    recognizeEmployee.Country = e.WorkAddress.Country;

                }
                else
                {
                    recognizeEmployee.Email = string.Empty;
                    recognizeEmployee.Team = string.Empty;
                    recognizeEmployee.Country = string.Empty;
                }

                if(e.DepartmentPosition!=null)
                {
                    recognizeEmployee.JobTitle = e.DepartmentPosition.JobTitle;
                    recognizeEmployee.Roles = StringUtility.GetRoleNameFromPositionCode(e.DepartmentPosition.PositionCode);
                }
                else
                {
                    recognizeEmployee.JobTitle = string.Empty;
                    recognizeEmployee.Roles = string.Empty;
                }

                if (e.Status != null)
                {
                    recognizeEmployee.Status = e.Status.EmployeeStatus;
                    recognizeEmployee.StartDate = e.Status.HireDate.ToString("MM/dd/yyyy");
                }
                else
                {
                    recognizeEmployee.Status = string.Empty;
                    recognizeEmployee.StartDate = string.Empty;
                }    

                recognizeEmployee.FirstName = e.FirstName;
                recognizeEmployee.LastName = e.LastName;
                recognizeEmployee.DisplayName = $"{e.FirstName} {e.LastName}";
                recognizeEmployee.Phone = string.Empty;
                recognizeEmployee.BirthDate = e.BirthDate.ToString("MM/dd/yyyy");
                recognizeEmployee.ManagerEmail = string.Empty;
                recognizeEmployee.Department = string.Empty;
                recognizeEmployee.Locale = string.Empty;
            }


            return recognizeEmployee;
        }

        public static void WriteToCSVFile(IEnumerable<RecognizeEmployee> employees)
        {
            string strFilePath = @"C:\Users\CebuDev15\source\repos\GillettePepsi\Documents\recognizeemp.csv";
            string commaSeparator = ",";
            StringBuilder employeeString = new StringBuilder();
            employeeString.AppendLine("Employee ID,Email,First Name,Last Name,Display Name,Job Title,Phone,Team,Roles,Start Date,Birthday,Manager Email,Country,Department,Locale");
            foreach (var employee in employees)
            {
                employeeString.Append(employee.EmployeeId);
                employeeString.Append(commaSeparator);
                employeeString.Append(employee.Email);
                employeeString.Append(commaSeparator);
                employeeString.Append(employee.FirstName);
                employeeString.Append(commaSeparator);
                employeeString.Append(employee.LastName);
                employeeString.Append(commaSeparator);
                employeeString.Append(employee.DisplayName);
                employeeString.Append(commaSeparator);
                employeeString.Append(employee.JobTitle);
                employeeString.Append(commaSeparator);
                employeeString.Append(employee.Phone);
                employeeString.Append(commaSeparator);
                employeeString.Append(employee.Team);
                employeeString.Append(commaSeparator);
                employeeString.Append(employee.Roles);
                employeeString.Append(commaSeparator);
                employeeString.Append(employee.StartDate);
                employeeString.Append(commaSeparator);
                employeeString.Append(employee.BirthDate);
                employeeString.Append(commaSeparator);
                employeeString.Append(employee.ManagerEmail);
                employeeString.Append(commaSeparator);
                employeeString.Append(employee.Country);
                employeeString.Append(commaSeparator);
                employeeString.Append(employee.Department);
                employeeString.Append(commaSeparator);
                employeeString.Append(employee.Locale);
                employeeString.AppendLine();
            }
            // Create and write the csv file
            File.WriteAllText(strFilePath, employeeString.ToString());

        }
    }
}
