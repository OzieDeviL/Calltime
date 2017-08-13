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

        function link(scope, iElem, iAttrs, controller) {
            controller.includesForm = false;
            iElem.on('click', crudFormHandler);
            function crudFormHandler(event) {
                //check if the form is already on the DOM
                if (angular.iElem('oz-crud-form').length === 0) {
                    //determine whether to initialize the form in post or edit mode, assume post
                    var postEditMode = "post";
                    if (iElem.hasClass('oz-crud-form-edit-btn')) {
                        postEditMode = "edit";
                    }
                    createCrudForm(postEditMode);
                    //flip the status in the crudTable controller to indicate the crud Form will now on the DOM
                    controller.includesForm = true;
                } else {
{
                        //will result in the ngShow/Hide status changing
                        controller.includesForm = !controller.includesForm;
                        scope.$apply();
                    }
                }
            }

            function createCrudForm(postEditMode) {
                var newEl = $compile('<oz-crud-form x-oz-crud-entity="' + ctrl.entity + '" class="oz-' + postEditMode + '" ng-show="crudTable.includesForm"></oz-crud-form>')(scope);
                //not good practice to have a selector dependency, less reusable
                angular.iElem('.crudTableSearchCreateRow').after(newEl);
            }

        }
    }
})();