using static Demo.EmailSender.Services.AuthService;

namespace Demo.EmailSender.Services.Contracts
{
    public interface IAuthervice
    {
        AuthentaticationResponseObj Authenticate();
    }
}