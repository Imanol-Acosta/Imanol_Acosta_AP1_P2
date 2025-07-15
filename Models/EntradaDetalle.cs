using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Imanol_Acosta_AP1_P2.Models;

public class EntradaDetalle
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "El ID de entrada es requerido")]
    public int EntradaId { get; set; }

    [Required(ErrorMessage = "El ID del producto es requerido")]
    [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un producto válido")]
    public int ProductoId { get; set; }

    [Required(ErrorMessage = "La cantidad es requerida")]
    [Range(0.01, double.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
    public double Cantidad { get; set; }

    [ForeignKey("EntradaId")]
    public virtual Entrada? Entrada { get; set; }

    [ForeignKey("ProductoId")]
    public virtual Producto? Producto { get; set; }
}