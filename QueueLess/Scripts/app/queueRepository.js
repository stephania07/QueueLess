angular.module('QueueLess')
    .factory('queueRepository', function ($resource) {
        return $resource('/api/queue/:id');


        //    get: function(){
        //        return $resource('/api/queue').queue();
        // },

        //submit: function(queue){
        //    return $resource('/api/queue').submit(queue);
        //}
    

});