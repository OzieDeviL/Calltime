(function () {
    "use strict";

    angular.module("avout")
        .service('productionService', ProductionService);

    ProductionService.$inject = ['crudService'];

    function ProductionService(crudService) {
        var svc = this;

        //public properties
        svc.entity = 'production';
        svc.requestData = {};
        svc.requestParams = {};
        svc.id = {};
        svc.model = {};
        //public methods
        svc.post = _post;
        svc.get = _get;
        svc.getById = _getById;
        svc.put = _put;
        svc.delete = _delete;

        return svc;

        //-------POST--------//
        function _post(requestData) {
            crudService.post(svc.requestData, onPostSuccess, onPostError, svc.entity);
        }
        function _onPostSuccess() {
            console.log("postSuccess");
        }
        function _onPostSuccess() {
            console.log("postError");
        }

        //-------GET--------//
        function _get(requestData) {
            crudService.get(onGetSuccess, onGetError, svc.entity, svc.requestParams);
        }
        function _onGetSuccess() {
            console.log("getSuccess");
        }
        function _onGetSuccess() {
            console.log("getError");
        }

        //-------GETBYID--------//
        function _getById(requestData) {
            crudService.getById(svc.id, onGetByIdSuccess, onGetByIdError, svc.entity, svc.requestParams);
        }
        function _onGetByIdSuccess() {
            console.log("getByIdSuccess");
        }
        function _onGetByIdSuccess() {
            console.log("getByIdError");
        }

        //-------PUT--------//
        function _put(requestData) {
            crudService.put(svc.id, requestData, onPutSuccess, onPutError, svc.entity);
        }
        function _onPutSuccess() {
            console.log("putSuccess");
        }
        function _onPutSuccess() {
            console.log("putError");
        }

        //-------DELETE--------//
        function _deleteById(requestData) {
            crudService.deleteById(svc.id, onDeleteByIdSuccess, onDeleteByIdError, svc.entity);
        }
        function _onDeleteByIdSuccess() {
            console.log("deleteByIdSuccess");
        }
        function _onDeleteByIdSuccess() {
            console.log("deleteByIdError");
        }       
    }
})();