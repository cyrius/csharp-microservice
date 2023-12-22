# Injection de dépendance

Comme on utilise le framework ASP.Net on ne contrôle pas l'instanciation de nos Controller.

Si j'ai besoin d'avoir accès a un Client HTTP ou a une classe particulière dans mon controller, j'utilise l'injection de dépendance.

Dans mon `Program.cs` je peux demander de au framework de créer certaine classe pour moi.

```cs
// Permet au framework d'injecter une instance de MaClasse dans les controller
// Scoped signifie qu'a chaque requête l'instance est recrée
builder.Services.AddScoped<MaClasse>();

// Si je veux avoir un instance persistante je peux demander un singleton
builder.Services.AddSingleton<MaClasse>();

// Si je veux avoir accès un HTTPClient on peux utiliser la focntion suivante
builder.Services.AddHttpClient();
```


```cs
namespace Exemple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExempleController : ControllerBase
    {
        HttpClient _client;
        MaClasse _maClasse;

        // Dans mon constructeur je demande un HTTPClient et une instance de MaClasse
        // Ceux si seront automatiquement crée par le framework sans action de notre part autre que l'ajout dans le `Program.cs`
        public ExempleController(HttpClient client, MaClasse mc)
        {
            client = client;
            _maClasse = mc;
        }
    }
}
```