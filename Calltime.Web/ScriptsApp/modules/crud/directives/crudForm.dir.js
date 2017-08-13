(function () {
    "use strict"

    angular.module("app")
        .directive("ozCrudForm", CrudFormDir);

    CrudFormDir.$inject = [];
    
    function CrudFormDir() {
        var ddo = {
            
            bindToController: true
            , scope: {
                entity: '@ozCrudEntity'
            }
            , controller: 'crudFormCtrl'
            , controllerAs: 'crudForm'
            , link: link
            , restrict: 'E'
            , require: ['ozCrudForm', '^ozCrudTable']
            , templateUrl: function (tElement, tAttrs) {
                return '/ScriptsApp/modules/crud/templates/' + tAttrs.ozCrudEntity + 'CrudForm.template.html'
            }
        }
        return ddo;

        function link(scope, element, attrs, controllers, transclude) {
            var crudFormCtrl = controllers[0];
            var crudTableCtrl = controllers[1];
            crudFormCtrl.formVisible = true;
            //if the crudForm is embedded in a crudTable create a getter and setter on the crudTableCtrl for a crudTableCtrl.postEditMode property which will access the corresponding mode property on the crudFormCtrl this is probably better done through bi-directional binding
            if (crudTableCtrl !== undefined) {
                Object.defineProperties(
                    crudTableCtrl
                    , { postEditMode: {
                            get: function () { return crudFormCtrl.postEditMode }
                            , set: function (newValue) { crudFormCtrl.postEditMode = newValue }
                        }
                        , formVisible: {
                            get: function () { return crudFormCtrl.formVisible }
                            , set: function (newValue) { crudFormCtrl.formVisible = newValue }
                        }
                    }
                )
            }
        //    scope.$watch(
        //        //check if the postEditMode has changed
        //        //this gets triggered when the form is first rendered
        //        function watchPostEditMode(scope) {
        //            return crudFormCtrl.postEditMode;
        //        }
        //        //if so, call this function
        //        , _postEditModeSwap
        //        //check by value, not reference
        //        , true);
        //    function _postEditModeSwap() {
        //        //determine which state we're changing to. The postEditMode value changes before the watch this event handler is triggered
        //        if (crudFormCtrl.postEditMode === "post") {
        //            toggleToPostMode();
        //        } else if (crudFormCtrl.postEditMode === "edit") {
        //            toggleToEditMode();
        //        } else {
        //            console.error("PostEditToggleFailure due to unexpected postEditMode value: " + crudFormCtrl.postEditMode)
        //        }
        //    }

        //    function toggleToPostMode() {
        //        const postHtml = '<i class="fa fa-plus"></i><span>New Production</span>'
        //        //change form title
        //        angular.element('oz-crud-form .panel-title span').replaceWith(postHtml);
        //        //change submit button language
        //        //change submit button classes
        //    }

        //    function toggleToEditMode() {
        //        const postHtml = '<i class="fa fa-pencil-square-o"></i><span>Edit Production</span>'
        //        //change form title
        //        angular.element('oz-crud-form .panel-title span').replaceWith(postHtml);
        //        //change submit button language
        //        //change submit button classes
        //        //apply digest cycle
        //    }

        }
    }
})();