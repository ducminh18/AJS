MyApp.controller("SanPhamController", ['$scope', 'CrudService',
    function ($scope, CrudService) {
        //khai báo các xử lý cho controller
        //khai báo các giá trị khởi tạo ban đầu
        var baseUrl = "/Home/";
        $scope.MaLoai = "";
        $scope.MaSP = "";
        $scope.TenSP = "";
        $scope.SoLuong = 0;
        $scope.MoTa = "";
        $scope.Anh = "";
        $scope.DonGia = 0;
        $scope.btnText = "Thêm";
        //xây dựng hàm lấy về các bản ghi trong đối tượng Loại SP
        $scope.LoadData = function () {
            var apiRoute = baseUrl + "GetAll";
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
            var apiRoute = baseUrl + "GetByID";
            var oneLSP = CrudService.getbyid(apiRoute, s.MaSP);
            oneLSP.then(function (res) {
                $scope.MaLoai = res.data.MaLoai;
                $scope.MaSP = res.data.MaSP;
                $scope.TenSP = res.data.TenSP;
                $scope.SoLuong = res.data.SoLuong;
                $scope.MoTa = res.data.MoTa;
                $scope.Anh = res.data.Anh;
                $scope.DonGia = res.data.DonGia;
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
                MaSP: $scope.MaSP,
                TenSP: $scope.TenSP,
                SoLuong: $scope.SoLuong,
                MoTa: $scope.MoTa,
                Anh: $scope.Anh,
                DonGia: $scope.DonGia
            };
            /* any way to get the object input */
            console.log("Uploading");
            var file = document.querySelector('input[type=file]');
            let reader = new FileReader();
            if (file.files[0]) {
                reader.onload = () => {
                    imgBase64 = reader.result;
                    console.log(reader.result);
                    $scope.Anh = reader.result;
                }
                reader.readAsDataURL(file[0]);
            }
            //thực hiện thao tác sửa loại sản phẩm
            var apiRoute = baseUrl + "AddOrEdit";
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
            $("#exampleModal").modal("hide");
        }
        //thực hiện xóa loại sản phẩm
        $scope.DeleteSP = function (dataModel) {
            if (!confirm("Bạn có chắc chắn muốn xóa dữ liệu không?")) {
                return;
            }
            var apiRoute = baseUrl + "Delete";
            var deletedata = CrudService.getbyid(apiRoute, dataModel.MaSP);
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
            $scope.MaSP = "";
            $scope.TenSP = "";
            $scope.SoLuong = 0;
            $scope.MoTa = "";
            $scope.Anh = "";
            $scope.DonGia = 0;
            $scope.btnText = "Thêm";
        }
    }]);