(function () {
    "use strict";
    angular.module("app")
        .controller("crudFormCtrl", CrudFormCtrl);
    //add CRUD Service Dependency
    //add CRUD Model Dependency
    CrudFormCtrl.$inject = ['$scope'
                            , '$injector'
                            , '$attrs'];

    function CrudFormCtrl($scope
                        , $injector
                        , $attrs) {
        var vm = this;
        vm.$scope = $scope;
        vm.inputs = {};
        vm.postEditMode = $attrs.class.slice(3);
        vm.entitySvc = $injector.get($attrs.ozCrudEntity + 'Svc'); //concatenate the name of the entity, obtained from the directive attribute, and Svc, then inject the particular service
        vm.formVisible = true;

        vm.submit = _submit;
        vm.togglePostEditMode = _togglePostEditMode;
        
        //////////////////////////////////////////////

        function _submit() {
            //post
            if (vm.postEditMode === "post") {
                vm.entitySvc.post(vm.inputs);
            //edit
            } else if (vm.postEditMode === "edit") {
                vm.entitySvc.put(vm.inputs);
            } else {
                console.error("the postEditMode property of CrudFormCtrl is neither post nor edit. Its value is currently: " + vm.postEditMode);
            }            
        }

        function _togglePostEditMode() {
            if (vm.postEditMode === "post") {
                vm.postEditMode = "edit";
            } else if (vm.postEditMode === "edit") {
                vm.postEditMode = "post";
            } else {
                console.error("togglePostEditMode cannot proceed because post/edit is not in either value")
            }
        }

    }

})();