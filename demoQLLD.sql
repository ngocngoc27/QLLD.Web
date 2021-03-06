USE [demoQLLD]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/25/2022 3:55:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ACCOUNT]    Script Date: 4/25/2022 3:55:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACCOUNT](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[RoleID] [bigint] NULL,
	[Fullname] [nvarchar](50) NULL,
	[DateOfBirth] [date] NULL,
	[Sex] [nvarchar](5) NULL,
	[Picture] [ntext] NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_TAIKHOAN_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CALENDAR]    Script Date: 4/25/2022 3:55:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CALENDAR](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SessionOfDay] [nvarchar](10) NULL,
	[Weekdays] [nvarchar](20) NULL,
	[Day] [date] NULL,
	[LimitsNumber] [int] NOT NULL,
	[RegistrationTotal] [int] NOT NULL,
	[Status] [int] NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_LICHLAODONG] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CLASS]    Script Date: 4/25/2022 3:55:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CLASS](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ClassCode] [varchar](20) NULL,
	[CLassName] [nvarchar](50) NULL,
	[Training] [nvarchar](20) NULL,
	[TypeOfEducation] [nvarchar](20) NULL,
	[Total] [int] NOT NULL,
	[TotalOfWork] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[FacultyID] [bigint] NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_LOP_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FACULTY]    Script Date: 4/25/2022 3:55:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FACULTY](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[FacultyName] [nvarchar](100) NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_KHOA] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GROUPS]    Script Date: 4/25/2022 3:55:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GROUPS](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GroupsName] [nvarchar](50) NULL,
	[JobID] [bigint] NULL,
	[Leader] [nvarchar](50) NULL,
	[Status] [int] NULL,
	[IsDelete] [bit] NULL,
	[CalendarID] [bigint] NULL,
 CONSTRAINT [PK_GROUPS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JOB]    Script Date: 4/25/2022 3:55:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JOB](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[JobName] [nvarchar](100) NULL,
	[Description] [ntext] NULL,
	[Locate] [nvarchar](50) NULL,
	[IsDelete] [bit] NULL,
	[BenefitOfDay] [int] NULL,
 CONSTRAINT [PK_CONGVIEC] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MENUS]    Script Date: 4/25/2022 3:55:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MENUS](
	[ID_MN] [bigint] IDENTITY(1,1) NOT NULL,
	[Label] [nvarchar](100) NULL,
	[Parent] [bigint] NULL,
	[UrlLink] [varchar](200) NULL,
	[OrderKey] [bigint] NULL,
	[UserAdd] [bigint] NULL,
	[Hide] [bit] NULL,
 CONSTRAINT [PK_DANHMUC] PRIMARY KEY CLUSTERED 
(
	[ID_MN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MENUS_ROLE]    Script Date: 4/25/2022 3:55:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MENUS_ROLE](
	[ID_MN] [bigint] NULL,
	[RoleID] [bigint] NULL,
	[IsDelete] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MUSTER]    Script Date: 4/25/2022 3:55:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MUSTER](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[StudentID] [bigint] NULL,
	[RollUp] [bit] NOT NULL,
	[GroupsID] [bigint] NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_DIEMDANH] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ROLE]    Script Date: 4/25/2022 3:55:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROLE](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[NameRole] [nvarchar](50) NULL,
	[IsDelete] [bit] NULL,
	[Code] [int] NULL,
 CONSTRAINT [PK_QUYEN] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[STUDENT]    Script Date: 4/25/2022 3:55:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STUDENT](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MSSV] [varchar](20) NULL,
	[NumberOfWork] [int] NOT NULL,
	[ClassID] [bigint] NULL,
	[AccountID] [bigint] NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_SINHVIEN_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TOOL]    Script Date: 4/25/2022 3:55:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TOOL](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Tool] [nvarchar](50) NULL,
	[Sum] [int] NULL,
	[Unit] [nvarchar](50) NULL,
	[Available] [int] NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_DUNGCULAODONG] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TOOLTICKER]    Script Date: 4/25/2022 3:55:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TOOLTICKER](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ToolID] [bigint] NULL,
	[Amount] [int] NULL,
	[Notes] [ntext] NULL,
	[IsDelete] [bit] NULL,
	[GroupsID] [bigint] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_PHIEUDUNGCU] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WORKTICKER]    Script Date: 4/25/2022 3:55:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WORKTICKER](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CalendarID] [bigint] NULL,
	[AccountID] [bigint] NULL,
	[Status] [int] NULL,
	[RegistrationForm] [nvarchar](50) NULL,
	[IsDelete] [bit] NULL,
	[Note] [nvarchar](100) NULL,
	[RegistrationNumber] [int] NULL,
 CONSTRAINT [PK_PHIEULAODONG] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ACCOUNT] ON 

