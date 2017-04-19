(function () {
    "use strict";

    angular.module("avout")
        .directive("avoutCrudTable", CrudTableDirective);

    CrudTableDirective.$inject = [];

    function CrudTableDirective() {

        var ddo = {
            restrict: 'E'
            , scope: true
            , controller: 'crudTableController'
            , controllerAs: 'crudTable'
            , bindToController: true
            , templateUrl: '/Scripts/appAngular/avoutMod/crud/crudTable/crudTable.html'
        }
        //ddo.controllerAs = ddo.scope.CrudEntity + "Table";
        return ddo;

    }

})();