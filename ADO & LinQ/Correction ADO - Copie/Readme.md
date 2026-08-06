# Exercice

## Slide 52 - 53
- Depuis Visual Studio et à l’aide d’un projet SQL Serveur, créez une base de données appelée « ADO » d’après le schéma du slide précédent.
En sachant que :
    - ID de Student est auto-incrémenté
    - «Active» à pour valeur par défaut « 1 »
    
- Créez une vue «V_Student » n’affichant que les étudiants actifs
- Ajoutez la clé étrangère de « SectionID » dans « Student » vers « ID » de « Section »
- Ajoutez les contraintes suivantes :
    - «YearResult » doit-être compris entre 0 et 20
    - «BirthDate » doit-être supérieure ou égale au 1er Janvier 1930
- Ajouter les procédures :
    - AddStudent
    - UpdateStudent (ne peut modifier que la SectionID et le résultat annuel)
    - DeleteStudent
    - AddSection
- Ajoutez un trigger qui remplace un ordre « Delete from Student » par un ordre « Update Student set Active = 0 where … » 
- Créer un script Post-Déploiement reprenant le contenu du fichier « ADO_LoadData.sql »
- Déployer votre base de données sur « SQL Serveur »

## Slide 61

- Etablissez la connexion à votre base de données « ADO »

## Slide 78

- Afficher l’« ID », le « Nom », le « Prenom » de chaque étudiant depuis la vue «V_Student » en utilisant la méthode connectée
- Afficher la moyenne annuelle des étudiants

## Basé sur 85

- Créer un repository pour vos étudiants avec:
- - un GetAll
- - un GetOneById
- - un create
- Instanciez un objet de type « Student » contenant vos informations
- Insérez votre objet en base de données en récupérant son « ID » au passage