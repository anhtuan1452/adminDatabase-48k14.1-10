use QlyNhaTro


-- Tạo database
CREATE DATABASE QLyNhaTro;
GO

USE QLyNhaTro;
GO

-- Tạo bảng Chủ trọ
CREATE TABLE ChuTro (
    CT_IDChuTro INT PRIMARY KEY,
    CT_TenChuTro VARCHAR(100) NOT NULL,
    CT_SoDienThoai VARCHAR(15) NOT NULL,
    CT_TenTaiKhoan VARCHAR(50) NOT NULL,
    CT_MatKhau VARCHAR(100) NOT NULL
);

-- Tạo bảng Phòng
CREATE TABLE Phong (
    P_id INT PRIMARY KEY NOT NULL,
    P_sophong INT NOT NULL,
    P_giaphong INT NOT NULL,
    P_tinhtrangphong NVARCHAR(50) NOT NULL
);

-- Tạo bảng Người thuê phòng
CREATE TABLE NguoiThuePhong (
    NTP_IDnguoithuephong INT PRIMARY KEY NOT NULL,
    P_id INT NOT NULL,
    NTP_tenkhach VARCHAR(100) NOT NULL,
    NTP_anhcancuoc VARBINARY(MAX) NOT NULL,
    NTP_sodienthoai VARCHAR(15) NOT NULL,
    NTP_tentaikhoan VARCHAR(50) NOT NULL,
    NTP_matkhau VARCHAR(100) NOT NULL,
    NTP_loaitaikhoan int NOT NULL, ---1 tkoan dang su dung, 0 tai khoan bi khoa
    FOREIGN KEY (P_id) REFERENCES Phong(P_id)
);



-- Tạo bảng Bảng hóa đơn
CREATE TABLE BangHoaDon (
    BHD_idBanghoadon INT PRIMARY KEY NOT NULL,
    P_ID INT NOT NULL,
    BHD_ngaylaphoadon DATE NOT NULL,
    BHD_tongsotien INT NOT NULL,
    BHD_tienphong INT NOT NULL,
    BHD_trangthai INT NOT NULL,
    FOREIGN KEY (P_ID) REFERENCES Phong(P_id)
);

-- Tạo bảng Minh chứng
CREATE TABLE MinhChung (
    MC_id INT PRIMARY KEY NOT NULL,
    BHD_idBanghoadon INT NOT NULL,
    MC_anhminhchung VARBINARY(MAX) NOT NULL,
    MC_trangthai int NOT NULL, --0 là chưa xác nhận 1 là xác nhận rồi.
    FOREIGN KEY (BHD_idBanghoadon) REFERENCES BangHoaDon(BHD_idBanghoadon)
);

-- Tạo bảng Hợp đồng
CREATE TABLE HopDong (
    HD_mahopdong INT PRIMARY KEY,
    P_id INT,
    HD_tienphong INT NOT NULL,
    HD_ngaybatdauthue DATE NOT NULL,
    HD_thoihanthue VARCHAR(50) NOT NULL,
    HD_anhhopdong VARBINARY(MAX) NOT NULL,
    FOREIGN KEY (P_id) REFERENCES Phong(P_id)
);

CREATE TABLE DichVu (
    DV_iddichvu INT PRIMARY KEY,
    DV_tendichvu VARCHAR(50) NOT NULL,
    DV_tiencuadichvu INT NOT NULL
);

CREATE TABLE HoaDonDichVu (
    HDDV_idhoadondichvu INT PRIMARY KEY,
    BHD_idBanghoadon INT ,
    FOREIGN KEY (BHD_idBanghoadon) REFERENCES BangHoaDon(BHD_idBanghoadon)
);

