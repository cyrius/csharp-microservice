# toString

Quand vous faite un affichage sur la console d'une instance d'une classe il vous affiche `Namespace.Classe`.

Vous pouvez surcharger la méthode toString pour choisir quoi afficher.

```cs
public class User
{
    public int Id { get; set; }
    public string? Name { get; set;}
    public string? Email { get; set;}
    public string? PasswordHash { get; set; }

    // Notez la présence de override qui précise que cette méthode existe deja et que l'on la surcharge
    public override string ToString()
    {
        return $"Id: ${Id} Name: ${Name} Email : ${Email} Pass: ${PasswordHash}";
    }
}

User u = new User():
u.Id = 0;
u.Name = "abc";
u.Email = "a@b.c";
u.PasswordHash = "";

Console.WriteLine(u);
// Affichera
// Id: 0 Name: abc Email : a@b.c Pass: 
```

C'est très pratique pour debuguer le contenu d'une classe.