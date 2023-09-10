# TechnicalTestTask

Sistema de Gestión de Tareas

Este proyecto consiste en una prueba técnica, la cual está estructurada de la siguiente forma:

<ul>
  <li>DB - Objetos creados en base de datos (Oracle)</li>
  <li>TaskClient - Cliente desarrollado en AngularJS (versión 16) y PrimeNG (versión 16).</li>
  <li>TaskAPI - API Desarrollada con NetCore 6</li>
</ul>

Se desarrolla este proyecto teniendo en cuenta las versiones más actuales y estables de las tecnologías anteriormente mencionadas. Se tienen en cuenta patrones de desarrollo y código limpio para que sea escalable en el futuro. Además, se realiza el proyecto en inglés para una mejor comprensión.

### Desarrollo de la prueba

Para que la aplicación funcione correctamente, es necesario tener en cuenta los siguientes pasos:

Obtener el repositorio <link> https://github.com/Katlan9808/TechnicalTestTask.git


### Base de datos
Ejecutar los scripts con un usuario que tenga los privilegios 'sysdba':
<ul>
  <li>1.users.sql</li>
  <li>2.objects.sql</li>
</ul>

En estos scripts se encuentra la forma de crear el esquema y los objetos de base de datos que se necesitarán.

### TaskClient
En este proyecto se encuentra la estructura del cliente, que se desarrolló en AngularJS. Se integró el framework <strong>PrimeNG</strong><br>
En la ruta de la carpeta <strong>\TaskClient</strong> ejecutar <code>npm install</code>, para obtener todos los paquetes requeridos para que el cliente funcione. En el cliente, se pueden realizar las operaciones CRUD y los demás puntos solicitados.

Para el consumo de la API desde el cliente se, utiliza `HttpClient`, ya que con este objeto se realizan solicitudes HTTP y se maneja la respuesta del servidor. El servicio HttpClient tiene la responsabilidad de implementar otras funcionalidades como interceptores y encabezados.

### TaskAPI
En este proyecto se encuentra el backend de la aplicación, desarrollado implementando la arquitectura hexagonal. Esta arquitectura nos expone una aplicación totalmente independiente que puede ser usada de la misma forma por usuarios, programas, pruebas automatizadas o scripts, y puede ser desarrollada y probada de forma aislada de sus eventuales dispositivos y bases de datos en tiempo de ejecución.

Se integra el ORM (Object Relational Mapping) Entity Framework, el cual nos ayuda a mapear las entidades de la base de datos en nuestra API.

El archivo encargado de realizar este proceso se encuentra en la capa <strong>Task.Domain/Bat</strong>
<code>TaskContext.bat</code>

Ejecutar la aplicación para que el cliente pueda recibir las peticiones. En la API, se evidencia la estructura completa de la Arquitectura Hexagonal, con un proyecto adicional de xUnit, el cual se creó para realizar las pruebas unitarias.







