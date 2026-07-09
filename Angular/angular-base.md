# 🅰️ Angular Moderne

---

## 📋 Sommaire

**Jour 1 — Les fondations**
1. C'est quoi Angular, et pourquoi ?
2. Comment fonctionne une application Angular
3. CSR, SSR, SSG, Hydratation (culture générale)
4. Créer le projet et comprendre chaque fichier
5. TypeScript essentiel
6. Les composants
7. Le binding (interpolation, property, event)
8. Les directives modernes (`@if`, `@for`, `@switch`)
9. Les Signals

**Jour 2 — Construire une vraie application**
10. Communication entre composants (`input()` / `output()`)
11. Les services et l'injection de dépendances
12. Le routing
13. HttpClient et les appels API
14. Assemblage final du projet DevTask

---

## 🎯 Le projet fil rouge : DevTask

Pendant ces deux jours, on va construire **une seule application**, petit à petit : **DevTask**, un gestionnaire de tâches.

```
Jour 1 : DevTask apprend à afficher et ajouter des tâches (en local, dans le navigateur)
Jour 2 : DevTask apprend à naviguer entre plusieurs pages et à aller chercher ses tâches sur un serveur
```

Chaque nouvelle notion viendra enrichir cette application. À la fin des 2 jours, vous aurez un vrai petit projet Angular fonctionnel, et vous saurez expliquer **chaque ligne** de code que vous avez écrite.

---

# JOUR 1 — LES FONDATIONS

## 1. C'est quoi Angular, et pourquoi ?

### Le problème, avant l'outil

Vous savez déjà faire du JavaScript moderne : manipuler le DOM, faire des `fetch`, gérer des promesses. Alors une question légitime : **pourquoi ne pas juste continuer en JavaScript pur pour construire une application ?**

Imaginez que vous développiez DevTask uniquement en JavaScript vanilla. Voici ce qui arrive concrètement :

- Vous ajoutez une tâche → il faut manuellement créer un élément `<li>`, l'insérer dans le DOM, écouter le clic sur le bouton "supprimer", re-lire le tableau de tâches, re-générer le HTML...
- Votre fichier `app.js` grossit. Après 200 lignes, vous ne savez plus quelle fonction met à jour quel bout de HTML.
- Vous ajoutez une deuxième page (une page "Statistiques") → il faut gérer manuellement l'affichage/masquage de blocs HTML, ou recharger toute la page.
- Un collègue reprend votre code → il doit tout relire pour comprendre où est quoi.

Ce n'est pas que JavaScript est "mauvais". C'est que **construire une application avec beaucoup d'interactions demande une organisation** que le JavaScript brut ne fournit pas nativement.

### Angular, la réponse

Angular est un **framework** : une boîte à outils complète qui impose une organisation et automatise les tâches répétitives.

```
JavaScript vanilla                    Angular
─────────────────                    ───────
Vous gérez tout                      Angular gère l'affichage
manuellement                         automatiquement dès qu'une
(DOM, mise à jour...)                donnée change

Un seul (ou peu de) fichier(s)       Découpage en composants
qui grossit sans limite              réutilisables et isolés

Pas de structure imposée             Structure de projet standard
                                      (facile de rejoindre un projet
                                       inconnu)
```

Concrètement, avec Angular :
- vous décrivez **ce qui doit s'afficher** selon vos données, pas **comment** mettre à jour le DOM à la main ;
- votre application est découpée en petits blocs indépendants (les composants) ;
- il y a une seule façon "standard" de faire les choses (routing, appels API, formulaires...), ce qui rend le code de n'importe quel projet Angular lisible par n'importe quel développeur Angular.

### Quand choisir Angular ?

💡 **Bon à savoir** : Il n'y a pas de "meilleur framework" universel. Angular est particulièrement pertinent quand :
- l'application est grande et va vivre longtemps (plusieurs années, plusieurs développeurs) ;
- vous avez besoin d'une structure imposée et cohérente (utile en entreprise, avec des équipes qui tournent) ;
- vous venez d'un langage typé et orienté objet (comme C#) — vous allez vous sentir étonnamment à l'aise.

🎯 **À retenir** : Angular n'est pas "une meilleure version de JavaScript". C'est un cadre de travail qui vous fait gagner du temps sur l'organisation, au prix d'un peu plus de code au départ.

---

## 2. Comment fonctionne une application Angular ?

### Le problème

Quand vous ouvrez `localhost:4200` dans votre navigateur, qu'est-ce qui se passe **réellement**, avant même de voir la moindre tâche affichée ? Comprendre cette séquence est indispensable, sinon tout le reste (fichiers, composants...) reste abstrait.

### Le cycle de démarrage

```
Vous ouvrez localhost:4200
        ↓
Le navigateur télécharge index.html
        ↓
index.html contient une balise <app-root></app-root>
(vide au départ !) et charge main.ts
        ↓
main.ts exécute bootstrapApplication()
        ↓
Angular repère AppComponent (le composant racine)
        ↓
Angular construit l'arbre de composants
(AppComponent, puis ses enfants, etc.)
        ↓
Angular remplace <app-root></app-root>
par le vrai contenu généré
        ↓
Le navigateur affiche la page complète
```

Autrement dit : **`index.html` est presque vide**. C'est Angular, via `main.ts`, qui va "remplir" la page une fois le JavaScript exécuté.

### Pourquoi ça compte

⚠️ **Piège fréquent** : les débutants pensent qu'`index.html` contient toute la structure de la page. En réalité, dans une application Angular classique, `index.html` ne contient presque qu'une seule balise (`<app-root>`). Tout le reste est généré dynamiquement par Angular au démarrage.

C'est fondamentalement différent d'un site HTML/CSS classique où toute la structure est écrite à la main dans le fichier HTML.

🎯 **À retenir** : Angular ne "modifie" pas une page existante, il **construit** la page depuis presque rien, à partir de vos composants.

---

## 3. Angular est exécuté où ? (CSR, SSR, SSG, Hydratation)

### Le problème

Dans le schéma précédent, on a vu que le navigateur doit d'abord télécharger et exécuter du JavaScript avant d'afficher quoi que ce soit. Ça pose une vraie question : **où est réellement construite la page ? Dans le navigateur de l'utilisateur, ou avant, sur un serveur ?**

Cette question a plusieurs réponses possibles, et Angular moderne les supporte toutes. Pas besoin de les maîtriser en détail à ce stade — c'est de la culture générale utile, notamment si vous entendez parler de Next.js (l'équivalent côté React).

### CSR — Client-Side Rendering (ce qu'on utilise dans ce cours)

```
Serveur                          Navigateur
───────                          ──────────
Envoie un index.html   ────→     Reçoit une page presque vide
presque vide + le JS                    ↓
                                  Exécute le JS
                                         ↓
                                  Construit la page
                                         ↓
                                  Affiche le résultat
```
C'est le scénario qu'on a vu au point 2. Simple à développer, mais l'utilisateur voit un écran vide pendant une fraction de seconde (le temps que le JS s'exécute).

### SSR — Server-Side Rendering

```
Serveur                          Navigateur
───────                          ──────────
Construit la page HTML  ────→    Reçoit une page déjà
complète, avec les données              affichée
                                         ↓
                                  Affiche immédiatement
                                         ↓
                                  Angular "réactive" la
                                  page en arrière-plan
                                  (= hydratation)
```
Le serveur fait le travail de construction avant d'envoyer la page. L'utilisateur voit le contenu immédiatement, même avant que le JavaScript soit chargé.

### SSG — Static Site Generation

Comme le SSR, mais la page est construite **une seule fois, à l'avance** (au moment du déploiement), pas à chaque visite. Idéal pour des pages qui ne changent presque jamais (page "À propos", articles de blog...).

### Hydratation

