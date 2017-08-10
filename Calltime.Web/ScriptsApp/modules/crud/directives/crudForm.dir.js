(function () {
    "use strict"

    angular.module("app")
        .directive("ozCrudForm", CrudFormDir);

    CrudFormDir.$inject = [];

    function CrudFormDir() {
        var ddo = {
            restrict: 'E'
            , scope: {
                entity: '@ozCrudEntity'
            }
            , controller: 'crudFormCtrl'
            , controllerAs: 'crudForm'
            , bindToController: true
            , templateUrl: function (tElement, tAttrs) {
                return '/ScriptsApp/modules/crud/templates/' + tAttrs.ozCrudEntity + 'CrudForm.template.html'
            }
        }
        return ddo;

    }
})();