
(function() {
    "use strict";

    angular
        .module("nfcApp")
        .controller("mainCtrl", mainCtrl);

    mainCtrl.$inject = ["$uibModal", "$log", "crudServiceDel", "crudServiceSupp"];

    /* @ngInject */
    function mainCtrl($uibModal, $log, crudServiceDel, crudServiceSupp) {
        var vm = this;
        vm.title = "mainCtrl";
        vm.data = {};
        vm.details = {};
        vm.details.isShown = false;
        vm.isShown = true;
        vm.isShownNoResultInfo = false;
        vm.searchNoResultText = "Sorry, nothing found";
        vm.showSupplierDetails = true;
        vm.del = {};
        vm.supp = {};
        vm.getSupplierDetails = getSupplierDetails;
        vm.addNewSupplier = addNewSupplier;
        vm.addNewDelivery = addNewDelivery;
        vm.saveDel = saveDel;
        vm.saveSupp = saveSupp;
        vm.toggleDelForm = toggleDelForm;
        vm.toggleSuppForm = toggleSuppForm;
        vm.showDelForm = false;
        vm.showSuppForm = false;

        activate();

        ////////////////

        function activate() {
            loadDeliveries();
            loadSuppliers();
        }

        //addNewSupplier.html modal
        function addNewSupplier() {
            var modalInstance = $uibModal.open({
                templateUrl: "addNewSupplier.html",
                controller: "addNewSupplierCtrl",
                controllerAs: "$instc",
                resolve: {
                    items: function() {
                        return "Add new Supplier";
                    }
                }
            });

            modalInstance.result
                .then(function(suppl) {
                    saveSupp(suppl);
                })
                .catch(function(error) {
                    $log.info("Modal " + error + " at: " + new Date());
                });
        }

        function addNewDelivery() {
            var modalInstance = $uibModal.open({
                templateUrl: "addNewDelivery.html",
                controller: "addNewDeliveryCtrl",
                controllerAs: "$instc",
                resolve: {
                    items: function() {

                        var obj = {
                            title: "Add new Delivery",
                            options: vm.data.suppliers
                        };
                        return obj;
                    }
                }
            });

            modalInstance.result
                .then(function(suppl) {
                    saveDel(suppl);
                })
                .catch(function(error) {
                    $log.info("Modal " + error + " at: " + new Date());
                });
        }

        function toggleSuppForm() {
            vm.showSuppForm = !vm.showSuppForm;
        }

        function toggleDelForm() {
            vm.showDelForm = !vm.showDelForm;
        }

        function saveSupp(supp) {
            var save = crudServiceSupp.postSupplier(supp);
            var id = 0;
            save.then(function(resp) {
                debugger;
                id = resp.data.id;
                loadSuppliers();
                alert("New Supplier added successfuly");

            }, function(error) {
                vm.data.error = error;
            });
        }

        function saveDel(del) {
            var save = crudServiceDel.postDelivery(del);

            save.then(function(resp) {
                    debugger;
                    loadDeliveries();
                    alert("New Delivery added successfuly, id: " + resp.data.id);

                }, function(error) {
                    vm.data.error = error;
                }
            );
            debugger;
        }

        function loadDeliveries() {

            var result = crudServiceDel.getDeliveries();
            result.then(function(response) {
                vm.data.deliveries = response.data;
            }, function(error) {
                vm.data.error = error;
            });
        }

        function loadSuppliers() {

            var result = crudServiceSupp.getSuppliers();
            result.then(function(response) {
                vm.data.suppliers = response.data;
            }, function(error) {
                vm.data.error = error;
            });
        }

        function getSupplierDetails(id) {


            var result = {};
            var supplierItin = "";
            var deliveryCurrency = [];
            var totalDeliveryCount = 0;
            var totalDeliverySum = 0;
            //start
            for (var i = 0; i < vm.data.deliveries.length; i++) {
                var del = vm.data.deliveries[i];
                if (del.supplierId == id) {
                    // 0. getSupplierInn 
                    supplierItin = del.supplierItin;
                    //1.getTotalDeliveryCount
                    totalDeliveryCount++;
                    //2.getTotalDeliverySum
                    totalDeliverySum += del.total;
                    //3.getDeliveryCurrency
                    //exclude duplicates
                    if (deliveryCurrency.indexOf(del.currency) == -1) {
                        deliveryCurrency.push(del.currency);
                    }
                }
            }
            vm.details.isShown = true;
            vm.details.supplierItin = supplierItin;
            result.deliveryCurrency = deliveryCurrency;
            vm.details.totalDeliveryCount = totalDeliveryCount;
            vm.details.totalDeliverySum = totalDeliverySum;
            vm.details.deliveryCurrency = deliveryCurrency;
        }
    }
})();