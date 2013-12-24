$(function () {
    $.getScript('http://api-maps.yandex.ru/2.0-stable/?lang=ru-RU&coordorder=longlat&load=package.full&wizard=constructor&onload=fid_1351329533019358015298', function () {

    }
    );
});

function fid_1351329533019358015298() {
    var map = new ymaps.Map("ya-map", {
        center: [48.401230464145975, 54.32208635268065],
        zoom: 16,
        type: "yandex#map",
		behaviors: ["scrollZoom", "drag"]
    });
    map.controls
        .add("zoomControl");

    map.geoObjects
        .add(new ymaps.Placemark([48.400085092396665, 54.322389952814746], {
            balloonContent: "Бюро переводов Respect <br />2-й пер. Мира 28А"
        }, {
            preset: "twirl#redDotIcon"
        })).add(new ymaps.Polyline([
                    [48.40122961310636, 54.32161519231887],
                    [48.400906198189226, 54.3214219377487],
                    [48.39973139064074, 54.32203970593915],
                    [48.40027856127981, 54.32223099267997],
                    [48.400101755354825, 54.32232646252447]
                ], {
                    balloonContent: ""
                }, {
                    strokeColor: "33cc00",
                    strokeWidth: 2,
                    strokeOpacity: 0.8
                }));
}
             
                