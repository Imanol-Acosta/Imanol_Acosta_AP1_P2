using System.ComponentModel.DataAnnotations;

namespace Imanol_Acosta_AP1_P2.Models;

public class Producto
{
    [Key]
    public int ProductoID { get; set; }

    [Required(ErrorMessage = "La descripción es requerida")]
    [StringLength(200, ErrorMessage = "La descripción no puede exceder los 200 caracteres")]
    public string Descripcion { get; set; } = string.Empty;

    [Required(ErrorMessage = "El peso es requerido")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El peso debe ser mayor a 0")]
    public double Peso { get; set; }

    [Required(ErrorMessage = "La existencia es requerida")]
    [Range(0, double.MaxValue, ErrorMessage = "La existencia no puede ser negativa")]
    public double Existencia { get; set; }

    public bool EsCompuesto { get; set; }
}