INSERT [dbo].[ACCOUNT] ([ID], [Username], [Password], [RoleID], [Fullname], [DateOfBirth], [Sex], [Picture], [IsDelete]) VALUES (1, N'admin', N'��t��{��B��7Y', 1, N'Cán bộ quản lý', CAST(N'1992-03-01' AS Date), N'Nam', N'App-login-manager-icon220143634.png', 0)
INSERT [dbo].[ACCOUNT] ([ID], [Username], [Password], [RoleID], [Fullname], [DateOfBirth], [Sex], [Picture], [IsDelete]) VALUES (2, N'hongngoc27', N'��t��{��B��7Y', 2, N'Nguyễn Thị Hồng Ngọc', CAST(N'2000-07-02' AS Date), N'Nữ', N'user221906695.png', 0)
INSERT [dbo].[ACCOUNT] ([ID], [Username], [Password], [RoleID], [Fullname], [DateOfBirth], [Sex], [Picture], [IsDelete]) VALUES (3, N'Duy', N'��t��{��B��7Y', 2, N'Phạm Nguyễn Thanh Duy', CAST(N'2000-01-09' AS Date), N'Nam', N'user225026334.png', 0)
INSERT [dbo].[ACCOUNT] ([ID], [Username], [Password], [RoleID], [Fullname], [DateOfBirth], [Sex], [Picture], [IsDelete]) VALUES (4, N'THANHDUY', N'��t��{��B��7Y', 2, N'demo sv', CAST(N'2022-03-07' AS Date), N'Nam', N'user225026334.png', 1)
INSERT [dbo].[ACCOUNT] ([ID], [Username], [Password], [RoleID], [Fullname], [DateOfBirth], [Sex], [Picture], [IsDelete]) VALUES (5, N'trem', N'��t��{��B��7Y', 2, N'Võ Thị Bích Trăm', CAST(N'2000-12-19' AS Date), N'Nữ', N'user225026334.png', 0)
INSERT [dbo].[ACCOUNT] ([ID], [Username], [Password], [RoleID], [Fullname], [DateOfBirth], [Sex], [Picture], [IsDelete]) VALUES (6, N'bin', N'��t��{��B��7Y', 2, N'Đăng Ngọc Bin', CAST(N'2000-02-29' AS Date), N'Nam', N'user225026334.png', 0)
INSERT [dbo].[ACCOUNT] ([ID], [Username], [Password], [RoleID], [Fullname], [DateOfBirth], [Sex], [Picture], [IsDelete]) VALUES (7, N'nqnghia', N'��t��{��B��7Y', 2, N'Nguyễn Quốc Nghĩa', CAST(N'1999-04-14' AS Date), N'Nam', N'user225026334.png', 0)
INSERT [dbo].[ACCOUNT] ([ID], [Username], [Password], [RoleID], [Fullname], [DateOfBirth], [Sex], [Picture], [IsDelete]) VALUES (8, N'ttnhu', N'��t��{��B��7Y', 2, N'Trần Thái Nhu', CAST(N'1999-12-08' AS Date), N'Nam', N'user225026334.png', 0)
INSERT [dbo].[ACCOUNT] ([ID], [Username], [Password], [RoleID], [Fullname], [DateOfBirth], [Sex], [Picture], [IsDelete]) VALUES (9, N'lplam', N'��t��{��B��7Y', 2, N'Lê Phát Lảm', CAST(N'2000-04-13' AS Date), N'Nam', N'user225026334.png', 0)
INSERT [dbo].[ACCOUNT] ([ID], [Username], [Password], [RoleID], [Fullname], [DateOfBirth], [Sex], [Picture], [IsDelete]) VALUES (10, N'ldkhang', N'��t��{��B��7Y', 2, N'Lê Duy Khang', CAST(N'2000-07-01' AS Date), N'Nam', N'user225026334.png', 0)
INSERT [dbo].[ACCOUNT] ([ID], [Username], [Password], [RoleID], [Fullname], [DateOfBirth], [Sex], [Picture], [IsDelete]) VALUES (11, N'nlhtrung', N'��t��{��B��7Y', 2, N'Nguyễn Lê Hoàng Trung', CAST(N'2000-01-02' AS Date), N'Nam', N'user225026334.png', 0)
INSERT [dbo].[ACCOUNT] ([ID], [Username], [Password], [RoleID], [Fullname], [DateOfBirth], [Sex], [Picture], [IsDelete]) VALUES (12, N'ndkhoa', N'��t��{��B��7Y', 2, N'Nguyễn Duy Khoa', CAST(N'2000-01-01' AS Date), N'Nam', N'user225026334.png', 0)
INSERT [dbo].[ACCOUNT] ([ID], [Username], [Password], [RoleID], [Fullname], [DateOfBirth], [Sex], [Picture], [IsDelete]) VALUES (13, N'mclinh', N'��t��{��B��7Y', 2, N'Mai Chí Linh', CAST(N'1999-01-01' AS Date), N'Nam', N'user225026334.png', 0)
INSERT [dbo].[ACCOUNT] ([ID], [Username], [Password], [RoleID], [Fullname], [DateOfBirth], [Sex], [Picture], [IsDelete]) VALUES (14, N'nmman', N'��t��{��B��7Y', 2, N'Nguyễn Minh Mẫn', CAST(N'2000-01-01' AS Date), N'Nam', N'user225026334.png', 0)
INSERT [dbo].[ACCOUNT] ([ID], [Username], [Password], [RoleID], [Fullname], [DateOfBirth], [Sex], [Picture], [IsDelete]) VALUES (15, N'nvmy', N'��t��{��B��7Y', 2, N'Nguyễn Việt Mỹ', CAST(N'2000-01-01' AS Date), N'Nam', N'user225026334.png', 0)
INSERT [dbo].[ACCOUNT] ([ID], [Username], [Password], [RoleID], [Fullname], [DateOfBirth], [Sex], [Picture], [IsDelete]) VALUES (16, N'nvnhat', N'��t��{��B��7Y', 2, N'Nguyễn Việt Nhật', CAST(N'2000-01-01' AS Date), N'Nam', N'user225026334.png', 0)
INSERT [dbo].[ACCOUNT] ([ID], [Username], [Password], [RoleID], [Fullname], [DateOfBirth], [Sex], [Picture], [IsDelete]) VALUES (18, N'dncthu', N'��t��{��B��7Y', 2, N'Dương Nguyễn Cẩm Thu', CAST(N'2000-01-02' AS Date), N'Nữ', N'user225026334.png', 0)
INSERT [dbo].[ACCOUNT] ([ID], [Username], [Password], [RoleID], [Fullname], [DateOfBirth], [Sex], [Picture], [IsDelete]) VALUES (19, N'lhbduy', N'��t��{��B��7Y', 2, N'Lê Hoàng Bảo Duy', CAST(N'2000-01-01' AS Date), N'Nam', N'user225026334.png', 0)
INSERT [dbo].[ACCOUNT] ([ID], [Username], [Password], [RoleID], [Fullname], [DateOfBirth], [Sex], [Picture], [IsDelete]) VALUES (20, N'nva', N'��t��{��B��7Y', 2, N'Nguyễn Văn A', CAST(N'2000-01-01' AS Date), N'Nam', N'user225026334.png', 0)
SET IDENTITY_INSERT [dbo].[ACCOUNT] OFF
GO
SET IDENTITY_INSERT [dbo].[CALENDAR] ON 

