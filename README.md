# PRUEBA DE CONOCIMIENTO VIAJEMOS

La siguiente prueba se encuentra desarrollada en una arquitectura orientada a microservicios con un frontend hecho 
en ASP MVC net core y los microservicios en net core 3.1

Existe un microservicio encargado de la parte de administración de los respectivos dominios de la aplicación (autor, libros y editorial)

Existe aparte un apigateway con ocelot que se encarga de gestionar las peticiones al microservicio y por ahora no maneja algún tipo de seguridad


Para poner en funcionamiento la respectiva prueba, es necesario seguir los siguientes pasos:
 * Abrir la solución en visual studio 2019.
 * Ir al proyecto Viajemos.Test.Books.API
 * Ir a la sección de appsettings.json
 * dentro del archivo .json ubicar la llave "connectionStrings"
 * dentro de esa llave modificar el valor de la llave "conn" con los datos de la cadena de conexión del servidor donde se va a correr la bd. (actualizar las llaves de server, user y password)
 * Ir a la sección de herramientas
 * Seleccionar la opción administrador de paquetes Nuget
 * Seleccionar consola del administrador de paquetes
 * una vez se abra la pestaña dentro de visual studio validar que en la pestaña este las palabras PM>
 * escribir en la consola el comnado Update-Database -Verbosa.
 * esperar a que la consola compile la solución y ejecute la migración.
 * por último arraca el proyecto en iniciar, ya que esta configurado para que arranque todos los proyectos a la vez.
 
 
 Muchas gracias por la oportunidad. Muchos exitos.
 
 Edwin Borda
 cel: +57 3202660453
