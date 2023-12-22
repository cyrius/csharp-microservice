# Controlleur

Un controlleur est une classe qui hérite de `ControllerBase`.

Cette classe est précédé par 2 annotations
```cs
// Indique que notre controller sera accessible par l'url api/LeNomDuController
[Route("api/[controller]")]
// Indique que cette classe est un controleur d'API
[ApiController]
```

## Annotations 

Dans notre classe on défini des méthodes qui seront accessible depuis une route HTTP.

Cela se fait simplement en ajoutant une annotation avant la méthode.
Voici différents exemples d'annotations possible.

```cs
// Annotation basique, écoute sur la même URL que le controlleur
// filtre selon la méthode de la requtête HTTP GET/POST/PUT/DELETE
[HttpGet]
[HttpPost]
[HttpPut]
[HttpDelete]
// On peux surcharger l'URL a laquel la méthode sera appelé
// Ici pour appeler cette méthode on contactera /api/Controller/a/b/c
[HttpGet("a/b/c")]
// On peux également récuperer des paramètre passé dans l'url
// Ici on déclare que dans notre url on a un paramètre id
// On retrouve ce paramètre dans les arguments de notre méthode
[HttpGet("a/{id}")]
public void Param(int id) {}
```

## Envoyer de la donnée

Dans l'exemple précédent on a vu que l'on pouvait passer des paramètres dans l'URL.
Cela est cependant peux adapter quand notre volume de donnée a transmettre est important.

Dans ce cas la on utilise en général les méthode POST ou PUT qui servent a transmettre plus d'informations.

```cs
[HttpPost]
public void POST(Data data)
{
    Console.WriteLine(data.ChampLong);
}
// On peux même combiner les 2 en passant par url et par donnée
[HttpPost("{id}")]
public void POST(int id, Data data)
{
    Console.WriteLine(id);
    Console.WriteLine(data.ChampLong);
}

public class Data
{
    public string ChampLong { get; set; }
    public int[] TableauDeInt { get; set; }
}
```


## Exemple

Dans l'exemple qui suit on définit un controller `Random` qui sera joignable sur `/api/Random`.
Il expose 3 méthode qui sont appelable sur les URLs suivante :
- GET /api/Random
- GET /api/Random/0/100 0 = min 100 = max
- POST /api/Random data={ "min": 0, "max": 100 }

```cs
using Microsoft.AspNetCore.Mvc;

namespace MonApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Random : ControllerBase
    {
        // GET: api/Random
        [HttpGet]
        public int RandomGet()
        {
            return new Random().Next();
        }

        // GET api/Random/0/100
        [HttpGet("{min}/{max}")]
        public int RandomGetMinMax(int min, int max)
        {
            return new Random().Next(min, max);
        }

        // POST api/Random/post  DATA JSON { "min": 0, "max": 100 }
        [HttpPost]
        public int RandomPost(RandomValue value)
        {
            return new Random().Next(value.Min, value.Max);
        }
    }

    public class RandomValue
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }
}
```