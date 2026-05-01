<?php 
require_once 'config.php';
$pdo = getConnexion();

// --- 1. LOGIQUE DE RECHERCHE ET RÉCUPÉRATION ---
$livres = [];
if (isset($_GET['rechercher']) && !empty($_GET['lblrechercher'])) {
    $search = '%' . $_GET['lblrechercher'] . '%';
    $sql = "SELECT * FROM livres WHERE titre LIKE :s1 OR auteur LIKE :s2 ORDER BY titre ASC";
    $stmt = $pdo->prepare($sql);
    $stmt->execute([':s1' => $search, ':s2' => $search]);
    $livres = $stmt->fetchAll();
} else {
    $stmt = $pdo->query("SELECT * FROM livres ORDER BY titre ASC");
    $livres = $stmt->fetchAll();
}

// --- 2. CALCUL DES STATISTIQUES ---
// Nombre total de livres et quantité totale
$statsGenerales = $pdo->query("SELECT COUNT(*) as total_titres, SUM(quantite) as total_exemplaires FROM livres")->fetch();

// Livre le plus ancien et le plus récent
$ancien = $pdo->query("SELECT titre, annee_publication FROM livres ORDER BY annee_publication ASC LIMIT 1")->fetch();
$recent = $pdo->query("SELECT titre, annee_publication FROM livres ORDER BY annee_publication DESC LIMIT 1")->fetch();

// Auteur le plus représenté
$auteurTop = $pdo->query("SELECT auteur, COUNT(*) as nb FROM livres GROUP BY auteur ORDER BY nb DESC LIMIT 1")->fetch();

// Nombre de livres par genre (pour le graphique)
$genresData = $pdo->query("SELECT genre, COUNT(*) as nb FROM livres GROUP BY genre")->fetchAll();
$labels = [];
$counts = [];
foreach($genresData as $row) {
    $labels[] = $row['genre'];
    $counts[] = $row['nb'];
}
?>
<!DOCTYPE html>
<html lang="fr">
<head>
    <meta charset="UTF-8">
    <title>Bibliothèque - Tableau de bord</title>
    <link rel="stylesheet" href="style.css">
    <!-- Import de Chart.js -->
    <script src="https://jsdelivr.net"></script>
</head>
<body>
<div class="container">
    <div class="header">
        <h1>Tableau de bord de la Bibliothèque</h1>
    </div>

    <!-- --- SECTION STATISTIQUES --- -->
    <div class="stats-grid">
        <div class="stat-card">
            <h3>Total Titres</h3>
            <p><?php echo $statsGenerales['total_titres']; ?></p>
        </div>
        <div class="stat-card">
            <h3>Total Exemplaires</h3>
            <p><?php echo $statsGenerales['total_exemplaires'] ?? 0; ?></p>
        </div>
        <div class="stat-card">
            <h3>Auteur Phare</h3>
            <p><?php echo $auteurTop['auteur'] ?? 'N/A'; ?> (<?php echo $auteurTop['nb'] ?? 0; ?>)</p>
        </div>
        <div class="stat-card">
            <h3>Plus Ancien / Récent</h3>
            <p><?php echo ($ancien['annee_publication'] ?? '-') . " / " . ($recent['annee_publication'] ?? '-'); ?></p>
        </div>
    </div>

    <!-- --- GRAPHIQUE CHART.JS --- -->
    <div class="chart-container">
        <h2 style="text-align:center">Répartition par Genre</h2>
        <canvas id="genreChart" style="max-height: 300px;"></canvas>
    </div>

    <!-- Barre de recherche -->
    <div class="search-bar">
        <form method="GET">
            <input type="text" name="lblrechercher" placeholder="Titre ou auteur..." value="<?php echo $_GET['lblrechercher'] ?? ''; ?>">
            <button type="submit" name="rechercher">Rechercher</button>
        </form>
    </div>

    <!-- Tableau (Ton code existant) -->
    <div class="table-section">
        <table>
            <thead>
                <tr><th>ID</th><th>Titre</th><th>Auteur</th><th>Année</th><th>Genre</th><th>Qte</th><th>Actions</th></tr>
            </thead>
            <tbody>
                <?php foreach($livres as $l): ?>
                <tr>
                    <td><?= $l['id_livre'] ?></td>
                    <td><?= htmlspecialchars($l['titre']) ?></td>
                    <td><?= htmlspecialchars($l['auteur']) ?></td>
                    <td><?= $l['annee_publication'] ?></td>
                    <td><?= $l['genre'] ?></td>
                    <td><?= $l['quantite'] ?></td>
                    <td>
                        <a href="modifier.php?id=<?= $l['id_livre'] ?>">Modifier</a>
                    </td>
                </tr>
                <?php endforeach; ?>
            </tbody>
        </table>
    </div>
</div>

<script>
// Configuration du graphique
const ctx = document.getElementById('genreChart').getContext('2d');
new Chart(ctx, {
    type: 'bar',
    data: {
        labels: <?php echo json_encode($labels); ?>,
        datasets: [{
            label: 'Nombre de livres',
            data: <?php echo json_encode($counts); ?>,
            backgroundColor: 'rgba(54, 162, 235, 0.6)',
            borderColor: 'rgba(54, 162, 235, 1)',
            borderWidth: 1
        }]
    },
    options: {
        scales: { y: { beginAtZero: true, ticks: { stepSize: 1 } } }
    }
});
</script>
</body>
</html>
