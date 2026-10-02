using System.ComponentModel.DataAnnotations;

namespace Pagin_Web_Zoonosis.Models
{
    public class FichaItemViewModel
    {
        public int Id { get; set; }
        public string DuenoNombre { get; set; } = string.Empty;
        public string MascotaNombre { get; set; } = string.Empty;
        public string Raza { get; set; } = string.Empty;
        public string FechaConsulta { get; set; } = string.Empty;
    }

    public record DiferenciaDueno(string Campo, string Actual, string Nuevo);

    public class CrearFichaViewModel
    {
        // Dueño
        [Required(ErrorMessage = "Ingresá el DNI.")]
        [RegularExpression(@"^\d{7,9}$", ErrorMessage = "El DNI debe tener entre 7 y 9 números.")]
        public string DuenoDni { get; set; } = string.Empty;
        public bool DuenoBuscado { get; set; }
        [Required(ErrorMessage = "Ingresá el nombre del dueño.")] public string DuenoNombre { get; set; } = string.Empty;
        [Required(ErrorMessage = "Ingresá el apellido del dueño.")] public string DuenoApellido { get; set; } = string.Empty;
        [Required(ErrorMessage = "Ingresá la dirección.")] public string DuenoDireccion { get; set; } = string.Empty;
        [Required(ErrorMessage = "Ingresá el barrio.")] public string DuenoBarrio { get; set; } = string.Empty;
        [Required(ErrorMessage = "Ingresá el teléfono.")] public string DuenoTelefono { get; set; } = string.Empty;

        // Mascota (MascotaId null o 0 = mascota nueva)
        public int? MascotaId { get; set; }
        public string? MascotaNombre { get; set; }
        public string? MascotaEspecie { get; set; }
        public string? MascotaRaza { get; set; }
        public DateTime? MascotaFechaNacimiento { get; set; }
        public string? MascotaSexo { get; set; }
        public bool? MascotaCastrado { get; set; }

        // Visita
        [Required(ErrorMessage = "Ingresá el motivo de consulta.")] public string MotivoConsulta { get; set; } = string.Empty;
        public string? Diagnostico { get; set; }
        public string? Tratamiento { get; set; }
        public string? Observaciones { get; set; }
        [Range(0.01, 9999.99, ErrorMessage = "El peso debe ser mayor a 0.")] public decimal? Peso { get; set; }

        // "actualizar" / "mantener" cuando los datos del dueño difieren
        public string? DecisionDueno { get; set; }

        // Solo para mostrar
        public bool DuenoExiste { get; set; }
        public List<Mascota> MascotasDelDueno { get; set; } = new();
        public List<DiferenciaDueno> Diferencias { get; set; } = new();
    }

    public class EditarFichaViewModel
    {
        public int NroFicha { get; set; }
        [Required(ErrorMessage = "Ingresá el motivo de consulta.")] public string MotivoConsulta { get; set; } = string.Empty;
        public string? Diagnostico { get; set; }
        public string? Tratamiento { get; set; }
        public string? Observaciones { get; set; }
        [Range(0.01, 9999.99, ErrorMessage = "El peso debe ser mayor a 0.")] public decimal? Peso { get; set; }
    }

    public class EditarDuenoViewModel
    {
        public int IDdueño { get; set; }
        [Required] public string Nombre { get; set; } = string.Empty;
        [Required] public string Apellido { get; set; } = string.Empty;
        [Required] public string Direccion { get; set; } = string.Empty;
        [Required] public string Barrio { get; set; } = string.Empty;
        [Required] public string Telefono { get; set; } = string.Empty;
        [Required, RegularExpression(@"^\d{7,9}$", ErrorMessage = "El DNI debe tener entre 7 y 9 números.")]
        public string DNI { get; set; } = string.Empty;
    }

    public class EditarMascotaViewModel
    {
        public int IDmascota { get; set; }
        [Required] public string Nombre { get; set; } = string.Empty;
        [Required, RegularExpression("^(Perro|Gato|Otro)$")] public string Especie { get; set; } = string.Empty;
        [Required] public string Raza { get; set; } = string.Empty;
        [Required] public DateTime FechaDeNacimiento { get; set; }
        [Required, RegularExpression("^(Macho|Hembra)$")] public string Sexo { get; set; } = string.Empty;
        public bool Castrado { get; set; }
        public List<Dueno> Duenos { get; set; } = new();
    }

    public class EliminarDuenoViewModel
    {
        public Dueno Dueno { get; set; } = null!;
        public List<Mascota> MascotasQueSeEliminan { get; set; } = new();
        public List<Mascota> MascotasQuePersisten { get; set; } = new();
        public int FichasQueSeEliminan { get; set; }
    }

    // NUEVO: para el borrado de mascotas
    public class EliminarMascotaViewModel
    {
        public Mascota Mascota { get; set; } = null!;
        public List<Dueno> Duenos { get; set; } = new();
        public int FichasQueSeEliminan { get; set; }
    }
}