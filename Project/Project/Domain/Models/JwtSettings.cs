namespace Domain.Models
{
    public class JwtSettings
    {
        public const string Section = "JWTSecretKey";
        public string Key { get; set; }
        public override string ToString()
        {
            return Key;
        }
    }
}
