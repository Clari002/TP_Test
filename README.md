
# TRABAJO PRACTICO 1 
Tema: Pruebas del software (uso de un framework de testing)

Integrantes:
Díaz Claribel Mariela;
Batallan Máximo

Lenguaje: C#
Framework: xUnit

##### 1. ¿Puedes identificar pruebas de unidad y de integración en la práctica que se realizó?
Sí, se pueden identificar pruebas de unidad en por ejemplo, la creación de un objeto Producto, la incorporación de un producto al inventario, la búsqueda de un producto y su eliminación. 
También se identifica una prueba de integración cuando para probar un objeto Producto, se lo agrega a una Tienda y posteriormente se utiliza otro método de la tienda sobre ese producto. 

##### 2. ¿Podría haber escrito las pruebas primero antes de modificar el código de la aplicación? ¿Cómo sería el proceso de escribir primero los test?
Si, podria haber escrito las pruebas primero. El proceso sería primero pasar qué comportamiento debería tener el programa y escribir un test que 
compruebe ese comportamiento. Al ejecutarlo, el test fallaría porque todavía no está implementada ese funcionalidad. Después se modifica el código para que cumpla con lo que pide la prueba y se vuelve a ejecutar el test hasta que pase correctamente. 

##### 3. ¿Qué es un “test double”?
Un Test Double es un objeto "falso" o "simulado" que reemplaza a la clase real, en este caso "Producto" para probar únicamente la lógica de la clase que nos interesa (Tienda) en total aislamiento.
Es decir, a la clase Tienda no le importa cómo Producto cambia su precio internamente ni si lo guarda bien o mal. A Tienda solo le corresponde la responsabilidad de calcular bien la matemática del descuento y enviarle el nuevo valor al producto llamando a su método ActualizarPrecio. El Mock te permite comprobar exclusivamente que Tienda cumplió su contrato sin depender del código de Producto.

##### ¿Hay otros nombres para los objetos/funciones simulados?
El término general es Test Double (Doble de prueba). Los otros nombres o variaciones según su nivel de simulación son: Dummy, Stub, Spy, Mock y Fake.

##### ¿ En lo que va del trabajo práctico, ¿puedes identificar 'Controladores' y 'Resguardos'?
Controlador: Es el propio marco de pruebas (xUnit) y los métodos etiquetados con [Fact]. Ellos son los que "controlan" la ejecución, preparan el escenario y lanzan las llamadas para evaluar el sistema.   

Resguardo: Es el objeto Mock<Producto> que utilizamos. Sirve como resguardo simulado para devolver datos prefijados y responder a las llamadas de Tienda sin necesidad de instanciar o depender de la lógica real de Producto. 