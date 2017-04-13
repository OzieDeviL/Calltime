var example = {
    utilities: {}
    , layout: {}
    , page: {
        handlers: {
        }
        , startUp: null
    }
    , services: {}
    , ui: {}
};

example.moduleOptions = {
    APPNAME: "exampleApp"
        , extraModuleDependencies: []
        , runners: []
        , page: example.page//we need this object here for later use
};

example.layout.startUp = function () {

    console.debug("example.layout.startUp");

    //this does a null check on sabio.page.startUp
    if (example.page.startUp) {
        console.debug("example.page.startUp");
        example.page.startUp();
    }
};

example.APPNAME = "exampleApp";//legacy
$(document).ready(example.layout.startUp);