INSERT [dbo].[CALENDAR] ([ID], [SessionOfDay], [Weekdays], [Day], [LimitsNumber], [RegistrationTotal], [Status], [IsDelete]) VALUES (5, N'Sáng', N'Thứ sáu', CAST(N'2022-03-25' AS Date), 20, 42, 2, 1)
INSERT [dbo].[CALENDAR] ([ID], [SessionOfDay], [Weekdays], [Day], [LimitsNumber], [RegistrationTotal], [Status], [IsDelete]) VALUES (6, N'Chiều', N'Thứ sáu', CAST(N'2022-03-25' AS Date), 20, 80, 2, 1)
INSERT [dbo].[CALENDAR] ([ID], [SessionOfDay], [Weekdays], [Day], [LimitsNumber], [RegistrationTotal], [Status], [IsDelete]) VALUES (7, N'Sáng', N'Thứ hai', CAST(N'2022-03-14' AS Date), 50, -4, 1, 1)
INSERT [dbo].[CALENDAR] ([ID], [SessionOfDay], [Weekdays], [Day], [LimitsNumber], [RegistrationTotal], [Status], [IsDelete]) VALUES (9, N'Sáng', N'Thứ tư', CAST(N'2022-04-06' AS Date), 40, 0, 1, 0)
INSERT [dbo].[CALENDAR] ([ID], [SessionOfDay], [Weekdays], [Day], [LimitsNumber], [RegistrationTotal], [Status], [IsDelete]) VALUES (10, N'Sáng', N'Thứ sáu', CAST(N'2022-04-01' AS Date), 30, 0, 1, 0)
INSERT [dbo].[CALENDAR] ([ID], [SessionOfDay], [Weekdays], [Day], [LimitsNumber], [RegistrationTotal], [Status], [IsDelete]) VALUES (11, N'Sáng', N'Thứ tư', CAST(N'2022-04-06' AS Date), 25, 0, 1, 0)
INSERT [dbo].[CALENDAR] ([ID], [SessionOfDay], [Weekdays], [Day], [LimitsNumber], [RegistrationTotal], [Status], [IsDelete]) VALUES (12, N'Chiều', N'Thứ tư', CAST(N'2022-04-06' AS Date), 2, 9, 2, 0)
INSERT [dbo].[CALENDAR] ([ID], [SessionOfDay], [Weekdays], [Day], [LimitsNumber], [RegistrationTotal], [Status], [IsDelete]) VALUES (13, N'Sáng', N'Thứ năm', CAST(N'2022-04-07' AS Date), 40, 1, 1, 0)
INSERT [dbo].[CALENDAR] ([ID], [SessionOfDay], [Weekdays], [Day], [LimitsNumber], [RegistrationTotal], [Status], [IsDelete]) VALUES (14, N'Chiều', N'Thứ năm', CAST(N'2022-04-07' AS Date), 35, 8, 1, 0)
INSERT [dbo].[CALENDAR] ([ID], [SessionOfDay], [Weekdays], [Day], [LimitsNumber], [RegistrationTotal], [Status], [IsDelete]) VALUES (15, N'Sáng', N'Thứ sáu', CAST(N'2022-04-08' AS Date), 50, 0, 2, 1)
INSERT [dbo].[CALENDAR] ([ID], [SessionOfDay], [Weekdays], [Day], [LimitsNumber], [RegistrationTotal], [Status], [IsDelete]) VALUES (16, N'Chiều', N'Thứ sáu', CAST(N'2022-04-08' AS Date), 40, 0, 1, 0)
INSERT [dbo].[CALENDAR] ([ID], [SessionOfDay], [Weekdays], [Day], [LimitsNumber], [RegistrationTotal], [Status], [IsDelete]) VALUES (17, N'Sáng', N'Thứ bảy', CAST(N'2022-04-09' AS Date), 50, 0, 1, 1)
INSERT [dbo].[CALENDAR] ([ID], [SessionOfDay], [Weekdays], [Day], [LimitsNumber], [RegistrationTotal], [Status], [IsDelete]) VALUES (18, N'Sáng', N'Thứ hai', CAST(N'2022-04-11' AS Date), 35, 0, 2, 0)
INSERT [dbo].[CALENDAR] ([ID], [SessionOfDay], [Weekdays], [Day], [LimitsNumber], [RegistrationTotal], [Status], [IsDelete]) VALUES (19, N'Chiều', N'Thứ hai', CAST(N'2022-04-11' AS Date), 30, 0, 1, 0)
SET IDENTITY_INSERT [dbo].[CALENDAR] OFF
GO
SET IDENTITY_INSERT [dbo].[CLASS] ON 

