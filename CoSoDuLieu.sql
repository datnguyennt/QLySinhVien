IF EXISTS(SELECT name FROM sysdatabases WHERE name ='QLySinhVien')
USE master
DROP DATABASE QLySinhVien
go

-----------------------------------------
CREATE DATABASE QLySinhVien
GO
USE QLySinhVien

CREATE TABLE SinhVien(
	IDSinhVien INT IDENTITY(1,1) PRIMARY KEY,
	MaSinhVien VARCHAR(15) UNIQUE NOT NULL,
	HoTen NVARCHAR(100) NULL,
	MatKhau NVARCHAR(20) NULL
	)

GO
CREATE TABLE LopSinhHoat(
	MaLSH INT IDENTITY(1,1) PRIMARY KEY,
	MaKhoa INT NOT NULL,
	TenLSH NVARCHAR(50) NOT NULL
)
GO

CREATE TABLE ChiTietSinhVien(
	IDSinhVien INT FOREIGN KEY (IDSinhVien) REFERENCES dbo.SinhVien(IDSinhVien) NOT NULL,
	MaLSH INT FOREIGN KEY (MaLSH) REFERENCES dbo.LopSinhHoat(MaLSH) NOT NULL,
	SoDienThoai VARCHAR(15) NULL,
	GioiTinh BIT DEFAULT 1 NOT NULL,
	Email VARCHAR(200) NULL
	PRIMARY KEY(IDSinhVien)
)
GO
INSERT INTO dbo.SinhVien(MaSinhVien, HoTen, MatKhau)
VALUES
	('1811505310101', N'Nguyễn Ngọc Anh', N'1234567'),
	('1811505310102', N'Trần Chí', N'1234567'),
	('1811505310103', N'Nguyễn Đình Cường', N'1234567'),
	('1811505310104', N'Trần Hoàng Chung', N'1234567'),
	('1811505310105', N'Bùi Vạn Đạt', N'1234567'),
	('1811505310106', N'Cái Quốc Đạt', N'1234567'),
	('1811505310107', N'Nguyễn Thành Đạt', N'1234567'),
	('1811505310108', N'Nguyễn Khánh Hưng', N'1234567')

INSERT INTO dbo.LopSinhHoat(MaKhoa, TenLSH)
VALUES
	(1001, '18T1'),
	(1001, '18T2'),
	(1001, '18T3'),
	(1001, '18T4'),
	(1001, '19T1'),
	(1001, '19T2'),
	(1001, '19T3'),
	(1002, '18CDT1'),
	(1002, '18CDT2'),
	(1002, '18CDT3'),
	(1003, '18DT1'),
	(1004, '18HTP1'),
	(1004, '18HTP2'),
	(1004, '18HTP3')


INSERT INTO dbo.ChiTietSinhVien(IDSinhVien, MaLSH, GioiTinh, Email)
VALUES
(1,1,1,'1811505310101@gmail.com'),
(2,1,0,'1811505310102@gmail.com'),
(3,1,0,'1811505310103@gmail.com'),
(4,1,0,'1811505310104@gmail.com'),
(5,1,0,'1811505310105@gmail.com'),
(6,1,1,'1811505310106@gmail.com'),
(7,1,1,'1811505310107@gmail.com')