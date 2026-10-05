namespace Ninegoldy.Services.PasswordHasher
{
    public interface IPasswordHasherService
    {
        string Hash(string password);
        bool Verify(string password, string hashedPassword);
    }
}
