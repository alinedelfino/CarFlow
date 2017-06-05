using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
 * References:
 * https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/
 * https://docs.microsoft.com/en-us/ef/core/index
 * https://docs.microsoft.com/en-us/ef/core/modeling/relationships
 * https://stackoverflow.com/questions/8845738/database-design-for-a-particular-sales-order-scenario
 * */

namespace CarFlow.Models
{
    // Define plain object to represent the Survey forms table on the database
    public class Survey
    {
        public int ID { get; set; }
        public int Rate { get; set; }
        public bool Easy { get; set; }
        public bool Friendly { get; set; }
        public bool EnoughInfo { get; set; }
        public bool Recomend { get; set; }
        public string Suggestion { get; set; }
    }
}
