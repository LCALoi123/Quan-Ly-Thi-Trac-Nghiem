USE [QLTN]
GO
/****** Object:  User [loi]    Script Date: 11-Jan-21 8:01:39 PM ******/
CREATE USER [loi] FOR LOGIN [loi] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [loi]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [loi]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [loi]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [loi]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [loi]
GO
ALTER ROLE [db_datareader] ADD MEMBER [loi]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [loi]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [loi]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [loi]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 11-Jan-21 8:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[usName] [varchar](20) NOT NULL,
	[PassWord] [varchar](20) NOT NULL,
	[PhanHe] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 11-Jan-21 8:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Admin](
	[IDus] [int] NOT NULL,
	[IDadmin] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[UsName] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDadmin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CauHoi]    Script Date: 11-Jan-21 8:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CauHoi](
	[IDch] [int] IDENTITY(1,1) NOT NULL,
	[CauHoi] [nvarchar](1000) NOT NULL,
	[dapanA] [nvarchar](1000) NOT NULL,
	[dapanB] [nvarchar](1000) NOT NULL,
	[dapanC] [nvarchar](1000) NOT NULL,
	[dapanD] [nvarchar](1000) NOT NULL,
	[dapandung] [nvarchar](1000) NOT NULL,
	[DoKho] [int] NOT NULL,
 CONSTRAINT [PK_CauHoi] PRIMARY KEY CLUSTERED 
(
	[IDch] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CauHoiDongGop]    Script Date: 11-Jan-21 8:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CauHoiDongGop](
	[IDch] [int] IDENTITY(1,1) NOT NULL,
	[IDhs] [int] NULL,
	[CauHoi] [nvarchar](1000) NOT NULL,
	[dapanA] [nvarchar](1000) NOT NULL,
	[dapanB] [nvarchar](1000) NOT NULL,
	[dapanC] [nvarchar](1000) NOT NULL,
	[dapanD] [nvarchar](1000) NOT NULL,
	[dapandung] [nvarchar](1000) NOT NULL,
	[DoKho] [int] NOT NULL,
	[duyet] [bit] NOT NULL,
 CONSTRAINT [PK_CauHoiDongGop] PRIMARY KEY CLUSTERED 
(
	[IDch] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CT_DeThi]    Script Date: 11-Jan-21 8:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CT_DeThi](
	[MaDe] [varchar](10) NOT NULL,
	[IDch] [int] NOT NULL,
 CONSTRAINT [PK_CT_DeThi] PRIMARY KEY CLUSTERED 
(
	[MaDe] ASC,
	[IDch] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CT_HOCSINH_KYTHI]    Script Date: 11-Jan-21 8:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CT_HOCSINH_KYTHI](
	[MaKyThi] [varchar](10) NOT NULL,
	[IDhs] [int] NOT NULL,
 CONSTRAINT [PK_CT_HOCSINH_KYTHI] PRIMARY KEY CLUSTERED 
(
	[MaKyThi] ASC,
	[IDhs] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CT_HOCSINH_KyThiThu]    Script Date: 11-Jan-21 8:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CT_HOCSINH_KyThiThu](
	[MaKyThi] [varchar](10) NOT NULL,
	[IDhs] [int] NOT NULL,
 CONSTRAINT [PK_CT_HOCSINH_KYTHIThu] PRIMARY KEY CLUSTERED 
(
	[MaKyThi] ASC,
	[IDhs] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CT_KyThi]    Script Date: 11-Jan-21 8:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CT_KyThi](
	[MaKyThi] [varchar](10) NOT NULL,
	[MaDe] [varchar](10) NOT NULL,
 CONSTRAINT [PK_CT_KyThi] PRIMARY KEY CLUSTERED 
(
	[MaKyThi] ASC,
	[MaDe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CT_KyThiThu]    Script Date: 11-Jan-21 8:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CT_KyThiThu](
	[MaKyThi] [varchar](10) NOT NULL,
	[MaDe] [varchar](10) NOT NULL,
 CONSTRAINT [PK_CT_KyThiThu] PRIMARY KEY CLUSTERED 
(
	[MaKyThi] ASC,
	[MaDe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DeThi]    Script Date: 11-Jan-21 8:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DeThi](
	[MaDe] [varchar](10) NOT NULL,
	[TenDe] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_DeThi] PRIMARY KEY CLUSTERED 
(
	[MaDe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DiemThi]    Script Date: 11-Jan-21 8:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DiemThi](
	[MaKyThi] [varchar](10) NOT NULL,
	[MaDe] [varchar](10) NOT NULL,
	[IDhs] [int] NOT NULL,
	[Diem] [float] NOT NULL,
 CONSTRAINT [PK_DiemThi] PRIMARY KEY CLUSTERED 
(
	[MaKyThi] ASC,
	[MaDe] ASC,
	[IDhs] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GiaoVien]    Script Date: 11-Jan-21 8:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiaoVien](
	[IDgv] [int] IDENTITY(1,1) NOT NULL,
	[TenGV] [nvarchar](50) NOT NULL,
	[IDus] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDgv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HocSinh]    Script Date: 11-Jan-21 8:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HocSinh](
	[IDhs] [int] IDENTITY(1,1) NOT NULL,
	[TenHS] [nvarchar](50) NOT NULL,
	[Lop] [varchar](10) NOT NULL,
	[KhoiLop] [varchar](10) NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[IDus] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDhs] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KyThi]    Script Date: 11-Jan-21 8:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KyThi](
	[MaKyThi] [varchar](10) NOT NULL,
	[TenKyThi] [nvarchar](200) NOT NULL,
	[NgayThi] [date] NOT NULL,
 CONSTRAINT [PK_KyThi] PRIMARY KEY CLUSTERED 
(
	[MaKyThi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KyThiThu]    Script Date: 11-Jan-21 8:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KyThiThu](
	[MaKyThi] [varchar](10) NOT NULL,
	[TenKyThi] [nvarchar](200) NOT NULL,
	[NgayBD] [date] NOT NULL,
	[NgayKT] [date] NOT NULL,
 CONSTRAINT [PK_KyThiThu] PRIMARY KEY CLUSTERED 
(
	[MaKyThi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([ID], [usName], [PassWord], [PhanHe]) VALUES (3, N'leloi01', N'Lcaloi123', N'Giáo Viên')
INSERT [dbo].[Account] ([ID], [usName], [PassWord], [PhanHe]) VALUES (4, N'admin01', N'Admin01', N'Admin')
INSERT [dbo].[Account] ([ID], [usName], [PassWord], [PhanHe]) VALUES (5, N'hocsinh01', N'Hócinh01', N'Học Sinh')
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([IDus], [IDadmin], [HoTen], [NgaySinh], [UsName]) VALUES (4, 1, N'Admin', CAST(N'1999-04-29' AS Date), N'admin01')
SET IDENTITY_INSERT [dbo].[Admin] OFF
SET IDENTITY_INSERT [dbo].[CauHoi] ON 

INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (2, N'Ann_______ a dress for her doll.', N'made', N'built', N'sold', N'handed', N'A', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (3, N'A helicopter (managed) to land on the roof and rescued six of us', N'pretended', N'could', N'succeeded', N'was able', N'D', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (4, N'I know my_______ to school


', N'way', N'walk', N'lunch', N'book', N'A', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (5, N'Can you guess where Tom _______ his cat ?', N'looks', N'found', N'find', N'seen', N'C', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (6, N'Central Los Angeles was (rocked) by another car bomb explosion last
', N'taken', N'shaken violently', N'seized', N'taken seriously', N'B', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (7, N'I was (furious), and shouted at him.', N'hot', N'extremely angry', N'not very happy', N'too sad', N'B', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (8, N'The Caribbean ? - Oh, I can highly (recommend) it.', N'praise', N'introduce', N'say about', N'answer', N'A', 2)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (9, N'He will______ his brother with him', N'give', N'like', N'take', N'catch', N'C', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (10, N'I managed to stop, but (the ran) behind me didn''t.', N'the heavy car ', N'the small truck', N'the coach', N'the big motorbike', N'B', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (11, N'He was smiling happily and (cheering) wildly



', N'crying loudly', N'enjoying himself', N'observing the scene', N'shouting congratulations', N'D', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (12, N'Will you_______ me how to play the game ?



', N'learn', N'show', N'call', N'need', N'B', 3)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (13, N'It was quite an (ordinary) ghost, really



', N'good-looking', N'common', N'famous', N'gently', N'B', 4)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (14, N'The ball_______ the fence and into the street.', N'hit', N'shot', N'kicked', N'went over', N'D', 2)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (15, N'Abdul was (badly frightened) by a stranger in the market



', N'terrified', N'worried', N'surprised', N'embarrassed', N'A', 2)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (16, N'Mrs Riley, (an elderly) widow, was walking along a dark London street



', N'a very old', N'a somewhat old', N'an older', N'mature', N'B', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (17, N'We shall_______ a letter to John


', N'receive', N'send', N'ask', N'reply
', N'B', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (18, N'The spaceship (descended) slowly through the clouds.



', N'looked down', N'stepped down', N'went down', N'turned down', N'C', 3)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (19, N'How often do you ______ your cat ?



', N'food', N'feed', N'eat', N'give', N'B', 2)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (20, N'She has been (out of work) for a long time.



', N'unable to do', N'dissatisfied', N'disappointed', N'unemployed', N'D', 4)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (21, N'I''d like to have this skirt (lengthened)



', N'angrily', N'strong', N'healthy', N'tired', N'D', 4)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (22, N'Will you_______ me how to play the game ?


', N'call', N'show', N'need', N'learn', N'B', 2)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (23, N'I didn’t think his the comments were very (appropriate) at the time.', N'correct', N'right', N'exact', N'suitable', N'D', 2)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (24, N' People dont use this road very often.', N'This road is not used very often', N' Not very often this road is not used', N'This road very often is not used', N'This road not very often is used', N'A', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (25, N' He was very tired but he kept on working.', N'Despite very tired, he kept on working.', N' Though his tiredness, he kept on working.', N' Although he was very tired, but he kept on working.', N' He kept on working although he was very tired.', N'A', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (26, N' Although it rained heavily, they went on working.', N'In spite of the rain heavily, they went on working.', N'In spite of the raining heavily, they went on working.', N'Despite the heavy rain, they went on working.', N' Though the fact that it rained heavily, they went on working.', N'C', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (27, N' Cars cause pollution but people still want them.', N'Because cars cause pollution, people want them.', N' Despite the fact that cars cause pollution, people want them.', N'Cars cause pollution although people want them.', N' Cars cause pollution because people still want them.', N'B', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (28, N' They have built a new hospital near the airport.', N'Near the airport a new hospital has been built.', N' A new hospital has been built near the airport by them.', N' A new hospital near the airport has been built.', N'A new hospital has been built near the airport.', N'A', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (29, N'Developing new technologies are time-consuming and expensive', N'developing', N'technologies', N'are', N' time-consuming', N'C', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (30, N'The assumption that smoking has bad effects on our health have been proved', N'that ', N'effects', N'on', N' have been proved', N'D', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (31, N' A novel is a story long enough to fill a complete book, in that the characters and events are usually imaginary', N' long enough', N' complete', N' that', N' imaginary', N'C', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (32, N'The leader demanded from his members a serious attitude towards work, good team spirit, and that they work hard', N'leader', N'his members', N'attitude', N'that they work hard', N'D', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (33, N'The earth is the only planet with a large number of oxygen in its atmosphere.', N' the', N'number', N'oxygen', N'its', N'B', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (34, N'Not until he got home he realized he had forgotten to give her the present.', N'got', N'he realized', N'her ', N'the present', N'A', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (35, N' The longer the children waited in the long queue, the more impatiently they became', N'the longer', N'waited', N'the long queue', N'impatiently', N'D', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (36, N' People have discovered a new source of energy.', N'A new source of energy has discovered.', N'A new source of energy was discovered.', N'A new source of energy have been discovered', N'A new source of energy has been discovered', N'D', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (37, N'People say that he was born in London.', N' He is said to have been born in London.', N'That is said he was born in London.', N'It was said that he was born in London.', N'He was said to be born in London.', N'A', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (38, N'We have no seats left for the concert next Sunday.', N' All the seats for the concert next Sunday have been booked', N' All the seats were sold for the concert next Sunday.', N'The concert next Sunday had no seats for us.', N' No seats left for us for the concert next Sunday.', N'A', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (39, N'She had only just begun to speak when people started interrupting.', N'She hardly had begun to speak when people started interrupting.', N'Hardly she had begun to speak when people started interrupting.', N'Hardly had she begun to speak when people started interrupting.', N' She hadn’t begun to speak when people started interrupting.', N'C', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (40, N' The storm blew a lot of trees down last night.', N'A lot of trees were blown down last night by the storm.', N' A lot of trees were cut down last night', N' The storm could have blown a lot of trees down.', N'The storm was strong enough to blow down old trees.', N'A', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (41, N'Mrs. Stevens, along with her cousins from Canada, are planning to attend the firework display in Da Nang, Vietnam', N'with', N'her cousins', N'are', N' to attend', N'A', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (42, N'If one type of manufacturing expands, it is like that another type will shrink considerably.', N' expands ', N'like', N'another', N'considerably', N'A', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (43, N'Mrs. Stevens, along with her cousins from Canada, are planning to attend the firework display in Da Nang, Vietnam', N'with', N' her cousins', N'are', N' to attend', N'C', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (44, N' If one type of manufacturing expands, it is like that another type will shrink considerably', N'expands', N' like', N' another ', N'considerably', N'B', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (45, N'For thousands of years, man has created sweet-smelling substances from wood, herbs and flowers and using them for perfumes or medicine.', N'man', N' sweet-smelling', N'using them', N'or', N'C', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (46, N'People in every part of the world readily and easily communicates by means of electronic mail', N'every part ', N'readlily', N'communicates', N'by means', N'C', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (47, N'The grass needs cutting, so let us have one of the men to take lawn-mower and do it.', N' needs  ', N'cutting ', N' let', N'to take', N'A', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (48, N' What we know about certain diseases are still not sufficient to prevent them from spreading easily among the population.', N'What we know ', N'are', N' from spreading', N' among', N'B', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (49, N'By the time Robert will finish writing the first draft of his paper, most of the other students will have completed their final draft', N'will finish', N'writing', N' most', N' their', N'A', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (50, N'Each of the beautiful cars in the shop was quickly sold to their owner', N'Each', N'cars', N'quickly', N'their', N'D', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (51, N'Developing new technologies are time-consuming and expensive', N'developing', N'technologies', N'are', N' time-consuming', N'C', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (52, N'The assumption that smoking has bad effects on our health have been proved', N'that ', N'effects', N'on', N' have been proved', N'D', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (53, N' A novel is a story long enough to fill a complete book, in that the characters and events are usually imaginary', N' long enough', N' complete', N' that', N' imaginary', N'C', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (54, N'The leader demanded from his members a serious attitude towards work, good team spirit, and that they work hard', N'leader', N'his members', N'attitude', N'that they work hard', N'D', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (55, N'The earth is the only planet with a large number of oxygen in its atmosphere.', N' the', N'number', N'oxygen', N'its', N'B', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (56, N'Not until he got home he realized he had forgotten to give her the present.', N'got', N'he realized', N'her ', N'the present', N'A', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (57, N' The longer the children waited in the long queue, the more impatiently they became', N'the longer', N'waited', N'the long queue', N'impatiently', N'D', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (58, N'Mrs. Stevens, along with her cousins from Canada, are planning to attend the firework display in Da Nang, Vietnam', N'with', N'her cousins', N'are', N' to attend', N'A', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (59, N'If one type of manufacturing expands, it is like that another type will shrink considerably.', N' expands ', N'like', N'another', N'considerably', N'A', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (60, N'Mrs. Stevens, along with her cousins from Canada, are planning to attend the firework display in Da Nang, Vietnam', N'with', N' her cousins', N'are', N' to attend', N'C', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (61, N' If one type of manufacturing expands, it is like that another type will shrink considerably', N'expands', N' like', N' another ', N'considerably', N'B', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (62, N'For thousands of years, man has created sweet-smelling substances from wood, herbs and flowers and using them for perfumes or medicine.', N'man', N' sweet-smelling', N'using them', N'or', N'C', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (63, N'People in every part of the world readily and easily communicates by means of electronic mail', N'every part ', N'readlily', N'communicates', N'by means', N'C', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (64, N'The grass needs cutting, so let us have one of the men to take lawn-mower and do it.', N' needs  ', N'cutting ', N' let', N'to take', N'A', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (65, N' What we know about certain diseases are still not sufficient to prevent them from spreading easily among the population.', N'What we know ', N'are', N' from spreading', N' among', N'B', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (66, N'By the time Robert will finish writing the first draft of his paper, most of the other students will have completed their final draft', N'will finish', N'writing', N' most', N' their', N'A', 1)
INSERT [dbo].[CauHoi] ([IDch], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho]) VALUES (67, N'Each of the beautiful cars in the shop was quickly sold to their owner', N'Each', N'cars', N'quickly', N'their', N'D', 1)
SET IDENTITY_INSERT [dbo].[CauHoi] OFF
SET IDENTITY_INSERT [dbo].[CauHoiDongGop] ON 

INSERT [dbo].[CauHoiDongGop] ([IDch], [IDhs], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho], [duyet]) VALUES (1, 2, N'When being interviewed, you should (concentrate) on what the interviewer is saying or asking you.', N'symptoms', N'demonstrations', N'effects', N'hints', N'D', 2, 0)
INSERT [dbo].[CauHoiDongGop] ([IDch], [IDhs], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho], [duyet]) VALUES (4, 2, N'She came to the meeting late (on purpose) so she would miss the introductory speech.', N'aiming at ', N'intentionally', N'with a goal', N'reasonably', N'C', 3, 0)
INSERT [dbo].[CauHoiDongGop] ([IDch], [IDhs], [CauHoi], [dapanA], [dapanB], [dapanC], [dapanD], [dapandung], [DoKho], [duyet]) VALUES (5, 2, N'(Childbearing) is the women''s most wonderful role.', N'Bring up a child', N'Giving birth to a baby ', N'Educating a child ', N'Having no child', N'B', 2, 0)
SET IDENTITY_INSERT [dbo].[CauHoiDongGop] OFF
SET IDENTITY_INSERT [dbo].[GiaoVien] ON 

INSERT [dbo].[GiaoVien] ([IDgv], [TenGV], [IDus]) VALUES (2, N'Lê Công Anh Lợi', 3)
SET IDENTITY_INSERT [dbo].[GiaoVien] OFF
SET IDENTITY_INSERT [dbo].[HocSinh] ON 

INSERT [dbo].[HocSinh] ([IDhs], [TenHS], [Lop], [KhoiLop], [NgaySinh], [IDus]) VALUES (2, N'Học Sinh ', N'10B2', N'10', CAST(N'1999-01-09' AS Date), 5)
SET IDENTITY_INSERT [dbo].[HocSinh] OFF
ALTER TABLE [dbo].[Admin]  WITH CHECK ADD FOREIGN KEY([IDus])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[CT_DeThi]  WITH CHECK ADD FOREIGN KEY([IDch])
REFERENCES [dbo].[CauHoi] ([IDch])
GO
ALTER TABLE [dbo].[CT_DeThi]  WITH CHECK ADD FOREIGN KEY([MaDe])
REFERENCES [dbo].[DeThi] ([MaDe])
GO
ALTER TABLE [dbo].[CT_HOCSINH_KYTHI]  WITH CHECK ADD FOREIGN KEY([MaKyThi])
REFERENCES [dbo].[KyThi] ([MaKyThi])
GO
ALTER TABLE [dbo].[CT_HOCSINH_KYTHI]  WITH CHECK ADD FOREIGN KEY([IDhs])
REFERENCES [dbo].[HocSinh] ([IDhs])
GO
ALTER TABLE [dbo].[CT_HOCSINH_KyThiThu]  WITH CHECK ADD FOREIGN KEY([MaKyThi])
REFERENCES [dbo].[KyThiThu] ([MaKyThi])
GO
ALTER TABLE [dbo].[CT_HOCSINH_KyThiThu]  WITH CHECK ADD FOREIGN KEY([IDhs])
REFERENCES [dbo].[HocSinh] ([IDhs])
GO
ALTER TABLE [dbo].[CT_KyThi]  WITH CHECK ADD FOREIGN KEY([MaDe])
REFERENCES [dbo].[DeThi] ([MaDe])
GO
ALTER TABLE [dbo].[CT_KyThi]  WITH CHECK ADD FOREIGN KEY([MaKyThi])
REFERENCES [dbo].[KyThi] ([MaKyThi])
GO
ALTER TABLE [dbo].[CT_KyThiThu]  WITH CHECK ADD FOREIGN KEY([MaKyThi])
REFERENCES [dbo].[KyThiThu] ([MaKyThi])
GO
ALTER TABLE [dbo].[CT_KyThiThu]  WITH CHECK ADD FOREIGN KEY([MaDe])
REFERENCES [dbo].[DeThi] ([MaDe])
GO
ALTER TABLE [dbo].[DiemThi]  WITH CHECK ADD FOREIGN KEY([MaKyThi], [MaDe])
REFERENCES [dbo].[CT_KyThi] ([MaKyThi], [MaDe])
GO
ALTER TABLE [dbo].[DiemThi]  WITH CHECK ADD FOREIGN KEY([IDhs])
REFERENCES [dbo].[HocSinh] ([IDhs])
GO
ALTER TABLE [dbo].[GiaoVien]  WITH CHECK ADD FOREIGN KEY([IDus])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[HocSinh]  WITH CHECK ADD FOREIGN KEY([IDus])
REFERENCES [dbo].[Account] ([ID])
GO
