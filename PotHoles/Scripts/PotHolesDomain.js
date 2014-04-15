//var baseUrl = "http://spotholes.herokuapp.com/api/pothole";

var baseUrl = "/PotHoles/Create";

var AddNewPotHole = function (longitude, latitude, description) {

    var postObj = { longitude: longitude, latitude: latitude, description: description };

    $.ajax({
        url: "/PotHoles/Create",
        crossDomain: true,
        type: "POST",
        data: JSON.stringify(postObj),
        contentType: "application/json",
        dataType: "json",
        success: function() {
          
        }
    });
};

var GetPotholesByLocation = function (latitude, longitude) {

    $.getJSON('/PotHoles/GetByLongLat?latitude=' + latitude + '&longitude=' + longitude)
    .done(function (data) {

        // TODO Move the map/point links back into the page. It should not be here!

        var blueStar = {
            path: 'M0,8a8,8 0 1,0 16,0a8,8 0 1,0 -16,0',
            fillColor: 'navy',
            fillOpacity: 0.8,
            scale: 1,
            strokeColor: 'navy',
            strokeWeight: 0
        };

        var redStar = {
            path: 'M0,8a8,8 0 1,0 16,0a8,8 0 1,0 -16,0',
            fillColor: 'red',
            fillOpacity: 0.8,
            scale: 1,
            strokeColor: 'red',
            strokeWeight: 0
        };

        var goldStar = {
            path: 'M0,8a8,8 0 1,0 16,0a8,8 0 1,0 -16,0',
            fillColor: 'yellow',
            fillOpacity: 0.8,
            scale: 1,
            strokeColor: 'gold',
            strokeWeight: 0
        };

        for (var i = 0; i < data.length; i++) {
            var potHole = data[i];
            var lat = potHole.latitude;
            var lng = potHole.longitude;
            var colorStar = redStar;

            if (potHole.description == 'SMALL')
                colorStar = blueStar;
            
            if (potHole.description == 'MEDIUM')
                colorStar = goldStar;


            var latLng = new google.maps.LatLng(lat, lng);

            var marker = new google.maps.Marker({
                position: latLng,
                icon: colorStar,
                map: map
                
            });
        }
    });
}