CREATE TABLE Hd_Dv (
    DV_iddichvu INT,
    HDDV_idhoadondichvu INT,
    soluong INT NOT NULL,
    tiendichvu INT NOT NULL,
    PRIMARY KEY (DV_iddichvu, HDDV_idhoadondichvu),
    FOREIGN KEY (DV_iddichvu) REFERENCES DichVu(DV_iddichvu),
    FOREIGN KEY (HDDV_idhoadondichvu) REFERENCES HoaDonDichVu(HDDV_idhoadondichvu)
);

--dump bảng phong
go
create or alter proc dumpPhong
as
begin
	declare @P_id INT=1,@P_sophong INT,@P_giaphong INT,@P_tinhtrangphong NVARCHAR(50) = 'ok'
	while @P_id <= 1000
		begin
			set @P_sophong = @P_id
			set @P_giaphong = CAST((RAND() * (1500000 - 1000000 + 1) + 1000000) AS INT)
			insert into Phong( P_id, P_sophong, P_giaphong , P_tinhtrangphong) values (@P_id ,@P_sophong ,@P_giaphong ,@P_tinhtrangphong)
			set @P_id = @P_id +1;

		end
end

--dump bảng NguoiThuePhong
go
create or alter proc dumpnguoithuephong
as
begin
    declare 
        @ntp_idnguoithuephong int = 1,
        @p_id int,
        @ntp_tenkhach varchar(100),
        @ntp_anhcancuoc varbinary(max) = convert(varbinary(max), 'placeholder for can cuoc image'),
        @ntp_sodienthoai varchar(15),
        @ntp_tentaikhoan varchar(50),
        @ntp_matkhau varchar(100);

    while @ntp_idnguoithuephong <= 1000
    begin
        set @p_id = @ntp_idnguoithuephong;
        set @ntp_tenkhach = 'khach ' + cast(@ntp_idnguoithuephong as varchar(10));
        set @ntp_sodienthoai = '09' + right('000000000' + cast(abs(checksum(newid())) % 1000000000 as varchar(10)), 8);

        set @ntp_tentaikhoan = 'user' + cast(@ntp_idnguoithuephong as varchar(10));
        set @ntp_matkhau = 'password' + cast(@ntp_idnguoithuephong as varchar(10));
			
        insert into nguoithuephong(ntp_idnguoithuephong, p_id, ntp_tenkhach, ntp_anhcancuoc, ntp_sodienthoai, ntp_tentaikhoan, ntp_matkhau)
        values (@ntp_idnguoithuephong, @p_id, @ntp_tenkhach, @ntp_anhcancuoc, @ntp_sodienthoai, @ntp_tentaikhoan, @ntp_matkhau);

        set @ntp_idnguoithuephong = @ntp_idnguoithuephong + 1;
    end
end

---dump Bảng MinhChung
go
create or alter proc dumpMinhChung
as
begin
	declare @MC_id int=1,
		@BHD_idBHD int,
		@MC_anhminhchung varbinary
	while @MC_id<=1000
	begin
		select top 1 @BHD_idBHD=BHD_idBanghoadon
		from HoaDonDichVu
		order by NEWID()
		set @MC_id=@MC_id+1
		set @MC_anhminhchung=convert(varbinary(max),newid())
		set @MC_anhminhchung=CAST(REPLICATE(0x4, 1) AS VARBINARY(MAX)) 
		insert into MinhChung(MC_id,BHD_idBanghoadon,MC_anhminhchung) values (@MC_id,@BHD_idBHD,@MC_anhminhchung)
		
	end
end
exec dumpMinhChung
select * from MinhChung

-- dump bảng hopdong
go
create or alter proc dumpHopDong
as
begin
	DECLARE @i INT = 1;
	WHILE @i <= 1000
	BEGIN
		INSERT INTO HopDong (HD_mahopdong, P_id, HD_tienphong, HD_ngaybatdauthue, HD_thoihanthue, HD_anhhopdong)
		VALUES (@i, 
				ABS(CHECKSUM(NEWID()) % 100) + 1, 
				ABS(CHECKSUM(NEWID()) % 500000) + 100000, 
				DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 30), GETDATE()), 
				CONCAT(ABS(CHECKSUM(NEWID()) % 12) + 1, ' tháng'),  
				NULL);  

		SET @i = @i + 1;
	END;