INSERT [dbo].[CLASS] ([ID], [ClassCode], [CLassName], [Training], [TypeOfEducation], [Total], [TotalOfWork], [Status], [FacultyID], [IsDelete]) VALUES (1, N'0155', N'Tổ quản lý môi trường', NULL, N'Đại học', 1, 0, 3, 12, NULL)
INSERT [dbo].[CLASS] ([ID], [ClassCode], [CLassName], [Training], [TypeOfEducation], [Total], [TotalOfWork], [Status], [FacultyID], [IsDelete]) VALUES (2, N'001841480101A', N'ĐHCNTT18A', N'2018-2022', N'Đại học', 10, 1, 1, 1, NULL)
INSERT [dbo].[CLASS] ([ID], [ClassCode], [CLassName], [Training], [TypeOfEducation], [Total], [TotalOfWork], [Status], [FacultyID], [IsDelete]) VALUES (3, N'001941480101A', N'ĐHCNTT19A', N'2019-2023', N'Đại học', 2, 0, 1, 1, 0)
INSERT [dbo].[CLASS] ([ID], [ClassCode], [CLassName], [Training], [TypeOfEducation], [Total], [TotalOfWork], [Status], [FacultyID], [IsDelete]) VALUES (4, N'0020410101A', N'ĐHCNTT20A', N'2020-2024', N'Đại học', 0, 0, 3, 1, 0)
INSERT [dbo].[CLASS] ([ID], [ClassCode], [CLassName], [Training], [TypeOfEducation], [Total], [TotalOfWork], [Status], [FacultyID], [IsDelete]) VALUES (5, N'00204101010B', N'ĐHCNTT20B', N'2020-2024', N'Đại học', 4, 0, 1, 1, 0)
INSERT [dbo].[CLASS] ([ID], [ClassCode], [CLassName], [Training], [TypeOfEducation], [Total], [TotalOfWork], [Status], [FacultyID], [IsDelete]) VALUES (6, N'0021410101A', N'ĐHCNTT21A', N'2021-2025', N'Đại học', 0, 0, 1, 1, 0)
INSERT [dbo].[CLASS] ([ID], [ClassCode], [CLassName], [Training], [TypeOfEducation], [Total], [TotalOfWork], [Status], [FacultyID], [IsDelete]) VALUES (7, N'00214100101B', N'ĐHCNTT21B', N'2021-2025', N'Đại học', 0, 0, 3, 1, 0)
INSERT [dbo].[CLASS] ([ID], [ClassCode], [CLassName], [Training], [TypeOfEducation], [Total], [TotalOfWork], [Status], [FacultyID], [IsDelete]) VALUES (8, N'00204120102A', N'ĐHSTIN20A', N'2020-2024', N'Đại học', 0, 0, 3, 1, 0)
INSERT [dbo].[CLASS] ([ID], [ClassCode], [CLassName], [Training], [TypeOfEducation], [Total], [TotalOfWork], [Status], [FacultyID], [IsDelete]) VALUES (9, N'00184100202A', N'ĐHGDTH18A', N'2018-2022', N'Đại học', 0, 0, 3, 9, 0)
INSERT [dbo].[CLASS] ([ID], [ClassCode], [CLassName], [Training], [TypeOfEducation], [Total], [TotalOfWork], [Status], [FacultyID], [IsDelete]) VALUES (10, N'0019410202A', N'ĐHGDTH19A', N'2019-2023', N'Đại học', 0, 0, 3, 9, 0)
INSERT [dbo].[CLASS] ([ID], [ClassCode], [CLassName], [Training], [TypeOfEducation], [Total], [TotalOfWork], [Status], [FacultyID], [IsDelete]) VALUES (11, N'00184102014', N'ĐHGDTC18A', N'2018-2022', N'Đại học', 0, 0, 3, 8, 0)
INSERT [dbo].[CLASS] ([ID], [ClassCode], [CLassName], [Training], [TypeOfEducation], [Total], [TotalOfWork], [Status], [FacultyID], [IsDelete]) VALUES (12, N'00184120230A', N'ĐHSANH18A', N'2018-2022', N'Đại học', 0, 0, 3, 3, 0)
INSERT [dbo].[CLASS] ([ID], [ClassCode], [CLassName], [Training], [TypeOfEducation], [Total], [TotalOfWork], [Status], [FacultyID], [IsDelete]) VALUES (13, N'00194120505A', N'ĐHSANH19A', N'2019-2023', N'Đại học', 0, 0, 3, 3, 0)
INSERT [dbo].[CLASS] ([ID], [ClassCode], [CLassName], [Training], [TypeOfEducation], [Total], [TotalOfWork], [Status], [FacultyID], [IsDelete]) VALUES (14, N'0018410354B', N'ĐHTQ18A', N'2018-2022', N'Đại học', 0, 0, 3, 3, 0)
INSERT [dbo].[CLASS] ([ID], [ClassCode], [CLassName], [Training], [TypeOfEducation], [Total], [TotalOfWork], [Status], [FacultyID], [IsDelete]) VALUES (15, N'0019410202C', N'ĐHTQ19C', N'2019-2023', N'Đại học', 0, 0, 3, 3, 0)
INSERT [dbo].[CLASS] ([ID], [ClassCode], [CLassName], [Training], [TypeOfEducation], [Total], [TotalOfWork], [Status], [FacultyID], [IsDelete]) VALUES (16, N'18400211', N'ĐHSANH', N'2018-2022', N'Cao đẳng', 2, 0, 1, 3, 0)
SET IDENTITY_INSERT [dbo].[CLASS] OFF
GO
SET IDENTITY_INSERT [dbo].[FACULTY] ON 

INSERT [dbo].[FACULTY] ([ID], [FacultyName], [IsDelete]) VALUES (1, N'Khoa Sư phạm Toán Tin', NULL)
INSERT [dbo].[FACULTY] ([ID], [FacultyName], [IsDelete]) VALUES (2, N'Khoa Kinh Tế', NULL)
INSERT [dbo].[FACULTY] ([ID], [FacultyName], [IsDelete]) VALUES (3, N'Khoa Ngoại Ngữ', NULL)
INSERT [dbo].[FACULTY] ([ID], [FacultyName], [IsDelete]) VALUES (4, N'Khoa Sư phạm Khoa học tự nhiên', NULL)
INSERT [dbo].[FACULTY] ([ID], [FacultyName], [IsDelete]) VALUES (5, N'Khoa Sư phạm Ngữ văn', NULL)
INSERT [dbo].[FACULTY] ([ID], [FacultyName], [IsDelete]) VALUES (6, N'Khoa Sư phạm Nghệ thuật', NULL)
INSERT [dbo].[FACULTY] ([ID], [FacultyName], [IsDelete]) VALUES (7, N'Khoa Sư phạm Khoa học xã hội', NULL)
INSERT [dbo].[FACULTY] ([ID], [FacultyName], [IsDelete]) VALUES (8, N'Khoa Giáo dục thể chất - Quốc phòng và An ninh', NULL)
INSERT [dbo].[FACULTY] ([ID], [FacultyName], [IsDelete]) VALUES (9, N'Khoa Giáo dục Tiểu học - Mầm non', NULL)
INSERT [dbo].[FACULTY] ([ID], [FacultyName], [IsDelete]) VALUES (10, N'Khoa Nông nghiệp và Tài nguyên môi trường', NULL)
INSERT [dbo].[FACULTY] ([ID], [FacultyName], [IsDelete]) VALUES (11, N'Khoa Văn hóa - Du lịch và Công tác xã hội', NULL)
INSERT [dbo].[FACULTY] ([ID], [FacultyName], [IsDelete]) VALUES (12, N'Trung tâm quản lý dịch vụ', NULL)
SET IDENTITY_INSERT [dbo].[FACULTY] OFF
GO
SET IDENTITY_INSERT [dbo].[GROUPS] ON 

