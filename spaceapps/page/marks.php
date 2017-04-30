<?php

class Marks{


  protected $conection;
  public function __construct(){

      require("connection.php");
      $this->conection = conexion::conection();

  }


  public function getDates(){

      $query = $this->conection->query("SELECT registro. * , especie_fauna.nombre, especie_fauna.nombre_cientifico, especie_fauna.descripcion, especie_fauna.habitad, especie_fauna.alimentacion, especie_fauna.reproduccion, comportamiento, especie_fauna.status, especie_fauna.likes, especie_fauna.dislike FROM registro INNER JOIN especie_fauna ON registro.id_especie = especie_fauna.id_especie");

      $resul = $query->fetchAll(PDO::FETCH_OBJ);

      echo json_encode($resul);


  }



}

  $x = new Marks();
  $x->getDates();


 ?>
