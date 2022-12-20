using System.ComponentModel.DataAnnotations;

namespace Lamazon.DomainModels.Entities
{
    public class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        [Key]
        public string Key { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
