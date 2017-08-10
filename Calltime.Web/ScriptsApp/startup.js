var oziedevil = {
    utilities: {}
    , layout: []
    , page: {
        handlers: {
        }
        , startup: null
    }
    , services: {}
    , ui: {}
};

oziedevil.moduleOptions = {
    app : "app"
        , extraModuleDependencies: []
        , runners: []
        , page: oziedevil.page
};

oziedevil.layout.startUp = function () {
    if (oziedevil.page.startup) {
        oziedevil.page.startup();
    }
}

oziedevil.app = "app";//legacy 
$(document).ready(oziedevil.layout.startUp);