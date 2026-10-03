using Tienda;
using Moq;

namespace Tienda.Tests;

public class ProductoTests
{
    [Fact]
    public void CrearProductoGuardar()
    {
        
        var producto = new Producto(
            "Notebook",
            500000,
            "Electrónica");

        
        var nombre = producto.Nombre;
        var precio = producto.Precio;
        var categoria = producto.Categoria;

        
        Assert.Equal("Notebook", nombre);
        Assert.Equal(500000, precio);
        Assert.Equal("Electrónica", categoria);
    }

    [Fact]
    public void ActualizarPrecioExcepcion()
    {
        var producto = new Producto(
            "Notebook",
            500000,
            "Electrónica");
        Assert.Throws<ArgumentException>(
            () => producto.ActualizarPrecio(-1000));
    }
}

public class TiendaFixture
{
    public Tienda TiendaEjemplo { get; private set; }

    public TiendaFixture()
    {
        TiendaEjemplo = new Tienda();

        // Precargamos la tienda con productos de prueba antes de que corran los tests
        TiendaEjemplo.AgregarProducto(new Producto("Laptop", 1200000m, "Tecnología"));
        TiendaEjemplo.AgregarProducto(new Producto("Mouse", 15000m, "Accesorios"));
        TiendaEjemplo.AgregarProducto(new Producto("Teclado", 45000m, "Accesorios"));
    }
}

public class TiendaTests : IClassFixture<TiendaFixture>
{
    private readonly Tienda _tienda;

    public TiendaTests(TiendaFixture fixture)
    {
        _tienda = fixture.TiendaEjemplo;
    }

    [Fact]
    public void AgregarProducto_UsandoFixture()
    {
        int cantidadInicial = _tienda.Inventario.Count;
        var nuevoProducto = new Producto("Monitor", 250000m, "Tecnología");

        _tienda.AgregarProducto(nuevoProducto);

        Assert.Equal(cantidadInicial + 1, _tienda.Inventario.Count);
    }

    [Fact]
    public void BuscarProducto_ExistenteEnFixture()
    {
        var resultado = _tienda.BuscarProducto("Mouse");

        Assert.NotNull(resultado);
        Assert.Equal("Mouse", resultado.Nombre);
        Assert.Equal(15000m, resultado.Precio);
    }

    [Fact]
    public void BuscarProductoInexistente()
    {
        Assert.Throws<KeyNotFoundException>(
            () => _tienda.BuscarProducto("Manzana"));
    }

    [Fact]
    public void EliminarProducto_Inexistente()
    {
        Assert.Throws<KeyNotFoundException>(
            () => _tienda.EliminarProducto("Manzana"));
    }

    [Fact]
    public void AplicarDescuento_UsandoMock()
    {
        var tienda = new Tienda();

        // Creo un MOCK (doble de prueba u "objeto falso") de Producto.
        var mockProducto = new Mock<Producto>("Televisor", 1000m, "Electro");

        tienda.AgregarProducto(mockProducto.Object);

        tienda.AplicarDescuento("Televisor", 20m);

        // Como aplique 20% de descuento el nuevo precio deberia ser 800
        mockProducto.Verify(p => p.ActualizarPrecio(800m), Times.Once);
    }

    [Fact]
    public void CalcularTotalCarritoConDescuento()
    {
        //aplico 10% de descuento
        _tienda.AplicarDescuento("Laptop", 10m);

        var carrito = new List<string> {"Laptop", "Mouse"};
        decimal totalCalcu = _tienda.CalcularTotalCarrito(carrito);
        Assert.Equal(1095000m, totalCalcu);
    }
}
