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
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Position { get; set; }

        [ForeignKey("DepartmentId")]
        public int[] DepartmentId { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<Department> Departments { get; set; }

        public Employee() { }
    }
}
