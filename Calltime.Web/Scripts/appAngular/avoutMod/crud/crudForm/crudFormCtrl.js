(function () {
    "use strict";
    angular.module("avout")
        .controller("crudFormController", CrudFormController);
    //add CRUD Service Dependency
    //add CRUD Model Dependency
    CrudFormController.$inject = ['$scope'];

    function CrudFormController($scope) {
        var vm = this;
        vm.$scope = $scope;
        vm.crudForm = {};

        //add form CRUD ops

    }

})();