using System.ComponentModel.DataAnnotations;

namespace ApiEmpresa.Models
{
    public class Clientes
    {
        [Key]
        public int Id_cliente { get; set; }
        
        [Required]
        public string CUI { get; set; } = string.Empty;
        
        [Required]
        public string NIT { get; set; } = string.Empty;
        
        [Required]
        public string Nombres { get; set; } = string.Empty;
        
        [Required]
        public string Apellidos { get; set; } = string.Empty;
        
        public string? Direccion { get; set; }
        
        public string? Telefono { get; set; }
        
        [Required]
        public DateTime Fecha_Nacimiento { get; set; }
    }
}