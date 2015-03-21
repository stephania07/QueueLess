angular.module('QueueLess')
    .factory('queueRepository', function ($resource) {
        return {
            get: function(){
                return $resource('/api/queue').query();
            },

            submit: function(queue){
                return $resource('/api/queue').submit(queue);
            }
        }

    });