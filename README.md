# 🐦 X Clone API – ASP.NET Core 8

Replica funcional del backend de **X (Twitter)** desarrollada en **.NET 8**, bajo los principios de **Clean Architecture**.  
Incluye autenticación **JWT**, validación con **FluentValidation**, y endpoints organizados en módulos:  
`Auth`, `Users`, `Posts` y `Feed`.

---

## 🚀 Tecnologías y herramientas utilizadas

| Tipo | Tecnologías |
|------|--------------|
| **Framework principal** | .NET 8 (ASP.NET Core Web API) |
| **ORM / Base de datos** | Entity Framework Core + SQL Server / SQLite |
| **Autenticación** | JWT (JSON Web Token) con `System.IdentityModel.Tokens.Jwt` |
| **Validación** | FluentValidation (validación automática de DTOs) |
| **Patrón arquitectónico** | Clean Architecture + Repository / Unit of Work |
| **Inyección de dependencias** | Microsoft.Extensions.DependencyInjection |
| **Manejo de DTOs** | Mappeo manual (Mapper estático) |
| **Documentación** | Swagger / OpenAPI (listo para agregar) |

---

## 🔐 Autenticación y seguridad

- **JWT** usado para proteger todos los endpoints (excepto `register` y `login`).  
- Los controladores utilizan `[Authorize]` y extraen el `userId` desde los *claims* del token.  
- `appsettings.json` contiene la configuración del token (`Jwt:Key`, `Issuer`, `Audience`).  

---

## 📚 Endpoints implementados

### 🔸 AuthController – `/api/auth`

| Método | Endpoint | Descripción |
|--------|-----------|-------------|
| **POST** | `/api/auth/register` | Registrar un nuevo usuario y devolver token JWT. |
| **POST** | `/api/auth/login` | Iniciar sesión con credenciales y devolver token JWT. |
| **GET** | `/api/auth/me` | Obtener información del usuario autenticado (requiere token). |

---

### 🔸 UsersController – `/api/users`

| Método | Endpoint | Descripción |
|--------|-----------|-------------|
| **GET** | `/api/users/search?query={text}` | Buscar usuarios por nombre o username parcial. |
| **GET** | `/api/users/{id}` | Obtener perfil de usuario. |
| **GET** | `/api/users/{id}/followers` | Listar seguidores. |
| **GET** | `/api/users/{id}/following` | Listar seguidos. |
| **POST** | `/api/users/{id}/follow` | Seguir usuario. |
| **DELETE** | `/api/users/{id}/follow` | Dejar de seguir usuario. |
| **GET** | `/api/users/{id}/posts` | Timeline del usuario (posts, replies, reposts). |
| **GET** | `/api/users/{id}/likes` | Posts que el usuario ha likeado. |

---

### 🔸 PostsController – `/api/posts`

| Método | Endpoint | Descripción |
|--------|-----------|-------------|
| **GET** | `/api/posts/{id}` | Obtener detalle de un post. |
| **POST** | `/api/posts` | Crear nuevo post. |
| **DELETE** | `/api/posts/{id}` | Eliminar post propio. |
| **POST** | `/api/posts/{id}/reply` | Responder a un post. |
| **GET** | `/api/posts/{id}/replies` | Listar respuestas directas. |
| **POST** | `/api/posts/{id}/quote` | Citar (quote) un post. |
| **POST** | `/api/posts/{id}/repost` | Repostear un post. |
| **DELETE** | `/api/posts/{id}/repost` | Eliminar repost. |
| **GET** | `/api/posts/{id}/reposts` | Listar usuarios que repostearon. |
| **POST** | `/api/posts/{id}/like` | Dar like a un post. |
| **DELETE** | `/api/posts/{id}/like` | Quitar like. |
| **GET** | `/api/posts/{id}/likes` | Listar usuarios que dieron like. |

---

### 🔸 FeedController – `/api/feed`

| Método | Endpoint | Descripción |
|--------|-----------|-------------|
| **GET** | `/api/feed` | Obtener el feed principal (posts, replies y reposts de seguidos). |

---

## 🧠 Características principales

- 🧩 **Arquitectura limpia:** capas separadas (API, Servicios, Data, Dominio).  
- 🧑‍💻 **DTOs y validaciones:** FluentValidation en cada request (`CreatePost`, `Reply`, `Quote`, `Register`, `Login`).  
- 🔄 **Relaciones modeladas:** Users ↔ Follows, Posts ↔ Likes, Posts ↔ Reposts.  
- 💬 **Soporte para replies y quotes anidados.**  
- 🔒 **Autenticación JWT totalmente funcional.**  
- 🧾 **Feed y timeline diferenciados.**

---

## ⚙️ Configuración

### `appsettings.json`
```json
{
  "Jwt": {
    "Key": "super-secret-key",
    "Issuer": "MyApp",
    "Audience": "MyAppUsers"
  },
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=XCloneDb;Trusted_Connection=True;"
  }
}
```

### ▶️ Ejecución del proyecto
- dotnet restore
- dotnet ef database update
- dotnet run

Luego abrí tu navegador o Postman en:
- https://localhost:5001/swagger (si tenés Swagger habilitado).

---

## 👨‍💻 Autor
- Valentín Sarnari
- 🧠 Desarrollador Backend .NET
