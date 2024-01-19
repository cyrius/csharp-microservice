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

# Séance 4 & 5

- Finaliser la mise en place des différents micro services et de leur intéractions


# Projet attendu 

Pour la notation, chaque groupe devra mettre en ligne un repo git contenant le code du projet.

Vous enverrez le lien du git à cyril@algorion.fr en mentionnant les membres du groupe.

Vous pouvez heberger le projet sur github, gitlab, ... a votre convenance, tant que je peux y accéder.

## Contenu du projet

J'attend que le projet rendu contienne a minima : 
- 1 appli front en blazor
- 1 microservice API Gateway
- 1 microservice Utilisateur
- 1 microservice pour la gestion des todos (ou autre)

La notation dépendra principalement des points suivants:
- Le front intéragit avec la gateway
- La gateway intéragit avec les micro services
- Le front permet la connexion/inscription d'un utilisateur
- Une fois connecté le front dispose d'un token JWT qu'il utilise pour authentifier les requêtes a la gateway
- Le front permet de visualiser/modifier/supprimer les données du microservice des todos
- Les todos sont associés a un utilisateur, si je me connecte avec le compte A, je ne vois pas les todos de B et inversement
- Les données sont validés/filtrés par la gateway, on interdit les mail avec des caractère spéciaux par exemple

Bonus (non exhaustif) :
- Vous avez rajoutez un champ rôle aux utilisateurs (basique, admin), ceci nécessite de faire une migration et de l'appliquer en base
- Vous affichez une page en plus sur le front en fonction du rôle de l'utilisateur (admin peux consulter la liste de tout les utilisateurs inscrit)
- Gestion des erreurs, si le login/pass est invalide j'affiche un message. Si une requête a la gateway renvoi une erreur, elle est géré
- Les données du second micro service sont persisté (base de donnée, fichier, ...)
- Bonne qualité de code (bien indenté, lisible)
- Vous avez un konami code
- Vous ajoutez d'autres intéractions/fonctionalités
