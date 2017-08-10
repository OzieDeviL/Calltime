(function () {
    "use strict";

    angular.module("app")
        .directive("ozCrudTable", CrudTableDir);

    CrudTableDir.$inject = [];

    function CrudTableDir() {

        var ddo = {
            restrict: 'EA'
            , scope: {
                crudEntity: "@ozCrudEntity"
            }
            , controller: 'crudTableCtrl'
            , controllerAs: 'crudTable'
            //, bindToController: true ///this is making the local properties dissapear from scope but isn't binding them to the controller
            , templateUrl: '/ScriptsApp/modules/crud/templates/crudTable.template.html'
        }
        return ddo;

    }
})();