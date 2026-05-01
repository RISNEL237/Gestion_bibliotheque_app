<?php
 define ('DB_HOST', 'localhost');
 define ('DB_NAME', 'bibliotheque_db');
 define ('DB_USER', 'root');
 define ('DB_PASS', '');
 define ('DB_CHARSET', 'utf8mb4');
function getConnexion(){
   /* $con=mysqli_connect(DB_HOST, DB_USER, DB_PASS, DB_NAME);
    return $con;*/
 try {
$dsn = "mysql:host=" . DB_HOST . ";dbname=" . DB_NAME . ";charset =" . DB_CHARSET ;
$options = [
 PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION,
 PDO::ATTR_DEFAULT_FETCH_MODE => PDO::FETCH_ASSOC,
 PDO::ATTR_EMULATE_PREPARES => false,
 PDO::MYSQL_ATTR_INIT_COMMAND => "SET NAMES " . DB_CHARSET
 ];

 $pdo = new PDO($dsn, DB_USER, DB_PASS, $options);
  return $pdo;
} catch ( PDOException $e ) {
 die (" Erreur de connexion : " . $e -> getMessage() );
} 
}
?>