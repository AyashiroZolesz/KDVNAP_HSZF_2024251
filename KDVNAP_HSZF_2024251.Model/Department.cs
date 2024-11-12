using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KDVNAP_HSZF_2024251.Model
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("FactoryID")]
        public int FactoryId { get; set; }

        [JsonIgnore]
        public virtual Factory Factory { get; set; }

        [JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; }
        public Department() {}
    }
}
