# Demo - Clean Architecture
Exemple d'impl�mentation d'une Clean Architecture en .Net.


## Objectifs :
- Maintenance du projet
- Meilleure s�paration des responsabilit�s _(Separation of Concerns)_
- Meilleure gestion des d�pendances


## Explication des couches 

### Domain
Les �l�ments n�cessaires au projet
- Modeles
- Exceptions
- Enums
- Etc...

### ApplicationCore
L'impl�mentation des r�gles m�tier sous forme de service. \
D�finition des interfaces dont elle d�pend et qu'elle expose.

### Presentation
Les clients :
- ASP.Net API
- App console
- Etc...

### Infrastructure
Acc�s aux donn�es externes : 
- Base de donn�es
- Fichiers
- API ext�rieur
- Email
- Etc...
