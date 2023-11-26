


<?php
$latitude = '-22.14337134';
$longitude = '-43.41784496';
$tempo = 300;
$veiculo = 'car'; // "car" "bike" "foot" "hike" "mtb" "racingbike" "scooter" "truck" "small_truck"
if (isset($_GET['latitude'])){
$latitude = 	$_GET['latitude'];
}
if (isset($_GET['longitude'])){
$longitude = 	$_GET['longitude'];
}
if (isset($_GET['tempo'])){
$tempo = 	$_GET['tempo'];
$distancia = '';
}

if (isset($_GET['distancia'])){
$tempo = 	'';
$distancia =$_GET['distancia'];
}


?>

<html>
<head>

<link rel="stylesheet" href="1.7.1/leaflet.css" />
  <script src="1.7.1/leaflet.js"></script> 
  <script src="jquery.js"></script> 
  <script src="esri-leaflet.js"></script>
  </head>
<body>  
   <style>

#map { height: 400px; }
</style>

   
 <div id="map"></div>
 <script>


var latitude = <?php echo $latitude; ?>;
var longitude = <?php echo $longitude; ?>;


var operadora = <?php echo $_GET['operadora']; ?> //169094 = claro 161704 = vivo   161679 = oi 161694 = TIM

// add an OpenStreetMap tile layer
L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', {
    attribution: '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
}).addTo(map2);




var map = L.map('map').setView([latitude, longitude], 10);
map.createPane('labels');


L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', {
    attribution: '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
}).addTo(map);

//169094 = claro

 L.esri.tiledMapLayer({
    url: 'https://cobertura.claro.com.br/arcgis/mapserver/Claro_2G_prd/MapServer',
	opacity: 0.3
  }).addTo(map);
  
  
  
  
L.tileLayer('https://app.nperf.com/signal-'+operadora+'-{z}-{x}-{y}.png', {
    attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors',
	opacity: 0.9
}).addTo(map);



L.tileLayer('https://opencellid.org/images/maps/opencellid/{z}/{x}/{y}.png?v=', {
    attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors',
	opacity: 0.9
}).addTo(map);


L.marker([ latitude, longitude]).addTo(map)
    .bindPopup('CLARO WorldSat do Brasil.')
    .openPopup();
	
	function onEachFeature(feature, layer) {
    // does this feature have a property named popupContent?
    if (feature.properties && feature.properties.popupContent) {
        layer.bindPopup(feature.properties.popupContent);
    }
}

?>

	</script>
	</body>
	</html>