# C# Variables

## Types

[Documentation officiel](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/types)

En C# les variables sont typés, voici une liste des types les plus commun

```cs
byte b = 255;
short s = -42;
ushort us = 65535;
int i = .1337;
uint ui = 1337;
long l = -13374269;
ulong ul = 13374269;
char c = 'a';
float f = 0.0f;
double d = 0.0d;
bool bo = false;
```

## Tableau

[Documentation officiel](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/arrays)

Il est possible de créer des tableau via la syntaxe suivante : 

```cs
// Crée un tableau de 10 int
int[] tableau = new int[10];
// Assigne 1 à l'index 0
tableau[0] = 1;

// Crée un tableau et l'initialise avec les éléments 0, 2, 4, 6, 8 
int[] a = {0, 2, 4, 6, 8};
// Cette ligne équivaut à celle du dessus
int[] a = new int[] {0, 2, 4, 6, 8};
Console.WriteLine(a[1]); // 2
```

### Multi dimensions

On peux également créer des tableaux à plusieurs dimensions.

```cs
// Crée un tableau a 2 dimension de 10 * 10
int[,] deuxDimensions = new int[10, 10];
Console.WriteLine(a[0, 0]); // 0
a[0, 0] = 1;
Console.WriteLine(a[0, 0]); // 1
```

### Tableau de tableau

Un tableau multi dimension est différent d'un tableau de tableau.
Voici comment créer un tableau de tableau si besoin

```cs
int[][] tableauCeption =
{
    new int[] {1},
    new int[] {1, 1},
    new int[] {1, 2, 1},
    new int[] {1, 3, 3, 1}
};
Console.WriteLine(tableauCeption[2][1]); // 2
tableauCeption[0][0] = 10;
Console.WriteLine(tableauCeption[0][0]); // 10
```

