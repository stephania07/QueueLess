; (function () {
    'use strict';
    angular.module('QueueLess')
    .controller('ShowQueueController', function ($scope, $http, QueueRepository) {
        $scope.queues = QueueRepository.get();
            
    })
}());