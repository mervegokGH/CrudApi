using System.ComponentModel.DataAnnotations;

namespace CrudApi.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public int Grade { get; set; }
        public int IsActive { get; set; }
    }
}
