﻿-- Của Quân 
-- Tạo stored procedure để thêm hợp đồng mới
go
CREATE OR ALTER PROC ThemHopDong
    @P_id INT,                -- ID Phòng
    @HD_tienphong INT,        -- Tiền phòng
    @HD_ngaybatdauthue DATE,  -- Ngày bắt đầu thuê
    @HD_thoihanthue VARCHAR(50), -- Thời hạn thuê
    @HD_anhhopdong VARBINARY(MAX) -- Ảnh hợp đồng
AS
BEGIN
    -- Thêm bản ghi hợp đồng mới
    INSERT INTO HopDong (P_id, HD_tienphong, HD_ngaybatdauthue, HD_thoihanthue, HD_anhhopdong)
    VALUES (@P_id, @HD_tienphong, @HD_ngaybatdauthue, @HD_thoihanthue, @HD_anhhopdong);
    -- Trả về thông báo thành công
    PRINT 'Hợp đồng mới đã được thêm thành công!';
END;


-- Tạo stored procedure để cập nhật thông tin hợp đồng
GO
CREATE OR ALTER PROC CapNhatHopDong
    @HD_mahopdong INT,        -- Mã hợp đồng cần cập nhật
    @HD_tienphong INT,        -- Tiền phòng mới
    @HD_thoihanthue VARCHAR(50), -- Thời hạn thuê mới
    @HD_ngaybatdauthue DATE,  -- Ngày bắt đầu thuê mới
    @HD_anhhopdong VARBINARY(MAX) -- Ảnh hợp đồng mới (nếu có)
AS
BEGIN
    -- Cập nhật bản ghi hợp đồng theo mã hợp đồng
    UPDATE HopDong
    SET HD_tienphong = @HD_tienphong, 
        HD_thoihanthue = @HD_thoihanthue,
        HD_ngaybatdauthue = @HD_ngaybatdauthue,
        HD_anhhopdong = @HD_anhhopdong
    WHERE HD_mahopdong = @HD_mahopdong;
    
    -- Trả về thông báo thành công
    PRINT 'Thông tin hợp đồng đã được cập nhật thành công!';
END;


-- tìm kiếm hợp đồng theo phòng
GO
CREATE OR ALTER PROC TimKiemHopDongTheoPhong
    @P_id INT -- Mã phòng
AS
BEGIN
    SELECT * FROM HopDong
    WHERE P_id = @P_id;
END;

-- xây dựng modunl hợp đồng
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

