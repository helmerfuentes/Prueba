var ListadoVeredas;
var global = {};



require([
    "esri/Map",
    "esri/views/MapView",
    "esri/layers/FeatureLayer",
    "esri/layers/GraphicsLayer",
    "dijit/Dialog",
    "esri/widgets/Sketch",
    "esri/widgets/Sketch/SketchViewModel",
    "dojo/domReady!"


], function (Map, MapView, FeatureLayer, GraphicsLayer, Dialog, Sketch, SketchViewModel) {

    const graphicsLayer = new GraphicsLayer();

    var map = new Map({
        basemap: "national-geographic",
        layers: [graphicsLayer]

    });

    var view = new MapView({
        container: "viewDiv",
        map: map,

        center: [-72.4782449846235, 4.887407292289377], // longitude, latitude Colombia
        zoom: 6
    });





    var sketchVM = new SketchViewModel({
        layer: graphicsLayer,
        view: view,
        polygonSymbol: {
            type: "simple-fill",
            style: "none",
            outline: {
                color: "black",
                width: 1
            }
        }
    });
        var _DepartamentoFeature = new FeatureLayer({
            url: "https://ags.esri.co/server/rest/services/DA_DANE/departamento_mgn2016/MapServer",
            outFields: ["*"],
            opacity: 0,
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
            }
        });

    sketchVM.on(["create"], function (event) {
        if (event.state === "complete") {
            map.remove(map.layers.find(x => x.type === "graphics"));

            if (FatureDepartamento) {
                var query = FatureDepartamento.createQuery();
                query.geometry = event.graphic.geometry;
                query.distance = 2;
               
               
                query.units = "miles";
                query.spatialRelationship = "intersects";  // this is the default
                query.returnGeometry = true;
                query.outFields = ["*"];

                FatureDepartamento.queryFeatures(query)
                    .then(function (response) {
                        view.when(function () {

                            console.log(response.features);
                          
                            stateMap = true;
                            view.extent = response.features[0].geometry.extent;
                            view.popup.title = response.features[0].attributes.DPTO_CNMBRE;
                            view.popup.open({
                                location: {
                                    latitude: response.features[0].geometry.centroid.latitude,
                                    longitude: response.features[0].geometry.centroid.longitude
                                },
                                title: "Información de " + response.features[0].attributes.DPTO_CNMBRE,
                                content: `
                                            OBJECTID: ${response.features[0].attributes.OBJECTID} <br> 
                                            Código DANE departamento: ${response.features[0].attributes.DPTO_CCDGO} <br> 
                                            Año de creación del departamento: ${response.features[0].attributes.DPTO_NANO_CREACION} <br> 
                                            Nombre del departamento: ${response.features[0].attributes.DPTO_CNMBRE} <br> 
                                            Acto administrativo de creación del departamento: ${response.features[0].attributes.DPTO_CACTO_ADMNSTRTVO} <br> 
                                            Área oficial del departamento en Km2: ${response.features[0].attributes.DPTO_NAREA} <br> 
                                            Año vigencia de información municipal (Fuente DANE): ${response.features[0].attributes.DPTO_NANO} <br> 
                                          `
                            });
                            FeatureVereda.definitionExpression = `COD_DPTO=${response.features[0].attributes.DPTO_CCDGO}`;
                            FeatureVereda.opacity = .75;
                            FeatureVereda.renderer = renderizado;
                            view.goTo(response.features[0].geometry.extent.expand(1));
                        });

                    });

            }
        }

    });

      

    ////tolbar de dibujo de puntos y pol
    let sketch = new Sketch({
        layer: graphicsLayer,
        viewModel: sketchVM,
        view: view,

        creationMode: "single"
    });
    ////Se diseña el contenido que se mostrara en la ventana
    view.ui.add(sketch, "top-right");


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
    var FatureDepartamento = new FeatureLayer({
        url: "https://ags.esri.co/server/rest/services/DA_DANE/departamento_mgn2016/MapServer",
        outFields: ["*"],
        popupTemplate: popuDepartamentos,
        opacity: .2,
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

    map.add(FatureDepartamento);

        var renderizado = {
            type: "simple",
            symbol: {
                type: "simple-fill",
                color: "cyan",
                style: "solid",
                outline: {
                    color: "cyan",
                    width: 0
                }
            }
        }
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
    map.add(FeatureVereda);
    //obtengo lista veredas del FeatureLeayer
    FeatureVereda.queryFeatures({
        where: "1=1",
        outFields: ["*"]
    }).then(function (results) {
        
        ListadoVeredas = results.features;

    });


    verDialog = new Dialog({
        title: "Listado de Veredas",
        content: "<div  id='tablaVeredas'>Cargando...</div>",
        style: "width: 50%; position:center;",
    });

    userDialog = new Dialog({
        title: "Listado de Usuarios",
        content: "<div  id='tablaUsuarios'>Cargando...</div>",
        style: "width: 50%; position:center;",
    });

    global.verVereda = function (nomVer) {
        console.log(nomVer);
        FeatureVereda.definitionExpression = `NOMBRE_VER='${nomVer.toUpperCase()}'`;
        verDialog.hide();
        FeatureVereda.queryFeatures({
            where: `NOMBRE_VER='${nomVer.toUpperCase()}'`,
            returnGeometry: true,
            outFields: ["*"]
        }).then(function (results) {
            console.log(results);
            view.popup.title = results.features[0].attributes.NOMBRE_VER;
            view.popup.open({
                location: {
                    latitude: results.features[0].geometry.centroid.latitude,
                    longitude: results.features[0].geometry.centroid.longitude
                },
                title: "Información de " + results.features[0].attributes.NOMBRE_VER,
                content: `
                            OBJECTID: ${results.features[0].attributes.OBJECTID} <br> 
                            Código DANE departamento: ${results.features[0].attributes.DPTO_CCDGO} <br> 
                            Año de creación del departamento: ${results.features[0].attributes.DPTO_NANO_CREACION} <br> 
                            Nombre del departamento: ${results.features[0].attributes.DPTO_CNMBRE} <br> 
                            Acto administrativo de creación del departamento: ${results.features[0].attributes.DPTO_CACTO_ADMNSTRTVO} <br> 
                            Área oficial del departamento en Km2: ${results.features[0].attributes.DPTO_NAREA} <br> 
                            Año vigencia de información municipal (Fuente DANE): ${results.features[0].attributes.DPTO_NANO} <br> 
                            `
            });
            view.extent = results.features[0].geometry.extent.expand(1.5);
            FeatureVereda.opacity = .75;
        });
    };

});