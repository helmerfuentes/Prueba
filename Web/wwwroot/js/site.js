var ListadoVeredas;

require([
    "esri/Map",
    "esri/views/MapView",
    "esri/layers/FeatureLayer",
    "dijit/Dialog",
    "dojo/domReady!",
    "dojo/dom"
    
], function (Map, MapView, FeatureLayer, Dialog,dom) {

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

        var popuDepartamentos = {
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
        //carga departamentos
    var trailheadsLayer = new FeatureLayer({
        url: "https://ags.esri.co/server/rest/services/DA_DANE/departamento_mgn2016/MapServer",
        outFields: ["*"],
        popupTemplate: popuDepartamentos ,
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
        
        var PopupVereda = {
            "title": "Información de {NOMBRE_VER}",
            "content": [
                {
                    "type": "fields",
                    "fieldInfos": [
                        {
                            "fieldName": "OBJECTID",
                            "label": "Id",
                            "isEditable": true,
                            "tooltip": "",
                            "visible": true,
                            "format": null,
                            "stringFieldOption": "text-box"
                        },
                        {
                            "fieldName": "DPTOMPIO",
                            "label": "DPTOMPIO",
                            "isEditable": true,
                            "tooltip": "",
                            "visible": true,
                            "format": null,
                            "stringFieldOption": "text-box"
                        },
                        {
                            "fieldName": "CODIGO_VER",
                            "label": "CODIGO_VER",
                            "isEditable": true,
                            "tooltip": "",
                            "visible": true,
                            "format": null,
                            "stringFieldOption": "text-box"
                        },
                        {
                            "fieldName": "NOM_DEP",
                            "label": "NOM_DEP",
                            "isEditable": true,
                            "tooltip": "",
                            "visible": true,
                            "format": null,
                            "stringFieldOption": "text-box"
                        },
                        {
                            "fieldName": "NOMB_MPIO",
                            "label": "NOMB_MPIO",
                            "isEditable": true,
                            "tooltip": "",
                            "visible": true,
                            "format": null,
                            "stringFieldOption": "text-box"
                        },
                        {
                            "fieldName": "NOMBRE_VER",
                            "label": "NOMBRE_VER ",
                            "isEditable": true,
                            "tooltip": "",
                            "visible": true,
                            "format": null,
                            "stringFieldOption": "text-box"
                        },
                        {
                            "fieldName": "VIGENCIA",
                            "label": "VIGENCIA",
                            "isEditable": true,
                            "tooltip": "",
                            "visible": true,
                            "format": null,
                            "stringFieldOption": "text-box"
                        },
                        {
                            "fieldName": "FUENTE",
                            "label": "FUENTE",
                            "isEditable": true,
                            "tooltip": "",
                            "visible": true,
                            "format": null,
                            "stringFieldOption": "text-box"
                        },
                        {
                            "fieldName": "DESCRIPCIO",
                            "label": "DESCRIPCIO",
                            "isEditable": true,
                            "tooltip": "",
                            "visible": true,
                            "format": null,
                            "stringFieldOption": "text-box"
                        },
                        {
                            "fieldName": "SEUDONIMOS",
                            "label": "SEUDONIMOS",
                            "isEditable": true,
                            "tooltip": "",
                            "visible": true,
                            "format": null,
                            "stringFieldOption": "text-box"
                        },
                        {
                            "fieldName": "AREA_HA",
                            "label": "AREA_HA",
                            "isEditable": true,
                            "tooltip": "",
                            "visible": true,
                            "format": null,
                            "stringFieldOption": "text-box"
                        },
                        {
                            "fieldName": "COD_DPTO",
                            "label": "COD_DPTO",
                            "isEditable": true,
                            "tooltip": "",
                            "visible": true,
                            "format": null,
                            "stringFieldOption": "text-box"
                        }
                    ]
                }]
        }
        //cargar veredas
        var FeatureVereda = new FeatureLayer({
            url: "https://ags.esri.co/server/rest/services/DA_DatosAbiertos/VeredasColombia/MapServer/0",
            outFields: ["*"],
            opacity: 0,
            renderer: {
                type: "simple",
                symbol: {
                    type: "simple-fill",
                    color: "cyan",
                    style: "solid",
                    outline: {
                        color: "black",
                        width: 1
                    }
                }
            },
            popupTemplate: PopupVereda
        });
      
        //obtengo lista veredas del FeatureLeayer
        FeatureVereda.queryFeatures({
            where: "1=1",
            outFields: ["*"]
        }).then(function (results) {
            console.log(results);
            ListadoVeredas = results.features;
              
        });


        verDialog = new Dialog({
            title: "Listado de Veredas",
            content: "<div  id='tablaVeredas'>Cargando...</div>",
            style: "width: 50%; position:center;",
        });
});