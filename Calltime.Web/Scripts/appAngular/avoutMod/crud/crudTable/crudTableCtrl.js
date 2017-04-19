(function () {
    "use strict";
    angular.module("avout")
        .controller("crudTableController", CrudTableController);
    //add CRUD Service Dependency
    //add CRUD Model Dependency
    CrudTableController.$inject = ['$scope'];

    function CrudTableController($scope) {
        var vm = this;
        vm.$scope = $scope;
        vm.crudTable = {};

        //add form CRUD ops

    }

})();