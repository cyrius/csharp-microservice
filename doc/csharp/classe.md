# Les classes

C# étant un langage objet, il permet de créer des classes.

## Classe

[Documentation officiel](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/classes)

```cs
public class MaClasse
{
    int _valeur;
    public MaClasse(int valeur) {
        _valeur = valeur
    }
}

// pour l'instancier
MaClasse c = new MaClasse(0);
```

## Constructeur


Une classe peut avoir un ou plusieurs constructeur. Si celui-ci n'est pas implémenté, un constructeur vide sera automatiquement appelé.

```cs
public class MaClasse
{
    int _valeur;
    public MaClasse(int valeur) {
        _valeur = valeur;
    }

    public MaClasse() {
        _valeur = 0;
    }

    public MaClasse(int valeur) => _valeur = valeur;
    }
}
```

Depuis la version C# 12 il est possible de définir le constructeur directement après le nom de la classe

```cs
public class MaClasse(int valeur)
{
    int _valeur = valeur;
}
```