end
exec dumpHopDong
--dump bảng dichvu
go
create or alter proc dumpDichVu
as
begin
	 declare @DV_iddichvu int = 0, @DV_tendichvu varchar(50) = 'aa', @DV_tiencuadichvu int
	 while @DV_iddichvu < 1000
		begin
			set @DV_tiencuadichvu = rand() * (80000-20000) +20000
			insert into DichVu (DV_iddichvu, DV_tendichvu, DV_tiencuadichvu ) values (@DV_iddichvu, @DV_tendichvu, @DV_tiencuadichvu )
			set @DV_iddichvu= @DV_iddichvu +1
		end
end
exec dumpDichVu
--dump bảng hoadon
go
Create or ALTER   proc [dbo].[dumpHoaDon]
as
begin
	declare @BHD_idBanghoadon INT=1,@P_ID INT,@BHD_ngaylaphoadon date, @BHD_tongsotien int, @BHD_tienphong int;
	while @BHD_idBanghoadon <= 1000
		begin
			set @P_id = @BHD_idBanghoadon
			set @BHD_ngaylaphoadon = '2020/04/15'
			select  @BHD_tienphong = (select p_giaphong
									   from Phong
									   where P_id = @P_id) 
			set @BHD_tongsotien = @BHD_tienphong + 200000
			insert into BangHoaDon(BHD_idBanghoadon, P_ID, BHD_ngaylaphoadon, BHD_tongsotien, BHD_tienphong) values (@BHD_idBanghoadon, @P_id, @BHD_ngaylaphoadon, @BHD_tongsotien, @BHD_tienphong)
			set @BHD_idBanghoadon = @BHD_idBanghoadon +1

		end
end
exec [dbo].[dumpHoaDon]






/**Module**/


---1.Cập nhật trạng thái hóa đơn sau khi đã xác minh minh chứng
GO
create proc UpdateTrangthai
    @BHD_id INT,
    @MC_trangthai int 
as
begin
    if exists (select 1 from BangHoaDon where BHD_idBanghoadon = @BHD_id)
    begin
        select @MC_trangthai=MC_trangthai from MinhChung 
        if @MC_trangthai = 1
        begin
            update BangHoaDon
            set BHD_Trangthai = 1
            where BHD_idBanghoadon = @BHD_id;
        end
        else
        begin
            update BangHoaDon
            set BHD_Trangthai = 0
            where BHD_idBanghoadon = @BHD_id;
        end
        print 'Trạng thái được cập nhật thành công.';
    end
end


--2.Kiểm tra tính hợp lệ của dữ liệu (ảnh minh chứng)
GO
create or alter proc ThemAnhMC
    @mc_id int,
    @bhd_idbanghoadon int,
    @mc_anhminhchung varbinary(max)
as
begin

    if @mc_anhminhchung is not null and substring(@mc_anhminhchung, 1, 2) != 0xffd8 and 
       substring(@mc_anhminhchung, 1, 4) != 0x89504e47
    begin
        print N'Ảnh chèn không hợp lệ'
        return;
    end
    insert into minhchung (MC_id, BHD_idBanghoadon, MC_anhminhchung)
    values (@mc_id, @bhd_idbanghoadon, @mc_anhminhchung);
end;

--3,Thêm minh chứng mới, kiểm tra đã có mã MC và mã HĐ trước đó chưa
go
create or alter trigger ThemMC
on MinhChung
instead of insert
as
begin
	if exists (select 1 from MinhChung
				join inserted on MinhChung.MC_id=inserted.MC_id 
				and MinhChung.BHD_idBanghoadon=inserted.BHD_idBanghoadon)
	begin
		print N'Đã tồn tại mã minh chứng và mã hóa đơn'
		rollback
	end
	insert into MinhChung(MC_id,BHD_idBanghoadon,MC_anhminhchung)
	select MC_id,BHD_idBanghoadon,MC_anhminhchung from inserted
