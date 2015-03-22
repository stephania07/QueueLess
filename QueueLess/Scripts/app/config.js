angular.module('QueueLess', ['ngRoute', 'ngResource'])
    .config(function ($routeProvider) {
        $routeProvider.when('/', {templateUrl: 'Static/View/Home.html' });
        $routeProvider.when('/JoinQueue',{templateUrl: 'Static/View/JQueue.html', controller: 'AddQueueController'});
        $routeProvider.when('/ShowQueue', { templateUrl: 'Static/View/SQueue.html', controller: 'ShowQueueController' });

    })

.controller('AddQueueController', function($scope, queueRepository, $location){
    $scope.queues = queueRepository.query();

    $scope.save = function () {
        queueRepository.save($scope.queue);
        $location.url("/ShowQueue");
    }
})
.controller('ShowQueueController', function ($scope, queueRepository, $location) {
    $scope.queues = queueRepository.query();
})

    //To be revised
.controller('ShowQueueController', function ($scope, queueRepository, $location) {
    $scope.queues = queueRepository.query();

    $scope.delete = function () {
        queueRepository.delete($scope.queue);
        $location.url("/JoinQueue");
    }
})

        //counts the queue
.controller('queueCountCtrl', function ($scope, queueRepository) {
        $scope.queuecount = queueRepository.query();
})

    //counts by category/service = to be revised
.controller('serviceCountCtrl', function ($scope, queueRepository) {
    $scope.queueservice = queueRepository.query();
    })