INSERT [dbo].[GROUPS] ([ID], [GroupsName], [JobID], [Leader], [Status], [IsDelete], [CalendarID]) VALUES (31, N'A', 3, NULL, 3, 1, 7)
INSERT [dbo].[GROUPS] ([ID], [GroupsName], [JobID], [Leader], [Status], [IsDelete], [CalendarID]) VALUES (34, N'B', 1, NULL, 2, 1, 7)
INSERT [dbo].[GROUPS] ([ID], [GroupsName], [JobID], [Leader], [Status], [IsDelete], [CalendarID]) VALUES (35, N'A', 7, NULL, 3, 0, 14)
INSERT [dbo].[GROUPS] ([ID], [GroupsName], [JobID], [Leader], [Status], [IsDelete], [CalendarID]) VALUES (36, N'B', 8, NULL, 1, 0, 14)
INSERT [dbo].[GROUPS] ([ID], [GroupsName], [JobID], [Leader], [Status], [IsDelete], [CalendarID]) VALUES (37, N'C', 3, NULL, 1, 1, 14)
INSERT [dbo].[GROUPS] ([ID], [GroupsName], [JobID], [Leader], [Status], [IsDelete], [CalendarID]) VALUES (38, N'A', 1, NULL, 2, 0, 12)
SET IDENTITY_INSERT [dbo].[GROUPS] OFF
GO
SET IDENTITY_INSERT [dbo].[JOB] ON 

INSERT [dbo].[JOB] ([ID], [JobName], [Description], [Locate], [IsDelete], [BenefitOfDay]) VALUES (1, N'Vệ sinh C1-C2', N'Dọn rác trong và ngoài dãy C1 và C2', N'C1 - C2', NULL, 1)
INSERT [dbo].[JOB] ([ID], [JobName], [Description], [Locate], [IsDelete], [BenefitOfDay]) VALUES (2, N'Dọn dẹp H1', N'Lau chùi, quét dọn tòa nhà', N'H1', 0, 2)
INSERT [dbo].[JOB] ([ID], [JobName], [Description], [Locate], [IsDelete], [BenefitOfDay]) VALUES (3, N'Dọn cỏ sân bóng ', N'Dọn cỏ, gom và đổ sau lưng dãy H2', N'Sân banh 11', 0, 1)
INSERT [dbo].[JOB] ([ID], [JobName], [Description], [Locate], [IsDelete], [BenefitOfDay]) VALUES (4, N'Vệ sinh đường ống', N'Quét rác và đổ rác toàn bộ đường ống trong trường', N'Tất cả đường ống', 0, 1)
INSERT [dbo].[JOB] ([ID], [JobName], [Description], [Locate], [IsDelete], [BenefitOfDay]) VALUES (5, N'Vệ sinh hồ bơi', N'Lau tường, dọn rác xung quanh và trong lòng hồ bơi', N'Hồ bơi', 0, 2)
INSERT [dbo].[JOB] ([ID], [JobName], [Description], [Locate], [IsDelete], [BenefitOfDay]) VALUES (6, N'Vệ sinh dãy A1', N'Quét rác, dọn dẹp xung quanh khu vực nêu trên', N'Trước khu vực nhà hiệu bộ', NULL, 2)
INSERT [dbo].[JOB] ([ID], [JobName], [Description], [Locate], [IsDelete], [BenefitOfDay]) VALUES (7, N'Vệ sinh hàng rào', N'Thực hiện quét, dọn vệ sinh khu vực hàng rào trước cổng trường', N'Hàng rào cổng A đến cổng C', 0, 2)
INSERT [dbo].[JOB] ([ID], [JobName], [Description], [Locate], [IsDelete], [BenefitOfDay]) VALUES (8, N'Vệ sinh khu kí túc xá B6', N'Dọn dẹp', N'Dãy B6', 1, 2)
SET IDENTITY_INSERT [dbo].[JOB] OFF
GO
SET IDENTITY_INSERT [dbo].[MENUS] ON 

INSERT [dbo].[MENUS] ([ID_MN], [Label], [Parent], [UrlLink], [OrderKey], [UserAdd], [Hide]) VALUES (5, N'Trang chủ', 0, N'#', 1, 1, 0)
SET IDENTITY_INSERT [dbo].[MENUS] OFF
GO
SET IDENTITY_INSERT [dbo].[MUSTER] ON 

