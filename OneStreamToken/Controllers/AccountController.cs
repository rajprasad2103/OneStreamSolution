using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneStreamToken.Security;
using OneStreamEncryption;
using System.Security.Cryptography;

namespace OneStreamToken.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {       
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("Token")]
        public IActionResult Token(string xSecretKey)
        {

           // string xEn = AESEncryption.Encrypt(xSecretKey);
          

            if (xSecretKey != null && xSecretKey != string.Empty)
            {
                string xSecretKeyValue = AESEncryption.Decrypt(xSecretKey ?? "");
                string? ConfigSecretKey = OneStreamEncryption.ConfigurationProvider.Configuration["Security:SecretKey"];
                if (xSecretKeyValue == ConfigSecretKey)
                {
                    string token = string.Empty;
                    token = JwtToken.GetToken(xSecretKey ?? "");
                    return Ok(new { token });
                }
                else
                {
                    return NotFound(new ErrorResponse { Message = "Key not Valid", StatusCode = 404 });
                }
               
            }
            else
            {
                return NotFound(new ErrorResponse { Message = "Key not Null", StatusCode = 404 });               
            }

           
        }
       
    }
}
