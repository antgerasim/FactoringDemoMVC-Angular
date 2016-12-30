/**
 * Created by Fenchelteefee on 14.12.2016.
 */
(function() {
    "use strict";

    angular
        .module("nfcApp")
        .controller("addNewSupplierCtrl", addNewSupplierCtrl);

    addNewSupplierCtrl.$inject = ["$uibModalInstance", "items"];

    /* @ngInject */
    function addNewSupplierCtrl($uibModalInstance, items) {
        var $instc = this;
        $instc.title = items;
        $instc.editableSupplier = {};
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
            $uibModalInstance.close($instc.editableSupplier);
        }

        function cancel() {
            $uibModalInstance.dismiss("dismissed");
        }
    }

})();