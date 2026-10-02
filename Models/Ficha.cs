using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagin_Web_Zoonosis.Models
{
    [Table("Ficha")]
    public class Ficha
    {
        [Key]
        [Column("NroFicha")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NroFicha { get; set; }

        [Column("FechaVisita")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // la pone la base (now())
        public DateTime FechaVisita { get; set; }

        [Column("IDmascota")] public int IDmascota { get; set; }
        [Column("IDdueño")] public int? IDdueño { get; set; }
        [Column("IDveterinario")] public int? IDveterinario { get; set; }

        [Column("MotivoConsulta")] public string MotivoConsulta { get; set; } = string.Empty;
        [Column("Diagnostico")] public string? Diagnostico { get; set; }
        [Column("Tratamiento")] public string? Tratamiento { get; set; }
        [Column("Observaciones")] public string? Observaciones { get; set; }
        [Column("Peso")] public decimal? Peso { get; set; }

        [Column("Eliminada")] public bool Eliminada { get; set; }
        [Column("FechaEliminacion")] public DateTime? FechaEliminacion { get; set; }

        public Mascota Mascota { get; set; } = null!;
        public Dueno? Dueno { get; set; }
        public Usuario? Veterinario { get; set; }
    }
}