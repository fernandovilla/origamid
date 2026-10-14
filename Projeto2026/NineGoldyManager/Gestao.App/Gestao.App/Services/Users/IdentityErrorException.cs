using Microsoft.AspNetCore.Identity;

namespace Gestao.App.Services.Users
{
    public class IdentityErrorException : Exception
    {
        public IEnumerable<IdentityError> Errors { get; private set; }

        public IdentityErrorException(IEnumerable<IdentityError> errors)
        {
            Errors = errors;
        }
    }
}
