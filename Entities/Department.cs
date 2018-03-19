using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF6Repository.Entities
{
    public class Department
    {
        public object this[string propertyName]
        {
            get { return this.GetType().GetProperty(propertyName).GetValue(this, null); }
            set { this.GetType().GetProperty(propertyName).SetValue(this, value, null); }
        }

        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [Required()]
        [MaxLength(100)]
        [Display(Name = "Name")]
        public string name { get; set; }

        [MaxLength()]
        [Display(Name = "Description")]
        public string description { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool active { get; set; }
    }
}
