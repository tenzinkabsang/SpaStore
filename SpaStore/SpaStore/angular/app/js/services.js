'use strict';

/* Services */

angular.module('myStore.services', ['ngResource']).

    factory('ProductBriefs', function ($resource) {
        return $resource('api/productBriefs/:Id', { Id: '@Id' }, { 'update': { method: 'PUT' } });
    }).

    factory('Products', function ($resource) {
        return $resource('api/products/:Id', { Id: '@Id' }, { 'update': { method: 'PUT' } });
    }).

    factory('CategorieBriefs', function ($resource) {
        return $resource('api/categorieBriefs');
    }).

    factory('Categories', function ($resource) {
        return $resource('api/categories/:Id', { Id: '@Id' }, { 'update': { method: 'PUT' } });
    });
 