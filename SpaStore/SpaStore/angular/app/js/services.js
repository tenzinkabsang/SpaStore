'use strict';

/* Services */

angular.module('myStore.services', ['ngResource']).

    factory('ProductBriefs', function ($resource) {
        return $resource('api/productBriefs');
    }).

    factory('Products', function ($resource) {
        return $resource('api/products/:Id', { Id: '@Id' }, { 'update': { method: 'PUT' } });
    }).

    factory('CategoryBriefs', function ($resource) {
        return $resource('api/categoryBriefs');
    }).

    factory('Categories', function ($resource) {
        return $resource('api/categories/:Id', { Id: '@Id' }, { 'update': { method: 'PUT' } });
    });
 