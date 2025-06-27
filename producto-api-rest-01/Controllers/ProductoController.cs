using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using producto_api_rest_01.DTOs;
using producto_api_rest_01.models;
using producto_api_rest_01.Services;

namespace producto_api_rest_01.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _productoService;
        
        // inyectar de dependencia ProductoService
        public ProductoController(ProductoService productoService)
        {
            _productoService = productoService;
        }

        // create new Producto
        [HttpPost]
        public async Task<ActionResult<ApiResponse<ProductoResponseDTO>>> CreateProducto(
            [FromBody] ProductoCreateDTO productoCreateDTO)
        {
            var response = await _productoService.CreateProductoAsyn(productoCreateDTO);

            if (response.StatusCode != 200)
            {
                return StatusCode(response.StatusCode, response);
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApiResponse<ProductoResponseDTO>>>> ListarProductos()
        {
            var response = await _productoService.ListarProductos();

            if (response.StatusCode != 200)
            {
                return StatusCode(response.StatusCode, response);
            }

            return Ok(response);
        }
    }
}
