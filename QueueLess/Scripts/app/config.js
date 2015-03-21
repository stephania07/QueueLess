angular.module('QueueLess', ['ngRoute', 'ngResource'])
    .config(function ($routeProvider) {
        $routeProvider.when('/', {templateUrl: 'Static/View/Home.html' });
        $routeProvider.when('/JoinQueue',{templateUrl: 'Static/View/JQueue.html', controller: 'AddQueueController'});
        $routeProvider.when('/ShowQueue',{templateUrl: 'Static/View/SQueue.html', controller: 'ShowQueueController'});
    })

.controller('AddQueueController', function($scope, queueRepository, $location){
    $scope.queues = queueRepository.query();

    $scope.save = function () {
       // console.log($scope.queue);
        queueRepository.save($scope.queue);
        $location.url("/ShowQueue");
    }
})
.controller('ShowQueueController', function ($scope, queueRepository) {
    $scope.queues = queueRepository.query();

})


