angular.module('QueueLess')
    .factory('queueRepository', function ($resource) {
        return $resource('/api/queue/:id');

});