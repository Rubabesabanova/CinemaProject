var map;
  $(document).ready(function(){
    map = new GMaps({
      el: '#map',
      lat: -12.043333,
      lng: -77.028333
    });
    map.addMarker({
      lat: -12.042,
      lng: -77.028333,
    });
  });