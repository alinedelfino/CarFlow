using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
 * References:
 * https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/
 * https://docs.microsoft.com/en-us/ef/core/index
 * https://docs.microsoft.com/en-us/ef/core/modeling/relationships
 * */

namespace CarFlow.Models
{
    // Define plain object to represent the SalesAdvisor table on the database
    public class SalesAdvisor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public DateTime BirthDay { get; set; }
        public decimal Sallary { get; set; }
    }
}
