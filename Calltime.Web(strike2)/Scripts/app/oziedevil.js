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
    avout : "avout"
        , extraModuleDependencies: []
        , runners: []
        , page: oziedevil.page
};

oziedevil.layout.startUp = function () {
    if (oziedevil.page.startup) {
        oziedevil.page.startup();
    }
}

oziedevil.avout = "avout";//legacy 
$(document).ready(oziedevil.layout.startUp);
//githubtest
