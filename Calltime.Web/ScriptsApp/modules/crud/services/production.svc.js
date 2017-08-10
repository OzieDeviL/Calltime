(function () {
    "use strict";

    angular.module("app")
        .service('productionSvc', ProductionSvc);

    ProductionSvc.$inject = ['crudCalltimeWebApiSvc', "appModel"];
    
    function ProductionSvc(crudCalltimeWebApiSvc, appModel) {
        var svc = this;
        //public properties
        svc.entity = 'production';
        svc.m = appModel;
        svc.m.production = {};
        svc.requestData = {};
        svc.requestParams = {};
        svc.id = {};
        //public methods
        svc.post = _post;
        svc.get = _get;
        svc.getById = _getById;
        svc.put = _put;
        svc.deleteById = _deleteById;

        ///////////////////////////////////////////////////////////

        //-------POST--------//
        function _post(requestData) {
            crudCalltimeWebApiSvc.post(svc.requestData, svc.entity)
                .then(_postSuccess, _postError);
        }
        function _onPostSuccess() {
            console.log("postSuccess");
        }
        function _onPostSuccess() {
            console.error("postError");
        }

        //-------GET--------//
        function _get(requestData) {
            crudCalltimeWebApiSvc.get(svc.entity, svc.requestParams)
                .then(_getSuccess, _getError);
        }
        function _getSuccess(response) {
            if (response.data.items && response.data.items.length > 0) {
                svc.m.production.entityList = response.data.items;
                svc.m.production.keys = Object.keys(response.data.items[0]);
            }
            console.log("getSuccess");
        } 
        function _getError(response) {
            console.error(response);
        }

        //-------GETBYID--------//
        function _getById(requestData) {
            crudCalltimeWebApiSvc.getById(svc.entity, svc.id, svc.requestParams)
                .then(_getByIdSuccess, _getByIdError);
        }
        function _getByIdSuccess() {
            console.log(svc.entity + "getByIdSuccess");
        }
        function _getByIdError() {
            console.error(svc.entity + "getByIdError");
        }

        //-------PUT--------//
        function _put(requestData) {
            crudCalltimeWebApiSvc.put(svc.entity, data, svc.id)
                .then(_getByIdSuccess, _getByIdError);;
        }
        function _putSuccess() {
            console.log(svc.entity + "putSuccess");
        }
        function _putError() {
            console.error(svc.entity + "putError");
        }

        //-------DELETE--------//
        function _deleteById(requestData) {
            crudCalltimeWebApiSvc.deleteById(svc.entity, svc.id)
                .then(_getByIdSuccess, _getByIdError);
        }
        function _deleteByIdSuccess() {
            console.log(svc.entity + "deleteByIdSuccess");
        }
        function _deleteByIdSuccess() {
            console.log(svc.entity + "deleteByIdError");
        }       
    }
})();