# Demo - Clean Architecture
Exemple d'impl�mentation d'une Clean Architecture en .Net.


## Objectifs :
- Maintenance du projet
- Meilleure s�paration des responsabilit�s _(Separation of Concerns)_
- Meilleure gestion des d�pendences


## Explication des couches 

### Domain
Les �l�ments necessaires au projet
- Modeles
- Exceptions
- Enums
- Etc...

### ApplicationCore
L'impl�mentation des r�gles m�tiers sous forme de service. \
D�finition des interfaces dont elle d�pend et qu'elle expose.

### Presentation
Les clients :
- ASP.Net API
- App console
- Etc...

### Infrastructure
Acces aux donn�es externe : 
- Base de donn�es
- Fichiers
- API exterieur
- Email
- Etc...