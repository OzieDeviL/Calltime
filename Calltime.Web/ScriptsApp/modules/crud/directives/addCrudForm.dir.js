(function () {
    'use strict';

    angular
        .module('app')
        .directive('ozAddCrudForm', addCrudFormDir);

    addCrudFormDir.$inject = ['$compile'];

    function addCrudFormDir($compile) {
        // Usage:
        //     <addCrudForm></addCrudForm>
        // Creates:
        // 
        var directive = {
            link: link
            , require: '^ozCrudTable'
            , restrict: 'A'
            , scope: false
        };
        return directive;

        function link(scope, iElem, iAttrs, controller) {
            var crudTableCtrl = controller;
            crudTableCtrl.includesForm = false;
            crudTableCtrl.$scope.$watch(
                function () {
                    return crudTableCtrl.includesForm;
                }
                , function (newValue, oldValue, scope) {
                    //check in case by some mix up it's turning false
                    if (newValue === true) {
                        //double-check that the form isn't already on the DOM
                        if (angular.element('oz-crud-form').length !== 0) {
                            console.error("addForm watch triggered but the form is already on the DOM")
                        } else {
                            controller.formVisible = true;
                            createCrudForm();
                            //make this next code line the success method of a promise
                            //flip the status in the crudTable controller to indicate the crud Form will now on the DOM
                            controller.includesForm = true;
                        }
                    } else if (newValue !== false && newValue !== true) {
                        console.error("crudTable.includesForm has changed to a non true/false value, currently: " + newValue + ". previously: " + oldValue);
                    }
                }
                //deep-check, not reference
                , true
            )

            function createCrudForm() {
                //compile the new form
                var newEl = $compile(
                    '<oz-crud-form x-oz-crud-entity="' + crudTableCtrl.entity + '"'
                    + ' class="oz-' + crudTableCtrl.postEditMode + '"'
                    + ' ng-show="crudTable.formVisible"></oz-crud-form>'

                )(crudTableCtrl.$scope);
                //insert it. Not good practice to have a selector dependency, less reusable
                angular.element('.crudFormPlaceholder').replaceWith(newEl);
            }
        }

    }
})();