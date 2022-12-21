using System.ComponentModel;

namespace WebApp.Models
{
    public class Owner
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public int? Age { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
