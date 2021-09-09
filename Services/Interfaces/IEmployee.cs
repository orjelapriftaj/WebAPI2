using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
   public  interface IEmployee
    {
        //Employee AddEmployee(Employee employee);
         Task <Employee> Get(int id);
         Task <IEnumerable<Employee>> Get();
        Task<Employee> Create(Employee employee);

        Task Update(Employee employee);

        Task Delete(int id);
    }
}
