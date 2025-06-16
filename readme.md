# Demo - Clean Architecture
Exemple d'implémentation d'une Clean Architecture en .Net.


## Objectifs :
- Maintenance du projet
- Meilleure séparation des responsabilités _(Separation of Concerns)_
- Meilleure gestion des dépendances


## Explication des couches 

### Domain
Les éléments nécessaires au projet
- Modeles
- Exceptions
- Enums
- Etc...

### ApplicationCore
L'implémentation des régles métier sous forme de service. \
Définition des interfaces dont elle dépend et qu'elle expose.

### Presentation
Les clients :
- ASP.Net API
- App console
- Etc...

### Infrastructure
Accès aux données externes : 
- Base de données
- Fichiers
- API extérieur
- Email
- Etc...
