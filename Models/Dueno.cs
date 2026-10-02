using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagin_Web_Zoonosis.Models
{
    [Table("Dueño")]
    public class Dueno
    {
        [Key]
        [Column("IDdueño")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDdueño { get; set; }

        [Column("Nombre")] public string Nombre { get; set; } = string.Empty;
        [Column("Apellido")] public string Apellido { get; set; } = string.Empty;
        [Column("Direccion")] public string Direccion { get; set; } = string.Empty;
        [Column("Barrio")] public string Barrio { get; set; } = string.Empty;
        [Column("Telefono")] public string Telefono { get; set; } = string.Empty;
        [Column("DNI")] public string DNI { get; set; } = string.Empty;

        public ICollection<DuenoMascota> DuenoMascotas { get; set; } = new List<DuenoMascota>();
    }
}