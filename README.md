# Evaluación Técnica 2

Evalaución técnica para del curso Ingeniería de Software. 

## Descripcion del proyecto

Aplicación web que permita a los administradores agregar carreras y contenidos a las carreras para las ferias vocacionales que se darán a través del Campus Virtual UCR.

## Integrantes

Jorge Diaz Sagot - C12565

# Análisis y discusión

## Arquitecturas limpias 

Las recomendaciones de diseño para cumplir con la arquitectura limpia son las siguientes:

### 1. Identificar las entidades de dominio

El primer paso para implementar una arquitectura limpia es identificar las entidades de dominio del proyecto. 

En el caso de este proyecto las entidades que de identificaron son:

- Carrera
- Contenido

Esto también nos llevó a concluir que el tipo del sistema es transaccional.

### 2. Definir las capas de la arquitectura

Una vez identificadas las entidades de dominio y el sistema, se deben definir las capas de la arquitectura.

Primeramente, se decidió que la arquitectura sería de cuatro capas, que es uno de los modelos más comunes para sitios transaccionales. 

Tomaremos aquí en cuenta que se implementó desde el backend al frontend, por lo que se decidió una estructura compartida entre los dos sistemas. Dado a que por el scope del proyecto se consideró óptimo la reutalización de código de algunas capas.

Pero siguen habiendo capas que si son específicas de cada sistema, como la capa de presentación y la capa de infraestructura.

Para este proyecto se definen las siguientes capas:

- Capa de presentación
- Capa de aplicación (Compartido)
- Capa de dominio (Compartido)
- Capa de infraestructura

Lo cuales son las ideales en nuestra perspectiva para un sitio transaccional con información sobre carreras y contenidos.

Siendo también ideal si desearamos cambiar el datasource o el API de la capa de presentación si es necesario. 

### 3. Diseñar las interfaces entre capas

Para diseñar las interfaces entre capas se deben definir los contratos que permitan la comunicación entre las capas.

En este caso se definen las siguientes interfaces por capa:

- Capa de presentación
	- Usa los servicios de la capa de aplicación

- Capa de aplicación
	- ICarreraService
	- IContenidoService

- Capa de dominio
	- ICarreraRepository
	- IContenidoRepository

- Capa de infraestructura
	- Implementa las interfaces de la capa de dominio

Con esta estructura se logra una separación de responsabilidades y se facilita la implementación de pruebas unitarias, por componentes y por capas.

### 4. Implementar los componentes de cada capa

- Capa de presentación:
	- Backend			
		- Se usó un API llamado Swagger para la comunicación con el frontend. 
		- Este API se encarga de recibir las peticiones del frontend y enviarlas a la capa de aplicación por medio de HTTP.
    - Frontend
		- Se uso un Blazor, el cual provee la funcionalidad de utilizar **C#** con webassembly.

- Capa de aplicación:
	- Se implementaron los servicios de aplicación que se encargan de orquestar las operaciones de las entidades de dominio.
	- Específicamente se implementaron las interfaces de carrera y contenido.

- Capa de dominio:
	- Se implementaron las entidades de dominio Carrera y Contenido.
 	- Se implementaron los value objects de las entidades de dominio para validar las reglas de negocio.

- Capa de infraestructura:
	- Backend															
		- Implementa las interfaces de la capa de dominio, se encarga de realizar los accesos a la base de datos y de implementar la lógica de persistencia de las entidades de dominio.
		- Se utilizó Entity Framework Core para la persistencia de las entidades de dominio en una base de datos **SQL Server**. Por medio de **LINQ**, para mantener las guidelines de **C#** y **.NET8**.
	- Frontend
		- Implementa las interfaces de la capa de dominio, pero con la diferencia que se utilizó **Kiota** para su implementación, simulando ser una base de datos, que en realidad funciona de API para comunicarse con el endpoint de Swagger.


## SOLID

### Single Responsibility Principle

Se aplicó el principio de responsabilidad única en todas las clases del proyecto según la medida de lo posible.

Por ejemplo la clase [CarreraDtoMapper](Web\Infrastructure.ApiClient\Dtos\CarreraDtoMapper.cs) tiene la única responsabilidad de mapear una carrera a un DTO de carrera.

### Open/Closed Principle

Se aplicó el principio de abierto/cerrado en todas las clases del proyecto según la medida de lo posible.

Por ejemplo la clase [Carrera](Web\Domain\Entities\Carrera.cs) se aplicó el **Open/Closed** ya que tiene los atributos código, nombre y escuela, pero está abierta a la extensión, ya que se pueden agregar un nuevo atributo como una descripción.


### Liskov Substitution Principle

En este proyecto se decidió poner primero la composición por encima de la herencia, para evitar problemas de **Liskov Substitution**.

### Interface Segregation Principle

Se aplicó el principio de segregación de interfaces en todas las clases del proyecto según la medida de lo posible. Ya que todas las interfaces que se hicieron son mínimas y usadas solo una misma clase.

Por ejemplo la interfaz [IContenidoService](Web\Application\Services\IContenidoService.cs) tiene la única responsabilidad de tener los métodos de la clase ContenidoService.

### Dependency Inversion Principle

Se aplicó el principio de inversión de dependencias en todas las capas del proyecto según la medida de lo posible para evitar dependencias sin sentido.

Por ejemplo en la capa de presentación se inyectan los servicios de aplicación y infraestructura por medio de la interfaces.


[program.cs](Web\Presentation.Api\Program.cs)  de Presentation.api
```csharp
// Add services to the container.
builder.Services.AddApplicationLayerServices();
builder.Services.AddInfrastructureLayerServices(builder.Configuration);
```

Que llama a los métodos de extensión que inyectan las dependencias.

[InfrastructureLayerDependencyInjection](Web\Infrastructure\InfrastructureLayerDependencyInjection.cs)

---
### ¿Qué se logró entegrar y que nó?

Se logró entregar la versión funcional de las cuatro historias de usuario que se solicitaron en el planning del proyecto:

- Agregar carrerera
- Buscar carrera por nombre
- Listar contenidos de una carrera
- Agregar contenidos a una carrera
- Buscar una carrera por nombre
- CRL de contenidos de una carrera 
- Mostrar información de una carrera con su presupuesto de becas
- Mostrar información de una carrera con sus contenidos

No se logró
- Delete de contenidos
- Actualización de contenidos
- Llegar al coverage deseado, en las capas de Infrastructure en Fronend.
- Indicio de testeo en las capas de Presentation de Frontend y Backend.

### Desafios
Presenté problemas con el tiempo que debo dedicarle a otros cursos. Dado que aunque las historias son relizables, el testeo y buenas prácticas del software requieren que el tiempo que se aplique para cada cosa se multiplique bastante. Las historias que se completaron están al 100%, y las que no al 0% segun mis criterios de aceptación. 
 
