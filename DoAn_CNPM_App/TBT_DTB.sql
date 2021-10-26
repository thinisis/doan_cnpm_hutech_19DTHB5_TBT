USE [TBT_DTB]
GO
/****** Object:  Table [dbo].[ACCOUNT]    Script Date: 10/23/2021 7:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACCOUNT](
	[id] [int] NOT NULL,
	[username] [varchar](20) NULL,
	[password] [varchar](50) NULL,
	[lv] [nchar](10) NOT NULL,
	[MaNV] [varchar](10) NULL,
 CONSTRAINT [PK_ACCOUNT] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[lv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ACCOUNTLV]    Script Date: 10/23/2021 7:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACCOUNTLV](
	[lv] [nchar](10) NOT NULL,
	[Quyen] [nvarchar](50) NULL,
 CONSTRAINT [PK_ACCOUNTLV] PRIMARY KEY CLUSTERED 
(
	[lv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CALAMVIEC]    Script Date: 10/23/2021 7:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CALAMVIEC](
	[MaCa] [varchar](10) NOT NULL,
	[MaNV] [varchar](10) NULL,
	[ThoiGianBatDau] [varchar](50) NULL,
	[ThoiGianKetThuc] [varchar](50) NULL,
	[Ngay] [smalldatetime] NULL,
 CONSTRAINT [PK_CALAMVIEC] PRIMARY KEY CLUSTERED 
(
	[MaCa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTDONHANG]    Script Date: 10/23/2021 7:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTDONHANG](
	[MaHD] [varchar](10) NOT NULL,
	[MaLK] [varchar](10) NULL,
	[DonGia] [money] NULL,
	[SoLuong] [int] NULL,
	[GiamGia] [money] NULL,
 CONSTRAINT [PK_HOADON] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DONHANG]    Script Date: 10/23/2021 7:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DONHANG](
	[MaDH] [varchar](10) NOT NULL,
	[MaKH] [varchar](10) NOT NULL,
	[MaNV] [varchar](10) NULL,
	[TongTien] [money] NULL,
	[NgayGiao] [smalldatetime] NULL,
	[NgayLapDH] [smalldatetime] NULL,
 CONSTRAINT [PK_DONHANG_1] PRIMARY KEY CLUSTERED 
(
	[MaDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HANG]    Script Date: 10/23/2021 7:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HANG](
	[MaHang] [nchar](10) NOT NULL,
	[TenHang] [nvarchar](50) NULL,
 CONSTRAINT [PK_HANG] PRIMARY KEY CLUSTERED 
(
	[MaHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 10/23/2021 7:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MaKH] [varchar](10) NOT NULL,
	[TenKH] [nvarchar](50) NULL,
	[SDT] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[NgaySinh] [smalldatetime] NULL,
	[CMND] [varchar](50) NULL,
	[Phai] [bit] NULL,
 CONSTRAINT [PK_KHACHHANG] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHO]    Script Date: 10/23/2021 7:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHO](
	[MaKho] [varchar](50) NOT NULL,
	[TenKho] [nvarchar](50) NULL,
 CONSTRAINT [PK_KHO] PRIMARY KEY CLUSTERED 
(
	[MaKho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LINHKIEN]    Script Date: 10/23/2021 7:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LINHKIEN](
	[MaLK] [varchar](10) NOT NULL,
	[MaLoai] [varchar](50) NOT NULL,
	[TenLK] [nvarchar](100) NULL,
	[Serial] [char](20) NULL,
	[NoiSanXuat] [nvarchar](50) NULL,
	[DonGia] [money] NULL,
	[MaKho] [varchar](50) NULL,
	[MaNCC] [char](10) NULL,
	[MaHang] [nchar](10) NULL,
 CONSTRAINT [PK_LINHKIEN_1] PRIMARY KEY CLUSTERED 
(
	[MaLK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAILINHKIEN]    Script Date: 10/23/2021 7:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAILINHKIEN](
	[MaLoai] [varchar](50) NOT NULL,
	[TenLoai] [nvarchar](50) NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_LOAILINHKIEN] PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHACUNGCAP]    Script Date: 10/23/2021 7:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHACUNGCAP](
	[MaNCC] [char](10) NOT NULL,
	[TenNCC] [nvarchar](50) NULL,
	[SDT] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
 CONSTRAINT [PK_NHACUNGCAP] PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 10/23/2021 7:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MaNV] [varchar](10) NOT NULL,
	[TenNV] [nvarchar](50) NULL,
	[SDT] [varchar](15) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[ChucVu] [nvarchar](20) NULL,
	[Email] [varchar](50) NULL,
	[Phai] [bit] NULL,
 CONSTRAINT [PK_NHANVIEN] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THEKHACHHANG]    Script Date: 10/23/2021 7:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THEKHACHHANG](
	[MaThe] [varchar](10) NOT NULL,
	[MaKH] [varchar](10) NOT NULL,
	[NgayLap] [smalldatetime] NULL,
	[DiemTichLuy] [int] NULL,
 CONSTRAINT [PK_THEKHACHHANG] PRIMARY KEY CLUSTERED 
(
	[MaThe] ASC,
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ACCOUNT]  WITH CHECK ADD  CONSTRAINT [FK_ACCOUNT_ACCOUNTLV] FOREIGN KEY([lv])
REFERENCES [dbo].[ACCOUNTLV] ([lv])
GO
ALTER TABLE [dbo].[ACCOUNT] CHECK CONSTRAINT [FK_ACCOUNT_ACCOUNTLV]
GO
ALTER TABLE [dbo].[CALAMVIEC]  WITH CHECK ADD  CONSTRAINT [FK_CALAMVIEC_NHANVIEN] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[CALAMVIEC] CHECK CONSTRAINT [FK_CALAMVIEC_NHANVIEN]
GO
ALTER TABLE [dbo].[CTDONHANG]  WITH CHECK ADD  CONSTRAINT [FK_CTDONHANG_DONHANG] FOREIGN KEY([MaHD])
REFERENCES [dbo].[DONHANG] ([MaDH])
GO
ALTER TABLE [dbo].[CTDONHANG] CHECK CONSTRAINT [FK_CTDONHANG_DONHANG]
GO
ALTER TABLE [dbo].[CTDONHANG]  WITH CHECK ADD  CONSTRAINT [FK_CTDONHANG_LINHKIEN] FOREIGN KEY([MaLK])
REFERENCES [dbo].[LINHKIEN] ([MaLK])
GO
ALTER TABLE [dbo].[CTDONHANG] CHECK CONSTRAINT [FK_CTDONHANG_LINHKIEN]
GO
ALTER TABLE [dbo].[DONHANG]  WITH CHECK ADD  CONSTRAINT [FK_DONHANG_KHACHHANG] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
GO
ALTER TABLE [dbo].[DONHANG] CHECK CONSTRAINT [FK_DONHANG_KHACHHANG]
GO
ALTER TABLE [dbo].[DONHANG]  WITH CHECK ADD  CONSTRAINT [FK_DONHANG_NHANVIEN] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[DONHANG] CHECK CONSTRAINT [FK_DONHANG_NHANVIEN]
GO
ALTER TABLE [dbo].[LINHKIEN]  WITH CHECK ADD  CONSTRAINT [FK_LINHKIEN_HANG] FOREIGN KEY([MaHang])
REFERENCES [dbo].[HANG] ([MaHang])
GO
ALTER TABLE [dbo].[LINHKIEN] CHECK CONSTRAINT [FK_LINHKIEN_HANG]
GO
ALTER TABLE [dbo].[LINHKIEN]  WITH CHECK ADD  CONSTRAINT [FK_LINHKIEN_KHO] FOREIGN KEY([MaKho])
REFERENCES [dbo].[KHO] ([MaKho])
GO
ALTER TABLE [dbo].[LINHKIEN] CHECK CONSTRAINT [FK_LINHKIEN_KHO]
GO
ALTER TABLE [dbo].[LINHKIEN]  WITH CHECK ADD  CONSTRAINT [FK_LINHKIEN_LOAILINHKIEN] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[LOAILINHKIEN] ([MaLoai])
GO
ALTER TABLE [dbo].[LINHKIEN] CHECK CONSTRAINT [FK_LINHKIEN_LOAILINHKIEN]
GO
ALTER TABLE [dbo].[LINHKIEN]  WITH CHECK ADD  CONSTRAINT [FK_LINHKIEN_NHACUNGCAP] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NHACUNGCAP] ([MaNCC])
GO
ALTER TABLE [dbo].[LINHKIEN] CHECK CONSTRAINT [FK_LINHKIEN_NHACUNGCAP]
GO
ALTER TABLE [dbo].[THEKHACHHANG]  WITH CHECK ADD  CONSTRAINT [FK_THEKHACHHANG_KHACHHANG] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
GO
ALTER TABLE [dbo].[THEKHACHHANG] CHECK CONSTRAINT [FK_THEKHACHHANG_KHACHHANG]
GO