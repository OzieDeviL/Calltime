(function () {
    'use strict';

    angular.module('avout')
        .controller('crudController', CrudController);

    //add CRUD Service Dependency
    //add CRUD Model Dependency
    CrudController.$inject = ['$scope'];

    function CrudController($scope) {
        var vm = this;
        vm.$scope = $scope;

        //add form CRUD ops

        //activate();

        //function activate() { }
    }
})();
