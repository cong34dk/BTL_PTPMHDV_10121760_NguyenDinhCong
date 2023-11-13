// Khai báo ứng dụng AngularJS
var app = angular.module("AppBanDienThoai", []);

// Tạo controller để quản lý logic
app.controller("HomeController", function ($scope, $http, $window, $interval) {


  $scope.categories;
  $scope.currentImage;
  $scope.imageIndex = 0;


  $scope.LoadChuyenMuc = function () {
    $http({
      method: "GET",
      url: "https://localhost:44321/api/Home/GetAllChuyenMuc",
    }).then(function (response) {
      // Gán dữ liệu từ API vào $scope để hiển thị trong trang HTML
      //   $scope.categories = response.data;
      // Chia dữ liệu thành các hàng (mỗi hàng có 6 phần tử)
      $scope.categories = chunkArray(response.data, 6);
      //   console.log($scope.categories);
    });
  };



  $scope.LoadSlide = function (){
    $http({
        method: "GET",
        url: "https://localhost:44321/api/Home/GetAllSlide",
    }).then(function (response){
        $scope.images = response.data;
        $scope.currentImage = $scope.images[0].linkAnh;

        // Sử dụng $interval để tự động chuyển ảnh sau 3 giây
        $interval($scope.nextImage, 3000);      
    })
  }

  // Hàm chia mảng thành các mảng con với kích thước được chỉ định
  function chunkArray(array, size) {
    var result = [];
    for (var i = 0; i < array.length; i += size) {
      result.push(array.slice(i, i + size));
    }
    return result;
  }


  $scope.nextImage = function () {
    $scope.imageIndex++;
    if ($scope.imageIndex >= $scope.images.length) {
      $scope.imageIndex = 0;
    }
    $scope.currentImage = $scope.images[$scope.imageIndex].linkAnh;
  };

  $scope.previousImage = function () {
    $scope.imageIndex--;
    if ($scope.imageIndex < 0) {
      $scope.imageIndex = $scope.images.length - 1;
    }
    $scope.currentImage = $scope.images[$scope.imageIndex].linkAnh;
  };

  // Gọi API khi trang được tải
  $scope.LoadChuyenMuc();
  $scope.LoadSlide();
});
