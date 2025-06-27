using System.ComponentModel.DataAnnotations;

namespace producto_api_rest_01.DTOs
{
    public class ProductoResponseDTO
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }
    }
}
