using System.ComponentModel.DataAnnotations;
namespace Imanol_Acosta_AP1_P2.Models;

public class Producto
{
    [Key]

    public int ProductoID { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public double Peso { get; set; }
    public double Existencia { get; set; }
    public bool EsCompuesto { get; set; }

}

