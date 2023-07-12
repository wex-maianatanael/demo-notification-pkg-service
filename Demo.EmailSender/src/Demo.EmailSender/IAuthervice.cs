using static Demo.EmailSender.AuthService;

namespace Demo.EmailSender
{
    public interface IAuthervice
    {
        AuthentaticationResponseObj Authenticate();
    }
}