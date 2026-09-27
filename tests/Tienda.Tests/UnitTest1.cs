using Tienda;

namespace Tienda.Tests;

public class ProductoTests
{
    [Fact]
    public void CrearProductoGuardar()
    {
        
        var producto = new Producto(
            "Notebook",
            500000m,
            "Electrónica");

        
        var nombre = producto.Nombre;
        var precio = producto.Precio;
        var categoria = producto.Categoria;

        
        Assert.Equal("Notebook", nombre);
        Assert.Equal(500000m, precio);
        Assert.Equal("Electrónica", categoria);
    }
}

public class TiendaTests
{
    [Fact]
    public void AgregarProductoAlInventario()
    {
     
        var tienda = new Tienda();
        var producto = new Producto(
            "Mouse",
            15000m,
            "Accesorios");

    
        tienda.AgregarProducto(producto);


        Assert.Single(tienda.Inventario);
        Assert.Equal(producto, tienda.Inventario[0]);
    }

    [Fact]
public void BuscarProductoNombre()
{
    var tienda = new Tienda();
    var producto = new Producto(
        "Mouse",
        15000m,
        "Accesorios");

    tienda.AgregarProducto(producto);

    var resultado = tienda.BuscarProducto("Mouse");

    Assert.Equal(producto, resultado);
}

[Fact]
public void BuscarProductoInexistente()
{
    var tienda = new Tienda();

    Assert.Throws<KeyNotFoundException>(
        () => tienda.BuscarProducto("Manzana"));
}
[Fact]
public void EliminarProductoDelInventario()
{
  
    var tienda = new Tienda();

    var producto = new Producto(
        "Mouse",
        15000m,
        "Accesorios");

    tienda.AgregarProducto(producto);


    tienda.EliminarProducto("Mouse");

    
    Assert.Empty(tienda.Inventario);
}
}

