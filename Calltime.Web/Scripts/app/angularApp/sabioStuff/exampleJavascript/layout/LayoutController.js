(function () {

    'use strict';
    console.log('creating the Layout Controller...');
    angular.module(example.APPNAME).controller('layoutController', LayoutController);
    LayoutController.$inject = ['$scope'];

    function LayoutController($scope) {

        console.log('entering LayoutController function creation...');
        var vm = this;
        vm.$scope = $scope;
        vm.msg = 'Layout Controller is available!';
        vm.displayBodyContent = true;

        render();
        function render() {

            console.log('Starting render method of the LayoutController...');
            vm.displayBodyContent = true;
            console.log('Layout is ready!');

        };

    };

})();