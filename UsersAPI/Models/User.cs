using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Models
{
    public class User
    {
        public Guid Guid { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z\d]+$")]
        public string Login { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z\d]+$")]
        public string Password { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Zа-яА-Я]+$")]
        public string Name { get; set; }
        [Required]
        public int Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public bool Admin { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? RevokedOn { get; set; }
        public string? RevokedBy { get; set; }
    }
}
