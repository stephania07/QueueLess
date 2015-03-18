;(function(){
    'use strict';
    angular.module('QueueLess')
    .config(function($routeProvider){
        $routeProvider
        .when('/', {
            templateUrl: 'Views/Queue/Index.cshtml'
        })

            .when('/AddQueue', {
                templateUrl: 'Views/',
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