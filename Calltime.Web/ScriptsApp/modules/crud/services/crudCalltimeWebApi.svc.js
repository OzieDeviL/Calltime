(function () {
    "use strict";

    angular.module("app")
        .service("crudCalltimeWebApiSvc", CrudCalltimeWebApiSvc);

    CrudCalltimeWebApiSvc.$inject = ['$http', '$location', '$httpParamSerializerJQLike'];

    function CrudCalltimeWebApiSvc($http, $location, $httpParamSerializerJQLike) {
        const url = $location.$$protocol + "://" + $location.$$host + '/api/'; 
        return {
            post: function (entity, data) {
                return $http({
                    method: 'POST'
                    , url: url + entity
                    , data: data
                });
            }
            , get: function (entity, params) {
                return $http({
                    method: 'GET'
                    , url: url + entity
                    , params: params
                    , paramSerializer: '$httpParamSerializerJQLike'
                });
            }
            , getById: function (entity, id, params) {
                return $http({
                    method: 'GET'
                    , url: url + entity + '/' + id
                    , params: params
                    , paramSerializer: '$httpParamSerializerJQLike'
                });
            }
            , put: function (entity, data, id) {
                return $http({
                    method: 'PUT'
                    , url: url + entity + "/" + id
                    , data: data
                });
            }
            , deleteById: function (entity, id) {
                return $http({
                    method: 'DELETE'
                    , url: url + entity + "/" + id
                });
            }
        };
    }
})();