
(function () {
    'use strict';

    angular
        .module('nfcApp')
        .factory('crudServiceSupp', crudServiceSupp);

    crudServiceSupp.$inject = ['$http'];

    /* @ngInject */
    function crudServiceSupp($http) {
        var service = {
            //getDeliveriesLocal: getDeliveriesLocal,
            getSuppliers: getSuppliers,
            getSupplier: getSupplier,
            putSupplier: putSupplier,
            postSupplier: postSupplier,
            deleteSupplier: deleteSupplier

        };
        return service;

        ////////////////

        //get all
        function getSuppliers() {
            return $http.get('/api/Suppliers');
        }
/*        function getDeliveriesLocal() {
            return $http.get('/data/deliveries.json')
        }*/
        //get single by id
        function getSupplier(id) {
            return $http.get('/api/Suppliers/' + id);
        }
        /*        function getDeliveryLocal(id) {
                    $http.get('api/Deliveries/' + id)
                }*/


        //update by id
        function putSupplier(id, delivery) {
            var putRequest = $http({
                method: 'put',
                url: '/api/Suppliers/' + id,
                data: delivery
            });
            return putRequest;
        }
        //save
        function postSupplier(delivery) {
            var postRequest = $http({
                method: 'post',
                url: '/api/Suppliers',
                data: delivery
            });
            return postRequest;
        }
        //delete
        function deleteSupplier(id) {
            var deletedRecord = $http({
                method: 'delete',
                url: '/api/Suppliers/' + id
            });
            return deletedRecord;
        }
    }
})();

