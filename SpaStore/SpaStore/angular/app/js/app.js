'use strict';


// Declare app level module which depends on filters, and services
angular.module('myStore', ['myStore.filters', 'myStore.services', 'myStore.directives', 'myStore.controllers']).
  config(['$routeProvider', function($routeProvider) {
    $routeProvider.
    	when('/', {
    		templateUrl:  relativeUrl('partials/home.html'),
    		controller: 'HomeCtrl'
    	}).

    	when('/products', {
    		templateUrl: relativeUrl('partials/store.html'), 
    		controller: 'ProductsCtrl'
    	}).

    	when('/product/:id', {
    		templateUrl: relativeUrl('partials/product-detail.html'),
    		controller: 'ProductDetailCtrl'
    	});

    $routeProvider.otherwise({ redirectTo: '/' });

    function relativeUrl(url) { return "angular/app/" + url; };
  }]);
