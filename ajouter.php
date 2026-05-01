<?php
session_start(); // Obligatoire pour utiliser $_SESSION
require_once 'config.php';

function validerDonnees($data) {
    $errors = [];
    if (empty($data['titre'])) {
        $errors[] = "Le titre est obligatoire";
    }
    if (empty($data['auteur'])) {
        $errors[] = "L'auteur est obligatoire";
    }
    if (empty($data['annee_publication']) || !is_numeric($data['annee_publication'])) {
        $errors[] = "L'année doit être un nombre valide";
    } else {
        $annee = (int) $data['annee_publication'];
        if ($annee < 1400 || $annee > (int)date('Y')) {
            $errors[] = "L'année doit être comprise entre 1400 et " . date('Y');
        }
    }
    if (empty($data['genre'])) {
        $errors[] = "Le genre est obligatoire";
    }
    return $errors;
}

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $errors = validerDonnees($_POST);
    
    if (empty($errors)) {
        try {
            $pdo = getConnexion();
            $sql = "INSERT INTO livres (titre, auteur, annee_publication, genre, isbn, quantite)
                    VALUES (:titre, :auteur, :annee, :genre, :isbn, :quantite)";
            
            $stmt = $pdo->prepare($sql);
            
            $isbn = !empty($_POST['isbn']) ? $_POST['isbn'] : null;
            $quantite = !empty($_POST['quantite']) ? (int)$_POST['quantite'] : 1;

            $stmt->execute([
                ':titre'    => htmlspecialchars($_POST['titre']),
                ':auteur'   => htmlspecialchars($_POST['auteur']),
                ':annee'    => (int)$_POST['annee_publication'],
                ':genre'    => $_POST['genre'], // Suppression de l'espace après 'genre'
                ':isbn'     => $isbn,
                ':quantite' => $quantite
            ]);

            header('Location: index.php?message=' . urlencode('Livre ajouté avec succès'));
            exit();

        } catch (PDOException $e) {
            // 23000 = Erreur de duplication (souvent l'ISBN)
            if ($e->getCode() == 23000) {
                $error = "Un livre avec cet ISBN existe déjà";
            } else {
                $error = "Erreur technique : " . $e->getMessage();
            }
        }
    } else {
        $error = implode("<br>", $errors);
    }

    // Si on arrive ici, c'est qu'il y a eu une erreur
    if (isset($error)) {
        $_SESSION['error'] = $error;
        header('Location: index.php');
        exit();
    }
} else {
    header('Location: index.php');
    exit();
}
?>
