# Prueba técnica: Implementación realizada

## _Hitos del Desarrollo y Mejoras Implementadas_

1. Implementación del código faltante para el funcionamiento del CRUD de clientes.  
2. Incorporación de mejoras solicitadas en el CRUD de clientes.  
3. Aplicación de buenas prácticas en la nomenclatura durante el refactor.  
4. Desarrollo del CRUD de productos basado en la lógica del CRUD de clientes.  
5. Creación del controlador **HealthCheck** con su correspondiente endpoint.  
6. Creación de un proyecto de **Unit Testing** para probar las funciones CRUD.


## _Mejoras en la Estructura del Código_

La reorganización del proyecto ha dado lugar a una estructura más clara y mantenible:

1. **API**:  
   - Centralización de los controladores para gestionar los endpoints de manera eficiente.  
   - Se han añadido nuevos controladores:  
     - **ProductController**: Maneja todas las operaciones CRUD relacionadas con productos.  
     - **HealthCheckController**: Proporciona un endpoint para monitorear el estado de la aplicación, facilitando la supervisión y la disponibilidad del sistema.

2. **Models**:  
   - Anteriormente, las entidades estaban separadas en dos proyectos: **Entities** (entidades del dominio) y **DTOs** (objetos de transferencia de datos). Ahora, ambos se han unificado bajo **Models**, simplificando la estructura y mejorando la cohesión.  

3. **Data**:  
   - Gestión centralizada de la persistencia mediante repositorios y contexto de base de datos, facilitando el acceso y la administración de datos.  

4. **Services**:  
   - La lógica de negocio se ha desacoplado de los controladores, lo que mejora la reutilización del código y la capacidad de realizar pruebas unitarias.

Esta nueva estructura modular facilita el mantenimiento, mejora la claridad y permite escalar el proyecto de manera más eficiente.

## _Principios SOLID Aplicados_

1. **SRP (Single Responsibility Principle)**:  
   - Cada clase tiene una única responsabilidad, lo que facilita su mantenimiento y comprensión.  
   - **Ejemplo**: La clase **ClientServiceTests** se encarga exclusivamente de las pruebas del servicio de clientes, sin mezclar lógica adicional.

2. **OCP (Open/Closed Principle)**:  
   - El código está diseñado para ser abierto a extensiones, pero cerrado a modificaciones, evitando cambios innecesarios en el código existente.  
   - **Ejemplo**: Se pueden agregar nuevas implementaciones de **IClientService** sin modificar las clases ya existentes.

3. **LSP (Liskov Substitution Principle)**:  
   - Las clases derivadas pueden sustituir a sus clases base sin alterar el comportamiento del programa.  
   - **Ejemplo**: **Mock<IClientRepository>** puede ser utilizado en lugar de **IClientRepository** en las pruebas, manteniendo la funcionalidad intacta.

4. **ISP (Interface Segregation Principle)**:  
   - Las interfaces son específicas, evitando que las clases implementen métodos que no necesitan.  
   - **Ejemplo**: **IClientRepository** solo contiene métodos relacionados con la gestión de clientes, garantizando interfaces limpias y concisas.

5. **DIP (Dependency Inversion Principle)**:  
   - El código depende de abstracciones, no de implementaciones concretas, lo que facilita el desacoplamiento y la prueba unitaria.  
   - **Ejemplo**: Las interfaces como **IClientRepository** se inyectan en lugar de instanciar clases concretas, promoviendo la flexibilidad y la modularidad.

## _Mejoras Técnicas Planificadas_

1. **Actualización a .NET 9**: Se planea migrar el proyecto a la última versión del framework para mejorar el rendimiento y la compatibilidad con nuevas funcionalidades.  
2. **Actualización de Librerías**: Se actualizarán todas las dependencias a sus versiones más recientes para garantizar estabilidad y acceso a mejoras y correcciones de errores.  
3. **Revisión de Deprecaciones**: Se llevará a cabo una revisión exhaustiva para asegurar que no se utilicen métodos o librerías obsoletas, garantizando la sostenibilidad del proyecto a largo plazo.  
4. **Implementación de Autenticación y Autorización**: Se integrará un sistema robusto de autenticación y autorización utilizando OAuth para gestionar de manera segura el acceso y los permisos dentro de la aplicación.
5. **Programación Asíncrona**: Se refactorizará el código para adoptar programación asíncrona, incrementando la eficiencia y la capacidad de respuesta de la aplicación.

