# Proyecto Control Logístico (Clean Architecture)

Resumen
-------
Proyecto de ejemplo/producción para la gestión y control logístico, implementado siguiendo principios de Clean Architecture sobre .NET 10 y Razor Pages. Está diseñado para separar responsabilidades en capas (Aplicación, Dominio, Infraestructura, UI) y facilitar mantenimiento, pruebas y escalabilidad.

Características principales
-------------------------
- Aplicación web con Razor Pages (ASP.NET Core, .NET 10)
- Arquitectura limpia (Clean Architecture)
- Separación en capas: UI (Razor Pages), Aplicación, Dominio, Infraestructura
- Soporte para migraciones y persistencia en base de datos (configurable)
- Tests y estructura preparada para pruebas unitarias/integración

Requisitos
---------
- .NET 10 SDK
- Visual Studio 2022/2024/2026 o VS Code
- (Opcional) SQL Server / PostgreSQL u otra base de datos soportada
- (Opcional) Docker si se desea contenerizar

Instalación y ejecución local
----------------------------
1. Clonar el repositorio:

   git clone https://github.com/dalza1601/Proyecto_Control_Logistico.git
   cd Proyecto_Control_Logistico_Clean_Architecture

2. Restaurar paquetes y compilar:

   dotnet restore
   dotnet build

3. Configurar la cadena de conexión:

   - Abrir appsettings.json (o appsettings.Development.json) en el proyecto Web/UI.
   - Configurar la clave `ConnectionStrings:DefaultConnection` apuntando a su base de datos.

4. Aplicar migraciones (si el proyecto incluye Entity Framework Core):

   dotnet ef database update --project src/Infrastructure --startup-project src/Web

   Nota: ajustar rutas de proyecto según la estructura real.

5. Ejecutar la aplicación:

   dotnet run --project src/Web

   O abrir la solución en Visual Studio y ejecutar la configuración de inicio.

Estructura recomendada (ejemplo)
--------------------------------
- src/
  - Web/            -> Proyecto Razor Pages (UI)
  - Application/    -> Casos de uso, DTOs, interfaces de servicios
  - Domain/         -> Entidades, servicios de dominio, reglas
  - Infrastructure/ -> Implementaciones de persistencia, EF Core, servicios externos
  - Tests/          -> Proyectos de pruebas unitarias e integración

Buenas prácticas
----------------
- Mantener las reglas de negocio en la capa Domain.
- Exponer sólo interfaces desde Application; implementar en Infrastructure.
- Usar inyección de dependencias configurada en Web/Program.cs.
- Mantener Razor Pages ligeras; lógica en Application/Servicios.

Despliegue
---------
- Publicar con dotnet publish:

  dotnet publish -c Release -o ./publish --project src/Web

- (Opcional) Construir imagen Docker con un Dockerfile en el proyecto Web y desplegar en su plataforma preferida.

Pruebas
------
- Ejecutar pruebas con:

  dotnet test

Contribución
------------
1. Crear un fork del repositorio.
2. Crear una branch feature/desc para cambios.
3. Abrir un pull request describiendo los cambios.

Licencia
--------
Incluir licencia del proyecto (por ejemplo MIT) en el fichero LICENSE si procede.

Contacto
--------
Repositorio original: https://github.com/dalza1601/Proyecto_Control_Logistico

Notas finales
-------------
Este README es una plantilla inicial. Actualizar las secciones de instalación, migraciones y estructura para reflejar las rutas y herramientas específicas del repositorio si difieren de lo aquí descrito.