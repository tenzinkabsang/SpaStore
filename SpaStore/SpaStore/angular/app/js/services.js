'use strict';

/* Services */

angular.module('myStore.services', ['ngResource']).
    
    factory('Products', function($resource) {
        return $resource('api/products/:Id', { Id: '@Id' }, { 'update': { method: 'PUT' } });
    }).
    
    factory('Categories', function($resource) {
        return $resource('api/categories/:Id', { Id: '@Id' }, { 'update': { method: 'PUT' } });
    });
 