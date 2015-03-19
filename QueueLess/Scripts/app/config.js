;(function(){
    'use strict';
    angular.module('QueueLess')
    .config(function($routeProvider){
        $routeProvider.when('/', {
            templateUrl: 'Static/Index.html'
        });

        $routeProvider.when('/JoinQueue', {
            templateUrl: 'Static/JQueue.html',
            controller: 'AddQueueController'
        })

           $routeProvider.when('/ShowQueue', {
                templateUrl: 'Static/SQueue.html',
                controller: 'AddQueueController'
            })
        .otherwise({redirectTo: '/home'});
      })
}());

