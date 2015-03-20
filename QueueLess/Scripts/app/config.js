;(function(){
    'use strict';
    angular.module('QueueLess')
    .config(function($routeProvider){
        $routeProvider.when('/', {
            templateUrl: 'Static/View/Home.html'
        });

        //$routeProvider.when('/login', {
        //    templateUrl: 'Static/View/login.html',
        //    controller: 'LoginController'
        //});

        //$routeProvider.when('/register', {
        //    templateUrl: 'Static/View/signup.html',
        //    controller: 'SignupController'
        //});

          $routeProvider.when('/JoinQueue', {
            templateUrl: 'Static/View/JQueue.html',
            controller: 'AddQueueController'
          });

           $routeProvider.when('/ShowQueue', {
                templateUrl: 'Static/View/SQueue.html',
                controller: 'AddQueueController'
            })
        .otherwise({redirectTo: '/Index'});
      })
}());