end

--4.Kiểm tra khách thuê phòng gần nhất vào tháng mấy
go
CREATE PROCEDURE sp_KhachThueGanNhat
AS
BEGIN
    SELECT TOP 1 
           NTP_tenkhach AS TenKhachHang,
           MONTH(HD.HD_ngaybatdauThue) AS ThangThue
    FROM NguoiThuePhong NTP
    JOIN HopDong HD ON NTP.P_id = HD.P_id
    ORDER BY HD.HD_ngaybatdauThue DESC 
END



--5.  Tính mã phòng mới, quy tắc như sau: mã phòng mới= Max( mã phòng đang có trong bảng Phòng) +1 
go
create or alter function idPhongMoi()
returns int
as
begin
	declare @macu int,
			@mamoi int
	set @macu = (select max(P_id) from Phong )
	set @mamoi = (@macu + 1)
	return @mamoi 
end 

--6. Update phòng, thêm phòng và kiểm tra giá phòng có đúng trong khoảng 1-2 triệu hay không
go
create or alter trigger add_phong 
on Phong
after insert
as
begin
	declare @P_id int , @P_sophong int,@P_giaphong int, @P_tinhtrangphong varchar(50)
	select @P_id=P_id, @P_sophong=P_sophong, @P_giaphong=P_giaphong,@P_tinhtrangphong=P_tinhtrangphong
	from inserted
	if (@P_giaphong<1000000 or @P_giaphong>2000000)
	begin
		print N'Giá không phòng hợp lệ'
		rollback
		return
	end
	else 
		begin
			if (@@ROWCOUNT >= 1)
			begin
				print N' Thêm phòng thành công'
			end
			else 
				begin
					print N' Có lỗi, chưa thêm được phòng'
				end
		end
end
--7. tạo hóa đơn
go
create or alter proc ThemHoaDon 
as
begin
	declare @BHD_idbanghoadon int, @P_idphong int = 1, @BHD_ngaylaphoadon date, @BHD_tongsotien int, @BHD_tienphong int, @BHD_trangthai int = 0
	declare @slp int, @slhd int, @ttp int
	
	select @slp = (select top 1 p_id
				   from phong
				   order by p_id desc)
	
	select @slhd = (select top 1 BHD_idbanghoadon
				   from BangHoaDon
				   order by BHD_idbanghoadon desc)

	while @P_idphong <= @slp
		begin
			select @ttp = (select P_tinhtrangphong
					   from phong
					   where P_id= @P_idphong)
			if @ttp = 1
				begin
					set @BHD_idbanghoadon = @slhd+1
					set @BHD_ngaylaphoadon = getdate()
					select @BHD_tienphong = (select P_giaphong
											 from phong
											 where P_id = @P_idphong)
					select @BHD_tongsotien = (select sum(soluong*tiendichvu)
											  from HoaDonDichVu 
											  join BangHoaDon on HoaDonDichVu.BHD_idBanghoadon = BangHoaDon.BHD_idBanghoadon
											  join HD_DV on HD_DV.HDDV_idhoadondichvu = HoaDonDichVu.HDDV_idhoadondichvu
											  where HoaDonDichVu.BHD_idBanghoadon = @BHD_idbanghoadon)
					set @BHD_tongsotien = @BHD_tongsotien +  @BHD_tienphong
					insert into BangHoaDon (BHD_idbanghoadon, P_id, BHD_ngaylaphoadon, BHD_tongsotien, BHD_tienphong, BHD_TRANGTHAI) 
					values (@BHD_idbanghoadon, @P_idphong, @BHD_ngaylaphoadon, @BHD_tongsotien, @BHD_tienphong , @BHD_trangthai)
					set @P_idphong = @P_idphong +1
				end
			else
				set @P_idphong = @P_idphong +1
		end