INSERT [dbo].[MUSTER] ([ID], [StudentID], [RollUp], [GroupsID], [IsDelete]) VALUES (11, 2, 1, 31, 0)
INSERT [dbo].[MUSTER] ([ID], [StudentID], [RollUp], [GroupsID], [IsDelete]) VALUES (12, 2, 0, 35, 0)
INSERT [dbo].[MUSTER] ([ID], [StudentID], [RollUp], [GroupsID], [IsDelete]) VALUES (13, 3, 0, 35, 0)
INSERT [dbo].[MUSTER] ([ID], [StudentID], [RollUp], [GroupsID], [IsDelete]) VALUES (14, 4, 1, 35, 0)
INSERT [dbo].[MUSTER] ([ID], [StudentID], [RollUp], [GroupsID], [IsDelete]) VALUES (15, 17, 1, 35, 0)
INSERT [dbo].[MUSTER] ([ID], [StudentID], [RollUp], [GroupsID], [IsDelete]) VALUES (16, 17, 0, 35, 1)
INSERT [dbo].[MUSTER] ([ID], [StudentID], [RollUp], [GroupsID], [IsDelete]) VALUES (17, 13, 1, 35, 0)
INSERT [dbo].[MUSTER] ([ID], [StudentID], [RollUp], [GroupsID], [IsDelete]) VALUES (18, 16, 0, 35, 1)
INSERT [dbo].[MUSTER] ([ID], [StudentID], [RollUp], [GroupsID], [IsDelete]) VALUES (19, 15, 0, 35, 0)
INSERT [dbo].[MUSTER] ([ID], [StudentID], [RollUp], [GroupsID], [IsDelete]) VALUES (20, 15, 0, 36, 1)
INSERT [dbo].[MUSTER] ([ID], [StudentID], [RollUp], [GroupsID], [IsDelete]) VALUES (21, 17, 0, 38, 0)
INSERT [dbo].[MUSTER] ([ID], [StudentID], [RollUp], [GroupsID], [IsDelete]) VALUES (22, 14, 0, 36, 1)
INSERT [dbo].[MUSTER] ([ID], [StudentID], [RollUp], [GroupsID], [IsDelete]) VALUES (23, 16, 0, 36, 1)
INSERT [dbo].[MUSTER] ([ID], [StudentID], [RollUp], [GroupsID], [IsDelete]) VALUES (24, 4, 0, 36, 1)
INSERT [dbo].[MUSTER] ([ID], [StudentID], [RollUp], [GroupsID], [IsDelete]) VALUES (25, 13, 0, 36, 1)
INSERT [dbo].[MUSTER] ([ID], [StudentID], [RollUp], [GroupsID], [IsDelete]) VALUES (26, 13, 0, 36, 1)
INSERT [dbo].[MUSTER] ([ID], [StudentID], [RollUp], [GroupsID], [IsDelete]) VALUES (27, 16, 0, 36, 1)
INSERT [dbo].[MUSTER] ([ID], [StudentID], [RollUp], [GroupsID], [IsDelete]) VALUES (28, 16, 0, 36, 1)
INSERT [dbo].[MUSTER] ([ID], [StudentID], [RollUp], [GroupsID], [IsDelete]) VALUES (29, 2, 0, 36, 1)
INSERT [dbo].[MUSTER] ([ID], [StudentID], [RollUp], [GroupsID], [IsDelete]) VALUES (30, 3, 0, 36, 1)
INSERT [dbo].[MUSTER] ([ID], [StudentID], [RollUp], [GroupsID], [IsDelete]) VALUES (31, 3, 0, 36, 1)
INSERT [dbo].[MUSTER] ([ID], [StudentID], [RollUp], [GroupsID], [IsDelete]) VALUES (32, 17, 0, 36, 1)
INSERT [dbo].[MUSTER] ([ID], [StudentID], [RollUp], [GroupsID], [IsDelete]) VALUES (33, 16, 0, 36, 0)
INSERT [dbo].[MUSTER] ([ID], [StudentID], [RollUp], [GroupsID], [IsDelete]) VALUES (34, 16, 0, 36, 1)
INSERT [dbo].[MUSTER] ([ID], [StudentID], [RollUp], [GroupsID], [IsDelete]) VALUES (35, 13, 0, 36, 0)
SET IDENTITY_INSERT [dbo].[MUSTER] OFF
GO
SET IDENTITY_INSERT [dbo].[ROLE] ON 

INSERT [dbo].[ROLE] ([ID], [NameRole], [IsDelete], [Code]) VALUES (1, N'Admin', NULL, NULL)
INSERT [dbo].[ROLE] ([ID], [NameRole], [IsDelete], [Code]) VALUES (2, N'User', NULL, NULL)
SET IDENTITY_INSERT [dbo].[ROLE] OFF
GO
SET IDENTITY_INSERT [dbo].[STUDENT] ON 

INSERT [dbo].[STUDENT] ([ID], [MSSV], [NumberOfWork], [ClassID], [AccountID], [IsDelete]) VALUES (1, NULL, 0, 1, 1, 0)
INSERT [dbo].[STUDENT] ([ID], [MSSV], [NumberOfWork], [ClassID], [AccountID], [IsDelete]) VALUES (2, N'0018413046', 0, 2, 2, 0)
INSERT [dbo].[STUDENT] ([ID], [MSSV], [NumberOfWork], [ClassID], [AccountID], [IsDelete]) VALUES (3, N'0018410634', 0, 2, 3, 0)
INSERT [dbo].[STUDENT] ([ID], [MSSV], [NumberOfWork], [ClassID], [AccountID], [IsDelete]) VALUES (4, N'0018413055', 2, 2, 5, 0)
INSERT [dbo].[STUDENT] ([ID], [MSSV], [NumberOfWork], [ClassID], [AccountID], [IsDelete]) VALUES (5, N'0018412699', 0, 3, 6, 0)
INSERT [dbo].[STUDENT] ([ID], [MSSV], [NumberOfWork], [ClassID], [AccountID], [IsDelete]) VALUES (8, N'0020413050', 0, 5, 9, 0)
INSERT [dbo].[STUDENT] ([ID], [MSSV], [NumberOfWork], [ClassID], [AccountID], [IsDelete]) VALUES (9, N'0020413022', 0, 3, 8, 0)
INSERT [dbo].[STUDENT] ([ID], [MSSV], [NumberOfWork], [ClassID], [AccountID], [IsDelete]) VALUES (10, N'0020410569', 0, 5, 7, 0)
INSERT [dbo].[STUDENT] ([ID], [MSSV], [NumberOfWork], [ClassID], [AccountID], [IsDelete]) VALUES (11, N'0018410632', 0, 2, 19, 0)
INSERT [dbo].[STUDENT] ([ID], [MSSV], [NumberOfWork], [ClassID], [AccountID], [IsDelete]) VALUES (12, N'0018410644', 0, 5, 10, 0)
INSERT [dbo].[STUDENT] ([ID], [MSSV], [NumberOfWork], [ClassID], [AccountID], [IsDelete]) VALUES (13, N'0018410325', 0, 2, 18, 0)
INSERT [dbo].[STUDENT] ([ID], [MSSV], [NumberOfWork], [ClassID], [AccountID], [IsDelete]) VALUES (14, N'0018410660', 0, 2, 11, 0)
INSERT [dbo].[STUDENT] ([ID], [MSSV], [NumberOfWork], [ClassID], [AccountID], [IsDelete]) VALUES (15, N'0018413602', 0, 2, 12, 0)
INSERT [dbo].[STUDENT] ([ID], [MSSV], [NumberOfWork], [ClassID], [AccountID], [IsDelete]) VALUES (16, N'0018416030', 0, 2, 14, 0)
INSERT [dbo].[STUDENT] ([ID], [MSSV], [NumberOfWork], [ClassID], [AccountID], [IsDelete]) VALUES (17, N'0018412501', 2, 2, 15, 0)
INSERT [dbo].[STUDENT] ([ID], [MSSV], [NumberOfWork], [ClassID], [AccountID], [IsDelete]) VALUES (18, N'0018410001', 0, 16, 20, 0)
SET IDENTITY_INSERT [dbo].[STUDENT] OFF
GO
SET IDENTITY_INSERT [dbo].[TOOL] ON 

