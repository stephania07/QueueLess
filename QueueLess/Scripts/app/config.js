angular.module('QueueLess', ['ngRoute', 'ngResource'])
    .config(function ($routeProvider) {
        $routeProvider.when('/', {templateUrl: 'Static/View/Home.html' });
        $routeProvider.when('/JoinQueue',{templateUrl: 'Static/View/JQueue.html', controller: 'AddQueueController'});
        $routeProvider.when('/ShowQueue', { templateUrl: 'Static/View/SQueue.html', controller: 'ShowQueueController' });
        $routeProvider.when('/DeleteQueue', { templateUrl: 'Static/View/DQueue.html', controller: 'ShowQueueController'});
        $routeProvider.when('/EditQueue', { templateUrl: 'Static/View/EQueue.html', controller: 'ShowQueueController' });


    })

.controller('AddQueueController', function($scope, queueRepository, $location){
    $scope.queues = queueRepository.query();

    $scope.save = function () {
        queueRepository.save($scope.queue);
        $location.url("/ShowQueue");
    }
})
    //show all queue
.controller('ShowQueueController', function ($scope, queueRepository, $location) {
    $scope.queues = queueRepository.query();

    //delete queue
    $scope.delete = function (id) {
        queueRepository.delete({ id: id });
        $location.url("/DeleteQueue");
    }

    //edit queue
    $scope.edit = function (id) {
        queueRepository.edit({ id: id });
        $location.url("/EditQueue");
    }
})

    //counts the queue
.controller('queueCountCtrl', function ($scope, queueRepository) {
    $scope.queuecount = queueRepository.query();

})

    //counts by service = to be revised
.controller('servicecountCtrl', function ($scope, queueRepository) {
    $scope.queueservice = queueRepository.query();

})






