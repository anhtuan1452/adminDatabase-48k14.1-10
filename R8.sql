---1.Tạo schema
go
CREATE SCHEMA BaoMat;
GO
--Schema bảng chủ trọ (không bao gồm mật khẩu để bảo vệ tính bảo mật)
create view  BaoMat.ChuTro_View as
select CT_IDChuTro, CT_TenChuTro, CT_SoDienThoai, CT_TenTaiKhoan
from ChuTro;
go

--Schema Bảng Phòng
create view BaoMat.Phong_View as
select P_id, P_sophong, P_giaphong, P_tinhtrangphong
from Phong;
go 
--Schema bảng người thuê phòng, không bao gồm ảnh căn cước và mật khẩu để bảo vệ tính riêng tư và bảo mật.(Cho người thuê)
create or alter view BaoMat.NguoiThuePhongNgThue_View as
select NTP_IDnguoithuephong, P_id, NTP_tenkhach, NTP_sodienthoai, NTP_tentaikhoan, NTP_loaitaikhoan
from NguoiThuePhong;
go
--Schema bảng người thuê phòng (Cho chủ trọ)
create or alter view BaoMat.NguoiThuePhongNgChutro_View as
select NTP_IDnguoithuephong, P_id, NTP_tenkhach, NTP_sodienthoai, NTP_tentaikhoan, NTP_loaitaikhoan,NTP_anhcancuoc
from NguoiThuePhong;
go
--Schema Bảng hóa đơn
create view BaoMat.BangHoaDon_View as
select
    BHD_idBanghoadon, 
    P_ID, 
    BHD_ngaylaphoadon, 
    BHD_tongsotien, 
    BHD_tienphong
from
    BangHoaDon;
go
--Schema bảng minh chứng
create view BaoMat.MinhChung_View as
select
    MC_id, 
    BHD_idBanghoadon
	MC_anhminhchung
from
    MinhChung;
go
-- bảng cập nhật ảnh cho người thuê
create view BaoMat.UpdateMinhChung_View as
select
    MC_id, 
	MC_anhminhchung
from
    MinhChung;
go
--Bang HoaDonDichVu
create view BaoMat.HoaDonDichVu_View as
select
    HDDV_idhoadondichvu, 
    BHD_idBanghoadon
from
    HoaDonDichVu;
go
--Bảng HopDong (không bao gồm ảnh hợp đồng để đảm bảo bảo mật )(Bảng này cho người thuê)
create or alter view BaoMat.NgthueHopDong_View as
select
    HD_mahopdong, 
    P_id, 
    HD_tienphong, 
    HD_ngaybatdauthue, 
    HD_thoihanthue
from
    HopDong;
go
--Bảng HopDong (Bảng này cho chủ trọ)
create or alter view BaoMat.ChutroHopDong_View as
select
    HD_mahopdong, 
    P_id, 
    HD_tienphong, 
    HD_ngaybatdauthue, 
    HD_thoihanthue,
	HD_anhhopdong
from
    HopDong;
go
--Bảng DichVu
create view BaoMat.DichVu_View as
select
    DV_iddichvu, 
    DV_tendichvu, 
    DV_tiencuadichvu
from    DichVu;
go
--Bảng Hd_Dv
create view BaoMat.Hd_Dv_View as
select
    DV_iddichvu, 
    HDDV_idhoadondichvu, 
    tiendichvu
from
    Hd_Dv;
go
--2.Thiết lập truy cập dữ liệu qua thủ tục
-- 2.1 Lấy thông tin người thuê phòng (Dành cho người thuê)
create or alter proc LayNguoiThueChoNguoiThue
as
begin
    select * 
    from BaoMat.NguoiThuePhongNgThue_View
end;
go
exec LayNguoiThueChoNguoiThue
go
--2.2 Lấy thông tin người thuê phòng (Dành cho chủ trọ)
create or alter proc LayNguoiThueChoChuTro
as
begin
    select *  
    from BaoMat.NguoiThuePhongNgChutro_View
end
go
exec LayNguoiThueChoChuTro
go
--2.3 Truy vấn hợp đồng (Dành cho người thuê)
create or alter proc LayHopDongChoNguoiThue
as
begin
    select *  
    from BaoMat.NgthueHopDong_View
end;
go
exec LayHopDongChoNguoiThue
go
--2.4 Truy vấn hợp đồng (Dành cho chủ trọ)
create or alter proc LayHopDongChoChuTro
as
begin
    select * 
    from BaoMat.ChutroHopDong_View
end;
go
exec LayHopDongChoChuTro
go
--2.5 Lấy danh sách hóa đơn
create or alter proc LayDanhSachHoaDon
as
begin
    select *
    from BaoMat.BangHoaDon_View
end;
go
exec LayDanhSachHoaDon
go
--2.6 Thủ tục xóa người thuê phòng
create or alter proc  XoaNguoiThueTro
    @NTP_IDnguoithuephong int
as
begin
	if not exists (select 1 from NguoiThuePhong where NTP_IDnguoithuephong = @NTP_IDnguoithuephong)
    begin
        print N'Người thuê phòng không tồn tại'
        return
	end

    delete from NguoiThuePhong 
	where NTP_IDnguoithuephong = @NTP_IDnguoithuephong;
    print  N'Xóa thành công'
end

exec XoaNguoiThueTro @NTP_IDnguoithuephong = 1;
select * from NguoiThuePhong where @NTP_IDnguoithuephong = 1
go

