# Guide de développement

## Ajout d'une énigme

Les étapes d'ajout d'une énigme sont les suivantes :
  1. Ajouter d'une [issue](https://github.com/SteeveDroz/enigmos/issues) proposant l'idée de nouvelle énigme.
  2. Attendre que l'idée soit acceptée et reçoive un label **idée acceptée**. Alternativement, trouver une idée parmi celles proposées dans les [idées acceptées](https://github.com/SteeveDroz/enigmos/labels/idée acceptée) à condition qu'elle ne soit pas encore assignée.
  3. Développer l'énigme en ajoutant les éléments suivants au programme :
    1. Dans le sous-répertoire `Enigmas/`, ajouter un nouveau fichier portant le nom de la classe. La nouvelle classe doit avoir un nom se terminant par `EnigmaPanel` (Exemple : `SimpleEnigmaPanel`). Elle doit en outre hériter de `EnigmaPanel` (Avec la déclaration de classe `class SimpleEnigmaPanel : EnigmaPanel`).
    2. Si le développement d'un ou plusieurs composants est nécessaire, placer ceux-ci dans le sous-répertoire `Enigmas/Components`.
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
