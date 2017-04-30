<?php

class conexion{


    public static function conection(){
        require("daten_inc.php");
        try{
          $conexion = new PDO("mysql:host=$DB_HOST;dbname=$DB_NAME", "$DB_USER", "$DB_PASS");
          $conexion->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
          $conexion->exec("SET CHARACTER SET UTF8");


        }catch(Exception $e){
          die ("Error al conectar con la base de datos");
          echo "Linea: " . $e->getLine();
        }

        return $conexion;

    }

}

 ?>
