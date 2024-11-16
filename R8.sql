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
--Schema bảng người thuê phòng
--không bao gồm ảnh căn cước và mật khẩu để bảo vệ tính riêng tư và bảo mật.(Cho người thuê)
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
create proc BaoMat.CapNhatTinhTrangPhong
    @P_id INT,
    @P_tinhtrangphong NVARCHAR(50)
as
begin
    Update Phong
    set P_tinhtrangphong = @P_tinhtrangphong
    where P_id = @P_id;
end;
go
--Tự động cập nhật trạng thái hóa đơn sau khi xác minh minh chứng
create or alter trigger trg_UpdateTrangthai
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
--thủ tục cho minh chứng trạng thái
create or alter proc ThemMinhChung
    @BHD_idBanghoadon INT,
    @MC_anhminhchung VARBINARY(MAX),
    @MC_trangthai INT
as
begin
    if exists ( select 1 from BangHoaDon where BHD_idBanghoadon = @BHD_idBanghoadon)
    begin
        -- Thêm mới minh chứng
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
--thủ tục cập nhật minh chứng trạng thái
create or alter proc CapNhatTrangThaiMinhChung
    @MC_id INT,
    @MC_trangthai INT
as
begin
	if exists( select 1 from MinhChung where MC_id = @MC_id)
    begin
        update MinhChung
        set MC_trangthai = @MC_trangthai
        where MC_id = @MC_id;
		print 'Cập nhật trạng thái minh chứng thành công.';
	end
	else
	begin
		print 'Mã minh chứng không tồn tại.';
	end
end
go

--3. Mã hóa
 --Thủ tục để thêm người thuê phòng một cách an toàn.
create or alter proc ThemNguoiThuePhong
    @P_id INT,
    @NTP_tenkhach VARCHAR(100),
    @NTP_anhcancuoc VARBINARY(MAX),
    @NTP_sodienthoai VARCHAR(15),
    @NTP_tentaikhoan VARCHAR(50),
    @NTP_matkhau VARCHAR(100),
    @NTP_loaitaikhoan INT
as
begin
    insert into NguoiThuePhong (P_id, NTP_tenkhach, NTP_anhcancuoc, NTP_sodienthoai, NTP_tentaikhoan, NTP_matkhau, NTP_loaitaikhoan)
    values (@P_id, @NTP_tenkhach, @NTP_anhcancuoc, @NTP_sodienthoai, @NTP_tentaikhoan, HASHBYTES('SHA2_256', @NTP_matkhau), @NTP_loaitaikhoan);
end;
go

--- Thủ tục để thêm chủ trọ một cách an toàn.
create or alter proc ThemChuTro
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
    insert into ChuTro (CT_TenChuTro, CT_SoDienThoai, CT_TenTaiKhoan, CT_MatKhau)
    values (@CT_TenChuTro, @CT_SoDienThoai, @CT_TenTaiKhoan, HASHBYTES('SHA2_256', @CT_MatKhau));
	print 'Thêm thành công';
end

exec ThemChuTro 
    @CT_TenChuTro = 'Nguyễn Văn A', 
    @CT_SoDienThoai = '0912345679', 
    @CT_TenTaiKhoan = 'nguyenvana', 
    @CT_MatKhau = 'MatKhau123!';




create or alter proc TimTKMK
	@tenTK varchar(50),
	@MK varchar(255)
as
begin
	select *
	from NguoiThuePhong
	where NTP_tentaikhoan=@tenTK and NTP_matkhau=@MK
end

declare @tenTK varchar(50),
		 @MK varchar(255)
set @tenTK=''
---Phần ni t tìm chat khong ra :((( tại hắn kêu ni là dễ xảy ra SQL injection nên chat chỉ sửa lại code thoi
/*set @MK="'or 1=1--'
exec TimTKMK @tenTK,@MK
go*/

