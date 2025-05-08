using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Table("Jedi")]
    public class Jedi
    {
        public int JediId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
