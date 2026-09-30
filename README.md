
# TRABAJO PRACTICO 1 
Tema: Pruebas del software (uso de un framework de testing)

Integrantes:
Díaz Claribel Mariela;
Batallan Máximo

Lenguaje: C#
Framework: xUnit

1. ¿Puedes identificar pruebas de unidad y de integración en la práctica que se realizó?
Sí, se pueden identificar pruebas de unidad en por ejemplo, la creación de un objeto Producto, la incorporación de un producto al inventario, la búsqueda de un producto y su eliminación. 
También se identifica una prueba de integración cuando para probar un objeto Producto, se lo agrega a una Tienda y posteriormente se utiliza otro método de la tienda sobre ese producto. 

2. ¿Podría haber escrito las pruebas primero antes
de modificar el código de la aplicación?
¿Cómo sería el proceso de escribir primero los test?
Si, podria haber escrito las pruebas primero. El proceso sería primero pasar qué comportamiento debería tener el programa y escribir un test que 
compruebe ese comportamiento. Al ejecutarlo, el test fallaría porque todavía no está implementada ese funcionalidad. Después se modifica el código para que cumpla con lo que pide la prueba y se vuelve a ejecutar el test hasta que pase correctamente. 
