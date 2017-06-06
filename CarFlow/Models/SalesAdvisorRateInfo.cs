using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarFlow.Models
{
    public class SalesAdvisorRateInfo
    {
        public List<SalesAdvisor> salesAdvisor;
        public double avgRating { get; set; }
        public int numSales { get; set; }
    }
}
