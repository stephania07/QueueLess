; (function () {
    'use strict';
    angular.module('QueueLess')
    .controller('AddQueueController', function($scope){
        $scope.submit = function () {
            var Queue = {
                Service: $scope.Service,
                FirstName: $scope.FirstName,
                LastName: $scope.LastName,
                PhoneNumber: $scope.PhoneNumber,
                Email: $scope.Email
            };
        };
      })
}());