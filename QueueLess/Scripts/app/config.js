//;(function(){
//    'use strict';
//    angular.module('QueueLess')
//    .config(function($routeProvider, $locationProvider){
//        $routeProvider.when('/', {
//            templateUrl: 'Static/View/Home.html'
//        });
//          $routeProvider.when('/JoinQueue', {
//            templateUrl: 'Static/View/JQueue.html',
//            controller: 'AddQueueController'
//          });

//          $routeProvider.when('/ShowQueue', {
//              templateUrl: 'Static/View/SQueue.html',
//              controller: 'ShowQueueController'
//          })
//       // $locationProvider.html5Mode(true)

//        .otherwise({redirectTo: '/Index'});
//      })
//}());

angular.module('QueueLess', ['ngRoute', 'ngResource'])
    .config(function ($routeProvider) {
        $routeProvider.when('/', {templateUrl: 'Static/View/Home.html' });
        $routeProvider.when('/JoinQueue',{templateUrl: 'Static/View/JQueue.html', controller: 'AddQueueController'});
        $routeProvider.when('/ShowQueue',{templateUrl: 'Static/View/SQueue.html', controller: 'ShowQueueController'});
    })

.controller('AddQueueController', function($scope, queueRepository, $location){
    $scope.queues = queueRepository.get();

    $scope.submit = function (queue) {
        queueRepository.submit(queue);
        $location.url("/ShowQueue");
    }
})
.controller('ShowQueueController', function ($scope, queueRepository) {
    $scope.queues = queueRepository.get();

})


