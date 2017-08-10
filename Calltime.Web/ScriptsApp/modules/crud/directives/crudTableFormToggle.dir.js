(function () {
    'use strict';

    angular.module('app')
        .directive('ozCrudTableFormToggle', CrudTableFormToggleDir);

    CrudTableFormToggleDir.$inject = ['$compile'];

    function CrudTableFormToggleDir ($compile) {
        // Usage:
        //     <ANY toggleCrudForm></ANY>
        // Creates:
        // 
        var ddo = {
            link: link
            , scope: true
            , restrict: 'A'
            //, controller: 'crudTableFormToggleCtrl'
            //, controllerAs: crudTableFormToggle
            //, bindToController: true
            , require: '^^ozCrudTable'
        };
        return ddo;

        function link(scope, element, attrs, ctrl) {
            ctrl.includesForm = false;

            element.on('click', crudFormHandler);

            function crudFormHandler(event) {
                //adds the form to the DOM
                if (angular.element('oz-crud-form').length === 0) {
                    ctrl.includesForm = true;
                    createCrudForm();
                } else {
                    //will result in the ngIf directive removing the form from the DOM
                    ctrl.includesForm = !ctrl.includesForm;
                    ctrl.$scope.$apply();
                }
            }

            function createCrudForm() {
                var newEl = $compile('<oz-crud-form oz-crud-entity="' + ctrl.entity + '" ng-show="crudTable.includesForm"></oz-crud-form>')(scope);
                //not good practice to have a selector dependency, less reusable
                angular.element('.crudTableSearchCreateRow').after(newEl);
            }

        }
    }
})();