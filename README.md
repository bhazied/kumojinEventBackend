> kumojinEvents

# Introduction

La solutions **KumojinEvents **est une application pour la gestion des événements partout dans le monde. Cette application est composé de deux parties:

1. Une application Backend: Développé sous .net core 8, le backend est une api Rest.
2. Une application Frontend : Développé avec Angular 17, concu pour qu'elle soit l'interface graphique pour les utilisateurs de cette application.

Les fonctionnalités fournit par cette application sont les suivants:

- La création d'un événement : pouvoir ajouter un nouveau événement qui peut avoir lieu n'importe oû dans le monde. Un événement est caracterisé par une date de début et une date de début, titre, une description, lieu , type et programme.
- La liste des événements : Les événement doit être consultable via une interface avec la possibilité de distinguer les événements qui sont en court de celles qui sont fini et qui vont être prochainnement lancer.

# pré-requis

- .net 8 core:
- Angular 17 mode standalone
- node 18 ou superieurs

## Architecture et composition

La totalité de la solution **KumojinEvent **est composé par deux application, une application Frontend sous Agular et une autre application concu sous .net Core 8 et elle est consédiré comme un fornisseur des données.

La base des données utilisé pour ce projet est Sqlite V3.45

### Architecture d'API

basé sur le patterne cqrs (commande query reponsability segregation), qui offre une séparation des mode lecture et écriture.

le besoin d'une tell architecture, c'est de tirer profit de l'un des majeurs atout:

- rapidité : facile à configurer des lecteure via des vue de base des données et laisser que le mode écriture qui est le moins couteux agit sur la table.
- Meilleur facon pour organiser les events sur les models
- ....

Utilisation de minimal Api avec des EndPoint au lieux de controlleurs :

- plus léger
- plus visible en terme maintenance
- organisation meilleur

basé sur l'architecture clean avec les différents couche ci-dessous:

- kumojin.Event.Model: contient les entités
- kumojin.Event.Application: les cas d'utilisation métiers
- kumojin.Event.infrastructure : accès aux service tiers , pour notre exemple , cette couche s'occupe de contexte de base des données, les repositories et l'exécution de migration.
- kumojin.Event.Migrator: la configuration et les scripts de création, mise à jours de la structure de base des données, aussi l'injection des données de dev.
- kumojin.Event.Api: couche de présentation, qui fournit les data à consommer et de les écrire.

### Migration de base des données

La migration de la base des données ainsi l'injection des données est gérer dans la projet 'kumojin.Event.Migrator'

lors de l'initialisation de l'application  (api) en mode dev, la migration se lance automatiquement.

Pour lancer la migration au voulenté, il suffit de :

- installer le CLI de fluent migrator:

```bash
dotnet tool install -g FluentMigrator.DotNet.Cli
```

- Migre à l'aide des commande line

dotnet fm migrate -p sqlite -c "Data Source=test.db" -a ".\\bin\\Debug\\netcoreapp2.1\\test.dll

Pour plus de détails

https://fluentmigrator.github.io/articles/quickstart.html?tabs=runner-in-process

### Architecture Angular

J'ai choisi, Angular 17.3 pour ce test, juste pour voir quoi de neuf dans cetet version, car la dernière version que j'ai utilisé c'est la 13.

NB: lorsque j'étais entrain de travailler sur la version 17, Angular à mis en release la version 18.

Parmis les nouveautés:

- mode standalone des component: plus besoin d'une application modulaire, un composant peut s'injecter ou on veut, presque plus besoin des modules ni de chared module.
- l'injection des dépendance est meilleur en mode dev et en mode de performance
- Memory leack approuvé vs les version inferieurs
- revu controle flow : *ngIf --> @if , ngFor--> @for

En global, l'architecture d'uen application Angular est devenu plus simple tel que React ou vueJs, c'est juste d'organiser nos répertoire. Personellemet, j'ai choisis l'organisation par foncionnalité:

Features ==> Event ==> Add : Ajouter un event , contient le component et son test ainsi la template html

Features ==> Event ==> List : lister les events, contient le component et son test ainsi la template html

Features ==> Event ==> Common: contien le model DTO , le service et les mocks utilisé aux test pour mocker les services si besoin
