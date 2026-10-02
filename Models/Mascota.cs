using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagin_Web_Zoonosis.Models
{
    [Table("Mascota")]
    public class Mascota
    {
        [Key]
        [Column("IDmascota")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDmascota { get; set; }

        [Column("Nombre")] public string Nombre { get; set; } = string.Empty;
        [Column("especie")] public string Especie { get; set; } = string.Empty; // Perro / Gato / Otro
        [Column("raza")] public string Raza { get; set; } = string.Empty;
        [Column("fechadenacimiento", TypeName = "date")] public DateTime FechaDeNacimiento { get; set; }
        [Column("sexo")] public string Sexo { get; set; } = string.Empty;    // Macho / Hembra
        [Column("castrado")] public bool Castrado { get; set; }

        public ICollection<DuenoMascota> DuenoMascotas { get; set; } = new List<DuenoMascota>();
        public ICollection<Ficha> Fichas { get; set; } = new List<Ficha>();
    }
}