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
    // Define plain object to represent the sales order table on the database
    public class SalesOrder
    {
        public int ID { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Sale price"), DataType(DataType.Currency)]        
        public decimal SalePrice { get; set; }

        [Display(Name = "Sale date"), DataType(DataType.Date)]        
        public DateTime SaleDate { get; set; }

        // References to other tables
        public int SalesAdvisorId { get; set; }
        [ForeignKey("SalesAdvisorId")]
        [Display(Name = "Sales Advisor")]
        public SalesAdvisor SalesAdvisor { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
}
