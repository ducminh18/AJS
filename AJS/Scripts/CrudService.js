//Khai báo các dịch vụ dùng 1 lần
MyApp.service('CrudService', function ($http) {
    //Tất cả các dịch vụ viết trong hàm này
    //lấy về danh sách loại sp
    this.getAll = function (apiRoute) {
        urlGet = apiRoute;
        return $http.get(urlGet);
    }
    //lấy về một loại sản phẩm
    this.getbyid = function (apiRoute, maloai) {
        urlGet = apiRoute + "/" + maloai;
        return $http.get(urlGet);
    }
    //Thêm mới loại sản phẩm
    this.post = function (apiRoute, Model) {
        var request = $http({
            method: "post",
            url: apiRoute,
            data: Model
        });
        return request;
    }
    //Sửa loại sản phẩm
    this.put = function (apiRoute, Model) {
        var request = $http({
            method: "put",
            url: apiRoute,
            data: Model
        });
        return request;
    }
    //xóa loại sản phẩm
    this.delete = function (apiRoute) {
        var request = $http({
            method: "delete",
            url: apiRoute
        });
        return request;
    }
});
