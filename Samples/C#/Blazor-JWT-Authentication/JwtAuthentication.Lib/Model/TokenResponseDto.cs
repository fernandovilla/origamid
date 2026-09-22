namespace JwtAuthentication.Lib.Models
{
    public class TokenResponseDto
    {
        public required string AccessToken { get; set; }
        public required DateTime AccessTokenExpiresAt { get; set; }
        public required string RefreshToken { get; set; }
    }
}
