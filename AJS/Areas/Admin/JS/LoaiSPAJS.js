MyApp.controller("LoaiSPController", ['$scope', 'CrudService', function ($scope, CrudService) {
    //khai báo các xử lý cho controller
    //khai báo các giá trị khởi tạo ban đầu
    var baseUrl = "/Admin/HomeAd/";
    $scope.MaLoai = "";
    $scope.TenLoai = "";
    $scope.GhiChu = "";
    $scope.btnText = "Thêm";
    //xây dựng hàm lấy về các bản ghi trong đối tượng Loại SP
    $scope.LoadData = function () {
        var apiRoute = baseUrl + "GetAllLSP";
        var allData = CrudService.getAll(apiRoute);
        allData.then(function (res) {
            $scope.listdata = res.data;
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }
    $scope.LoadData();
    //Viết hàm lấy về một sản phẩm
    $scope.GetByID = function (s) {
        var apiRoute = baseUrl + "GetOneLSP";
        var oneLSP = CrudService.getbyid(apiRoute, s.MaLoai);
        oneLSP.then(function (res) {
            $scope.MaLoai = res.data.MaLoai;
            $scope.TenLoai = res.data.TenLoai;
            $scope.GhiChu = res.data.GhiChu;
            $scope.btnText = "Sửa";
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }
    //Viết hàm thực hiện thêm mới một sản phẩm
    $scope.SaveUpdate = function () {
        //khai báo một bản ghi
        var singledata = {
            MaLoai: $scope.MaLoai,
            TenLoai: $scope.TenLoai,
            GhiChu: $scope.GhiChu
        };
        if ($scope.btnText == "Thêm") {
            //thực hiện thao tác thêm loại sản phẩm
            var apiRoute = baseUrl + "CreateLSP";
            var saveData = CrudService.post(apiRoute, singledata);
            saveData.then(function (res) {
                if (res.data != null) {
                    alert("Thêm mới thành công!");
                    $scope.LoadData();
                    $scope.Clear();
                }
            }, function (error) {
                console.log("Lỗi: " + error);
            });
        }
        else {
            //thực hiện thao tác sửa loại sản phẩm
            var apiRoute = baseUrl + "UpdateLSP";
            var updateData = CrudService.post(apiRoute, singledata);
            updateData.then(function (res) {
                if (res.data != "") {
                    alert("Cập nhật thành công");
                    $scope.LoadData();
                    $scope.Clear();
                }
            }, function (error) {
                console.log("Lỗi: " + error);
            });
        }
        $("#exampleModal").modal("hide");
    }
    //thực hiện xóa loại sản phẩm
    $scope.DeleteLSP = function (dataModel) {
        if (!confirm("Bạn có chắc chắn muốn xóa dữ liệu không?")) {
            return;
        }
        var apiRoute = baseUrl + "DeleteLSP";
        var deletedata = CrudService.getbyid(apiRoute, dataModel.MaLoai);
        deletedata.then(function (res) {
            if (res.data != "") {
                alert("Xóa thành công");
                $scope.LoadData();
                $scope.Clear();
            }
        }, function (error) {
            console.log("Lỗi: " + error);
        });
        $("#exampleModal").modal("hide");
    }
    //khai báo hàm Clear
    $scope.Clear = function () {
        $scope.MaLoai = "";
        $scope.TenLoai = "";
        $scope.GhiChu = "";
    }
}]);