<?php
require_once 'config.php';

// Vérification de l'ID
if (!isset($_GET['id']) || empty($_GET['id'])) {
    header('Location: index.php');
    exit();
}

$id = (int) $_GET['id'];

try {
    $pdo = getConnexion();

    // Option 1: Suppression physique (efface définitivement)
    $sql = "DELETE FROM livres WHERE id_livre = :id";
    $stmt = $pdo->prepare($sql);
    $stmt->execute([':id' => $id]);

    $message = "Livre supprimé avec succès";

} catch (PDOException $e) {
    // Code 23000 correspond souvent à une violation de contrainte d'intégrité
    if ($e->getCode() == 23000) {
        $message = "Impossible de supprimer ce livre car il est référencé ailleurs (ex: un emprunt en cours)";
    } else {
        $message = "Erreur lors de la suppression : " . $e->getMessage();
    }
}

// Redirection avec le message
header('Location: index.php?message=' . urlencode($message));
exit();
?>
