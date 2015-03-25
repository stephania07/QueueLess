angular.module('QueueLess', ['ngRoute', 'ngResource'])
    .config(function ($routeProvider) {
        $routeProvider.when('/', {templateUrl: 'Static/View/Home.html' });
        $routeProvider.when('/JoinQueue',{templateUrl: 'Static/View/JQueue.html', controller: 'AddQueueController'});
        $routeProvider.when('/ReplyQueue', { templateUrl: 'Static/View/RQueue.html', controller: 'ShowQueueController' });
        $routeProvider.when('/DeleteQueue', { templateUrl: 'Static/View/DQueue.html', controller: 'ShowQueueController'});
        $routeProvider.when('/EditQueue', { templateUrl: 'Static/View/EQueue.html', controller: 'ShowQueueController' });
        $routeProvider.when('/ShowQueue', { templateUrl: 'Static/View/SQueue.html', controller: 'ShowQueueController' });



    })

.controller('AddQueueController', function($scope, queueRepository, $location, $rootScope){
    $scope.queues = queueRepository.query();

    $scope.save = function () {
        queueRepository.save($scope.queue);
        $rootScope.currentQueue = $scope.queue;
        $location.url("/ReplyQueue");
    }
    $scope.new = 0;
    $scope.existing = 0;

    queueRepository.query(function (queues) {
        queues.forEach(function (queue) {
            console.log(queue);
            if (queue.Service == "new") {
                $scope.new++;
            }
            else {
                $scope.existing++;

            }
        })
    })
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

//    //counts the queue
//.controller('queueCountCtrl', function ($scope, queueRepository) {
//    $scope.queuecount = queueRepository.query();

//    $scope.new = 0;
//    $scope.existing = 0;

//    queueRepository.query().forEach(function (queue) {
//        if(queue.Service == "New")
//        {
//            $scope.new++;
//        }
//        else
//        {
//            $scope.existing++;

//        }
           
//    })
//})



    //counts by service
.controller('ServiceCtrl', function ($scope, queueRepository) {
    $scope.queueservice = queueRepository.query();
     
})




