# JWT

JSON Web Token est un token d'authentification qui a la particularité de contenir de la donnée.
On peux donc l'envoyer a notre backend et celui-ci peux lire la donnée contenu a l'intérieur.
Comme celui-ci est signé avec une clé le backend peux vérifier l'authenticité de notre token et le client ne peux donc pas l'altérer.


## Package

Vous aurez besoin de ces packages pour utiliser le JWT

```
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package Microsoft.IdentityModel.Tokens
dotnet add package System.IdentityModel.Tokens.Jwt
```

## Ajouter la vérification du JWT daans notre API

On peux demander a notre API de s'occuper de verifier si les tokens qui lui sont passé sont bien valide

`Program.cs`
```cs
builder.Services.AddAuthorization();
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "Osef";
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ClockSkew = TimeSpan.FromMinutes(600),
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = "localhost:5000",
            ValidIssuer = "TodoProject",
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("YourSecretKeyLongLongLongLongEnough"))
        };
    });


...


app.UseAuthentication();
app.UseAuthorization();
```


## Créer un token JWT depuis le baack

```cs
    private string GenerateJwtToken(int userId)
    {
        var claims = new List<Claim>
        {
            // On ajoute un champ UserId dans notre token avec comme valeur userId en string
            new Claim("UserId", userId.ToString()) 
        };

        // On créer la clé de chiffrement
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSecretKeyLongLongLongLongEnough"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // On paramètre notre token
        var token = new JwtSecurityToken(
            issuer: "TodoProject", // Qui a émit le token
            audience: "localhost:5000", // A qui est destiné ce token
            claims: claims, // Les données que l'on veux encoder dans le token
            expires: DateTime.Now.AddMinutes(3000), // Durée de validité
            signingCredentials: creds); // La clé de chiffrement

        // On renvoie le token signé
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
```


## Utiliser le token dans nos controlleur

Pour signifier qu'une méthode est authentifié on ajoute [Authorize] en annotation.
Cela nous donne accès aux informations contenu dans notre token via la variable User.Claims qui nous est fourni pas la classe mère ControllerBase

```cs
[Authorize]
[HttpGet]
public async Task Authent()
{
    // On récupère la donnée encodé dans le champ UserId
    var UserId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
    // on vérifie qu'elle existe bien
    if (UserId == null) return Unauthorized();
}
```


## Ajouter l'auth dans swagger

Pour que Swagger vous propose d'ajouter le token a vos requêtes
`Program.cs`
```cs
builder.Services.AddSwaggerGen(option => {
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
        }
    }); 
});

...

app.MapSwagger().RequireAuthorization();
```


## Ajouter le token JWT a notre requete HTTP

Pour que le token JWT soit utilisé, il convient de l'envoyer en même temps que notre requête HTTP

Voici un exemple d'ajout du token a un client HTTP

```cs
HttpClient httpClient = new HttpClient());
_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "Ici on met le token");
HttpResponseMessage response = await _httpClient.GetAsync("http://localhost:5000/api/Todo");
```

Cette requête contiendra notre token et le service qui l'a recevra pourra le récupérer et authentifier l'émetteur grâce a celui-ci