--2.7 Thủ tục xóa Phòng
create or alter proc  XoaPhong
    @P_id int
as
begin
	if not exists (select 1 from Phong where P_id = @P_id)
    begin
        print N'Phòng không tồn tại'
        return
	end
    delete from HopDong where P_id = @P_id;
    delete from BangHoaDon where P_ID = @P_id;
    delete from Phong where P_id = @P_id;

    print N'Xóa thành công.';
end
go

exec XoaPhong @P_id = 1;
select * from Phong
go
--3.
--3.1 Mã hóa mật khẩu NTP đã có trong cơ sở dữ liệu
create or alter proc MaHoaMatKhauHTai
as
begin
        UPDATE NguoiThuePhong
        set NTP_matkhau = HASHBYTES('SHA2_256', CAST(NTP_matkhau as nvarchar (100)))
        where NTP_matkhau not like '0x%' 
end
go
exec MaHoaMatKhauHTai
select * from NguoiThuePhong
select * from ChuTro
go
--3.2 Tự động cập nhật trạng thái hóa đơn sau khi xác minh minh chứng
create or alter trigger UpdateTrangthai
on BangHoaDon
after insert, update
as
begin
    update BangHoaDon
	set BHD_trangthai = case
                        when MinhChung.MC_trangthai = 1 then 1
                        else 0
                    end
    from BangHoaDon 
    join MinhChung on BangHoaDon.BHD_idBanghoadon = MinhChung.BHD_idBanghoadon
    join inserted on BangHoaDon.BHD_idBanghoadon = inserted.BHD_idBanghoadon;
    print 'Cập nhật thành công.';
end;
go

--3.3 Thủ tục cho minh chứng trạng thái
create or alter proc ThemMinhChung
    @BHD_idBanghoadon INT,
    @MC_anhminhchung VARBINARY(MAX),
    @MC_trangthai INT
as
begin
    if exists ( select 1 from BangHoaDon where BHD_idBanghoadon = @BHD_idBanghoadon)
    begin
        insert into MinhChung (BHD_idBanghoadon, MC_anhminhchung, MC_trangthai)
        values (@BHD_idBanghoadon, @MC_anhminhchung, @MC_trangthai)
        print 'Thêm mới minh chứng thành công.';
	end
	else
    begin
        print 'Hóa đơn không tồn tại.';
	end
end
go

 --3.4 Thủ tục để thêm người thuê phòng một cách an toàn.
create or alter proc ThemNguoiThuePhong
	@NTP_IDNguoithuephong INT,
    @P_id INT,
    @NTP_tenkhach VARCHAR(100),
    @NTP_anhcancuoc VARBINARY(MAX),
    @NTP_sodienthoai VARCHAR(15),
    @NTP_tentaikhoan VARCHAR(50),
    @NTP_matkhau VARCHAR(100),
    @NTP_loaitaikhoan INT
as
begin
	if exists (select 1 from NguoiThuePhong where NTP_tentaikhoan=@NTP_tentaikhoan)
	begin
		print N'Đã tồn tại'
		return
	end
    insert into NguoiThuePhong (NTP_IDnguoithuephong,P_id, NTP_tenkhach, NTP_anhcancuoc, NTP_sodienthoai, NTP_tentaikhoan, NTP_matkhau, NTP_loaitaikhoan)
    values (@NTP_IDNguoithuephong,@P_id, @NTP_tenkhach, @NTP_anhcancuoc, @NTP_sodienthoai, @NTP_tentaikhoan,
	HASHBYTES('SHA2_256', @NTP_matkhau), @NTP_loaitaikhoan)
end;
go
exec ThemNguoiThuePhong 
	@NTP_IDNguoithuephong=1001,
	@P_id =1001,
    @NTP_tenkhach= N'ThanhNgan',
    @NTP_anhcancuoc =0x,
    @NTP_sodienthoai ='0142578952',
    @NTP_tentaikhoan ='user1001',
    @NTP_matkhau ='meow123',
    @NTP_loaitaikhoan =1
go
insert into Phong (P_id, P_sophong,P_giaphong,P_tinhtrangphong )
values(1001, 1001,1210395,'ok')
select * from NguoiThuePhong where P_id=1001
go
--- 3.5 Thủ tục để thêm chủ trọ một cách an toàn.
create or alter proc ThemChuTro
	@CT_IDChuTro int,
    @CT_TenChuTro VARCHAR(100),
    @CT_SoDienThoai VARCHAR(15),
    @CT_TenTaiKhoan VARCHAR(50),
    @CT_MatKhau VARCHAR(100)
as
begin
    if exists (select 1 from ChuTro where CT_TenTaiKhoan = @CT_TenTaiKhoan)
    begin
        print'Tên tài khoản đã tồn tại';
        return
    end
    insert into ChuTro (CT_IDChuTro,CT_TenChuTro, CT_SoDienThoai, CT_TenTaiKhoan, CT_MatKhau)
    values (@CT_IDChuTro,@CT_TenChuTro, @CT_SoDienThoai, @CT_TenTaiKhoan, HASHBYTES('SHA2_256', @CT_MatKhau));
	print 'Thêm thành công';
end
--test
exec ThemChuTro 
	@CT_IDChuTro=1002,
    @CT_TenChuTro = N'Nguyễn Văn A', 
    @CT_SoDienThoai = '0912345679', 
    @CT_TenTaiKhoan = 'nguyenvanan', 
    @CT_MatKhau = 'MatKhau123!';
select * from ChuTro where CT_IDChuTro=1002
