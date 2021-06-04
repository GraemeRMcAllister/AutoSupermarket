using System.ComponentModel.DataAnnotations;

namespace AuthService.DAL.Entities
{

    public class UserDetails
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public string Role { get; set; }


    }
}