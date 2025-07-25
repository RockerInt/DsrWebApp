# WebApp

## Descripción General

**WebApp** es una aplicación web moderna construida con una arquitectura de frontend Angular 20 y backend ASP.NET Core 9.0. El proyecto está preparado para despliegue en contenedores Docker, facilitando su ejecución en entornos locales, de desarrollo y producción. La solución sigue buenas prácticas de separación de responsabilidades, integración continua y despliegue automatizado.

Está diseñada para funcionar como base para applicaciones web .NET Core con Angular con las ultimas versiones de estos Frameworks.

---

## Arquitectura

- **Frontend:**  
  - Framework: [Angular 20](https://angular.dev/)
  - Construcción: Standalone components, zoneless, Vite, HttpClient moderno
  - Ubicación: `/webapp.client`
  - Build automatizado desde el backend (.csproj)

- **Backend:**  
  - Framework: [ASP.NET Core 9.0](https://learn.microsoft.com/aspnet/core/)
  - API REST y servidor de archivos estáticos (Angular build)
  - Ubicación: `/WebApp.Server`
  - Integración con OpenAPI (Swagger) y SpaProxy para desarrollo

- **Contenedores:**  
  - Docker multi-stage build para imágenes ligeras y seguras
  - Node.js y Angular CLI solo en la etapa de build
  - Publicación en `/app/publish` para producción

---

## Tecnologías Principales

- **Angular 20**: Frontend SPA, zoneless, HttpClient moderno, Vite
- **ASP.NET Core 9.0**: Backend API, hosting de archivos estáticos, OpenAPI
- **Node.js 20.x**: Build del frontend Angular
- **Docker**: Contenedores multi-stage para build y runtime
- **Swagger/OpenAPI**: Documentación y pruebas de la API

---

## Estructura del Proyecto

```
/
├── WebApp.Server/           # Proyecto ASP.NET Core (backend)
│   ├── Controllers/
│   ├── Properties/
│   ├── wwwroot/             # Archivos estáticos generados por Angular
│   └── WebApp.Server.csproj
├── webapp.client/           # Proyecto Angular (frontend)
│   ├── src/
│   ├── angular.json
│   └── package.json
├── Dockerfile               # Build y despliegue de la solución completa
└── README.md
```

---

## Generalidades y Buenas Prácticas

- **Build Unificado:**  
  El build del frontend Angular se ejecuta automáticamente como parte del build del backend, asegurando que siempre se sirvan los archivos más recientes.

- **Contenedor Optimizado:**  
  La imagen final solo contiene el runtime de ASP.NET y los archivos publicados, sin dependencias de Node.js ni Angular CLI.

- **Configuración de Puertos:**  
  El backend expone los puertos 8080 y 8081. Por defecto, la aplicación escucha en `0.0.0.0:8080` para compatibilidad con Docker y Kubernetes.

- **Despliegue Sencillo:**  
  Solo necesitas Docker para construir y ejecutar la aplicación en cualquier entorno.

---

## Comandos Útiles

### Ejecución en Development Stage

```bash
dotnet run --project "WebApp.Server/WebApp.Server.csproj"
```

### Construir la imagen Docker

```bash
docker build -t webapp -f WebApp.Server/Dockerfile .
```

### Ejecutar el contenedor

```bash
docker run -p 8080:8080 webapp
```

Luego accede a [http://localhost:8080](http://localhost:8080)

---

## Contribuciones

Las contribuciones son bienvenidas. Por favor, abre un issue o un pull request para sugerencias, mejoras o reportar problemas.

---

## Licencia

Este proyecto está bajo a licencia MIT.