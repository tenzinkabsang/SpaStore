'use strict';

/* Controllers */


Array.prototype.withNumbers = function (count) {
    var i;
    for (i = 1; i <= count; i++) {
        this.push(i);
    }
    return this;
};

angular.module('myStore.controllers', []).
    
    controller('HomeCtrl', ['$scope', function ($scope) {

    }]).
    
    controller('ProductsCtrl', ['$scope', 'Categories', 'Products', function($scope, Categories, Products) {
        $scope.categories = Categories.query();

        // use this as cache to hold all products
        $scope.allProducts = Products.query();

        // initially show all products without any category filters
        $scope.products = $scope.allProducts;

        // filter products by selected category
        $scope.productsWithCategory = function(categoryId) {
            if (categoryId) {
                $scope.products = _.where($scope.allProducts, { categoryId: categoryId });
            } else {
                $scope.products = $scope.allProducts;
            }
            $scope.currentPage = 1;
        };

        // handle pagination
        $scope.currentPage = 1;
        $scope.pageSize = 2;
        $scope.numberOfPages = function() {
            return Math.ceil($scope.products.length / $scope.pageSize);
        };

        $scope.startPage = function() {
            return ($scope.currentPage - 1) * $scope.pageSize;
        };

        // get the number of pages for the selected category of products
        $scope.pages = function() {
            return [].withNumbers($scope.numberOfPages());
        };

        // switch page as requested
        $scope.switchPage = function(index) {
            $scope.currentPage = index;
        };

        $scope.moveBack = function() {
            if ($scope.currentPage > 1) {
                $scope.currentPage--;
            }
        };

        $scope.moveForward = function() {
            if ($scope.currentPage < $scope.numberOfPages()) {
                $scope.currentPage++;
            }
        };

    }]).
    
    controller('ProductDetailCtrl', ['$scope', 'Products', function($scope, Products) {

    }]);