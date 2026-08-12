---
Language:
  - Csharp
Architecture logicielle:
  - Back End
  - Base de données
tags:
  - DB
  - Csharp
  - Orienté_objet
Pièce jointe:
  - PDF de cours
---
> [!info] <u>NuGet à installer</u>
> - Microsoft.EntityFrameworkCore
> - Microsoft.EntityFramework.SqlServer
> - Microsoft.EntityFramework.Design
> - Microsoft.EntityFramework.Tools
# Database First

1. Visual Studio : Outils > Gestionnaire de package NuGet > Console du Gestionnaire de package
2. Saisir la ligne de commande : `Scaffold-DbContext "Server=VOTRE_SERVEUR;Database=VOTRE_BDD;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models`

>[!info]
> Possible de changer le nom derrière `-OutputDir` pour personnalisé le nom du répertoire de sortie des modèles créés.

>[!bug] Si erreur `ErrorActionPreference` :
> 1. Visual Studio : Outils > Ligne de commande > Terminal *(raccourci : CTRL + ù)*
> 2. Saisir dans Developper Powershell la ligne de commande : `$ErrorActionPreference = "Continue"`

# Code First
1. Créer la Connection String
2. Création de Modèles 
3. Création du DbContext
## Création de la Connextion String

>[!tip]
>Voir aussi : [[Csharp - ADO]]
## Création des Modèles (Table)
Modèle = POCO *(Plain Old CLR Object)* = Class.cs
- 1 classe = 1 table
- propriétés = colonnes des tables

>[!info]
>Souvent rangé dans : 📁Model > 📁Entities
## Création du DbContext
>[!info]
> Souvent rangé dans : 📁Model

>[!Example]
>Pour plus de facilité, la suite sera basée sur un exemple de DB simple :
>- Table Alpha
>- Table Beta
>- Table Delta


```C#
using System.Data.Entity;
using Nom_Database.Model.Entities;

namespace Nom_Database.Model
{
    class Nom_DatabaseContext : DbContext //Héritage de la classe DbContext
    {
		public DbSet<Alpha> Alphas {get; set}
		public DbSet<Beta> Betas {get; set}
		public DbSet<Delta> Deltas {get; set}

    public Nom_DatabaseContext(DbContextOptions<Nom_DatabaseContext> options) : base(options) { } //constructeur

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Alpha>(entity =>
      {
        //cf. $Fluent Api pour les options
      }

      modelBuilder.Entity<Beta>(entity =>
      {
        //cf. $Fluent Api pour les options
      }

      modelBuilder.Entity<Delta>(entity =>
      {
        //cf. $Fluent Api pour les options
      }

    }
}
```

## Relation 1-1, 1-Many, Many-Many

|           | Class                                                                                                                                                                | DbContext                                                                                                                                                                                                   |
| --------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 1-1       | Côté entité faible (ex. Alpha) :<br>`public int BetaId {get; set}`<br>`public Beta Beta {get; set}`<br><br>Côté entité forte :<br>`public Alpha? Alpha {get; set}`   | Dans le `ModelBuilder` de l'entité faible :<br>`modelBuilder.Entity<Beta>().HasOne(e => e.Beta).WithOne(e => e.Alpha).HasForeignKey(e => e.BetaId);`<br>                                                    |
| 1-Many    | Côté 1 :<br>`public int BetaId {get; set}`<br>`public Beta Beta {get; set}`<br><br>Côté Many :<br>`public ICollection<Delta> Deltas {get; set} = new List<Delta>();` | Dans le `ModelBuilder` Côté One :<br>`modelBuilder.Entity<Delta>().HasOne(e => e.Beta).WithMany(e => e.Deltas).HasForeignKey(e => e.BetaID);`                                                               |
| Many-Many | De chaque côté <br>`public ICollection<Delta> Deltas {get; set} = new List<Delta>();`                                                                                | Plusieurs façon d'approche, dont une avec une Class de Jointure : se référer à la document [EF : Relationships Many-to-Many](https://learn.microsoft.com/en-us/ef/core/modeling/relationships/many-to-many) |

## Ajout des clés, contraintes, etc.

Caractéristique | Data Annotations | Fluent API (`OnModelCreating`)
-- | -- | --
Emplacement | Directement sur le modèle (attributs) | Dans la classe DbContext
Couverture | Partielle (scénarios courants) | Totale (100% des fonctionnalités)
Propreté du code | Pollue un peu les entités du domaine | Garde les classes POCO "propres"
Relations complexes | Difficile pour le plusieurs-à-plusieurs complexe | Idéal et fluide

### Data Annotations

