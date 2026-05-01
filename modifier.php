<?php
require_once 'config.php';
$pdo = getConnexion();
$error = '';
$success = '';

// Vérification de l'ID
if (!isset($_GET['id']) || empty($_GET['id'])) {
    header('Location: index.php');
    exit();
}

$id = (int) $_GET['id'];

// Traitement du formulaire
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    if (empty($_POST['titre']) || empty($_POST['auteur']) || empty($_POST['genre'])) {
        $error = "Tous les champs obligatoires doivent être remplis.";
    } else {
        try {
            $sql = "UPDATE livres 
                    SET titre = :titre, auteur = :auteur, annee_publication = :annee,
                        genre = :genre, isbn = :isbn, quantite = :quantite
                    WHERE id_livre = :id";
            
            $stmt = $pdo->prepare($sql);
            $isbn = !empty($_POST['isbn']) ? $_POST['isbn'] : null;

            $stmt->execute([
                ':id'       => $id,
                ':titre'    => htmlspecialchars($_POST['titre']),
                ':auteur'   => htmlspecialchars($_POST['auteur']),
                ':annee'    => (int) $_POST['annee_publication'],
                ':genre'    => $_POST['genre'],
                ':isbn'     => $isbn,
                ':quantite' => (int) $_POST['quantite']
            ]);

            $success = "Livre modifié avec succès";
            header('Location: index.php?message=' . urlencode($success));
            exit();

        } catch (PDOException $e) {
            $error = "Erreur lors de la modification : " . $e->getMessage();
        }
    }
}

// Récupération des données actuelles pour pré-remplir le formulaire
$sql = "SELECT * FROM livres WHERE id_livre = :id";
$stmt = $pdo->prepare($sql);
$stmt->execute([':id' => $id]);
$livre = $stmt->fetch();

if (!$livre) {
    header('Location: index.php');
    exit();
}
?>
<!DOCTYPE html>
<html lang="fr">
<head>
    <meta charset="UTF-8">
    <title>Modifier un livre</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
    <div class="container" style="max-width: 600px;">
        <div class="header">
            <h1>Modifier un livre</h1>
            <p><a href="index.php" style="color: white;">Retour à la liste</a></p>
        </div>

        <?php if ($error): ?>
            <div class="message message-error"><?php echo $error; ?></div>
        <?php endif; ?>

        <div class="content" style="grid-template-columns: 1fr;">
            <div class="form-section">
                <form method="POST">
                    <div class="form-group">
                        <label>Titre *</label>
                        <input type="text" name="titre" value="<?php echo htmlspecialchars($livre['titre']); ?>" required>
                    </div>
                    
                    <div class="form-group">
                        <label>Auteur *</label>
                        <input type="text" name="auteur" value="<?php echo htmlspecialchars($livre['auteur']); ?>" required>
                    </div>
                    
                    <div class="form-group">
                        <label>Année de publication *</label>
                        <input type="number" name="annee_publication" value="<?php echo $livre['annee_publication']; ?>" min="1400" max="2026" required>
                    </div>
                    
                    <div class="form-group">
                        <label>Genre *</label>
                        <select name="genre" required>
                            <option value="">-- Sélectionner --</option>
                            <?php 
                            $genres = ["Roman", "Science-fiction", "Conte", "Poésie", "Théâtre", "Policier", "Biographie", "Aventure"];
                            foreach($genres as $g) {
                                $selected = ($livre['genre'] == $g) ? 'selected' : '';
                                echo "<option value=\"$g\" $selected>$g</option>";
                            }
                            ?>
                        </select>
                    </div>
                    
                    <div class="form-group">
                        <label>ISBN</label>
                        <input type="text" name="isbn" value="<?php echo htmlspecialchars($livre['isbn'] ?? ''); ?>">
                    </div>
                    
                    <div class="form-group">
                        <label>Quantité</label>
                        <input type="number" name="quantite" value="<?php echo $livre['quantite']; ?>" min="0">
                    </div>
                    
                    <div class="form-buttons">
                        <button type="submit" class="btn btn-warning">Enregistrer</button>
                        <a href="index.php" class="btn btn-secondary">Annuler</a>
                    </div>
                </form>
            </div>
        </div>

        <div class="footer">
            <p>TALLA NGWANA - TP PHP / MySQL</p>
        </div>
    </div>
</body>
</html>
