(function () {
    "use strict";
    angular.module("app")
        .controller("crudTableCtrl", CrudTableCtrl);

    CrudTableCtrl.$inject = ['$scope'
                            , '$injector'];

    function CrudTableCtrl($scope
                            , $injector) {
        var vm = this;
        vm.$scope = $scope;
        vm.entity = vm.$scope.crudEntity; //bindtoController is giving me problems
        vm.entitySvc = $injector.get(vm.entity + 'Svc'); //concatenate the name of the entity, obtained from the directive attribute, and Svc, then inject the particular service

        vm.toggleFormMode = _changeFormMode;

        _render();
        ///////////////////////////////////////////////

        function _render() {
            vm.entitySvc.get();
        }

        function _changeFormMode($event) {
            //initialize the form if it hasn't been already, this triggers a watch set in the addCrudForm directive which accomplishes that
            if (!vm.includesForm) {
                vm.includesForm = true;
            }
            //may need to make this a promise the success method of a promise to wait until form compiling is complete
            //switch to edit
            if (angular.element($event.currentTarget).hasClass('oz-crud-form-edit-mode')) {
                //this postEditMode property is set in the crudForm directive, but that definition should probably be moved to the addCrudForm directive
                //edit
                vm.postEditMode = "edit";
            } else if (angular.element($event.currentTarget).hasClass('oz-crud-form-post-mode')) {
                //post
                vm.postEditMode = "post";
            } else if (angular.element($event.currentTarget).hasClass('oz-crud-form-toggle-mode')) {
                //toggle
                if (vm.postEditMode = "edit") {
                    vm.postEditMode = "post";
                } else if (vm.postEditMode = "post") {
                    vm.postEditMode = "edit";
                } else {
                    console.error("crudTableCtrl.postEditMode error it is not set to either post or edit. It is currently set to " + vm.postEditMode)
                }
            } else {
                console.error("Error setting form's postEdit mode after event " + $event);
            }
        }

    }
})();