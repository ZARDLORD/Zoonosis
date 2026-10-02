using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagin_Web_Zoonosis.Models
{
    [Table("Historial")]
    public class Historial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime FechaHora { get; set; }

        public int? IDusuario { get; set; }
        public string UsuarioEmail { get; set; } = string.Empty;
        public string Accion { get; set; } = string.Empty;
        public string Entidad { get; set; } = string.Empty;
        public int? IDentidad { get; set; }
        public string Descripcion { get; set; } = string.Empty;
    }
}