using System.Net;
using Demo.EmailSender.Services.Contracts;
using WEX.Edge.Core.Interfaces;
using WEX.Edge.Core.Models;

namespace Demo.EmailSender.Services
{
    public class AuthService : IAuthervice
    {
        private readonly ILogger<AuthService> _logger;
        private readonly IAuthServiceClient _authServiceClient;

        public AuthService(IAuthServiceClient authServiceClient, ILogger<AuthService> logger)
        {
            _authServiceClient = authServiceClient;
            _logger = logger;
        }

        public class AuthentaticationResponseObj
        {
            public HttpStatusCode StatusCode { get; set; }
            public string AccessToken { get; set; }
            public string TokenType { get; set; }
            public int ExpiresIn { get; set; }
        }

        public AuthentaticationResponseObj Authenticate()
        {
            try
            {
                var authResponse = _authServiceClient.Login(new LoginRequest
                {
                    Username = "notificationapi",
                    Password = "****"
                }).Result;

                if (authResponse.Login != null && authResponse.Login.Success)
                {
                    return new AuthentaticationResponseObj()
                    {
                        StatusCode = HttpStatusCode.OK,
                        AccessToken = authResponse.Login.Token,
                        TokenType = "Bearer",
                        ExpiresIn = 36000
                    };
                }

                return new AuthentaticationResponseObj()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    AccessToken = string.Empty,
                    ExpiresIn = 0,
                    TokenType = string.Empty
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error authenticating user in the Auth2 service: {ex.Message}", ex);
                throw;
            }
        }
    }
}
