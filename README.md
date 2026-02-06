# WebApp: Aplicación de Punto de Venta

## Descripción General

**WebApp** es una aplicación web completa diseñada como un sistema de punto de venta (POS). Permite gestionar clientes, productos, inventario y ventas de manera eficiente. La aplicación está construida con una arquitectura moderna que separa el frontend del backend, utilizando tecnologías de última generación para garantizar un rendimiento óptimo y una excelente experiencia de usuario.

El proyecto está configurado para un despliegue sencillo y escalable mediante contenedores Docker, facilitando su implementación en cualquier entorno.

## Arquitectura y Diseño

La solución sigue los principios de la **Arquitectura Limpia (Clean Architecture)**, dividiendo las responsabilidades en capas bien definidas para promover un código desacoplado, mantenible y fácil de probar.

- **`WebApp.Domain`**: Contiene las entidades del negocio (Cliente, Producto, Venta, etc.), las interfaces de los repositorios y la lógica de dominio principal. Es el núcleo de la aplicación y no depende de ninguna otra capa.
- **`WebApp.Application`**: Implementa la lógica de la aplicación y los casos de uso. Utiliza el patrón **CQRS (Command Query Responsibility Segregation)** con la ayuda de **MediatR** para separar las operaciones de escritura (Comandos) de las de lectura (Consultas).
- **`WebApp.Infrastructure`**: Proporciona la implementación de las interfaces definidas en la capa de Dominio, como los repositorios (usando **Entity Framework Core**) y otros servicios de infraestructura. Se encarga de la persistencia de datos y la comunicación con sistemas externos.
- **`WebApp.Server`**: Es el punto de entrada de la aplicación. Expone una **API REST** construida con **ASP.NET Core 9.0** y sirve los archivos estáticos del frontend de **Angular**.
- **`webapp.client`**: Es la aplicación de frontend, una **Single Page Application (SPA)** desarrollada con **Angular 20**. Se comunica con el backend a través de la API REST.

### Uso de DSR.Architecture

El proyecto integra las librerías de **DSR.Architecture**, un conjunto de paquetes NuGet diseñados para acelerar el desarrollo de aplicaciones .NET siguiendo patrones de diseño robustos.

- **`Dsr.Architecture.Application`**: Proporciona clases base y utilidades para la capa de aplicación, facilitando la implementación de casos de uso y la gestión de excepciones.
- **`Dsr.Architecture.Domain`**: Ofrece entidades y interfaces base que ayudan a definir el modelo de dominio de manera consistente.
- **`Dsr.Architecture.Infrastructure.Persistence`**: Contiene implementaciones genéricas para repositorios y el patrón **Unit of Work**, simplificando el acceso a datos.
- **`Dsr.Architecture.Infrastructure.Persistence.EntityFramework`**: Proporciona una implementación específica para Entity Framework Core, agilizando la configuración del DbContext y los repositorios.
- **`Dsr.Architecture.TryCatch`**: Una utilidad para el manejo de excepciones centralizado, que permite encapsular la lógica de `try-catch` de forma limpia y reutilizable en los controladores.

## Tecnologías Principales

### Backend

- **ASP.NET Core 9.0**: Framework para construir la API REST.
- **Entity Framework Core**: ORM para la interacción con la base de datos SQLite.
- **MediatR**: Para la implementación del patrón CQRS.
- **Swagger/OpenAPI**: Para la documentación y prueba de la API.
- **DSR.Architecture**: Librerías para acelerar el desarrollo y aplicar patrones de diseño.

### Frontend

- **Angular 20**: Framework para construir la SPA.
- **TypeScript**: Lenguaje principal para el desarrollo en Angular.
- **Vite**: Herramienta de construcción y servidor de desarrollo rápido.
- **Bootstrap**: Para el diseño y los componentes de la interfaz de usuario.

### Despliegue

- **Docker**: Para la contenerización de la aplicación.
- **Docker Compose**: Para orquestar la ejecución de la aplicación en un entorno de desarrollo.

## Estructura del Proyecto

```
├── WebApp.Domain/           # Lógica y entidades del negocio
├── WebApp.Application/      # Casos de uso y lógica de la aplicación (CQRS)
├── WebApp.Infrastructure/   # Repositorios, DbContext y servicios de infraestructura
├── WebApp.Server/           # API REST de ASP.NET Core y hosting del frontend
├── webapp.client/           # Proyecto de Angular (frontend)
└── docker-compose.yml       # Orquestación de contenedores
```

## Cómo Empezar

### Prerrequisitos

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Node.js y npm](https://nodejs.org/)
- [Docker](https://www.docker.com/products/docker-desktop)

### Ejecución en Desarrollo

1. **Clonar el repositorio:**

    ```bash
    git clone <URL_DEL_REPOSITORIO>
    cd DsrWebApp
    ```

2. **Restaurar dependencias del backend:**

    ```bash
    dotnet restore
    ```

3. **Instalar dependencias del frontend:**

    ```bash
    npm install --prefix webapp.client
    ```

4. **Ejecutar la aplicación:**

    ```bash
    dotnet run --project WebApp.Server/WebApp.Server.csproj
    ```

    La aplicación estará disponible en `https://localhost:53800`.

### Ejecución con Docker

1. **Construir la imagen de Docker:**

    ```bash
    docker-compose build
    ```

2. **Ejecutar el contenedor:**

    ```bash
    docker-compose up
    ```

    La aplicación estará disponible en `http://localhost:8080`.

## Contribuciones

Las contribuciones son bienvenidas. Por favor, abre un issue o un pull request para sugerencias, mejoras o reportar problemas.

## Licencia

Este proyecto está bajo la licencia MIT.
