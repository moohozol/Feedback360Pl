using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class CompetencyVM
    {


        public int Id { get; set; }
        public string Name { get; set; }
        public string Keywords { get; set; }
        public IEnumerable<string> Behaviors { get; set; } = new List<string>();

    }
}