C'est le mot qui décrit le moment où, après un rendu SSR ou SSG, Angular "prend le relais" côté navigateur pour rendre la page interactive (boutons cliquables, signals actifs...). Avant l'hydratation, la page est visible mais pas encore interactive.

### Petite comparaison avec Next.js

| | Angular | Next.js (React) |
|---|---|---|
| CSR | ✅ par défaut historiquement | ✅ |
| SSR | ✅ intégré nativement | ✅ (son point fort historique) |
| SSG | ✅ | ✅ |
| Hydratation | ✅ automatique | ✅ automatique |

💡 **Bon à savoir** : Angular et Next.js résolvent le même problème (où construire la page) avec des outils différents. Ce n'est pas propre à un seul framework.

🎯 **À retenir** : dans ce cours, on reste en **CSR**, le mode par défaut, le plus simple à comprendre pour débuter. Vous savez maintenant que SSR/SSG existent, et pourquoi.

---

*(Suite : création du projet et explication de chaque fichier)*

## 4. Créer le projet et comprendre chaque fichier

### Le problème

On sait maintenant *pourquoi* Angular existe et *comment* il démarre en théorie. Il est temps de créer un vrai projet et de voir ça en pratique — mais sans se précipiter sur le code. Chaque fichier généré a un rôle précis, et il faut comprendre **quand** et **pourquoi** il est utilisé avant d'écrire la moindre ligne dedans.

### Création du projet

```bash
ng new devtask
cd devtask
ng serve
```

Angular génère une structure de dossiers. Voici les fichiers qui nous intéressent vraiment :

```
devtask/
├── src/
│   ├── app/
│   │   ├── app.ts          → le composant racine
│   │   ├── app.html        → son template
│   │   ├── app.css         → son style
│   │   ├── app.config.ts   → la configuration globale de l'app
│   │   └── app.routes.ts   → la liste des routes (utile Jour 2)
│   ├── index.html          → la page HTML unique
│   ├── main.ts             → le point de démarrage
│   └── styles.css          → styles globaux
├── angular.json             → configuration du CLI
├── package.json             → dépendances du projet
└── tsconfig.json            → configuration TypeScript
```

### Chaque fichier, en détail

#### `index.html`

**À quoi il sert** : c'est la seule vraie page HTML de toute l'application. Elle est chargée **une seule fois**.

**Quand il est exécuté** : au tout premier chargement de l'application dans le navigateur.

**Pourquoi il existe** : un navigateur a besoin d'un point de départ HTML. Angular a besoin d'un endroit où s'accrocher — la balise `<app-root>` qu'il contient :

```html
<body>
  <app-root></app-root>
</body>
```

⚠️ **Piège fréquent** : ouvrir `index.html` en espérant y voir la structure de votre application (navbar, liste de tâches...). Vous n'y trouverez presque rien — c'est normal, tout est généré par Angular.

#### `main.ts`

**À quoi il sert** : démarrer l'application Angular dans le navigateur.

**Quand il est exécuté** : immédiatement après le chargement d'`index.html`.

**Pourquoi il existe** : Angular a besoin d'un point d'entrée JavaScript qui dit "voici quel composant utiliser comme racine, et voici la configuration à appliquer".

```ts
import { bootstrapApplication } from '@angular/platform-browser';
import { App } from './app/app';
import { appConfig } from './app/app.config';

bootstrapApplication(App, appConfig);
```

Traduction en français : *"Démarre l'application en utilisant `App` comme composant racine, et applique la configuration `appConfig`."*

#### `app.ts` (le composant racine)

**À quoi il sert** : c'est le tout premier composant affiché, celui qui contiendra (directement ou indirectement) tous les autres.

**Quand il est exécuté** : dès que `bootstrapApplication()` le demande.

**Pourquoi il existe** : Angular doit démarrer *quelque part*. Ce sera toujours ce composant.

```ts
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {}
```

💡 **Bon à savoir** : `standalone: true` veut dire que ce composant n'a besoin d'aucun `NgModule` pour fonctionner — il se suffit à lui-même. C'est la façon moderne de faire (avant, chaque composant devait être déclaré dans un module).

#### `app.config.ts`

**À quoi il sert** : configurer les fonctionnalités globales de l'application (routing, appels HTTP...).

**Quand il est exécuté** : au démarrage, lu par `bootstrapApplication()`.

