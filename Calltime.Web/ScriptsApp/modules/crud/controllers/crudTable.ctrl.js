(function () {
    "use strict";
    angular.module("app")
        .controller("crudTableCtrl", CrudTableCtrl);

    CrudTableCtrl.$inject = ['$scope'
                            , '$injector'
                            , '$compile'];

    function CrudTableCtrl($scope
                            , $injector
                            , $compile) {
        var vm = this;
        vm.$scope = $scope;
        vm.entity = vm.$scope.crudEntity; //bindtoController is giving me problems
        vm.entitySvc = $injector.get(vm.entity + 'Svc'); //concatenate the name of the entity, obtained from the directive attribute, and Svc, then inject the particular service
        
        _render();
        ///////////////////////////////////////////////

        function _render() {
            vm.entitySvc.get();
        }

    }
})();