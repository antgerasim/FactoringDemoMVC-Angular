/**
 * Created by Fenchelteefee on 14.12.2016.
 */
(function() {
    "use strict";

    angular
        .module("nfcApp")
        .controller("addNewDeliveryCtrl", addNewDeliveryCtrl);

    addNewDeliveryCtrl.$inject = ["$uibModalInstance", "items"];

    /* @ngInject */
    function addNewDeliveryCtrl($uibModalInstance, items) {
        var $instc = this;
        $instc.title = items.title;
        $instc.options = items.options;
        //$instc.selectedOption = {};
        $instc.editableDel = {};
        $instc.submitForm = submitForm;
        $instc.cancel = cancel;
        $instc.itinField = {};
        $instc.itinField.pattern = /^(9\d{2})([ \-]?)([7]\d|8[0-8])([ \-]?)(\d{4})$/;
        $instc.itinField.pattern2 = /^(9\d{2})([7]\d|8[0-8])([ \-]?)(\d{4})$/;


        //$instc.formFieldError = false;

        activate();

        ////////////////

        function activate() {

        }

        function submitForm() {
            var obj = {
                currency: $instc.editableDelivery.currency,
                delNo: $instc.editableDelivery.delNumber,
                total: $instc.editableDelivery.total,
                supplier: $instc.editableDelivery.suppl.companyName,
                supplieritin: $instc.editableDelivery.suppl.itin,
                supplierId: $instc.editableDelivery.suppl.id
            };
            $uibModalInstance.close(obj);
        }

        function cancel() {
            $uibModalInstance.dismiss("dismissed");
        }
    }

})();