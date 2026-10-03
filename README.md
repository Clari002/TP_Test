
# TRABAJO PRACTICO 1 
Tema: Pruebas del software (uso de un framework de testing)

Integrantes:
* Díaz Claribel Mariela
* Batallan Máximo

Lenguaje: C# 
Framework: xUnit
Librería de Mocks: Moq (instalar comando: "dotnet add package Moq" parados dentro de la carpeta del proyecto de pruebas: cd test/Tienda.Tests)

## Instrucciones para correr los test
* Ejecutar todas las pruebas
dotnet test

* Ejecutar las pruebas filtrado por actividad
Actividad 1 y 2 (Pruebas unitarias básicas y excepciones de Producto): 
dotnet test --filter 'FullyQualifiedName~ProductoTests'

Actividad 1,2,3,4 y 5 (Pruebas de Tienda, Fixtures, Mocks e Integración):
dotnet test --filter  'FullyQualifiedName~TiendaTests'

Actividad 3 (Prueba con Mocks - Moq):
dotnet test --filter 'FullyQualifiedName~AplicarDescuento_UsandoMock'

Actividad 4 (Prueba con Fixtures - IClassFixture):
dotnet test --filter 'FullyQualifiedName~BuscarProducto_ExistenteEnFixture'

Actividad 5 (Prueba de Integración y carrito de compras): 
dotnet test --filter 'FullyQualifiedName~CalcularTotalCarrito'

## Respuesta conceptuales 
#### 1. ¿Puedes identificar pruebas de unidad y de integración en la práctica que se realizó?
Sí, se pueden identificar pruebas de unidad en por ejemplo, la creación de un objeto Producto, la incorporación de un producto al inventario, la búsqueda de un producto y su eliminación. 
También se identifica una prueba de integración cuando para probar un objeto Producto, se lo agrega a una Tienda y posteriormente se utiliza otro método de la tienda sobre ese producto. 

#### 2. ¿Podría haber escrito las pruebas primero antes de modificar el código de la aplicación? ¿Cómo sería el proceso de escribir primero los test?
Si, podria haber escrito las pruebas primero. El proceso sería primero pasar qué comportamiento debería tener el programa y escribir un test que 
compruebe ese comportamiento. Al ejecutarlo, el test fallaría porque todavía no está implementada ese funcionalidad. Después se modifica el código para que cumpla con lo que pide la prueba y se vuelve a ejecutar el test hasta que pase correctamente. 

#### 3. ¿Qué es un “test double”?
Un Test Double es un objeto "falso" o "simulado" que reemplaza a la clase real, en este caso "Producto" para probar únicamente la lógica de la clase que nos interesa (Tienda) en total aislamiento.
Es decir, a la clase Tienda no le importa cómo Producto cambia su precio internamente ni si lo guarda bien o mal. A Tienda solo le corresponde la responsabilidad de calcular bien la matemática del descuento y enviarle el nuevo valor al producto llamando a su método ActualizarPrecio. El Mock te permite comprobar exclusivamente que Tienda cumplió su contrato sin depender del código de Producto.

#### ¿Hay otros nombres para los objetos/funciones simulados?
El término general es Test Double (Doble de prueba). Los otros nombres o variaciones según su nivel de simulación son: Dummy, Stub, Spy, Mock y Fake.

#### ¿ En lo que va del trabajo práctico, ¿puedes identificar 'Controladores' y 'Resguardos'?
Controlador: Es el propio marco de pruebas (xUnit) y los métodos etiquetados con [Fact]. Ellos son los que "controlan" la ejecución, preparan el escenario y lanzan las llamadas para evaluar el sistema.   

Resguardo: Es el objeto Mock<Producto> que utilizamos. Sirve como resguardo simulado para devolver datos prefijados y responder a las llamadas de Tienda sin necesidad de instanciar o depender de la lógica real de Producto. 

#### 4. Defina usando palabras propias y según la práctica realizada qué es un fixture. ¿Qué ventajas ve en el uso de fixtures?
Un Fixture es una clase auxiliar que se encarga de preparar los datos de prueba antes de que se ejecuten los tests. Por ejemplo, antes de implementar el fixture en el tp, en casi todos los métodos se escribía "var tienda = new Tienda();" y se creaban productos a mano con "new Producto("Mouse", 15000, "Accesorios")" duplicando el código.
Entonces, una clara ventaja del fixture es la reutilización de código, ya que evitamos escribir la instanciación de objetos en cada test.
Otra ventaja es la Mantenibilidad, si las clases principales cambian su estructura o constructor, solo se actualiza el fixture y no cada uno de los métodos de prueba.

#### ¿Qué enfoque de diseño de pruebas estaríamos aplicando (caja negra/blanca)?
Estaríamos aplicando un enfoque de Caja Blanca, ya que conocemos la estructura interna del sistema, las propiedades de las clases "Tienda" y "Producto", y cómo interactúan las listas de inventario entre sí para configurar explícitamente los datos de entrada del Fixture.

#### Explique los conceptos de Setup y Teardown en testing.
Setup (Configuración): Es el proceso o bloque de código que se ejecuta antes de correr las pruebas para preparar las precondiciones, crear objetos en memoria, abrir conexiones o poblar datos (lo que hace el constructor de TiendaFixture).   

Teardown (Limpieza): Es el proceso que se ejecuta después de terminar las pruebas para liberar recursos, eliminar archivos temporales o resetear el estado de la aplicación (en C#/xUnit esto se logra implementando la interfaz IDisposable en la clase del Fixture).

#### 5. ¿Realizó una prueba de cobertura completa? ¿Qué tipo de cobertura utilizó?
Si se utilizaron la cobertura de sentencias y la cobertura de decisión/ramas.
La cobertura de sentencias garantiza que cada línea de código dentro de los métodos CalcularTotalCarrito y BuscarProducto sea ejecutada al menos una vez. La cobertura de ramas evalúa que cada condición lógica (por ejemplo, cuando un producto del carrito existe y cuando no se encuentra o el carrito está vacío) sea probado tanto para el caso verdadero como para el falso. Al probar el flujo normal del carrito con descuentos junto con las pruebas de excepciones previas, se cubren todas las ramas y líneas de la aplicación.
#### ¿Puede describir una situación de desarrollo para este caso en donde se plantee pruebas de integración ascendente? Describa la situación.
1. Se desarrolla y prueba de forma aislada la clase Producto, validando su creación y la actualización de precios.
2. Una vez que Producto funciona correctamente, se construye la clase Tienda y se prueban las operaciones de inventario (AgregarProducto, BuscarProducto, EliminarProducto) utilizando instancias reales de Producto.
3. Se integra la lógica de negocios del carrito de compras (ClacularTotalCarrito), probando la interacción combinada entre Tienda, Producto y los descuentos.