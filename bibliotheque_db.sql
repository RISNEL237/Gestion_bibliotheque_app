-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : jeu. 30 avr. 2026 à 19:04
-- Version du serveur : 10.4.25-MariaDB
-- Version de PHP : 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `bibliotheque_db`
--

--
-- Déchargement des données de la table `livres`
--

INSERT INTO `livres` (`id_livre`, `titre`, `auteur`, `annee_publication`, `genre`, `isbn`, `quantite`, `date_creation`, `idcategorie`) VALUES
(1, 'Le Petit Prince', 'Antoine de Saint-Exupery', 1943, 'Conte', '978-2-07-040850-4', 5, '2026-04-27 09:54:00', NULL),
(3, 'Les Miserables', 'Victor Hugo', 1862, 'Roman', '978-2-01-323971-0', 2, '2026-04-27 09:54:00', NULL),
(4, 'L’Etranger', 'Albert Camus', 1942, 'Roman', '978-2-07-036002-4', 4, '2026-04-27 09:54:00', NULL),
(6, 'Notre-Dame de Paris', 'Victor Hugo', 1831, 'Roman', '978-2-07-036002-6', 3, '2026-04-27 09:54:00', NULL),
(8, 'Vingt Mille Lieues sous les Mers', 'Jules Verne', 1870, 'Aventure', '978-2-07-036002-8', 2, '2026-04-27 09:54:00', NULL),
(10, 'trois pretendant un mari', 'guillaume oyono mbiya', 1543, 'Roman', '978-2-222-42442-7', 7, '2026-04-30 14:54:44', NULL),
(11, 'les tribus de capitoline', 'pc ombette belle', 1967, 'Roman', '978-2-222-43445-7', 43, '2026-04-30 15:14:15', NULL),
(12, 'sous la cendre le feu', 'evelyne mpoundi ngolle', 1788, 'Roman', '978-2-222-42442-0', 5, '2026-04-30 15:37:08', NULL);

--
-- Déchargement des données de la table `utilisateurs`
--

INSERT INTO `utilisateurs` (`id_user`, `login`, `mot_passe`, `role`, `date_creation`) VALUES
(1, 'admin123', 'insagl2026', 'admin', '2026-04-30 16:58:06');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
