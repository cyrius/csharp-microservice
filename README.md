# csharp-microservice

Présentation : https://docs.google.com/presentation/d/1JN1UweJbJxXI2r3MYdZYrkFsgzTgNfYSrgl3JRacGV4/edit?usp=sharing

# Séance 2

Les objectifs sont les suivants.

Sur le front:
- Créer une page d'inscription
- Modifier le login pour que le front communique avec la gateway et appel la route de login
- Faire que la page d'inscription appel la gateway
 - Faire une page pour afficher un visuel de votre second micro service ( liste de tâches )

Sur la gateway:
- Créer la route register pour le user 
- Verifier que le user / pass ne comporte que des caractère alphanumérique.
- Ajouter un controller pour le second micro service qui relaie les appel

# Séance 3

Sur le front:
- Récuperer le JWT lors du login et le stocker dans le local storage
- Ajouter le token JWT aux appels HTTP autre que login / register
- Pouvoir lister les todo de l'utilisateur connecté
- Pouvoir supprimer un todo
- Pouvoir mettre à jour un todo

Sur la gateway:
- Ajouter la gestion du JWT
- Ajouter le JWT au swagger
- Rendre certaine route [Authorized]
- Récuperer l'id de l'utilisateur dur les route authentifié
- Transmettre l'id au micro service todo pour ne récuperer que les données concernant notre utilisateur

Sur le micro service todo:
- Ne renvoyer que les todo de notre utilisateur
- Créer une classe TodoDb qui contiendra la liste des todos.
- Ajouter la classe TodoDb dans le program.cs en tant que singleton
- Utiliser cette classe dans le service todo

Vous aurez besoin de ces packages pour utiliser le JWT

```
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package Microsoft.IdentityModel.Tokens
dotnet add package System.IdentityModel.Tokens.Jwt
```


