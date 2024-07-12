dotnet ef migrations add InitialCreate
dotnet ef database update

dotnet list package



# ADDING PACKAGES
> dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.6

# ANGULAR SETUP
ng new lisa_web --style=css --skip-tests --version=17



```
var tenants = dbContext.TenantProperties.Where(tp => tp.PropertyId == propertyId)
                                       .Select(tp => tp.Tenant)
                                       .Distinct();
```

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LisaApi.Controllers
{
    [ApiController]
    [Route("api/leases")]
    public class LeaseController : ControllerBase
    {
        [HttpPost("upload-agreement")]
        public IActionResult UploadAgreement([FromForm] Lease lease)
        {
            // Access the uploaded file
            var agreementFormFile = lease.AgreementFormFile;

            // Process the file or save it to a storage location
            // ...

            return Ok();
        }
    }
}

# KILLING PROCESS
➜ kill -9 534452
➜ lsof -i :5091


# REACT FILE UPLOAD
function convertFileToFormData(file) {
    return new Promise((resolve, reject) => {
        const reader = new FileReader();

        reader.onload = () => {
            const fileData = reader.result.split(',')[1]; // Extract base64 data
            const formData = new FormData();
            formData.append('agreementFormFileData', fileData); // Set field corresponding to line 8 in Lease.cs

            resolve(formData);
        };

        reader.onerror = error => reject(error);

        reader.readAsDataURL(file);
    });
}

// Example usage
const handleFileUpload = async (file) => {
    try {
        const formData = await convertFileToFormData(file);
        // Send formData to your backend API
    } catch (error) {
        console.error('Error converting file to FormData:', error);
    }
};


# AUTHENTICATIOn
> dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
> dotnet add package Microsoft.IdentityModel.Tokens


- Program.cs
```
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var key = Encoding.ASCII.GetBytes("YourSecretKeyHere"); // Use a strong secret key

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "yourdomain.com",
        ValidAudience = "yourdomain.com",
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


```