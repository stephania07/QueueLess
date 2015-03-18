;(function(){
    'use strict';
    angular.module('QueueLess')
    .config(function($routeProvider){
        $routeProvider
        .when('/', {
            templateUrl: 'Static/Index.html'
        })

            .when('/AddQueue', {
                templateUrl: 'Static/Home.html',
                Controller: 'AddQueueController',
                ControllerAs: 'AddCtrl'
            })
        .otherwise({redirectTo: '/home'});
      })
}());

//Eliza
//; (function () {
//    'use strict';
//    angular.module('QueueLess')
//    .config(function ($routeProvider) {
//        $routeProvider
//        .when('/', {
//            templateUrl: 'Views/Queue/Index'
//        })

//            .when('/AddQueue', {
//                templateUrl: 'Views/',
//                Controller: 'QueueController',
//                ControllerAs: 'QueueCtrl'
//            })
//        .otherwise({ redirectTo: '/' });
//    })
//}());