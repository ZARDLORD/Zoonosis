namespace Pagin_Web_Zoonosis.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; // hash bcrypt
        public string Rol { get; set; } = Roles.Recepcionista;
        public string? NombreCompleto { get; set; }
    }
}