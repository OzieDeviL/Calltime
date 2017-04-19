(function () {
    'use strict';

    angular.module('avout')
        .directive('avoutCrud', CrudDirective);

    CrudDirective.$inject = ['$location'];

    function CrudDirective($location) {

        var ddo = {
            restrict: 'E'
            ,scope: {
                crudEntity: '@'
            }
            , controller: 'crudController'
            , bindToController: true
            , templateUrl: '/Scripts/appAngular/avoutMod/crud/crudPage.html'
            , link: { pre: crudDirectivePreLink
            }
        };
        ddo.controllerAs = ddo.scope.crudEntity + "Crud";
        return ddo;

        function crudDirectivePreLink(scope, element, attrs) {
            
        }
    }

})();