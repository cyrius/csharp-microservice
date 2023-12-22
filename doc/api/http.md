# Requête HTTP

Pour faire communiquer nos services, on utilise des requêtes HTTP.

## Emmetre des requêtes HTTP

Voici quelques exemples de requêtes.

```cs
Todo todo = new Todo() { Text = "text", Status = false };
int UserId = 10;

// Requete GET sans paramètre
HttpResponseMessage response = await client.GetAsync("http://localhost:5000/api/Todo/list/");

// Requete GET avec paramètre
HttpResponseMessage response = await client.GetAsync($"http://localhost:5000/api/Todo/list/{UserId}");

// Requete POST avec donnée
HttpResponseMessage response = await client.PostAsJsonAsync($"api/Todo/create/", todo);

// Requete POST avec paramètre et donnée
HttpResponseMessage response = await client.PostAsJsonAsync($"api/Todo/create/{UserId}", todo);

// Requete POST avec paramètre et sans donnée
HttpResponseMessage response = await client.PostAsync($"api/Todo/create/{UserId}");

// Autre méthode (PUT et DELETE)
HttpResponseMessage response = await client.PutAsync($"api/Todo/create/");
HttpResponseMessage response = await client.DeleteAsync($"api/Todo/create/");
HttpResponseMessage response = await client.PutAsJsonAsync($"api/Todo/create/", todo);
```

## Utiliser la réponse

On sait comment envoyer une requêtes, maintenant récupéront sont résultat.

```cs
// On vérifie si la réponse a bien un code valide 200, 201, ...,299
// Cela correspond aux réponse Ok() CreatedAtAction() et autre
// Une liste est disponible ici https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase?view=aspnetcore-8.0

// Prenons comme exemple la récéption d'une classe UserLoginµ
public class UserLogin
{
    public required string Name { get; set; }
    public required string Pass { get; set; }
}

// On emet notre requete
HttpResponseMessage response = await client.GetAsync("http://localhost:5000/api/User/login");

// On recupere le résultat et on le transforme en une instance de UserLogin
UserLogin userLogin = await response.Content.ReadFromJsonAsync<UserLogin>();

// Si l'on veux récuperer le texte renvoyé et ne pas le convertir en instance d'une classe on le fait de la manière suivante
string str = await response.Content.ReadAsStringAsync();
```