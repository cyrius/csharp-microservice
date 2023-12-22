# Main

[Documentation officiel](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/program-structure/main-command-line)

Tout programme qui se lance a besoin d'un point d'entrée.

Par défaut le point d'entrée en C# est la fonction Main.

Cette fonction doit être déclaré dans une classe et une seule

```cs
class Programme
{
    static void Main(string[] args)
    {
        // Le programme commence ici
        Console.WriteLine("Hello, World!");
    }
}
```

## Sauf pour les consoles

[Documentation officiel](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/program-structure/top-level-statements)

Si votre projet est un projet console, vous pouvez ne pas utiliser Main.

Vous pouvez écrire votre code directement dans le fichier `Program.cs` et le compilateur s'occupera de créer le Main pour vous

L'exemple précédent s'écrirai donc simplement comme ceci.

```cs
Console.WriteLine("Hello, World!");
```