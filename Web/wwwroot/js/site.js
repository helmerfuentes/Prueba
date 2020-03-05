

require([
    "esri/Map",
    "esri/views/MapView",
    "esri/layers/FeatureLayer"
], function (Map, MapView, FeatureLayer) {

   var map = new Map({
        basemap: "national-geographic"
    });

    var view = new MapView({
        container: "viewDiv",
        map: map,

        center: [-72.4782449846235, 4.887407292289377], // longitude, latitude Colombia
        zoom: 6
    });

        //Se diseña el contenido que se mostrara en la ventana

        var popupTrailheads = {
            "title": "{DPTO_CNMBRE}",
            "content": "<b>Año:</b> {DPTO_NANO_CREACION}<br><b>Codigo:</b> {DPTO_CCDGO}<br><b>Area Oficial:</b> {DPTO_NAREA} ft"
        }
        var nomColLabel = {
            symbol: {
                type: "text",
                color: "white",
                haloColor: "black",
                haloSize: "1px",
                font: {
                    size: "12px",
                    family: "Noto Sans",
                    style: "italic",
                    weight: "normal"
                }
            },
            labelPlacement: "above-center",
            labelExpressionInfo: {
                expression: "$feature.DPTO_CNMBRE"
            }
        };
    var trailheadsLayer = new FeatureLayer({
        url: "https://ags.esri.co/server/rest/services/DA_DANE/departamento_mgn2016/MapServer",
        outFields: ["*"],
        popupTemplate: popupTrailheads ,
        opacity: .3,
        renderer: {
            type: "simple",
            symbol: {
                type: "simple-fill",
                color: "blue",
                style: "solid",
                outline: {
                    color: "black",
                    width: 1
                }
            }
        },
        labelingInfo: [nomColLabel]
     });

        map.add(trailheadsLayer);  
});