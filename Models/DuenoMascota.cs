using System.ComponentModel.DataAnnotations.Schema;

namespace Pagin_Web_Zoonosis.Models
{
    [Table("DuenoMascota")]
    public class DuenoMascota
    {
        [Column("IDdueño")] public int IDdueño { get; set; }
        [Column("IDmascota")] public int IDmascota { get; set; }

        public Dueno Dueno { get; set; } = null!;
        public Mascota Mascota { get; set; } = null!;
    }
}