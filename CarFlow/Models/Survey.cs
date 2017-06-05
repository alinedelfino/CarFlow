using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Required]
        [Display(Name = "Process was easy")]
        public bool Easy { get; set; }

        [Required]
        [Display(Name = "Friendly enviroment")]
        public bool Friendly { get; set; }

        [Required]
        [Display(Name = "Enough information")]
        public bool EnoughInfo { get; set; }

        [Required]
        [Display(Name = "Would you recomend")]
        public bool Recomend { get; set; }

        [Required]
        [Display(Name = "Any other suggestion")]
        public string Suggestion { get; set; }

        // Each survey relates to a sale order
        public int SalesOrderId { get; set; }
        [ForeignKey("SalesOrderId")]
        public SalesOrder SalesOrder { get; set; }
    }
}
