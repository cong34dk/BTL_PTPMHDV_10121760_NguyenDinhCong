var app = angular.module('AppBanDienThoai', []);

    app.controller('ProductController', function ($scope, $http) {
        //Khai báo biến
        $scope.products = []; // Dữ liệu sản phẩm được lấy từ API

        $scope.newProduct = {
            "maSanPham": 0,
            "maChuyenMuc": 31,
            "tenSanPham": "",
            "anhDaiDien": "",
            "gia": null,
            "giaGiam": null,
            "soLuong": null,
            "trangThai": true,
            "luotXem": 0,
            "dacBiet": false
        };

        // Hàm lấy danh sách sản phẩm
        $scope.LoadSanPham = function (){
            $http({
                method: "GET",
                url: "https://localhost:44388/api/SanPham/get-all"
            }).then(function (response) {
                $scope.products = response.data;
            }).catch(function (error) {
                console.log('Có lỗi khi lấy dữ liệu từ API', error);
            });
        }

        // Hàm xóa sản phẩm
        $scope.deleteProduct = function(productId) {
            if (confirm('Bạn có chắc chắn muốn xóa sản phẩm này không?')) {
                $http({
                    method: "DELETE",
                    url: `https://localhost:44388/api/SanPham/delete/${productId}`
                }).then(function (response) {
                    alert(response.data.message);
                    // Sau khi xóa thành công, cập nhật lại danh sách sản phẩm
                    $scope.LoadSanPham();
                }).catch(function (error) {
                    alert('Có lỗi khi xóa sản phẩm');
                    console.log('Lỗi khi xóa sản phẩm', error);
                });
            }
        };

        //Hàm thêm sản phẩm
        $scope.addProduct = function() {
            $http.post('https://localhost:44388/api/SanPham/create-SanPham', $scope.newProduct)
                .then(function(response) {
                    // Xử lý kết quả sau khi thêm sản phẩm thành công
                    console.log('Sản phẩm đã được thêm:', response.data);
                    // Đặt logic xử lý khi thêm sản phẩm thành công
                    alert('Sản phẩm đã được thêm thành công');
                    $scope.LoadSanPham();
                    $scope.newProduct = {};
                })
                .catch(function(error) {
                    // Xử lý khi có lỗi trong quá trình thêm sản phẩm
                    console.error('Lỗi khi thêm sản phẩm:', error);
                    // Đặt logic xử lý khi có lỗi
                    alert('Lỗi khi thêm sản phẩm');
                });
        };


        //Hàm sửa sản phẩm
        $scope.openEditModal = function (product) {
            $scope.isEditModalOpen = true;
            $scope.editedProduct = angular.copy(product); // Copy thông tin sản phẩm cần sửa vào biến editedProduct
        };

        $scope.closeEditModal = function () {
            $scope.isEditModalOpen = false;
        };

        $scope.saveEditedProduct = function () {
            // Sử dụng $scope.editedProduct để lấy thông tin sản phẩm đã chỉnh sửa
            // Sau khi gọi API xong, đóng modal sửa sản phẩm
            $http.put('https://localhost:44388/api/SanPham/update-SanPham', $scope.editedProduct)
                .then(function (response) {
                    // Xử lý kết quả từ API (response)
                    console.log(response.data.message); // Log message từ server
                    alert('Sửa sản phẩm thành công')
                    $scope.LoadSanPham()
                    $scope.isEditModalOpen = false; // Đóng modal sau khi cập nhật thành công
                })
                .catch(function (error) {
                    // Xử lý lỗi (nếu có)
                    console.error('Lỗi khi đang sửa sản phẩm:', error);
                });
        };
        

          // Gọi API khi trang được tải
          $scope.LoadSanPham()

    });