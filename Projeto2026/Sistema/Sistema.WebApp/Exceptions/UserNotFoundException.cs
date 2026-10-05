namespace Ninegoldy.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message = "Usuário não encontrado") 
            : base(message)
        { }
    }
}
