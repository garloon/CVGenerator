using CVGenerator.Core.Data.Entities;

namespace CVGenerator.Core.Models
{
    public class DepartmentDto : BaseDto<long>
    {
        public string Name { get; set; }
        public Role Role { get; set; }
        public bool IsForCv { get; set; }
    }
}
