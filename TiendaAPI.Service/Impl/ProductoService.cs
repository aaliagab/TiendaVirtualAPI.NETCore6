using TiendaAPI.Common.DTO.Response;
using TiendaAPI.Data;
using TiendaAPI.Data.Entities;
using TiendaAPI.Data.UoW;
using TiendaAPI.Services.Exceptions.NotFound;

namespace TiendaAPI.Services.Impl
{
    public class ProductoService : IProductoService
    {
        private readonly IUnitOfWork _uow;
        private readonly CoreDbContext _dbContext;

        public ProductoService(IUnitOfWork uow, CoreDbContext dbContext)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<ProductoResponse> CreateProductoAsync(string nombre, double precio, int stockDisponible)
        {
            var Producto = new Producto
            {
                Nombre = nombre,
                Precio = precio,
                StockDisponible = stockDisponible
            };

            _dbContext.Productos.Add(Producto);
            await _dbContext.SaveChangesAsync();

            return new ProductoResponse
            {
                ProductoId = Producto.ProductoId,
                Nombre = Producto.Nombre,
                Precio = Producto.Precio,
                StockDisponible = Producto.StockDisponible
            };
        }

        public async Task<bool> DeleteProducto(int ProductoId)
        {
            var Producto = await _uow.ProductoRepository.GetAsync(ProductoId);
            if (Producto != null)
            {
                _uow.ProductoRepository.Delete(Producto);
                await _uow.CommitAsync();
                return true;
            }
            return false;
        }

        public async Task<ProductoResponse> GetProductoById(int ProductoId)
        {
            var Producto = await _uow.ProductoRepository.GetAsync(ProductoId);
            var ProductoResponse = await mapProducto(Producto);
            return ProductoResponse;
        }

        public async Task<List<ProductoResponse>> GetProductoList()
        {
            List<ProductoResponse> ProductoResponses = new List<ProductoResponse>();
            var Productos = await _uow.ProductoRepository.GetAllAsync();
            foreach (var Producto in Productos)
            {
                ProductoResponses.Add(await mapProducto(Producto));
            }

            return ProductoResponses;
        }

        public async Task<ProductoResponse> UpdateProducto(int ProductoId, string nombre, double precio, int stockDisponible)
        {
            if (_uow.ProductoRepository.GetAsync(ProductoId) != null)
            {
                await _uow.ProductoRepository.UpdateAsync(new Producto
                {
                    ProductoId = ProductoId,
                    Nombre = nombre,
                    Precio = precio,
                    StockDisponible = stockDisponible
                }, ProductoId);
                await _uow.CommitAsync();

                var Producto = await _uow.ProductoRepository.GetAsync(ProductoId);
                return await mapProducto(Producto);
            }
            else {
                throw new ProductoNotFoundException();
            }
            
        }

        public async Task<ProductoResponse> mapProducto(Producto Producto) {
            //pedidos
            int ProductoIdDeseado = Producto.ProductoId;            
            return new ProductoResponse
            {
                ProductoId = Producto.ProductoId,
                Nombre = Producto.Nombre,
                Precio = Producto.Precio,
                StockDisponible = Producto.StockDisponible
            };
        }
    }
}