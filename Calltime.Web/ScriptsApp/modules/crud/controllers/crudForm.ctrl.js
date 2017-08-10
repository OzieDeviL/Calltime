(function () {
    "use strict";
    angular.module("app")
        .controller("crudFormCtrl", CrudFormCtrl);
    //add CRUD Service Dependency
    //add CRUD Model Dependency
    CrudFormCtrl.$inject = ['$scope'];

    function CrudFormCtrl($scope) {
        var vm = this;
        vm.$scope = $scope;
        vm.crudForm = {};

        //add form CRUD ops

    }

})();