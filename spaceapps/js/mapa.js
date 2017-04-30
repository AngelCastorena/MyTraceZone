function paintMap(uluru){

  var map = new google.maps.Map(document.getElementById('map'), {

    center: uluru,
    zoom: 10
  });


  document.getElementById('envia_geo').addEventListener('click', function() {
    var geocoder = new google.maps.Geocoder();
    geocodeAddress(geocoder, map);
  });
  var infowindow = new google.maps.InfoWindow();
  $.ajax({
//({ content: '<img src="' + data[i].foto +'"' + ' alt="Smiley face" height="100" width="100">' })
  url:  'page/marks.php',
  dataType:  'json',
  success : function(data){

        //console.log(data);
        for (var i=0; i<data.length; i++){
          var marker = new google.maps.Marker({
            position: new google.maps.LatLng(data[i].latitud, data[i].longitud),
            map: map
          });
          var infowindow = new google.maps.InfoWindow();
          var contenido = '<div id="map_mark"><img src="' + data[i].foto +'"' + ' alt="Smiley face" height="150" width="150">' + '<p><strong>' + data[i].nombre +'</strong><br>'+
          '<small>Persona: '+ data[i].nombre_cientifico+'</small><br><small>Reino: '+ data[i].reino + '</small><br>'+
          '<small>Habitad: '+ data[i].habitad + '</small><br><small>Descripcion: '+ data[i].descripcion + '</small><br>'+
          '<small>Alimentacion: '+ data[i].alimentacion + '</small><br><small>Reproduccion: ' + data[i].reproduccion + '</small></p></div>';
          (function(marker, contenido) {
          google.maps.event.addListener(marker, 'click', function() {
            infowindow.setContent(contenido);
            infowindow.open(map, marker);
          });
        })(marker, contenido);
        }



  }


});


}



function geocodeAddress(geocoder, map){
  var dato = document.getElementById('pac-input').value;
  geocoder.geocode({'address': dato}, function(results, status) {
   if (status === 'OK') {
     map.setCenter(results[0].geometry.location);
     //console.log(results[0].geometry.location);

   } else {
     alert('Geocode was not successful: ' + status);
   }
 });


}

  var uluru = {lat: 8.688836077380984, lng: -70.96444616875};
$(document).ready(function(){



    paintMap(uluru);
    var input = new google.maps.places.SearchBox(document.getElementById('pac-input'));
    //console.log("a" + map);








});