end
--8.hiển thị thông tin
go
create or alter proc HienTTdvu (@DV_iddichvu int, @tien int out, @ten int out)
as
begin
	select @tien = DV_tiencuadichvu, @ten = DV_tendichvu
	from hd_dv join dichvu on hd_dv.DV_iddichvu = dichvu.DV_iddichvu
	where dichvu.DV_iddichvu = @DV_iddichvu
end
--9 kiểm tra khách đã nộp minh chứng gần nhất chưa
go
create or alter function TbaoMC (@p_id int)
RETURNS INT
as
begin
	declare @ttp int
	select @ttp = (select P_tinhtrangphong
					   from phong
					   where P_id= @p_id)
	if @ttp = 1
		begin
			declare @anh VARBINARY(MAX)
			set @anh =( select top 1 MC_anhminhchung
						from phong
						join banghoadon on phong.p_id= banghoadon.p_id
						join minhchung on banghoadon.BHD_idbanghoadon = minhchung.BHD_idBanghoadon
						where phong.p_id=@p_id
						order by BHD_ngaylaphoadon desc)

			if @anh is not null
				return 1
			else
				return 0
		end
	else 
		return 9
	return -1;
end
---10.Thêm thông tin khách thuê

go
create procedure addnguoithuephong
    @p_id int,
    @ntp_tenkhach varchar(100),
    @ntp_anhcancuoc varbinary(max),
    @ntp_sodienthoai varchar(15),
    @ntp_tentaikhoan varchar(50),
    @ntp_matkhau varchar(100)
as
begin
    insert into nguoithuephong (p_id, ntp_tenkhach, ntp_anhcancuoc, ntp_sodienthoai, ntp_tentaikhoan, ntp_matkhau)
    values (@p_id, @ntp_tenkhach, @ntp_anhcancuoc, @ntp_sodienthoai, @ntp_tentaikhoan, @ntp_matkhau);
end
--- 11 .khi thêm có khách thuê mới thì sẽ tự cập nhật id_nguoithuephong bằng cách +1 
go
create or alter trigger set_id_nguoithuephong
on NguoiThuePhong
instead of insert
as
begin
    declare @new_id int
 
	-- Lấy ID lớn nhất hiện có và cộng thêm 1
    select @new_id = isnull(max(NTP_IDnguoithuephong), 0) + 1 from NguoiThuePhong
 
    insert into NguoiThuePhong (NTP_IDnguoithuephong, NTP_tenkhach, NTP_sodienthoai)
    select @new_id, NTP_tenkhach, NTP_sodienthoai
	from inserted
end
 
--12 	Khi thêm mới dữ liệu ,kiểm tra nếu họ tên và số điện thoại đã tồn tại trong bảng Người Thuê Phòng thì đưa ra thông báo ‘đã tồn tại khách hàng’ và hủy toàn bộ thao tác.
go
create or alter trigger add_nguoithuephong
on NguoiThuePhong
after insert
as
begin
	declare @NTP_tenkhach varchar(100), @NTP_sodienthoai varchar(15)
    select @NTP_tenkhach = NTP_tenkhach, @NTP_sodienthoai = NTP_sodienthoai
	from inserted
	if exists (select 1 from NguoiThuePhong
                where NTP_tenkhach = @NTP_tenkhach
                and NTP_sodienthoai = @NTP_sodienthoai)
    begin
        print N'Đã tồn tại khách hàng'
        rollback transaction
        return
	end
    print N'Thêm khách thành công'	
end
go

--13

CREATE TRIGGER KiemTraThoiHanThue
ON HopDong
after insert
as
begin
    declare @tgian int
	select @tgian = (select HD_thoihanthue
					 from inserted)
	if @tgian < 6
		BEGIN
        RAISERROR ('Thoi han thue phai lon hon 6 thang', 16, 1);
        ROLLBACK;
    END
END;
