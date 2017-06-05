using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarFlow.Models;

namespace CarFlow.Models
{
    public class CarFlowContext : DbContext
    {
        public CarFlowContext (DbContextOptions<CarFlowContext> options)
            : base(options)
        {
        }

        public DbSet<CarFlow.Models.Customer> Customer { get; set; }

        public DbSet<CarFlow.Models.SalesAdvisor> SalesAdvisor { get; set; }

        public DbSet<CarFlow.Models.SalesOrder> SalesOrder { get; set; }

        public DbSet<CarFlow.Models.Survey> Survey { get; set; }
    }
}
