using System.ComponentModel.DataAnnotations;

namespace GamestoreManagement.Domain
{
    public class Login
    {
        [Key] public string? username {  get; set; }
        public string? password { get; set; }


    }
}
