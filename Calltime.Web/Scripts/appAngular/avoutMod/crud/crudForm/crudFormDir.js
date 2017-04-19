(function () {
    "use strict"

    angular.module("avout")
        .directive("avoutCrudForm", CrudFormDirective);

    CrudFormDirective.$inject = [];

    function CrudFormDirective() {

        var ddo = {
            restrict: 'E'
            , scope: true
            , controller: 'crudFormController'
            , controllerAs: 'crudForm'
            , bindToController: true
            , templateUrl: '/Scripts/appAngular/avoutMod/crud/crudForm/crudForm.html'
        }

        return ddo;

    }

})();