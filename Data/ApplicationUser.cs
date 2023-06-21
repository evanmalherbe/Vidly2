using Microsoft.AspNetCore.Identity;
 
 
namespace ASPNetCoreIdentityCustomFields.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string DrivingLicence { get; set; }
    }
}