| Data Annotation                                                                                                  | Utilité                                                                                                                                               |
| ---------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------- |
| `[Key]`                                                                                                          | Clé primaire.                                                                                                                                         |
| `[Key]`<br>`[Column(Order=1)]`<br><br>`[Key]`<br>`[Column(Order=2)]`                                             | Clé primaire composite                                                                                                                                |
| `[ForeignKey("Delta")]`                                                                                          | Clé étrangère                                                                                                                                         |
| `[ForeignKey("Delta")]`<br>`[Column(Order=1)]`<br><br>`[ForeignKey("Delta")]`<br>`[Column(Order=2)]`             | Clé étrangère composite                                                                                                                               |
| `[Required]`                                                                                                     | Rendre colonne obligatoire (non null)                                                                                                                 |
| `[MaxLength(valeur)]`<br>`[MinLength(valeur)]`                                                                   | Spécifier une longueur d'un string                                                                                                                    |
| `[NotMapped]`                                                                                                    |                                                                                                                                                       |
| `[ComplexType]`                                                                                                  |                                                                                                                                                       |
| `[Timestamp]`                                                                                                    | Equivalent à Rowversion<br>Besoin que la propriété soit de type Byte[]                                                                                |
| `[Table("nom_tabme")]`                                                                                           | Renommer une table                                                                                                                                    |
| `[Column("nom_colonne)]`                                                                                         | Renommer une colonne                                                                                                                                  |
| `[DatabaseGeneratedOption.Computed]`<br>`[DatabaseGeneratedOption.Identity]`<br>`[DatabaseGeneratedOption.None]` | .Computed : seulement valable en Database first<br>.Identity : permet d'ajouter un Identity(1,1)<br>.None : si on ne veut pas que ce soit un Identity |
| `[Index("nom_index", IsUnique = true)]`                                                                          | Crée un index.<br>IsUnique est optionnel                                                                                                              |
| `[Index("nom_index", 1)]`<br>`[Index("nom_index", 2)]`                                                           | Crée un index selon plusieurs colonne.                                                                                                                |
| `[RegularExpression(@"regex")]`                                                                                  | Ajout constraint check selon une expression Regex                                                                                                     |
### Fluent API

```C#
modelBuilder.Entity<Alpha>(entity =>
{
    //Quelques exemples (liste non exhaustive)
    entity.HasKey(e => e.Id)
        .HasName("PK_nom");
    entity.Property(e => e.Nom)
        .IsRequired()
        .HasMaxLength(valeur)
        .HasMinLength(valeur)
        .HasDefaultValue(valeur)
        .HasColumnType("type_SQL")
        .IsFixedLength(valeur);
    entity.HasIndex(e => e.Nom)
        .IsUnique()
        .HasDatabaseName("nom")
        .IsDescending();
    entity.ToTable(e => e.HasCheckConstraint("nom_contrainte", "SQL_expression"));
    entity.HasNoKey()
        .ToView("Nom_vue");

    // définition des relations 1 exemple + cf. paragraphe Relation 1-1, 1-Many, Many-Many

    entity.HasOne(e => e.Beta)
        .WithMany(e => e.Deltas)
        .HasForeignKey(e => e.BetaID)
        .OnDelete(DeleteBehavior.Cascade) //.SetNull .NoAction .Restrict etc.
        .HasConstraintName("FK_nom");
})
```

## Heritage

- **Table per Hierarchy (TPH)** : Cette approche réunir toutes les classes et toutes les propriétés de chaque classe dans une seule table.
C'est l’approche par défaut d’Entity Framework.
- **Table per Type (TPT)** : Cette approche suggère une seule table par classe. Chaque classe sera représentée par une table dans la base
de données, que la classe soit abstraite ou concrète.
- **Table per Concrete Type (TPC)** : Cette approche suggère une table par classe concrète, mais pas pour la classe abstraite. Donc, si vous
héritez de la classe abstraite dans plusieurs classes concrètes, les propriétés de la classe abstraite feront partie de chaque table de
chaque classe concrète.

### Table per Hierarchy
```C#
// Dans les modèles :
abstract class Delta { prop ID, prop communes }

class Alpha : Delta  { prop distinctes }

class Beta : Delta  { prop distinctes }

// Dans le DbContext :
public DBSet<Delta> Deltas{get; set}
//seul le DbSet de la classe mère abstraite est nécessaire
```

>[!info]
>On obtient 1 table *Delta* et il y a l'ajout d'un discriminator pour différencier dans la table *Delta* un *Alpha* d'un *Beta*.

### Table per Type
```C#
// Dans les modèles :
abstract class Delta { prop ID, prop communes}

[Table("Alpha")]
class Alpha : Delta  { prop distinctes }

[Table("Beta")]
class Beta : Delta  { prop distinctes }
```
>[!info]
>On obtient 3 tables distinctes et l'on retrouve en clé étrangère *Delta* dans les tables *Alpha* et *Beta*.

### Table per Concrete Type
```C#
// Dans les modèles :
abstract class Delta { prop GUID ID, prop communes }

class Alpha : Delta  { prop distinctes }

class Beta : Delta  { prop distinctes }

// Dans le DbContext :
modelBuilder.Entity<Alpha>().Map(e => 
{
  e.MapInheritedProperties();
  e.ToTable("Alpha")
});

modelBuilder.Entity<Beta>().Map(e => 
{
  e.MapInheritedProperties();
  e.ToTable("Beta")
});
```

>[!info]
>On obtient 2 tables distinctes *Alpha* et *Beta* contenant l'ensemble des propriétés de *Delta* dont l'ID.

>[!attention]
>Puisque l'ID de la classe abstraite est reprise dans les 2 tables, il faut absolument que nous générions nous-mêmes un ID unique pour éviter l'erreur `InvalidOperationException` à l'execution du programme. Privilégier un ID de type GUID.

# Migration

Visual Studio : Outils > Gestionnaire de package NuGet > Console du Gestionnaire de package

| Ligne de commande              | Utilité                                                                              |
| ------------------------------ | ------------------------------------------------------------------------------------ |
| `add-migration 'Nom_commit'`   | Création d'une migration automatisée. La base de donnée n'est pas encore mise à jour |
| `update-database`              | Valider la mise à jour de la base de donnée selon le dernier ficher de migration     |
| `update-database 'Nom_commit'` | Rollback de la DB à l'état d'une migration automatique spécifique                    |
| `remove-migration`             | Supprime le dernier fichier de migration                                             |
| `remove-migration 'Nom_commit` | Supprime un fichier de migration automatique spécifique                              |
| `get-migrations`               | Récupérer la liste des migrations                                                    |

---

![[Entity Framework.pdf]]