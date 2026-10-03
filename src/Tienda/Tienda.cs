namespace Tienda;

public class Tienda
{
    private readonly List<Producto> inventario = new();

    public IReadOnlyList<Producto> Inventario => inventario;

    public void AgregarProducto(Producto producto)
    {
        inventario.Add(producto);
    }

    public Producto BuscarProducto(string nombre)
    {
        var producto = inventario.FirstOrDefault(p =>
            p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

        if (producto == null)
        {
            throw new KeyNotFoundException(
                $"No se encontró el producto '{nombre}'.");
        }

        return producto;
    }

    public void EliminarProducto(string nombre)
    {
        var producto = BuscarProducto(nombre);
        inventario.Remove(producto);
    }

    public void AplicarDescuento(string nombre, decimal porcentajeDescuento)
    {
        var producto = BuscarProducto(nombre);
        
        decimal nuevoPrecio = producto.Precio * (1 - (porcentajeDescuento / 100m));
        
        producto.ActualizarPrecio(nuevoPrecio);
    }

    public decimal CalcularTotalCarrito(List<string> nombresProductos)
    {
        if (nombresProductos == null)
        {
            throw new ArgumentException(nameof(nombresProductos));
    
        }
        decimal total = 0m;
        foreach (var nombre in nombresProductos)
        {
            var producto = BuscarProducto(nombre);
            total = total + producto.Precio;
        }
        return total;
    }
}