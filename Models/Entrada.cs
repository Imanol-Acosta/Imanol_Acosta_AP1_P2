using System.ComponentModel.DataAnnotations;

namespace Imanol_Acosta_AP1_P2.Models;

public class Entrada
{
    [Key]
    public int EntradaId { get; set; }

    [Required(ErrorMessage = "La fecha es requerida")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "El concepto es requerido")]
    [StringLength(200, ErrorMessage = "El concepto no puede exceder los 200 caracteres")]
    public string Concepto { get; set; } = string.Empty;

    [Required(ErrorMessage = "El peso total es requerido")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El peso total debe ser mayor a 0")]
    public double PesoTotal { get; set; }

    [Required(ErrorMessage = "El ID del producto es requerido")]
    [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un producto válido")]
    public int IdProducido { get; set; }

    [Required(ErrorMessage = "La cantidad producida es requerida")]
    [Range(0.01, double.MaxValue, ErrorMessage = "La cantidad producida debe ser mayor a 0")]
    public double CantidadProducida { get; set; }

    public virtual Producto? Producto { get; set; }
}