INSERT [dbo].[TOOL] ([ID], [Tool], [Sum], [Unit], [Available], [IsDelete]) VALUES (1, N'Ki hốt rác', 100, N'Cái', 98, 0)
INSERT [dbo].[TOOL] ([ID], [Tool], [Sum], [Unit], [Available], [IsDelete]) VALUES (2, N'Chổi', 120, N'Cây', 365, 0)
INSERT [dbo].[TOOL] ([ID], [Tool], [Sum], [Unit], [Available], [IsDelete]) VALUES (3, N'Cần xé đựng rác', 50, N'Cái', 45, 0)
INSERT [dbo].[TOOL] ([ID], [Tool], [Sum], [Unit], [Available], [IsDelete]) VALUES (4, N'Chét', 20, N'Cái', 20, 0)
INSERT [dbo].[TOOL] ([ID], [Tool], [Sum], [Unit], [Available], [IsDelete]) VALUES (5, N'Dao', 20, N'Cái', 20, 0)
INSERT [dbo].[TOOL] ([ID], [Tool], [Sum], [Unit], [Available], [IsDelete]) VALUES (6, N'Leng', 30, N'Cái', 29, 0)
INSERT [dbo].[TOOL] ([ID], [Tool], [Sum], [Unit], [Available], [IsDelete]) VALUES (7, N'Lưỡi hái', 10, N'Cái', 10, 0)
INSERT [dbo].[TOOL] ([ID], [Tool], [Sum], [Unit], [Available], [IsDelete]) VALUES (9, N'a', 125, N'cái', 125, 1)
INSERT [dbo].[TOOL] ([ID], [Tool], [Sum], [Unit], [Available], [IsDelete]) VALUES (10, N'Bao tay', 200, N'Cái', 200, 0)
SET IDENTITY_INSERT [dbo].[TOOL] OFF
GO
SET IDENTITY_INSERT [dbo].[TOOLTICKER] ON 

INSERT [dbo].[TOOLTICKER] ([ID], [ToolID], [Amount], [Notes], [IsDelete], [GroupsID], [Status]) VALUES (18, 1, 1, NULL, 1, 31, 3)
INSERT [dbo].[TOOLTICKER] ([ID], [ToolID], [Amount], [Notes], [IsDelete], [GroupsID], [Status]) VALUES (19, 2, 1, NULL, 1, 31, 3)
INSERT [dbo].[TOOLTICKER] ([ID], [ToolID], [Amount], [Notes], [IsDelete], [GroupsID], [Status]) VALUES (20, 2, 250, NULL, NULL, 36, 1)
INSERT [dbo].[TOOLTICKER] ([ID], [ToolID], [Amount], [Notes], [IsDelete], [GroupsID], [Status]) VALUES (21, 2, 6, NULL, NULL, 35, 1)
INSERT [dbo].[TOOLTICKER] ([ID], [ToolID], [Amount], [Notes], [IsDelete], [GroupsID], [Status]) VALUES (22, 1, 6, NULL, NULL, 35, 1)
INSERT [dbo].[TOOLTICKER] ([ID], [ToolID], [Amount], [Notes], [IsDelete], [GroupsID], [Status]) VALUES (23, 3, 4, NULL, NULL, 35, 1)
SET IDENTITY_INSERT [dbo].[TOOLTICKER] OFF
GO
SET IDENTITY_INSERT [dbo].[WORKTICKER] ON 

