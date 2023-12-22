# Structure

[Documentation officiel](https://learn.microsoft.com/fr-fr/dotnet/csharp/language-reference/builtin-types/enum)


Voici un exemple basique d'enumération

```cs
enum Saison
{
    Printemps,
    Ete,
    Automne,
    Hiver
}

Saison a = Season.Automne;
Console.WriteLine($"La valeur entière de {a} est {(int)a}");  // output: La valeur entière de Autumn est 2
```

On peut définir manuellement la valeur des membres de l'enum.

```cs
enum Saison : uint
{
    Printemps = 0,
    Ete = 10,
    Automne = 20,
    Hiver = 30
}
```