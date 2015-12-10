# Guide de développement

## Ajout d'une énigme

Les étapes d'ajout d'une énigme sont les suivantes :
  1. Ajouter d'une [issue](https://github.com/SteeveDroz/enigmos/issues) proposant l'idée de nouvelle énigme.
  2. Attendre que l'idée soit acceptée, reçoive un label **idée acceptée** et soit assignée.
  3. Développer l'énigme en ajoutant les éléments suivants au programme :
    1. Dans le sous-répertoire `/Enigmas`, ajouter un nouveau fichier portant le nom de la classe. La nouvelle classe doit avoir un nom se terminant par `EnigmaPanel` (Exemple : `SimpleEnigmaPanel`). Elle doit en outre hériter de `EnigmaPanel` (Avec la déclaration de classe `class SimpleEnigmaPanel : EnigmaPanel`).
    2. Si le développement d'un ou plusieurs composants est nécessaire, placer ceux-ci dans le sous-répertoire `/Enigmas/Components`.
    3. Dans la classe `EnigmaReferencer`, ajouter dans la méthode `ReferenceEnigmas` une nouvelle ligne qui ajoute la nouvelle énigme au jeu. Le titre de l'énigme doit être unique. Note : la méthode `DebugEnigma` permet de forcer l'affichage d'une énigme en particulier. Cette fonctionnalité est très utile en cours de développement.
    4. Dans le fichier `enigmas.xml`, ajouter un nouveau noeud selon le schéma ci-dessous :
      ```xml
      <enigma title="TITRE">
        <answer>RÉPONSE</answer>
        <hint>INDICE</hint>
      </enigma>
      ```
    5. Tester l'énigme afin d'éviter un maximum de bugs.
  4. Lorsque l'énigme est entièrement développée, effectuer un [pull request](https://github.com/SteeveDroz/enigmos/compare) afin de proposer l'implémentation de la nouvelle énigme.
  5. Si l'implémentation est refusée, suivre les instructions de modification et réitérer le pull request.

## Méthodes d'`EnigmaPanel`

Les méthodes ci-dessous peuvent être réimplémentées dans les classes dérivées, par exemple comme ceci :

```csharp
class OtherEnigmaPanel : EnigmaPanel
{
    // ...
    
    public override void Load()
    {
        // ...
    }
}
```

### `EnigmaPanel()`

Constructeur par défaut, fixe la taille de l'énigme à 800x600 et la couleur de fond à blanc. Il est possible de modifier ces deux valeurs.

### `void PressKey(object sender, KeyEventArgs e)`

Appelé lorsque l'utilisateur appuie sur une touche du clavier.

### `void ReleaseKey(object sender, KeyEventArgs e)`

Appelé lorsque l'utilisateur relâche une touche du clavier.

### `void Load()`

Appelé lorsque l'application affiche l'énigme à l'écran.

### `void Unload()`

Appelé lorsque l'application affiche une autre énigme.

## Mise en place de git pour Windows

  1. Effectuer un [fork](https://github.com/CPLN/enigmos#fork-destination-box) du repository (si ça n'a pas encore été fait) afin d'avoir une copie de travail personnelle sur github.
  2. Depuis son repository personnel, copier l'url de clonage situé dans la colonne de droite, sous _**HTTPS** clone url_.
  3. En local, ouvrir l'application GIT-GUI, soit par le menu Windows, soit avec un clic-droit dans un dossier ou sur le bureau.
  4. Choisir *Clone Existing Repository* et coller l'URL de clonage dans le premier champ.
  5. **Ajouter son nom d'utilisateur entre https:// et github. Exemple : https://MonPseudo@github.com/MonPseudo/mon-depot.git.** Sans cette action, git vous demandera votre nom d'utilisateur en plus de votre mot de passe à chaque connexion à github.
  6. Choisissez un emplacement local où stocker le projet.
  7. Dans la fenêtre qui apparait après validation, chosissez le menu *Remote -> Add* et ajoutez le repository principal. Son nom est **upstream** et son adresse est **https://github.com/CPLN/enigmos.git**.
  
