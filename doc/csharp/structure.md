# Structure

[Documentation officiel](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/program-structure/)

Un programme C# se compose d'un ou plusieurs fichiers, chacun de ces fichier peux contenir :
- Un ou plusieurs namespace
- Une ou plusieurs classe/struct/enum
- Une lise d'import (`using`)

Voici un exemple basique

```cs
using System; // Importe les définitions du namespace System

namespace MonNamespace
{
    class MaClasse
    {
    }

    class Programme
    {
        static void Main(string[] args)
        {
            // Le programme commence ici
            Console.WriteLine("Hello, World!");
        }
    }
}
```