INSERT [dbo].[WORKTICKER] ([ID], [CalendarID], [AccountID], [Status], [RegistrationForm], [IsDelete], [Note], [RegistrationNumber]) VALUES (64, 7, 2, 4, N'Cá nhân', 1, NULL, 1)
INSERT [dbo].[WORKTICKER] ([ID], [CalendarID], [AccountID], [Status], [RegistrationForm], [IsDelete], [Note], [RegistrationNumber]) VALUES (65, 7, 10, 4, N'Lớp', 1, NULL, 4)
INSERT [dbo].[WORKTICKER] ([ID], [CalendarID], [AccountID], [Status], [RegistrationForm], [IsDelete], [Note], [RegistrationNumber]) VALUES (66, 14, 19, 2, N'Lớp', NULL, NULL, 9)
INSERT [dbo].[WORKTICKER] ([ID], [CalendarID], [AccountID], [Status], [RegistrationForm], [IsDelete], [Note], [RegistrationNumber]) VALUES (67, 14, 2, 4, N'Cá nhân', 1, NULL, 1)
INSERT [dbo].[WORKTICKER] ([ID], [CalendarID], [AccountID], [Status], [RegistrationForm], [IsDelete], [Note], [RegistrationNumber]) VALUES (68, 12, 19, 2, N'Lớp', NULL, NULL, 9)
INSERT [dbo].[WORKTICKER] ([ID], [CalendarID], [AccountID], [Status], [RegistrationForm], [IsDelete], [Note], [RegistrationNumber]) VALUES (69, 14, 2, 4, N'Cá nhân', 1, NULL, 1)
INSERT [dbo].[WORKTICKER] ([ID], [CalendarID], [AccountID], [Status], [RegistrationForm], [IsDelete], [Note], [RegistrationNumber]) VALUES (70, 13, 19, 1, N'Cá nhân', NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[WORKTICKER] OFF
GO
ALTER TABLE [dbo].[ACCOUNT]  WITH CHECK ADD  CONSTRAINT [FK_TAIKHOAN_QUYEN] FOREIGN KEY([RoleID])
REFERENCES [dbo].[ROLE] ([ID])
GO
ALTER TABLE [dbo].[ACCOUNT] CHECK CONSTRAINT [FK_TAIKHOAN_QUYEN]
GO
ALTER TABLE [dbo].[CLASS]  WITH CHECK ADD  CONSTRAINT [FK_CLASS_FACULTY] FOREIGN KEY([FacultyID])
REFERENCES [dbo].[FACULTY] ([ID])
GO
ALTER TABLE [dbo].[CLASS] CHECK CONSTRAINT [FK_CLASS_FACULTY]
GO
ALTER TABLE [dbo].[GROUPS]  WITH CHECK ADD  CONSTRAINT [FK_GROUPS_CALENDAR] FOREIGN KEY([CalendarID])
REFERENCES [dbo].[CALENDAR] ([ID])
GO
ALTER TABLE [dbo].[GROUPS] CHECK CONSTRAINT [FK_GROUPS_CALENDAR]
GO
ALTER TABLE [dbo].[GROUPS]  WITH CHECK ADD  CONSTRAINT [FK_GROUPS_JOB] FOREIGN KEY([JobID])
REFERENCES [dbo].[JOB] ([ID])
GO
ALTER TABLE [dbo].[GROUPS] CHECK CONSTRAINT [FK_GROUPS_JOB]
GO
ALTER TABLE [dbo].[MENUS_ROLE]  WITH CHECK ADD  CONSTRAINT [FK_MENUS_ROLE_MENUS] FOREIGN KEY([ID_MN])
REFERENCES [dbo].[MENUS] ([ID_MN])
GO
ALTER TABLE [dbo].[MENUS_ROLE] CHECK CONSTRAINT [FK_MENUS_ROLE_MENUS]
GO
ALTER TABLE [dbo].[MENUS_ROLE]  WITH CHECK ADD  CONSTRAINT [FK_MENUS_ROLE_ROLE] FOREIGN KEY([RoleID])
REFERENCES [dbo].[ROLE] ([ID])
GO
ALTER TABLE [dbo].[MENUS_ROLE] CHECK CONSTRAINT [FK_MENUS_ROLE_ROLE]
GO
ALTER TABLE [dbo].[MUSTER]  WITH CHECK ADD  CONSTRAINT [FK_MUSTER_GROUPS] FOREIGN KEY([GroupsID])
REFERENCES [dbo].[GROUPS] ([ID])
GO
ALTER TABLE [dbo].[MUSTER] CHECK CONSTRAINT [FK_MUSTER_GROUPS]
GO
ALTER TABLE [dbo].[MUSTER]  WITH CHECK ADD  CONSTRAINT [FK_MUSTER_STUDENT] FOREIGN KEY([StudentID])
REFERENCES [dbo].[STUDENT] ([ID])
GO
ALTER TABLE [dbo].[MUSTER] CHECK CONSTRAINT [FK_MUSTER_STUDENT]
GO
ALTER TABLE [dbo].[STUDENT]  WITH CHECK ADD  CONSTRAINT [FK_SINHVIEN_LOP] FOREIGN KEY([ClassID])
REFERENCES [dbo].[CLASS] ([ID])
GO
ALTER TABLE [dbo].[STUDENT] CHECK CONSTRAINT [FK_SINHVIEN_LOP]
GO
ALTER TABLE [dbo].[STUDENT]  WITH CHECK ADD  CONSTRAINT [FK_SINHVIEN_TAIKHOAN] FOREIGN KEY([AccountID])
REFERENCES [dbo].[ACCOUNT] ([ID])
GO
ALTER TABLE [dbo].[STUDENT] CHECK CONSTRAINT [FK_SINHVIEN_TAIKHOAN]
GO
ALTER TABLE [dbo].[TOOLTICKER]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUDUNGCU_DUNGCULAODONG] FOREIGN KEY([ToolID])
REFERENCES [dbo].[TOOL] ([ID])
GO
ALTER TABLE [dbo].[TOOLTICKER] CHECK CONSTRAINT [FK_PHIEUDUNGCU_DUNGCULAODONG]
GO
ALTER TABLE [dbo].[TOOLTICKER]  WITH CHECK ADD  CONSTRAINT [FK_TOOLTICKER_GROUPS] FOREIGN KEY([GroupsID])
REFERENCES [dbo].[GROUPS] ([ID])
GO
ALTER TABLE [dbo].[TOOLTICKER] CHECK CONSTRAINT [FK_TOOLTICKER_GROUPS]
GO
ALTER TABLE [dbo].[WORKTICKER]  WITH CHECK ADD  CONSTRAINT [FK_PHIEULAODONG_LICHLAODONG] FOREIGN KEY([CalendarID])
REFERENCES [dbo].[CALENDAR] ([ID])
GO
ALTER TABLE [dbo].[WORKTICKER] CHECK CONSTRAINT [FK_PHIEULAODONG_LICHLAODONG]
GO
ALTER TABLE [dbo].[WORKTICKER]  WITH CHECK ADD  CONSTRAINT [FK_WORKTICKER_ACCOUNT] FOREIGN KEY([AccountID])
REFERENCES [dbo].[ACCOUNT] ([ID])
GO
ALTER TABLE [dbo].[WORKTICKER] CHECK CONSTRAINT [FK_WORKTICKER_ACCOUNT]
GO