**Pourquoi il existe** : certaines fonctionnalités (comme le routing qu'on verra Jour 2) doivent être activées une seule fois, globalement, pour toute l'application.

```ts
import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes)
  ]
};
```

🎯 **À retenir** — le cycle complet, maintenant avec les vrais fichiers :

```
index.html (charge main.ts)
        ↓
main.ts (appelle bootstrapApplication)
        ↓
app.config.ts (fournit la configuration)
        ↓
app.ts (composant racine, utilise app.html + app.css)
        ↓
Page affichée dans le navigateur
```

### 📝 Exercice 1 — Premier contact (10 min)

**Consigne** :
1. Crée le projet `devtask` avec `ng new`.
2. Lance-le avec `ng serve` et vérifie qu'il tourne sur `localhost:4200`.
3. Ouvre `app.html` et remplace tout son contenu par `<h1>DevTask</h1>`.
4. Vérifie que la page se met à jour automatiquement dans le navigateur.

### ✅ Correction

Si tout fonctionne, la page affiche "DevTask" en grand, et elle s'est mise à jour **sans que vous rechargiez la page manuellement** — c'est le "live reload" du CLI Angular, pas de la magie : le CLI surveille vos fichiers et redéclenche la compilation automatiquement à chaque sauvegarde.


---

## 5. TypeScript essentiel

### Le problème

Vous connaissez JavaScript. En JavaScript, ce code est parfaitement valide :

```js
function addTask(title) {
  return { title: title, done: false };
}

addTask(42); // Aucune erreur... jusqu'à ce que ça plante plus loin
```

Rien n'empêche d'appeler `addTask(42)` avec un nombre au lieu d'un texte. L'erreur ne sera visible que plus tard, potentiellement en production, quand quelque chose essaiera d'utiliser `42` comme un texte et plantera de façon inattendue.

### Pourquoi Angular utilise TypeScript

TypeScript = JavaScript + un système de types. Le code est vérifié **avant l'exécution**, dès que vous l'écrivez (votre éditeur vous prévient immédiatement) et à la compilation.

```
JavaScript                          TypeScript
──────────                          ──────────
Erreur détectée                     Erreur détectée
à l'exécution                       à l'écriture / à la compilation
(parfois en prod, chez              (dans votre éditeur, avant
 le client...)                       même de lancer le code)
```

Angular est un framework pensé pour de grosses applications, avec plusieurs développeurs. Plus une application grossit, plus les erreurs silencieuses de type deviennent coûteuses à débusquer. TypeScript réduit drastiquement cette catégorie de bugs.

💡 **Bon à savoir** : venant de C#, vous allez vous sentir en terrain familier — C# est aussi un langage typé. TypeScript reprend cette philosophie, mais reste un "sur-ensemble" de JavaScript : tout code JavaScript valide est aussi du TypeScript valide.

### Les types de base

```ts
let taskTitle: string = "Corriger le bug #42";
let priority: number = 3;
let isDone: boolean = false;
```

Si vous essayez `priority = "haute"`, TypeScript refuse immédiatement, avant même d'exécuter quoi que ce soit :

```ts
priority = "haute"; // ❌ Erreur : Type 'string' is not assignable to type 'number'
```

### Les tableaux typés

```ts
let titles: string[] = ["Corriger le bug", "Écrire les tests"];
let priorities: number[] = [1, 2, 3];
```

### Les objets, avec `type`

En JavaScript, un objet peut avoir n'importe quelle forme, changer de forme en cours de route, etc. En TypeScript, on décrit **la forme attendue** avec `type` :

```ts
type Task = {
  id: number;
  title: string;
  done: boolean;
};

const task: Task = {
  id: 1,
  title: "Corriger le bug #42",
  done: false
};
```

Si vous oubliez un champ, ou tapez une faute (`donee` au lieu de `done`), TypeScript vous le signale immédiatement.

### 🎯 Bonus — `type` vs `interface`

Vous croiserez parfois `interface` à la place de `type` dans du code Angular. Les deux servent à décrire la forme d'un objet, et sont très proches :

```ts
// avec type
type Task = {
  id: number;
  title: string;
};

// avec interface
interface Task {
  id: number;
  title: string;
}
```

Petit tableau pour s'y retrouver :

| | `type` | `interface` |
|---|---|---|
| Décrire un objet | ✅ | ✅ |
| Décrire une union de valeurs (`"low" \| "high"`) | ✅ | ❌ impossible |
| Étendre / hériter | avec `&` | avec `extends` (plus lisible) |
| Fusion automatique de deux déclarations du même nom | ❌ impossible | ✅ possible |

Dans ce cours, on utilisera **`type`**, parce qu'il est plus simple et plus flexible pour débuter. Mais sachez que `interface` existe et que vous le croiserez très souvent dans des projets réels, notamment pour typer les réponses d'API.

### `readonly`, `private`, `public`

Ces trois mots-clés viennent contrôler qui a le droit de lire ou modifier une donnée. Si vous venez de C#, vous connaissez déjà ce concept.

```ts
class TaskService {
  public taskCount: number = 0;   // accessible depuis n'importe où
  private apiUrl: string = "...";  // accessible uniquement dans cette classe
  readonly createdAt = new Date(); // ne peut jamais être réassigné après sa création
}
```

- **`public`** (par défaut si rien n'est précisé) : accessible depuis l'extérieur de la classe.
- **`private`** : accessible uniquement à l'intérieur de la classe. Utile pour cacher les détails internes.
- **`readonly`** : la valeur est fixée une fois pour toutes après sa création, plus aucune réassignation possible ensuite.

⚠️ **Piège fréquent** : `readonly` empêche de réassigner toute la variable (`this.createdAt = new Date()`), mais si la valeur est un objet ou un tableau, son **contenu** peut parfois quand même être modifié. `readonly` protège la référence, pas nécessairement tout ce qu'elle contient.

### Les fonctions typées

```ts
function calculatePriority(daysLeft: number): string {
  if (daysLeft <= 1) return "Urgent";
  return "Normal";
}
```

On type les paramètres d'entrée (`daysLeft: number`) et la valeur de retour (`: string`).

### 📝 Exercice 2 — Typer une tâche (10 min)

**Consigne** :
1. Crée un `type Task` avec `id` (number), `title` (string), `done` (boolean) et `priority` (number).
2. Crée une constante `myFirstTask` de type `Task` avec des valeurs de ton choix.
3. Crée une fonction `isUrgent(task: Task): boolean` qui renvoie `true` si `priority` est supérieure à 8.

### ✅ Correction

```ts
type Task = {
  id: number;
  title: string;
  done: boolean;
  priority: number;
};

const myFirstTask: Task = {
  id: 1,
  title: "Préparer la démo",
  done: false,
  priority: 9
};

function isUrgent(task: Task): boolean {
  return task.priority > 8;
}
```

🎯 **Résumé du chapitre** : TypeScript ajoute des types à JavaScript pour détecter les erreurs **avant** l'exécution. On type les variables, les tableaux, les objets (via `type`), les fonctions. `private`/`public`/`readonly` contrôlent l'accès aux données d'une classe.


---

## 6. Les composants

### Le problème

Imaginez DevTask avec : une navbar, une liste de tâches, et chaque tâche affichée avec un titre, une case à cocher et un bouton supprimer. Si tout ça est écrit dans un seul fichier HTML géant avec un seul fichier JS géant, on retombe exactement dans le problème du chapitre 1 : un code qui grossit sans limite et devient illisible.

### L'analogie LEGO

Pensez à des LEGO. Vous ne sculptez pas un château en un seul bloc de plastique — vous assemblez des petites pièces standardisées, chacune simple, réutilisable, et interchangeable.

```
Château en un seul bloc              Château en LEGO
────────────────────────             ───────────────
Impossible à modifier                Vous changez juste
sans tout casser                     une pièce
Impossible à réutiliser              Chaque pièce est
ailleurs                             réutilisable ailleurs
```

Un **composant Angular**, c'est une pièce LEGO : un petit bloc autonome, avec sa propre logique, son propre affichage, son propre style — et qui peut être combiné avec d'autres composants pour former l'application complète.

### Hiérarchie de composants pour DevTask

```
App (racine)
├── Navbar
├── TaskList
│   ├── TaskItem
│   ├── TaskItem
│   └── TaskItem
└── Footer
```

Chaque bloc de ce schéma sera, à terme, un composant Angular indépendant.

### Anatomie d'un composant : 3 fichiers, 3 responsabilités

```
TaskItem (composant)
├── task-item.ts
│   → logique : variables, fonctions, signals
│
├── task-item.html
│   → affichage : ce que l'utilisateur voit
│
└── task-item.css
    → style : l'apparence visuelle
```

**Pourquoi séparer ces 3 fichiers ?** Parce que ce sont 3 préoccupations différentes :
- la **logique** (que faire quand on clique sur "supprimer" ?) ne devrait pas être mélangée avec...
- l'**affichage** (où va le bouton, le titre...), qui ne devrait pas être mélangé avec...
- le **style** (couleurs, espacements...).

Ça permet à un développeur de modifier le style sans toucher à la logique, et inversement.

### Créer un composant

```bash
ng generate component task-item
# ou en raccourci :
ng g c task-item
```

Ça génère automatiquement les 3 fichiers, déjà reliés entre eux :

```ts
// task-item.ts
import { Component } from '@angular/core';

@Component({
  selector: 'app-task-item',
  standalone: true,
  templateUrl: './task-item.html',
  styleUrl: './task-item.css'
})
export class TaskItem {
  title = "Corriger le bug #42";
}
```

```html
<!-- task-item.html -->
<p>{{ title }}</p>
```

Le `selector: 'app-task-item'` définit le nom de la balise HTML personnalisée qu'on pourra utiliser ailleurs :

```html
<!-- dans app.html, par exemple -->
<app-task-item></app-task-item>
```

💡 **Bon à savoir** : `{{ title }}` est de l'**interpolation**, on va le détailler juste après — c'est ce qui permet d'afficher la valeur d'une variable TypeScript dans le HTML.

### 📝 Exercice 3 — Premier composant DevTask (15 min)

**Consigne** :
1. Génère un composant `task-item`.
2. Dans `task-item.ts`, crée une variable `title` avec le texte de ton choix.
3. Affiche cette variable dans `task-item.html`.
4. Utilise `<app-task-item>` dans `app.html` pour l'afficher.
5. Vérifie dans le navigateur.

### ✅ Correction

```ts
// task-item.ts
export class TaskItem {
  title = "Préparer la présentation client";
}
```
```html
<!-- task-item.html -->
<div class="task">
  <p>{{ title }}</p>
</div>
```
```html
<!-- app.html -->
<h1>DevTask</h1>
<app-task-item></app-task-item>
```

⚠️ **Piège fréquent** : oublier d'importer le composant enfant dans le composant parent. En standalone, il faut ajouter `TaskItem` dans le tableau `imports` du `@Component` de `App` :

```ts
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [TaskItem], // ← indispensable !
  templateUrl: './app.html'
})
export class App {}
```

Sans ça, Angular ne reconnaît pas la balise `<app-task-item>` et affiche une erreur.

🎯 **Résumé du chapitre** : un composant = 3 fichiers (logique / affichage / style). On les assemble comme des LEGO pour construire toute l'application. Il faut toujours importer un composant enfant dans le tableau `imports` du composant parent.


---

## 7. Le binding

### Le problème

On a un composant `TaskItem` qui affiche un titre en dur. Mais une vraie application a besoin de :
- afficher des données qui changent (le titre d'une vraie tâche) ;
- lier un attribut HTML à une donnée (l'image ne doit pas toujours être la même) ;
- réagir à une action de l'utilisateur (un clic sur "supprimer").

En JavaScript vanilla, ça demanderait de manipuler le DOM à la main (`document.querySelector`, `.addEventListener`...). Angular propose 3 mécanismes qui font ça automatiquement : le **binding**.

### 7.1 L'interpolation — afficher une valeur

**Pourquoi** : besoin d'afficher, dans le HTML, la valeur d'une variable TypeScript.

**Comment** : les doubles accolades `{{ }}`.

```ts
export class TaskItem {
  title = "Corriger le bug #42";
}
```
```html
<p>{{ title }}</p>
```

Résultat affiché : `Corriger le bug #42`. Dès que `title` change dans la classe, le texte affiché se met à jour automatiquement.

### 7.2 Le property binding — lier un attribut HTML

**Pourquoi** : certains attributs HTML (`src`, `href`, `disabled`...) doivent varier selon une donnée, pas être écrits en dur.

**Comment** : des crochets `[ ]` autour de l'attribut.

```ts
export class TaskItem {
  iconUrl = "check-icon.png";
  isDone = false;
}
```
```html
<img [src]="iconUrl" [alt]="title">
<button [disabled]="isDone">Marquer comme fait</button>
```

⚠️ **Piège fréquent** : écrire `src="iconUrl"` (sans crochets) affichera littéralement le texte `"iconUrl"` comme chemin d'image — Angular pensera que c'est une chaîne fixe, pas une variable à évaluer. Les crochets sont indispensables pour dire "évalue ceci comme une expression TypeScript".

### 7.3 L'event binding — réagir à une action

**Pourquoi** : il faut exécuter du code quand l'utilisateur clique, tape, survole...

**Comment** : des parenthèses `( )` autour de l'événement.

```ts
export class TaskItem {
  onDelete() {
    console.log("Tâche supprimée !");
  }
}
```
```html
<button (click)="onDelete()">Supprimer</button>
```

Ici, `(click)` écoute l'événement `click` du navigateur, et déclenche la méthode `onDelete()` de la classe.

### Récapitulatif visuel

```
{{ title }}          → Interpolation      : afficher une donnée
[src]="iconUrl"      → Property binding   : lier un attribut
(click)="onDelete()" → Event binding      : réagir à une action
```

### 📝 Exercice 4 — Enrichir TaskItem (15 min)

**Consigne** : Dans le composant `TaskItem` :
1. Ajoute une variable `isDone: boolean`.
2. Affiche un bouton "Marquer comme fait" désactivé (`disabled`) si `isDone` est déjà `true` (property binding).
3. Ajoute un bouton "Supprimer" qui appelle une méthode `onDelete()` affichant un message dans la console (event binding).

### ✅ Correction

```ts
export class TaskItem {
  title = "Corriger le bug #42";
  isDone = false;

  onDelete() {
    console.log(`Tâche "${this.title}" supprimée`);
  }
}
```
```html
<div class="task">
  <p>{{ title }}</p>
  <button [disabled]="isDone">Marquer comme fait</button>
  <button (click)="onDelete()">Supprimer</button>
</div>
```

🎯 **Résumé du chapitre** : 3 outils de binding, 3 usages différents — `{{ }}` pour afficher, `[ ]` pour lier un attribut, `( )` pour réagir à un événement. Ce sont les briques de base de tout template Angular.


---

## 8. Les directives modernes — `@if`, `@for`, `@switch`

### Le problème

Le binding permet d'afficher une valeur ou de réagir à un clic. Mais comment faire pour :
- afficher un bloc HTML **seulement si** une condition est vraie ?
- afficher une **liste** d'éléments à partir d'un tableau ?

En JavaScript vanilla, ça voudrait dire écrire manuellement des boucles pour générer du HTML, l'insérer dans le DOM... Angular propose une syntaxe dédiée, directement dans le template.

💡 **Bon à savoir** : si vous voyez du code Angular plus ancien (tutoriels, projets existants), vous croiserez `*ngIf` et `*ngFor`. `@if` et `@for` sont leur remplaçant moderne — plus proches de la syntaxe JavaScript classique, et plus performants. Dans ce cours, on utilise uniquement la syntaxe moderne.

### 8.1 `@if` — affichage conditionnel

```ts
export class TaskItem {
  isDone = false;
}
```
```html
@if (isDone) {
  <p>✅ Tâche terminée</p>
} @else {
  <p>⏳ Tâche en cours</p>
}
```

### 8.2 `@for` — afficher une liste

**Pourquoi** : DevTask doit afficher une liste de tâches, potentiellement des dizaines. Écrire chaque `<app-task-item>` à la main n'est pas envisageable.

```ts
type Task = { id: number; title: string };

export class TaskList {
  tasks: Task[] = [
    { id: 1, title: "Corriger le bug #42" },
    { id: 2, title: "Écrire les tests" },
  ];
}
```
```html
@for (task of tasks; track task.id) {
  <p>{{ task.title }}</p>
} @empty {
  <p>Aucune tâche pour le moment.</p>
}
```

⚠️ **Piège fréquent** : oublier `track task.id`. Ce n'est pas optionnel — Angular en a besoin pour savoir **quel** élément a changé dans la liste (pour ne mettre à jour que ce qui a réellement bougé, plutôt que de tout réafficher). En général on utilise l'`id` de l'élément, une valeur unique et stable.

`@empty` est optionnel : il s'affiche uniquement si le tableau est vide.

### 8.3 `@switch` — plusieurs cas possibles

**Pourquoi** : quand on a plus de 2 cas à gérer (un `@if`/`@else` devient vite illisible avec beaucoup de conditions).

```ts
export class TaskItem {
  priority: "low" | "medium" | "high" = "high";
}
```
```html
@switch (priority) {
  @case ("low") {
    <span>🟢 Basse</span>
  }
  @case ("medium") {
    <span>🟡 Moyenne</span>
  }
  @case ("high") {
    <span>🔴 Haute</span>
  }
  @default {
    <span>Non définie</span>
  }
}
```

### 📝 Exercice 5 — Liste de tâches DevTask (20 min)

**Consigne** :
1. Crée un composant `TaskList` avec un tableau de `Task` (au moins 3 tâches, avec `id`, `title`, `done`).
2. Affiche la liste avec `@for`.
3. Pour chaque tâche, affiche "✅" si `done` est `true`, sinon "⏳" (`@if`/`@else`).
4. Ajoute un message "Aucune tâche" si le tableau est vide (`@empty`).

### ✅ Correction

```ts
type Task = { id: number; title: string; done: boolean };

export class TaskList {
  tasks: Task[] = [
    { id: 1, title: "Corriger le bug #42", done: true },
    { id: 2, title: "Écrire les tests", done: false },
    { id: 3, title: "Préparer la démo", done: false },
  ];
}
```
```html
@for (task of tasks; track task.id) {
  <div class="task">
    @if (task.done) {
      <span>✅</span>
    } @else {
      <span>⏳</span>
    }
    <span>{{ task.title }}</span>
  </div>
} @empty {
  <p>Aucune tâche pour le moment.</p>
}
```

🎯 **Résumé du chapitre** : `@if`/`@else` pour l'affichage conditionnel, `@for` (avec `track` obligatoire) pour les listes, `@switch` pour les choix multiples. Ces directives remplacent `*ngIf`/`*ngFor` dans Angular moderne.


---

## 9. Les Signals

### Le problème, en partant d'une simple variable

Imaginons qu'on ajoute un compteur de tâches à DevTask, avec une variable JavaScript toute simple :

```ts
export class TaskCounter {
  count = 0;

  increment() {
    this.count = this.count + 1;
    console.log(this.count); // ça, ça marche
  }
}
```
```html
<p>Tâches ajoutées : {{ count }}</p>
<button (click)="increment()">Ajouter une tâche</button>
```

Ici, ça fonctionne — mais **pas grâce à la variable elle-même**. C'est Angular qui, après chaque événement (comme un clic), relance un mécanisme de vérification qui parcourt tout le composant pour voir si quelque chose a changé, et met à jour l'affichage si besoin.

### Pourquoi une simple variable ne suffit plus

Ce mécanisme de vérification globale fonctionne, mais il a un coût : plus l'application grossit (beaucoup de composants, beaucoup de données), plus Angular doit vérifier "un peu partout" si quelque chose a changé, même quand la plupart des choses n'ont pas bougé.

```
Variable classique
───────────────────
this.count = this.count + 1
        ↓
Angular ne sait pas QUOI a changé
        ↓
Il doit tout vérifier pour être sûr de rien manquer
```

### La solution : les Signals

Un **signal** est une valeur qui **sait elle-même** quand elle change, et **prévient directement** les endroits qui l'utilisent — sans qu'Angular ait besoin de tout vérifier.

```
Signal
──────
this.count.set(this.count() + 1)
        ↓
Le signal SAIT qu'il a changé
        ↓
Il prévient directement le template qui l'affiche
        ↓
Angular met à jour UNIQUEMENT ce qui dépend de ce signal
```

### Créer un signal

```ts
import { signal } from '@angular/core';

export class TaskCounter {
  count = signal(0);
}
```

### Lire un signal

⚠️ **Piège fréquent** : un signal ne se lit pas comme une variable classique. Il faut **l'appeler comme une fonction**, avec des parenthèses :

```html
<p>Tâches ajoutées : {{ count() }}</p>
```

```ts
console.log(this.count()); // et pas this.count !
```

`count` (sans parenthèses) est le signal lui-même (l'objet). `count()` (avec parenthèses) est **la valeur actuelle** qu'il contient.

### Modifier un signal — `set()`

**Pourquoi** : quand on connaît directement la nouvelle valeur à appliquer.

```ts
reset() {
  this.count.set(0);
}
```

### Modifier un signal — `update()`

**Pourquoi** : quand la nouvelle valeur dépend de l'ancienne (comme un incrément). `update()` reçoit la valeur actuelle et renvoie la nouvelle.

```ts
increment() {
  this.count.update(current => current + 1);
}
```

💡 **Bon à savoir** : `set()` et `update()` font parfois la même chose (`this.count.set(this.count() + 1)` équivaut à `this.count.update(c => c + 1)`), mais `update()` est plus sûr et plus lisible quand on dépend de la valeur précédente.

### Démo complète — compteur de tâches DevTask

```ts
import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-task-counter',
  standalone: true,
  template: `
    <p>Tâches ajoutées : {{ count() }}</p>
    <button (click)="increment()">Ajouter une tâche</button>
    <button (click)="reset()">Réinitialiser</button>
  `
})
export class TaskCounter {
  count = signal(0);

  increment() {
    this.count.update(current => current + 1);
  }

  reset() {
    this.count.set(0);
  }
}
```

### 📝 Exercice 6 — Compteur DevTask (10 min)

**Consigne** : Crée un composant `TaskCounter` avec un signal `count`, un bouton "+1" (`update()`) et un bouton "Reset" (`set()`).

### ✅ Correction
*(voir démo ci-dessus — c'est exactement cette structure)*

---

### Signals sur un tableau — ajouter des tâches

Un signal peut contenir n'importe quel type de valeur, y compris un tableau d'objets :

```ts
type Task = { id: number; title: string; done: boolean };

export class TaskList {
  tasks = signal<Task[]>([
    { id: 1, title: "Corriger le bug #42", done: false }
  ]);

  addTask(title: string) {
    this.tasks.update(current => [
      ...current,
      { id: Date.now(), title, done: false }
    ]);
  }
}
```
```html
@for (task of tasks(); track task.id) {
  <p>{{ task.title }}</p>
}
```

⚠️ **Piège fréquent** : ne jamais faire `this.tasks().push(newTask)` directement. Un signal doit être modifié via `set()` ou `update()`, jamais en modifiant son contenu "en cachette" — sinon Angular ne détecte pas le changement. C'est pour ça qu'on recrée un nouveau tableau avec `[...current, newTask]` plutôt que de modifier l'ancien.

### 🎯 Et `computed()` ?

**Pourquoi** : parfois, une valeur se **déduit** d'un ou plusieurs signals, sans qu'on ait besoin de la gérer manuellement. Exemple : le nombre de tâches restantes.

```ts
tasks = signal<Task[]>([...]);

remainingCount = computed(() =>
  this.tasks().filter(t => !t.done).length
);
```
```html
<p>{{ remainingCount() }} tâche(s) restante(s)</p>
```

La différence essentielle avec un signal classique : **on ne modifie jamais un `computed()` directement** (pas de `.set()` ni `.update()`). Il se recalcule automatiquement, tout seul, chaque fois qu'un signal dont il dépend change.

```
tasks change
      ↓
remainingCount se recalcule automatiquement
      ↓
Le template affichant remainingCount() se met à jour
```

💡 **Bon à savoir** : n'utilisez `computed()` que pour des valeurs **dérivées** d'autres signals. Si vous avez besoin de stocker une donnée modifiable directement par l'utilisateur, c'est un `signal()` classique qu'il vous faut, pas un `computed()`.

### 📝 Exercice 7 — TP récap Signals (20 min)

**Consigne** : Dans le composant `TaskList` de DevTask :
1. Un signal `tasks` (tableau de `Task` avec `id`, `title`, `done`).
2. Une méthode `addTask(title: string)` qui ajoute une nouvelle tâche (`update()`).
3. Une méthode `toggleDone(id: number)` qui bascule le `done` d'une tâche précise.
4. Un `computed()` `remainingCount` qui compte les tâches non terminées.
5. Affiche la liste, le compteur, et un bouton par tâche pour la basculer.

### ✅ Correction

```ts
type Task = { id: number; title: string; done: boolean };

export class TaskList {
  tasks = signal<Task[]>([
    { id: 1, title: "Corriger le bug #42", done: false },
    { id: 2, title: "Écrire les tests", done: true },
  ]);

  remainingCount = computed(() =>
    this.tasks().filter(t => !t.done).length
  );

  addTask(title: string) {
    this.tasks.update(current => [
      ...current,
      { id: Date.now(), title, done: false }
    ]);
  }

  toggleDone(id: number) {
    this.tasks.update(current =>
      current.map(t => t.id === id ? { ...t, done: !t.done } : t)
    );
  }
}
```
```html
<p>{{ remainingCount() }} tâche(s) restante(s)</p>

@for (task of tasks(); track task.id) {
  <div class="task">
    <span>{{ task.done ? '✅' : '⏳' }}</span>
    <span>{{ task.title }}</span>
    <button (click)="toggleDone(task.id)">Basculer</button>
  </div>
}
```

🎯 **Résumé du chapitre** :
```
signal(valeur)     → créer une valeur réactive
maSignal()         → LIRE la valeur (toujours avec les parenthèses)
maSignal.set(x)    → REMPLACER la valeur
maSignal.update(fn) → CALCULER la nouvelle valeur à partir de l'ancienne
computed(() => ...) → une valeur dérivée, en lecture seule, recalculée automatiquement
```

---

## 🏁 Fin du Jour 1 — Récapitulatif

Aujourd'hui, DevTask a appris à :
- s'organiser en composants (structure LEGO) ;
- afficher et réagir grâce au binding (`{{ }}`, `[ ]`, `( )`) ;
- afficher des listes et des conditions (`@if`, `@for`, `@switch`) ;
- réagir automatiquement aux changements de données grâce aux Signals.

```
App
├── TaskCounter   (signal : count)
└── TaskList      (signal : tasks, computed : remainingCount)
    └── @for → affichage de chaque tâche
```

Demain (Jour 2), DevTask va apprendre à avoir **plusieurs pages**, à **organiser sa logique dans des services**, et à **récupérer ses tâches depuis un vrai serveur**.


---

# JOUR 2 — CONSTRUIRE UNE VRAIE APPLICATION

## 10. Communication entre composants — `input()` / `output()`

### Le problème

Hier, `TaskList` affichait directement chaque tâche avec `@for`. Mais dans une vraie application, on veut un composant `TaskItem` séparé et réutilisable (rappelez-vous le schéma LEGO du chapitre 6) :

```
TaskList (parent)
└── TaskItem (enfant) ×3
```

Deux questions se posent immédiatement :
1. Comment le parent (`TaskList`) **donne** une tâche à chaque enfant (`TaskItem`) ?
2. Comment l'enfant **prévient** le parent quand on clique sur "Supprimer" (puisque c'est le parent qui détient la liste complète) ?

C'est exactement le rôle d'`input()` et `output()`.

### Schéma général

```
TaskList (parent)
      │
      │  input()  → donne les données à l'enfant
      ↓
TaskItem (enfant)
      │
      │  output() → prévient le parent d'un événement
      ↑
TaskList (parent)
```

### 10.1 `input()` — recevoir une donnée du parent

```ts
// task-item.ts
import { Component, input } from '@angular/core';

@Component({
  selector: 'app-task-item',
  standalone: true,
  template: `<p>{{ title() }}</p>`
})
export class TaskItem {
  title = input.required<string>();
}
```

`input.required<string>()` veut dire : *"ce composant a OBLIGATOIREMENT besoin qu'on lui fournisse un titre (texte)."* Si on oublie de le fournir, Angular affiche une erreur à la compilation.

Côté parent :
```html
<!-- task-list.html -->
<app-task-item [title]="'Corriger le bug #42'" />
```

Ou dynamiquement, dans une boucle :
```html
@for (task of tasks(); track task.id) {
  <app-task-item [title]="task.title" />
}
```

⚠️ **Piège fréquent** : comme un signal, un `input()` se lit **avec des parenthèses** dans le template (`title()`), pas juste `title`.

### 10.2 `output()` — prévenir le parent d'un événement

```ts
// task-item.ts
import { Component, input, output } from '@angular/core';

@Component({
  selector: 'app-task-item',
  standalone: true,
  template: `
    <p>{{ title() }}</p>
    <button (click)="onDeleteClick()">Supprimer</button>
  `
})
export class TaskItem {
  title = input.required<string>();
  id = input.required<number>();
  deleteRequested = output<number>();

  onDeleteClick() {
    this.deleteRequested.emit(this.id());
  }
}
```

Côté parent, on écoute cet événement comme n'importe quel event binding :
```html
<!-- task-list.html -->
@for (task of tasks(); track task.id) {
  <app-task-item
    [title]="task.title"
    [id]="task.id"
    (deleteRequested)="onDelete($event)" />
}
```
```ts
// task-list.ts
onDelete(id: number) {
  this.tasks.update(current => current.filter(t => t.id !== id));
}
```

### Schéma récapitulatif

```
Parent (TaskList)                    Enfant (TaskItem)
──────────────────                   ──────────────────
[title]="task.title"    ──input()──→  title = input.required<string>()

(deleteRequested)="onDelete($event)" ←──output()── deleteRequested.emit(id)
```

💡 **Bon à savoir** : `$event` dans le template parent contient automatiquement la valeur envoyée par `.emit(...)` côté enfant. Si l'enfant fait `deleteRequested.emit(this.id())`, alors `$event` vaut cet `id`.

### 📝 Exercice 8 — Séparer TaskItem de TaskList (20 min)

**Consigne** :
1. Dans `TaskItem`, ajoute `title` et `id` en `input.required`, et un `output()` `deleteRequested`.
2. Ajoute un bouton "Supprimer" qui émet `deleteRequested` avec l'`id` de la tâche.
3. Dans `TaskList`, boucle sur `tasks()` avec `@for`, utilise `<app-task-item>` pour chaque tâche, et écoute `(deleteRequested)` pour retirer la tâche du signal.

### ✅ Correction
*(voir code complet ci-dessus — c'est exactement cette structure)*

🎯 **Résumé du chapitre** : `input()` fait descendre une donnée du parent vers l'enfant. `output()` fait remonter un événement de l'enfant vers le parent. Les deux se lisent/déclenchent toujours avec des parenthèses côté TypeScript.


---

## 11. Les services et l'injection de dépendances

### Le problème

Actuellement, `TaskList` fait tout : elle détient les tâches, sait comment les ajouter, les supprimer... Que se passe-t-il si `TaskCounter` (un autre composant) a aussi besoin d'accéder à cette même liste de tâches ?

```
TaskList          TaskCounter
────────          ───────────
tasks = [...]     tasks = [...] ??
```

Si chaque composant a sa propre copie des tâches, elles ne seront jamais synchronisées entre elles. Il faut un **endroit unique** où vit la donnée, partagé par tous les composants qui en ont besoin.

### La solution : un service

**Pourquoi sortir la logique d'un composant ?** Un composant devrait se concentrer sur **l'affichage**. La logique de données (stocker, ajouter, appeler une API...) devrait vivre ailleurs, dans un endroit partageable.

```
Sans service                         Avec service
─────────────                        ────────────
TaskList détient les tâches          TaskService détient les tâches
TaskCounter ne peut pas y accéder            ↓
                                      TaskList ET TaskCounter
                                      utilisent le MÊME service
```

### Créer un service

```bash
ng generate service task
# ou : ng g s task
```

```ts
// task.service.ts
import { Injectable, signal, computed } from '@angular/core';

type Task = { id: number; title: string; done: boolean };

@Injectable({ providedIn: 'root' })
export class TaskService {
  tasks = signal<Task[]>([
    { id: 1, title: "Corriger le bug #42", done: false }
  ]);

  remainingCount = computed(() =>
    this.tasks().filter(t => !t.done).length
  );

  addTask(title: string) {
    this.tasks.update(current => [
      ...current,
      { id: Date.now(), title, done: false }
    ]);
  }

  deleteTask(id: number) {
    this.tasks.update(current => current.filter(t => t.id !== id));
  }
}
```

`@Injectable({ providedIn: 'root' })` veut dire : *"ce service existe en un seul exemplaire, partagé par toute l'application."*

### Qu'est-ce que l'injection de dépendances ?

**Le problème sans injection** : si `TaskList` avait besoin de créer elle-même son `TaskService` (`new TaskService()`), et que `TaskCounter` faisait pareil, on retomberait sur deux instances séparées, donc deux listes de tâches différentes.

**L'injection de dépendances** : au lieu que chaque composant **crée** ses propres outils, Angular les **fournit** automatiquement, en garantissant que tout le monde reçoit **la même instance**.

```
Sans injection                       Avec injection
───────────────                      ───────────────
TaskList crée son TaskService        Angular fournit LE MÊME
TaskCounter crée un AUTRE            TaskService à tous ceux
TaskService                          qui en font la demande
      ↓                                     ↓
Deux instances différentes           Une seule instance partagée
= données désynchronisées            = données toujours cohérentes
```

### Pourquoi `inject()` ?

`inject()` est la façon moderne de demander à Angular de nous fournir un service :

```ts
import { Component, inject } from '@angular/core';
import { TaskService } from './task.service';

@Component({ /* ... */ })
export class TaskList {
  private taskService = inject(TaskService);

  // On utilise directement les signals du service :
  tasks = this.taskService.tasks;
  remainingCount = this.taskService.remainingCount;

  addTask(title: string) {
    this.taskService.addTask(title);
  }
}
```

💡 **Bon à savoir** : avant, l'injection se faisait uniquement via le constructeur (`constructor(private taskService: TaskService) {}`). `inject()` fait la même chose, mais peut être utilisé n'importe où dans la classe, pas seulement dans le constructeur — c'est la manière recommandée aujourd'hui.

### 📝 Exercice 9 — Créer TaskService (20 min)

**Consigne** :
1. Génère un `TaskService` avec `providedIn: 'root'`.
2. Déplace le signal `tasks`, le `computed remainingCount`, et les méthodes `addTask`/`deleteTask` dedans.
3. Dans `TaskList`, injecte le service via `inject()` et utilise-le pour afficher/modifier la liste.
4. Crée un composant `TaskCounter` qui injecte **le même service** et affiche `remainingCount()`.
5. Vérifie que quand tu ajoutes une tâche depuis `TaskList`, le compteur dans `TaskCounter` se met à jour automatiquement — preuve que c'est bien la même donnée partagée.

### ✅ Correction
*(voir code du service ci-dessus, injecté de façon identique dans les deux composants)*

🎯 **Résumé du chapitre** : un service centralise une logique partagée. `@Injectable({ providedIn: 'root' })` en fait une instance unique pour toute l'app. `inject()` permet à n'importe quel composant d'accéder à cette même instance.


---

## 12. Le routing

### Le problème

Pour l'instant, DevTask n'a qu'une seule page. Une vraie application a généralement plusieurs écrans : la liste des tâches, une page "Statistiques", une page de détail d'une tâche...

**Pourquoi ne pas juste faire un site multi-pages classique**, comme en HTML pur (plusieurs fichiers `.html`) ? Parce qu'à chaque changement de page, le navigateur rechargerait **toute** l'application depuis zéro : re-télécharger le JS, ré-exécuter `bootstrapApplication()`, perdre l'état en mémoire... Lent, et une mauvaise expérience utilisateur.

### La solution : la SPA (Single Page Application)

Angular reste sur **une seule vraie page HTML** (on l'a vu au chapitre 2 — c'est `index.html`), mais **change le contenu affiché** dynamiquement, sans jamais recharger la page.

```
Site multi-pages classique           SPA (Angular)
───────────────────────────          ─────────────
Clic sur un lien                     Clic sur un lien
      ↓                                    ↓
Requête HTTP vers un                 Angular détecte l'URL
NOUVEAU fichier .html                      ↓
      ↓                              Il échange juste le
Rechargement complet                 composant affiché
de la page                                 ↓
                                      Pas de rechargement,
                                      c'est instantané
```

### Pourquoi un routeur ?

Le **routeur** est le composant d'Angular chargé de faire correspondre une URL (`/tasks`, `/stats`...) à un composant à afficher.

### Configurer les routes

```ts
// app.routes.ts
import { Routes } from '@angular/router';
import { TaskList } from './task-list/task-list';
import { Stats } from './stats/stats';

export const routes: Routes = [
  { path: '', component: TaskList },
  { path: 'stats', component: Stats },
];
```

```ts
// app.config.ts
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';

export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes)]
};
```

### Pourquoi `RouterOutlet` ?

**Le problème** : une fois qu'Angular sait "quel composant afficher pour telle URL", il faut bien un endroit **dans le HTML** où l'afficher.

```html
<!-- app.html -->
<nav>...</nav>

<router-outlet />
```

`<router-outlet />` est un emplacement réservé : Angular y insère automatiquement le composant correspondant à l'URL actuelle.

```
URL = "/"        →  <router-outlet /> affiche  →  TaskList
URL = "/stats"   →  <router-outlet /> affiche  →  Stats
```

### Pourquoi `RouterLink` ?

**Le problème** : pourquoi ne pas utiliser un simple `<a href="/stats">` ? Parce qu'un `<a href>` classique déclenche un **vrai rechargement de page** par le navigateur — exactement ce qu'on essaie d'éviter avec une SPA !

`RouterLink` intercepte le clic et laisse **Angular** gérer le changement d'URL, sans recharger la page :

```html
<nav>
  <a routerLink="/">Mes tâches</a>
  <a routerLink="/stats">Statistiques</a>
</nav>
```

### Schéma complet

```
Clic sur <a routerLink="/stats">
        ↓
Angular intercepte le clic (pas de rechargement)
        ↓
Le routeur met à jour l'URL en /stats
        ↓
Le routeur cherche la route correspondante
        ↓
<router-outlet /> affiche le composant Stats
```

### 📝 Exercice 10 — Navbar DevTask (20 min)

**Consigne** :
1. Crée un composant `Stats` (contenu simple, ex : "Page statistiques à venir").
2. Configure `app.routes.ts` avec deux routes : `''` → `TaskList`, `'stats'` → `Stats`.
3. Dans `app.html`, ajoute une navbar avec deux `routerLink`, et un `<router-outlet />`.
4. Vérifie que cliquer entre les deux liens change le contenu **sans recharger la page** (regarde l'URL changer sans "flash" blanc).

### ✅ Correction
*(voir code ci-dessus — structure exacte attendue)*

🎯 **Résumé du chapitre** : une SPA change de contenu sans recharger la page. Le routeur associe une URL à un composant. `<router-outlet />` est l'emplacement d'affichage. `routerLink` remplace `href` pour ne jamais déclencher de vrai rechargement.


---

## 13. HttpClient et les appels API

### Le problème

Jusqu'ici, les tâches de DevTask sont créées "en dur" dans le service, et disparaissent au rechargement de la page (elles ne vivent qu'en mémoire, dans le navigateur). Une vraie application doit pouvoir récupérer ses données depuis un serveur.

Vous savez déjà faire un `fetch()` en JavaScript pur. Angular propose son propre outil, `HttpClient`, intégré à son système de signals/services, pour rester cohérent avec le reste du framework.

💡 **Bon à savoir** : dans ce cours, on ne fait que des requêtes **GET** (récupérer des données) — pas de POST/PUT/DELETE. On utilise **JSONPlaceholder**, une fausse API publique faite pour s'entraîner (`https://jsonplaceholder.typicode.com`).

### Le trajet complet d'une donnée

```
Composant
    ↓ demande les tâches
Service
    ↓ utilise
HttpClient
    ↓ envoie une requête GET
API (JSONPlaceholder)
    ↓ répond
JSON
    ↓ rangé dans
Signal
    ↓ affiché dans
Template
```

Chaque étape a un rôle précis : le composant ne parle jamais directement à l'API — il passe toujours par le service, qui utilise `HttpClient`.

### Activer HttpClient

```ts
// app.config.ts
import { provideHttpClient } from '@angular/common/http';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideHttpClient()
  ]
};
```

### Faire une requête GET dans le service

```ts
// task.service.ts
import { Injectable, inject, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';

type RemoteTask = { id: number; title: string; completed: boolean };

@Injectable({ providedIn: 'root' })
export class TaskService {
  private http = inject(HttpClient);

  tasks = signal<RemoteTask[]>([]);

  loadTasks() {
    this.http
      .get<RemoteTask[]>('https://jsonplaceholder.typicode.com/todos?_limit=10')
      .subscribe(data => {
        this.tasks.set(data);
      });
  }
}
```

**Pourquoi `.subscribe()` ?** `HttpClient` ne renvoie pas directement le résultat (contrairement à une Promise avec `await`). Il renvoie un **Observable**, une sorte de "flux" auquel on doit s'abonner (`subscribe`) pour être prévenu quand la réponse arrive.

💡 **Bon à savoir** : vous connaissez déjà `fetch().then(...)`. `.subscribe(data => ...)` joue exactement le même rôle que le `.then(...)` : "quand la réponse arrive, fais ceci avec les données."

### Déclencher le chargement depuis un composant

```ts
// task-list.ts
import { Component, inject, OnInit } from '@angular/core';
import { TaskService } from './task.service';

@Component({ /* ... */ })
export class TaskList implements OnInit {
  private taskService = inject(TaskService);
  tasks = this.taskService.tasks;

  ngOnInit() {
    this.taskService.loadTasks();
  }
}
```

`ngOnInit()` est une méthode spéciale, appelée automatiquement par Angular **une seule fois**, juste après la création du composant — l'endroit idéal pour déclencher un chargement de données.

```html
@for (task of tasks(); track task.id) {
  <p>{{ task.title }}</p>
} @empty {
  <p>Chargement...</p>
}
```

⚠️ **Piège fréquent** : appeler `loadTasks()` directement dans le constructeur plutôt que dans `ngOnInit()`. Ça peut sembler marcher, mais `ngOnInit()` est le bon endroit conventionnel — le composant est alors complètement initialisé (inputs disponibles, etc.), ce qui n'est pas garanti dans le constructeur.

### 📝 Exercice 11 — Charger les tâches depuis JSONPlaceholder (25 min)

**Consigne** :
1. Active `provideHttpClient()` dans `app.config.ts`.
2. Dans `TaskService`, ajoute une méthode `loadTasks()` qui appelle `GET https://jsonplaceholder.typicode.com/todos?_limit=10` et range le résultat dans un signal.
3. Dans `TaskList`, appelle `loadTasks()` dans `ngOnInit()`.
4. Affiche la liste réelle venant de l'API avec `@for`.
5. Affiche "Chargement..." tant que la liste est vide (`@empty`).

### ✅ Correction
*(voir code complet ci-dessus)*

🎯 **Résumé du chapitre** : `HttpClient` fait des requêtes vers une API depuis un service. `.subscribe()` réagit à la réponse (comme `.then()` pour une Promise). On range toujours le résultat dans un signal, jamais utilisé directement dans le template. `ngOnInit()` est l'endroit conventionnel pour déclencher un chargement de données.


---

## 14. Assemblage final — DevTask au complet

### Le problème

On a vu chaque brique séparément : composants, binding, directives, signals, input/output, services, routing, HttpClient. Il est temps de voir comment elles s'assemblent **ensemble** dans une seule application cohérente.

### Architecture finale de DevTask

```
App (racine, avec navbar + <router-outlet />)
│
├── Route "" → TaskListPage
│                 │
│                 ├── injecte TaskService (inject())
│                 ├── appelle loadTasks() dans ngOnInit()
│                 │
│                 └── TaskItem (×N, via @for)
│                       ├── input() : title, id, done
│                       └── output() : deleteRequested, toggleRequested
│
└── Route "stats" → StatsPage
                      └── injecte TaskService (même instance !)
                            └── affiche remainingCount() (computed)


TaskService (providedIn: 'root')
├── http = inject(HttpClient)
├── tasks = signal<Task[]>([])
├── remainingCount = computed(...)
├── loadTasks()   → GET vers JSONPlaceholder
├── deleteTask(id)
└── toggleDone(id)
```

### Le trajet complet d'une action utilisateur

Prenons l'exemple concret d'un clic sur "Supprimer" une tâche, pour bien voir comment **toutes** les notions du cours s'enchaînent :

```
1. L'utilisateur clique sur le bouton "Supprimer"
   dans TaskItem
        ↓
2. (click)="onDeleteClick()"           ← event binding (ch.7)
        ↓
3. deleteRequested.emit(this.id())     ← output() (ch.10)
        ↓
4. Le parent TaskListPage reçoit l'événement
   (deleteRequested)="onDelete($event)" ← output() côté parent (ch.10)
        ↓
5. onDelete(id) appelle
   this.taskService.deleteTask(id)     ← service + inject() (ch.11)
        ↓
6. Le service met à jour le signal :
   this.tasks.update(current =>
     current.filter(t => t.id !== id)) ← signal (ch.9)
        ↓
7. Angular détecte le changement du signal
        ↓
8. @for se met à jour automatiquement   ← directive (ch.8)
        ↓
9. remainingCount (computed) se
   recalcule automatiquement            ← computed (ch.9)
        ↓
10. StatsPage affiche le nouveau total,
    sans qu'on ait rien fait de spécial
    (même service, même signal partagé) ← inject() (ch.11)
```

C'est exactement ce genre d'enchaînement automatique — une action déclenche une mise à jour de donnée, qui se propage toute seule partout où elle est utilisée — qui est **la vraie force** d'Angular moderne avec les Signals.

### 📝 Exercice final — DevTask complet (45-60 min)

**Consigne** : Assemble une version complète de DevTask avec :
1. `TaskService` : signal `tasks`, `computed remainingCount`, `loadTasks()` (GET JSONPlaceholder), `deleteTask(id)`, `toggleDone(id)`.
2. `TaskItem` : `input()` pour `title`/`id`/`done`, `output()` pour `deleteRequested` et `toggleRequested`.
3. `TaskListPage` : injecte le service, charge les tâches dans `ngOnInit()`, boucle avec `@for`, écoute les events des `TaskItem`.
4. `StatsPage` : injecte le **même** `TaskService`, affiche `remainingCount()`.
5. Navbar avec `routerLink` vers les deux pages, `<router-outlet />` dans `App`.

### ✅ Correction

La correction complète suit exactement la structure du schéma d'architecture ci-dessus — chaque brique reprend le code déjà vu dans les chapitres 9 à 13. Si un point bloque, relis le chapitre correspondant : chaque notion a été vue isolément avant cet exercice d'assemblage.

---

## 🏁 Bilan général de la formation

### Ce que vous savez faire maintenant

```
✅ Comprendre pourquoi et comment Angular démarre une application
✅ Lire et écrire du TypeScript de base (types, type vs interface,
   readonly/private/public, fonctions)
✅ Découper une application en composants réutilisables
✅ Utiliser les 3 types de binding ({{ }}, [ ], ( ))
✅ Afficher des conditions et des listes (@if, @for, @switch)
✅ Gérer un état réactif avec les Signals (signal, set, update, computed)
✅ Faire communiquer un parent et un enfant (input, output)
✅ Centraliser une logique dans un service (inject, injection de
   dépendances)
✅ Construire une SPA avec plusieurs pages (routing, RouterOutlet,
   RouterLink)
✅ Récupérer des données depuis une API (HttpClient, GET, subscribe)
```

### Pour aller plus loin (hors de ce cours)

- Les formulaires (template-driven / reactive forms)
- Les requêtes POST / PUT / DELETE
- Les tests unitaires (Jasmine/Jest)
- Les guards de routing et les intercepteurs HTTP
- `computed()` avec des dépendances multiples et des cas plus avancés
- `interface` en détail, les génériques TypeScript
- La gestion d'état avancée (signals store, NgRx signals)

🎯 **Dernier mot** : vous avez maintenant construit, brique par brique, une vraie petite application Angular moderne — DevTask — en comprenant **pourquoi** chaque notion existe, pas seulement **comment** l'écrire. C'est cette compréhension du "pourquoi" qui vous permettra d'aborder n'importe quel nouveau concept Angular par vous-mêmes, à l'avenir.