# Prueba técnica para Backend


Disponemos del esqueleto de una API con una arquitectura por capas con un CRUD (casi) funcional.
Lee el siguiente enunciado, y a continuación, los resultados que esperamos encontrar una vez entregada esta prueba técnica.
La API incluye un Swagger que mapea los controllers y sus EndPoints, puedes realizar las pruebas del CRUD desde el propio Swagger, pero siéntete libre de hacerlo desde Postman o cualquier otro entorno en el que te encuentres cómodo.

## _Enunciado_

Pero... ¡Un Junior nos ha borrado una pequeña parte del código por error! Por suerte hemos podido encontrar dónde se ubicaba este código, y hemos dejado algunos comentarios con TODOs por el código para que nos lo puedas rellenar y volver a hacer funcionar.

Por lo que hemos podido apreciar, se ha estropeado la inyección de dependencias del DL, algunos métodos del AppService (BL), otras pocas líneas del Repository (DL), entre otras cositas...
Si abres el "Task List" de VisualStudio o buscas por TODO en toda la solución, podrás encontrar todas las cosas a corregir.

La serialización de datos de un cliente, se vería reflejada tal que así:
```sh
{
	"id" : 12345,
	"docType" : "nif",
	"docNum" : "11223344E",
	"email" : "eromani@sample.com",
	"givenName" : "Enriqueta",
	"familyName1" : "Romani",
	"phone" : "668668668"
}
```

Si puedes dejar el CRUD funcionando (tal y como estaba antes del pequeño incidente...), ya nos habrás ayudado bastante!

Una vez te funcione el CRUD, estaría bien que pudieses implementar las siguientes mejoras al CRUD de clientes:
1. Comprobar que no se repita el DocNum con ningún otro usuario cuando se inserta (además del Id).
2. Validar que DocNum cumple el formato de NIF (8 dígitos y 1 letra) con un regex cuando el DocType es "nif". (Solo cuando es NIF, ignorar formato de NIE, CIF, etc.)
3. Implementar inversión de dependencias en la inyección del Repository en el AppService.
4. Refactorizar los nombres de las variables de ClientAppService. (El Junior estaba inspirado el día que creó esta clase...)

Necesitaríamos, que una vez tengas funcionando este CRUD, nos hagas uno exactamente igual para la entidad de Producto.
La serialización de datos de un producto, se vería reflejada tal que así:
```sh
{
	"id" : 1111111,
	"productName" : "Cristal ventanilla delantera",
	"productType" : 25,
	"numTerminal" : 933933933,
	"soldAt" : "2019-01-09 14:26:17"
}
```

Con que crees las validaciones para Id y ProductName, es más que suficiente.

Además, nos gustaría poder disponer de un controller llamado "HealthCheck", que tenga un EndPoint accesible con método Get cuyo nombre sea "KeepAlive", que simplemente devolverá un 200 OK, donde tendremos un servicio (que no debes implementar) que irá consultando que la API esté levantada en todo momento.

## _Resultados a evaluar_
1. Has podido intuir y rellenar el código que faltaba para que funcionase el CRUD de clientes.
2. Has podido implementar las mejoras (o algunas de ellas) solicitadas en el CRUD de clientes.
3. Has utilizado un buen naming convention en el refactor de ClientAppService.
4. Has podido implementar el CRUD de productos, basándote en el de clientes.
5. Has podido crear el controller de HealthCheck, con el EndPoint correspondiente.

## _Puntos extra_
1. Crear proyecto de Unit Testing donde pruebes las funciones CRUD.
2. Conseguir inyección de dependencias de validadores de forma genérica. (Parecido a la inyección de AppServices del Module de BL)
3. Coméntanos si has encontrado código mejorable en la prueba. (No cumple naming convention, se incumple algún principio SOLID, hay algo mal estructurado, etc.)