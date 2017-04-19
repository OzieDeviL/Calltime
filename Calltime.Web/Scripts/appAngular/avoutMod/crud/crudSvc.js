(function () {
    "use strict";

    angular.module("avout")
        .service("crudService", CrudService);

    CrudService.$inject = ['$http', '$location', '$httpParamSerializerJQLike'];

    function CrudService($http, $location, $httpParamSerializerJQLike) {
        const url = $location.protocol + "://" + $location.host + '/'; 
        return {             
            post: function (data, onSuccess, onError, entity) {
                return $http({
                    method: 'POST'
                    , url: url + entity
                    , data: data
                }).then(onSuccess, onError)
            }
            , get: function (onSuccess, onError, entity, params) {
                return $http({
                    method: 'GET'
                    , url: url + entity
                    , params: params
                    , paramSerializer: '$httpParamSerializerJQLike'
                }).then(onSuccess, onError)
            }
            , getById: function (id, onSuccess, onError, entity, params) {
                return $http({
                    method: 'GET'
                    , url: url + entity + '/' + id      
                    , params: params
                    , paramSerializer: '$httpParamSerializerJQLike'
                }).then(onSuccess, onError)
            }
            , put: function (id, data, onSuccess, onError, entity) {
                return $http({
                    method: 'PUT'
                    , url: url + entity + "/" + id
                    , data: data                    
                }).then(onSuccess, onError)
            }
            , deleteById: function (id, onSuccess, onError, entity) {
                return $http({
                    method: 'DELETE'
                    , url: url + entity + "/" + id
                }).then(onSuccess, onError)
            }
        }
    }
})();