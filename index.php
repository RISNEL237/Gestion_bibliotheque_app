<?php
require_once 'config.php';

// Initialisation de la connexion via ta fonction du config.php
$pdo = getConnexion(); 

// Fonction pour récupérer les livres avec filtrage PHP/SQL
function getLivres($pdo_conn, $search = '') {
    try {
        if (!empty($search)) {
            $sql = "SELECT * FROM livres 
                    WHERE titre LIKE :search 
                    OR auteur LIKE :search 
                    ORDER BY titre ASC";
            $stmt = $pdo_conn->prepare($sql);
            $stmt->execute([':search' => '%' . $search . '%']);
        } else {
            $sql = "SELECT * FROM livres ORDER BY titre ASC";
            $stmt = $pdo_conn->query($sql);
        }
        return $stmt->fetchAll();
    } catch (PDOException $e) {
        return [];
    }
}

// Logique de suppression intégrée
if (isset($_GET['action']) && $_GET['action'] == 'delete' && isset($_GET['id'])) {
    $id = $_GET['id'];
    $stmt = $pdo->prepare("DELETE FROM livres WHERE id_livre = :id");
    $stmt->execute([':id' => $id]);
    header('Location: index.php?message=Livre supprime');
    exit();
}

$recherche = isset($_GET['search']) ? $_GET['search'] : '';
$livres = getLivres($pdo, $recherche);
?>
<!DOCTYPE html>
<html lang="fr">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Bibliothèque - Gestion des livres</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
    <div class="container">
        <div class="header">
            <h1>Gestion de la Bibliothèque</h1>
            <p>Application complète CRUD en PHP & MySQL</p>
        </div>

        <?php if(isset($_GET['message'])): ?>
            <div class="message message-success">
                <?php echo htmlspecialchars($_GET['message']); ?>
            </div>
        <?php endif; ?>

        <!-- Barre de recherche modifiée pour fonctionner en PHP -->
        <div class="search-bar">
            <form action="index.php" method="GET" style="display: flex; width: 100%; gap: 10px;">
                <input type="text" name="search" id="searchInput" 
                       placeholder="Rechercher un livre par titre ou auteur..." 
                       value="<?php echo htmlspecialchars($recherche); ?>">
                <button type="submit">Rechercher</button>
                <button><a href="tableaudebord.php">tableau de bord</a></button>
                <?php if($recherche): ?>
                    <a href="index.php" class="btn btn-secondary" style="text-decoration: none; line-height: 35px; padding: 0 15px;">X</a>
                <?php endif; ?>
            </form>
        </div>

        <div class="content">
            <div class="form-section">
                <h2>Ajouter un nouveau livre</h2>
                <form action="ajouter.php" method="POST">
                    <div class="form-group">
                        <label>Titre *</label>
                        <input type="text" name="titre" required>
                    </div>
                    <div class="form-group">
                        <label>Auteur *</label>
                        <input type="text" name="auteur" required>
                    </div>
                    <div class="form-group">
                        <label>Annee de publication *</label>
                        <input type="number" name="annee_publication" min="1400" max="2026" required>
                    </div>
                    <div class="form-group">
                        <label>Genre *</label>
                        <select name="genre" required>
                            <option value="">-- Selectionner --</option>
                            <option value="Roman">Roman</option>
                            <option value="Science-fiction">Science-fiction</option>
                            <option value="Conte">Conte</option>
                            <option value="Poesie">Poésie</option>
                            <option value="Theatre">Théâtre</option>
                            <option value="Policier">Policier</option>
                            <option value="Biographie">Biographie</option>
                            <option value="Aventure">Aventure</option>
                        </select>
                    </div>
                    <div class="form-group">
                        <label>ISBN</label>
                        <input type="text" name="isbn" placeholder="Ex: 978-2-07-040850-4">
                    </div>
                    <div class="form-group">
                        <label>Quantite</label>
                        <input type="number" name="quantite" value="1" min="0">
                    </div>
                    <div class="form-buttons">
                        <button type="submit" class="btn btn-primary">Ajouter</button>
                        <button type="reset" class="btn btn-secondary">Effacer</button>
                    </div>
                </form>
            </div>

            <div class="table-section">
                <h2>Liste des livres</h2>
                <table id="livresTable">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Titre</th>
                            <th>Auteur</th>
                            <th>Annee</th>
                            <th>Genre</th>
                            <th>ISBN</th>
                            <th>Qte</th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        <?php if (count($livres) > 0): ?>
                            <?php foreach ($livres as $livre) : ?>
                            <tr>
                                <td><?php echo $livre['id_livre']; ?></td>
                                <td><?php echo htmlspecialchars($livre['titre']); ?></td>
                                <td><?php echo htmlspecialchars($livre['auteur']); ?></td>
                                <td><?php echo $livre['annee_publication']; ?></td>
                                <td><?php echo htmlspecialchars($livre['genre']); ?></td>
                                <td><?php echo htmlspecialchars($livre['isbn'] ?? '-'); ?></td>
                                <td><?php echo $livre['quantite']; ?></td>
                                <td class="action-buttons">
                                    <a href="modifier.php?id=<?php echo $livre['id_livre']; ?>" class="btn-edit">Modifier</a>
                                    <a href="index.php?action=delete&id=<?php echo $livre['id_livre']; ?>" 
                                       class="btn-delete" 
                                       onclick="return confirm('Supprimer ce livre ?')">Suppr</a>
                                </td>
                            </tr>
                            <?php endforeach; ?>
                        <?php else: ?>
                            <tr><td colspan="8" style="text-align:center;">Aucun livre trouvé.</td></tr>
                        <?php endif; ?>
                    </tbody>
                </table>
            </div>
                        </div>


        <div class="footer">
            <p>TALLA NGWANA - TP PHP / MySQL - Gestion de Bibliotheque</p>
        </div>
    </div>
</body>
</html>
