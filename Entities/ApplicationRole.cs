using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EF6Repository.Entities
{
    public class ApplicationRole : IdentityRole
    {

        public ApplicationRole()
            : base()
        {
        }

        public ApplicationRole(string name)
            : base(name)
        {
        }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required()]
        public bool active { get; set; }

    }
    
}
