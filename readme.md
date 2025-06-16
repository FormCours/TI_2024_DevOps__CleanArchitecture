# Demo - Clean Architecture
Exemple d'implémentation d'une Clean Architecture en .Net.


## Objectifs :
- Maintenance du projet
- Meilleure séparation des responsabilités _(Separation of Concerns)_
- Meilleure gestion des dépendences


## Explication des couches 

### Domain
Les éléments necessaires au projet
- Modeles
- Exceptions
- Enums
- Etc...

### ApplicationCore
L'implémentation des régles métiers sous forme de service. \
Définition des interfaces dont elle dépend et qu'elle expose.

### Presentation
Les clients :
- ASP.Net API
- App console
- Etc...

### Infrastructure
Acces aux données externe : 
- Base de données
- Fichiers
- API exterieur
- Email
- Etc...