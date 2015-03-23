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

    //counts the queue
.controller('queueCountCtrl', function ($scope, queueRepository) {
        $scope.queuecount = queueRepository.query();
})

    //counts by service = to be revised
.controller('serviceCountCtrl', function ($scope, queueRepository) {
    $scope.queueservice = queueRepository.query();
 })

   //delete To be revised
.controller('ShowQueueController', function ($scope, queueRepository, $location) {
    $scope.queues = queueRepository.query();

    $scope.delete = function () {
        queueRepository.delete();
        $location.url("/ShowQueue");
    }
})





