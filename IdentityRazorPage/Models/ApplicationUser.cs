using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;

namespace IdentityRazorPage.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string FName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LName { get; set; }
        public byte[]? ProfilePicture { get; set; }

        
    }
}
