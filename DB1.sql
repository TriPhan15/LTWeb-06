create database ql_sach
use ql_sach
create table nhasanxuat(
	mansx char(10) not null primary key,
	tennsx nvarchar(50)
)
create table loai (
	maloai char(10) not null primary key,
	tenloai nvarchar(50)
)
create table khachhang (
	makhachhang char(10) not null primary key,
	tenkhachhang nvarchar(50),
	sodienthoai varchar(20),
	matkhau nvarchar(50)
)
create table hoadon(
	mahoadon char(10) not null primary key,
	ngaytao date,
	makh char(10),
	constraint fk_hoadon_khachhang foreign key(makh) references khachhang(makhachhang)
)
create table sanpham(
	masanpham char(10) not null primary key,
	tensp nvarchar(50),
	mal char(10),
	masx char(10),
	gia decimal(10,2),
	ghichu nvarchar(50),
	hinh nvarchar(100),
	constraint fk_sanpham_loai foreign key(mal) references loai(maloai),
	constraint fk_sanpham_nhasanxuat foreign key(masx) references nhasanxuat(mansx)
)
create table chitiet(
	mahd char(10),
	masp char(10),
	soluong int,
	constraint pk_chitiet primary key(mahd,masp),
	constraint fk_chitiet_hoadon foreign key(mahd) references hoadon(mahoadon),
	constraint fk_chitiet_sanpham foreign key(masp) references sanpham(masanpham)
)

INSERT INTO nhasanxuat (mansx, tennsx) VALUES
('NSX001', N'NXB Kim Đồng'),
('NSX002', N'NXB Trẻ'),
('NSX003', N'NXB Giáo Dục'),
('NSX004', N'NXB Văn Học'),
('NSX005', N'NXB Lao Động'),
('NSX006', N'NXB Hội Nhà Văn'),
('NSX007', N'NXB Thanh Niên'),
('NSX008', N'NXB Chính Trị'),
('NSX009', N'NXB Hồng Đức'),
('NSX010', N'NXB Tổng Hợp');

INSERT INTO loai (maloai, tenloai) VALUES
('L001', N'Truyện tranh'),
('L002', N'Tiểu thuyết'),
('L003', N'Sách giáo khoa'),
('L004', N'Sách kỹ năng'),
('L005', N'Sách tâm lý'),
('L006', N'Sách kinh doanh'),
('L007', N'Sách thiếu nhi'),
('L008', N'Sách ngoại ngữ'),
('L009', N'Sách lịch sử'),
('L010', N'Sách khoa học');

INSERT INTO khachhang (makhachhang, tenkhachhang, sodienthoai, matkhau) VALUES
('KH001', N'Nguyễn Văn An', '0912345678', N'123456'),
('KH002', N'Trần Thị Bình', '0987654321', N'matkhau1'),
('KH003', N'Lê Văn Cường', '0938123456', N'abc123'),
('KH004', N'Phạm Thị Dung', '0909123456', N'123abc'),
('KH005', N'Hoàng Văn Đạt', '0967123456', N'qwerty'),
('KH006', N'Đỗ Thị Em', '0911223344', N'pass123'),
('KH007', N'Vũ Văn Phúc', '0988112233', N'test456'),
('KH008', N'Ngô Thị Hạnh', '0922334455', N'hello123'),
('KH009', N'Bùi Văn Ích', '0977665544', N'khach1'),
('KH010', N'Đinh Thị Giang', '0933445566', N'khach2');

INSERT INTO hoadon (mahoadon, ngaytao, makh) VALUES
('HD001', '2025-10-01', 'KH001'),
('HD002', '2025-10-02', 'KH002'),
('HD003', '2025-10-02', 'KH003'),
('HD004', '2025-10-03', 'KH004'),
('HD005', '2025-10-03', 'KH005'),
('HD006', '2025-10-04', 'KH006'),
('HD007', '2025-10-04', 'KH007'),
('HD008', '2025-10-05', 'KH008'),
('HD009', '2025-10-05', 'KH009'),
('HD010', '2025-10-06', 'KH010');

INSERT INTO sanpham (masanpham, tensp, mal, masx, gia, ghichu, hinh) VALUES
('SP001', N'Dế Mèn Phiêu Lưu Ký', 'L001', 'NSX001', 45000, N'Truyện thiếu nhi kinh điển', N'~/Image/dem.jpeg'),
('SP002', N'Tôi Thấy Hoa Vàng Trên Cỏ Xanh', 'L002', 'NSX002', 60000, N'Tiểu thuyết tuổi thơ', N'~/Image/hoavang.jpg'),
('SP003', N'Giáo Trình Toán 12', 'L003', 'NSX003', 52000, N'Sách học phổ thông', N'~/Image/toan12.png'),
('SP004', N'Đắc Nhân Tâm', 'L004', 'NSX004', 80000, N'Kỹ năng giao tiếp', N'~/Image/dacnhantam.jpg'),
('SP005', N'Quẳng Gánh Lo Đi', 'L005', 'NSX005', 75000, N'Sống tích cực hơn', N'~/Image/quangganh.jpg'),
('SP006', N'Cha Giàu Cha Nghèo', 'L006', 'NSX006', 99000, N'Sách tài chính cá nhân', N'~/Image/chagiau.jpg'),
('SP007', N'100 Câu Chuyện Đạo Đức', 'L007', 'NSX007', 40000, N'Dạy trẻ em', N'~/Image/daoduc.jpg'),
('SP008', N'Tự Học Tiếng Anh Giao Tiếp', 'L008', 'NSX008', 95000, N'Có bài tập thực hành', N'~/Image/ta_giaotiep.jpg'),
('SP009', N'Lịch Sử Việt Nam', 'L009', 'NSX009', 68000, N'Từ thời Hùng Vương đến nay', N'~/Image/lichsu.jpg'),
('SP010', N'Khám Phá Vũ Trụ', 'L010', 'NSX010', 87000, N'Sách khoa học hấp dẫn', N'~/Image/vutru.jpg');

INSERT INTO chitiet (mahd, masp, soluong) VALUES
('HD001', 'SP001', 1),
('HD002', 'SP002', 2),
('HD003', 'SP003', 1),
('HD004', 'SP004', 1),
('HD005', 'SP005', 1),
('HD006', 'SP006', 1),
('HD007', 'SP007', 3),
('HD008', 'SP008', 1),
('HD009', 'SP009', 1),
('HD010', 'SP010', 1);

-- Xóa dữ liệu chi tiết hóa đơn trước (bảng phụ thuộc nhiều nhất)
DELETE FROM chitiet;

-- Xóa hóa đơn
DELETE FROM hoadon;

-- Xóa sản phẩm (sách)
DELETE FROM sanpham;

-- Xóa khách hàng
DELETE FROM khachhang;

-- Xóa loại sách
DELETE FROM loai;

-- Xóa nhà xuất bản
DELETE FROM nhasanxuat;

create proc p_In_DS
as
	begin
		select * from sanpham
	end
exec p_In_DS
create proc p_ChiTiet_Ds
as
	begin
		select * from sanpham sp join chitiet ct on sp.masanpham=ct.masp 
	end