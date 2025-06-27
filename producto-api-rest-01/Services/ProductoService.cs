using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using producto_api_rest_01.Data;
using producto_api_rest_01.DTOs;
using producto_api_rest_01.models;

namespace producto_api_rest_01.Services
{
    public class ProductoService
    {
        private readonly ApplicationDbContext _context;

        public ProductoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<ProductoResponseDTO>> CreateProductoAsyn(
            ProductoCreateDTO productoCreateDTO)
        {
            try
            {
                var isNameProduct = await _context.Productos.AnyAsync(product =>
                product.Nombre.ToLower() == productoCreateDTO.Nombre.ToLower());

                if (isNameProduct)
                {

                    return new ApiResponse<ProductoResponseDTO>(
                        400, "Producto name is already exists.");
                };

                var producto = new Producto
                {
                    Nombre = productoCreateDTO.Nombre,
                    Descripcion = productoCreateDTO.Descripcion,
                    Precio = productoCreateDTO.Precio,
                    Stock = productoCreateDTO.Stock,
                    FechaRegistro = DateTime.Now,
                    Activo = true
                };

                // add producto to database
                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();

                var productoResponse = new ProductoResponseDTO
                {
                    ProductoId = producto.ProductoId,
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    Precio = producto.Precio,
                    Stock = producto.Stock,
                    FechaRegistro = producto.FechaRegistro,
                    Activo = producto.Activo
                };

                return new ApiResponse<ProductoResponseDTO>(200, productoResponse);
            }
            catch (Exception ex)
            {
                return new ApiResponse<ProductoResponseDTO>(500, $"Ocurrió un " +
                    $"error proceso de solicitud, Error: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<ProductoResponseDTO>>> ListarProductos()
        {
            try
            {
                var productos = await _context.Productos.AsNoTracking().ToListAsync();

                var productoList = productos.Select(product => new ProductoResponseDTO
                {
                    ProductoId = product.ProductoId,
                    Nombre = product.Nombre,
                    Descripcion = product.Descripcion,
                    Precio = product.Precio,
                    Stock = product.Stock,
                    FechaRegistro = product.FechaRegistro,
                    Activo = product.Activo
                }).ToList();

                return new ApiResponse<IEnumerable<ProductoResponseDTO>>(200, productoList);
            } catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<ProductoResponseDTO>>(500,
                    $"Ocurrió un error en la solicitud, Error: {ex.Message}");
            }
        }
    }
}
