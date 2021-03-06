USE [master]
GO
/****** Object:  Database [Hr]    Script Date: 2021/11/22 下午 06:28:59 ******/
CREATE DATABASE [Hr]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Hr', FILENAME = N'C:\Users\bruce\Hr.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Hr_log', FILENAME = N'C:\Users\bruce\Hr_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Hr] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Hr].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Hr] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Hr] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Hr] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Hr] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Hr] SET ARITHABORT OFF 
GO
ALTER DATABASE [Hr] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Hr] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Hr] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Hr] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Hr] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Hr] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Hr] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Hr] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Hr] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Hr] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Hr] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Hr] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Hr] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Hr] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Hr] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Hr] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Hr] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Hr] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Hr] SET  MULTI_USER 
GO
ALTER DATABASE [Hr] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Hr] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Hr] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Hr] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Hr] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Hr] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Hr] SET QUERY_STORE = OFF
GO
USE [Hr]
GO
/****** Object:  Table [dbo].[Cms]    Script Date: 2021/11/22 下午 06:28:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cms](
	[Id] [varchar](10) NOT NULL,
	[CmsType] [varchar](10) NOT NULL,
	[DataType] [varchar](10) NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Text] [nvarchar](max) NULL,
	[Html] [nvarchar](max) NULL,
	[Note] [nvarchar](255) NULL,
	[FileName] [nvarchar](100) NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[Status] [bit] NOT NULL,
	[Creator] [varchar](10) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Reviser] [varchar](10) NULL,
	[Revised] [datetime] NULL,
 CONSTRAINT [PK_Cms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustInput]    Script Date: 2021/11/22 下午 06:28:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustInput](
	[Id] [varchar](10) NOT NULL,
	[FldText] [nchar](10) NULL,
	[FldNum] [int] NULL,
	[FldNum2] [float] NULL,
	[FldCheck] [bit] NULL,
	[FldRadio] [tinyint] NULL,
	[FldSelect] [varchar](10) NULL,
	[FldDate] [date] NULL,
	[FldDatetime] [datetime] NULL,
	[FldFile] [nvarchar](100) NULL,
	[FldColor] [varchar](10) NULL,
	[FldTextarea] [nvarchar](max) NULL,
	[FldHtml] [nvarchar](max) NULL,
 CONSTRAINT [PK_CustInput] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dept]    Script Date: 2021/11/22 下午 06:28:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dept](
	[Id] [varchar](10) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[MgrId] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Dept] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Leave]    Script Date: 2021/11/22 下午 06:28:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Leave](
	[Id] [varchar](10) NOT NULL,
	[UserId] [varchar](10) NOT NULL,
	[AgentId] [varchar](10) NOT NULL,
	[LeaveType] [char](1) NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[Hours] [decimal](5, 1) NOT NULL,
	[FlowLevel] [tinyint] NOT NULL,
	[FlowStatus] [char](1) NOT NULL,
	[FileName] [nvarchar](100) NULL,
	[Status] [bit] NOT NULL,
	[Creator] [varchar](10) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Reviser] [varchar](10) NULL,
	[Revised] [datetime] NULL,
 CONSTRAINT [PK_Leave] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2021/11/22 下午 06:28:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [varchar](10) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Account] [varchar](20) NOT NULL,
	[Pwd] [varchar](32) NOT NULL,
	[DeptId] [varchar](10) NOT NULL,
	[PhotoFile] [nvarchar](100) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserJob]    Script Date: 2021/11/22 下午 06:28:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserJob](
	[Id] [varchar](10) NOT NULL,
	[UserId] [varchar](10) NOT NULL,
	[JobName] [nvarchar](30) NOT NULL,
	[JobType] [nvarchar](30) NULL,
	[JobPlace] [nvarchar](30) NULL,
	[StartEnd] [varchar](30) NULL,
	[CorpName] [nvarchar](30) NULL,
	[CorpUsers] [int] NOT NULL,
	[IsManaged] [bit] NOT NULL,
	[JobDesc] [varchar](max) NULL,
 CONSTRAINT [PK_UserJob] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLang]    Script Date: 2021/11/22 下午 06:28:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLang](
	[Id] [varchar](10) NOT NULL,
	[UserId] [varchar](10) NOT NULL,
	[LangName] [nvarchar](30) NOT NULL,
	[ListenLevel] [tinyint] NOT NULL,
	[SpeakLevel] [tinyint] NOT NULL,
	[ReadLevel] [tinyint] NOT NULL,
	[WriteLevel] [tinyint] NOT NULL,
	[Sort] [int] NOT NULL,
 CONSTRAINT [PK_UserLang] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLicense]    Script Date: 2021/11/22 下午 06:28:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLicense](
	[Id] [varchar](10) NOT NULL,
	[UserId] [varchar](10) NOT NULL,
	[LicenseName] [nvarchar](30) NOT NULL,
	[StartEnd] [varchar](30) NULL,
	[FileName] [nvarchar](100) NULL,
 CONSTRAINT [PK_UserLicense] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserSchool]    Script Date: 2021/11/22 下午 06:28:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSchool](
	[Id] [varchar](10) NOT NULL,
	[UserId] [varchar](10) NOT NULL,
	[SchoolName] [nvarchar](30) NOT NULL,
	[SchoolDept] [nvarchar](20) NULL,
	[SchoolType] [nvarchar](20) NULL,
	[StartEnd] [varchar](30) NULL,
	[Graduated] [bit] NOT NULL,
 CONSTRAINT [PK_UserSchool] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserSkill]    Script Date: 2021/11/22 下午 06:28:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSkill](
	[Id] [varchar](10) NOT NULL,
	[UserId] [varchar](10) NOT NULL,
	[SkillName] [nvarchar](30) NOT NULL,
	[SkillDesc] [nvarchar](500) NULL,
	[Sort] [int] NOT NULL,
 CONSTRAINT [PK_UserSkill] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XpCode]    Script Date: 2021/11/22 下午 06:28:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XpCode](
	[Type] [varchar](20) NOT NULL,
	[Value] [varchar](10) NOT NULL,
	[Name_zhTW] [nvarchar](30) NOT NULL,
	[Name_zhCN] [nvarchar](30) NULL,
	[Name_enUS] [nvarchar](30) NULL,
	[Sort] [int] NOT NULL,
	[Ext] [varchar](30) NULL,
	[Note] [nvarchar](255) NULL,
 CONSTRAINT [PK_XpCode] PRIMARY KEY CLUSTERED 
(
	[Type] ASC,
	[Value] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XpEasyRpt]    Script Date: 2021/11/22 下午 06:28:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XpEasyRpt](
	[Id] [varchar](10) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[TplFile] [nvarchar](100) NOT NULL,
	[ToEmails] [varchar](500) NOT NULL,
	[Sql] [nvarchar](500) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_XpEasyRpt] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XpFlow]    Script Date: 2021/11/22 下午 06:28:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XpFlow](
	[Id] [varchar](10) NOT NULL,
	[Code] [varchar](20) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Portrait] [bit] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Flow] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XpFlowLine]    Script Date: 2021/11/22 下午 06:28:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XpFlowLine](
	[Id] [varchar](10) NOT NULL,
	[FlowId] [varchar](10) NOT NULL,
	[StartNode] [varchar](10) NOT NULL,
	[EndNode] [varchar](10) NOT NULL,
	[CondStr] [varchar](255) NULL,
	[Sort] [smallint] NOT NULL,
 CONSTRAINT [PK_FlowLine] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XpFlowNode]    Script Date: 2021/11/22 下午 06:28:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XpFlowNode](
	[Id] [varchar](10) NOT NULL,
	[FlowId] [varchar](10) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[NodeType] [char](1) NOT NULL,
	[PosX] [smallint] NOT NULL,
	[PosY] [smallint] NOT NULL,
	[SignerType] [varchar](2) NULL,
	[SignerValue] [varchar](30) NULL,
	[PassType] [char](1) NOT NULL,
	[PassNum] [smallint] NULL,
 CONSTRAINT [PK_FlowNode] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XpFlowSign]    Script Date: 2021/11/22 下午 06:28:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XpFlowSign](
	[Id] [varchar](10) NOT NULL,
	[FlowId] [varchar](10) NOT NULL,
	[SourceId] [varchar](10) NOT NULL,
	[NodeName] [nvarchar](30) NOT NULL,
	[FlowLevel] [smallint] NOT NULL,
	[TotalLevel] [smallint] NOT NULL,
	[SignerId] [varchar](10) NOT NULL,
	[SignerName] [nvarchar](20) NOT NULL,
	[SignStatus] [char](1) NOT NULL,
	[SignTime] [datetime] NULL,
	[Note] [nvarchar](255) NULL,
 CONSTRAINT [PK_FlowSign] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XpImportLog]    Script Date: 2021/11/22 下午 06:28:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XpImportLog](
	[Id] [varchar](10) NOT NULL,
	[Type] [varchar](10) NOT NULL,
	[FileName] [nvarchar](100) NOT NULL,
	[OkCount] [smallint] NOT NULL,
	[FailCount] [smallint] NOT NULL,
	[TotalCount] [smallint] NOT NULL,
	[CreatorName] [nvarchar](30) NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_XpImportLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XpProg]    Script Date: 2021/11/22 下午 06:28:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XpProg](
	[Id] [varchar](10) NOT NULL,
	[Code] [varchar](30) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Icon] [varchar](20) NULL,
	[Url] [varchar](100) NULL,
	[Sort] [smallint] NOT NULL,
	[AuthRow] [tinyint] NOT NULL,
	[FunCreate] [tinyint] NOT NULL,
	[FunRead] [tinyint] NOT NULL,
	[FunUpdate] [tinyint] NOT NULL,
	[FunDelete] [tinyint] NOT NULL,
	[FunPrint] [tinyint] NOT NULL,
	[FunExport] [tinyint] NOT NULL,
	[FunView] [tinyint] NOT NULL,
	[FunOther] [tinyint] NOT NULL,
 CONSTRAINT [PK_Prog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XpRole]    Script Date: 2021/11/22 下午 06:28:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XpRole](
	[Id] [varchar](10) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XpRoleProg]    Script Date: 2021/11/22 下午 06:28:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XpRoleProg](
	[Id] [varchar](10) NOT NULL,
	[RoleId] [varchar](10) NOT NULL,
	[ProgId] [varchar](10) NOT NULL,
	[FunCreate] [tinyint] NOT NULL,
	[FunRead] [tinyint] NOT NULL,
	[FunUpdate] [tinyint] NOT NULL,
	[FunDelete] [tinyint] NOT NULL,
	[FunPrint] [tinyint] NOT NULL,
	[FunExport] [tinyint] NOT NULL,
	[FunView] [tinyint] NOT NULL,
	[FunOther] [tinyint] NOT NULL,
 CONSTRAINT [PK_RoleProg] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XpTranLog]    Script Date: 2021/11/22 下午 06:28:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XpTranLog](
	[Sn] [int] IDENTITY(1,1) NOT NULL,
	[RowId] [varchar](10) NOT NULL,
	[TableName] [varchar](30) NOT NULL,
	[ColName] [varchar](30) NULL,
	[OldValue] [nvarchar](500) NULL,
	[NewValue] [nvarchar](500) NULL,
	[Act] [varchar](10) NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_XpTranLog] PRIMARY KEY CLUSTERED 
(
	[Sn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XpUserRole]    Script Date: 2021/11/22 下午 06:28:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XpUserRole](
	[Id] [varchar](10) NOT NULL,
	[UserId] [varchar](10) NOT NULL,
	[RoleId] [varchar](10) NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Dept] ([Id], [Name], [MgrId]) VALUES (N'GM', N'管理部', N'Peter')
INSERT [dbo].[Dept] ([Id], [Name], [MgrId]) VALUES (N'RD', N'研發部', N'Nick')
GO
INSERT [dbo].[Leave] ([Id], [UserId], [AgentId], [LeaveType], [StartTime], [EndTime], [Hours], [FlowLevel], [FlowStatus], [FileName], [Status], [Creator], [Created], [Reviser], [Revised]) VALUES (N'5ZMJQQQBYA', N'Alex', N'Nick', N'P', CAST(N'2021-03-10T09:00:00.000' AS DateTime), CAST(N'2021-03-10T18:00:00.000' AS DateTime), CAST(8.0 AS Decimal(5, 1)), 3, N'Y', N'', 1, N'Alex', CAST(N'2021-03-07T22:19:00.000' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[User] ([Id], [Name], [Account], [Pwd], [DeptId], [PhotoFile], [Status]) VALUES (N'Alex', N'Alex Chen', N'aa', N'aa', N'RD', NULL, 1)
INSERT [dbo].[User] ([Id], [Name], [Account], [Pwd], [DeptId], [PhotoFile], [Status]) VALUES (N'Nick', N'Nick Wang', N'nn', N'nn', N'RD', NULL, 1)
INSERT [dbo].[User] ([Id], [Name], [Account], [Pwd], [DeptId], [PhotoFile], [Status]) VALUES (N'Peter', N'Peter Lin', N'pp', N'pp', N'GM', NULL, 1)
GO
INSERT [dbo].[UserJob] ([Id], [UserId], [JobName], [JobType], [JobPlace], [StartEnd], [CorpName], [CorpUsers], [IsManaged], [JobDesc]) VALUES (N'5XLQJ73PZA', N'U01', N'11', N'22', N'33', N'44', N'55', 6, 1, N'77123')
INSERT [dbo].[UserJob] ([Id], [UserId], [JobName], [JobType], [JobPlace], [StartEnd], [CorpName], [CorpUsers], [IsManaged], [JobDesc]) VALUES (N'5YG7AZMCJA', N'Bruce', N'11abc', N'22', N'33', N'55', N'66', 10, 1, N'test')
GO
INSERT [dbo].[UserLang] ([Id], [UserId], [LangName], [ListenLevel], [SpeakLevel], [ReadLevel], [WriteLevel], [Sort]) VALUES (N'5XL9RMXH3A', N'U01', N'22', 1, 2, 3, 2, 0)
INSERT [dbo].[UserLang] ([Id], [UserId], [LangName], [ListenLevel], [SpeakLevel], [ReadLevel], [WriteLevel], [Sort]) VALUES (N'5YG7AZMLFA', N'Bruce', N'33', 2, 2, 2, 2, 0)
GO
INSERT [dbo].[UserLicense] ([Id], [UserId], [LicenseName], [StartEnd], [FileName]) VALUES (N'5XTM6SN9FA', N'U01', N'11ab', N'22', N'_green wall.jpg')
INSERT [dbo].[UserLicense] ([Id], [UserId], [LicenseName], [StartEnd], [FileName]) VALUES (N'5Y1MNT0KXA', N'U01', N'2', N'22', N'dog.jpg')
INSERT [dbo].[UserLicense] ([Id], [UserId], [LicenseName], [StartEnd], [FileName]) VALUES (N'5YG7AZMQ1A', N'Bruce', N'55', N'66', N'dog.jpg')
GO
INSERT [dbo].[UserSchool] ([Id], [UserId], [SchoolName], [SchoolDept], [SchoolType], [StartEnd], [Graduated]) VALUES (N'5XL9R3JE9A', N'U01', N'11', N'22', N'33', N'44', 1)
INSERT [dbo].[UserSchool] ([Id], [UserId], [SchoolName], [SchoolDept], [SchoolType], [StartEnd], [Graduated]) VALUES (N'5YG7AZMHCA', N'Bruce', N'22', N'33', N'55', N'66', 1)
GO
INSERT [dbo].[UserSkill] ([Id], [UserId], [SkillName], [SkillDesc], [Sort]) VALUES (N'5XLQHPB6KA', N'U01', N'11', N'22', 0)
INSERT [dbo].[UserSkill] ([Id], [UserId], [SkillName], [SkillDesc], [Sort]) VALUES (N'5YG7AZMS4A', N'Bruce', N'66', N'77', 0)
GO
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'AndOr', N'{A}', N'And', NULL, NULL, 1, N'Flow', N'括號for避開regular')
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'AndOr', N'{O}', N'Or', NULL, NULL, 2, N'Flow', NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'AuthRange', N'0', N'無', NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'AuthRange', N'1', N'個人', NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'AuthRange', N'2', N'部門', NULL, NULL, 3, NULL, NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'AuthRange', N'9', N'全部', NULL, NULL, 9, NULL, NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'FlowStatus', N'0', N'簽核中', NULL, NULL, 1, N'Flow', NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'FlowStatus', N'N', N'拒絶', NULL, NULL, 3, N'Flow', NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'FlowStatus', N'Y', N'同意', NULL, NULL, 2, N'Flow', NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'LangLevel', N'1', N'略懂', NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'LangLevel', N'2', N'普通', NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'LangLevel', N'3', N'精通', NULL, NULL, 3, NULL, NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'LeaveType', N'B', N'公假', NULL, NULL, 3, NULL, N'business')
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'LeaveType', N'P', N'事假', NULL, NULL, 2, NULL, N'private')
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'LeaveType', N'S', N'病假', NULL, NULL, 1, NULL, N'sick')
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'LineOp', N'eq', N'=', NULL, NULL, 1, N'Flow', NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'LineOp', N'ge', N'>=', NULL, NULL, 4, N'Flow', NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'LineOp', N'gt', N'>', NULL, NULL, 3, N'Flow', NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'LineOp', N'neq', N'!=', NULL, NULL, 2, N'Flow', NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'LineOp', N'se', N'<=', NULL, NULL, 6, N'Flow', NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'LineOp', N'st', N'<', NULL, NULL, 5, N'Flow', NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'Menu', N'CmsMsg', N'11.最新消息維護', NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'Menu', N'CustInput', N'9.自訂輸入欄位', NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'Menu', N'Leave', N'1.請假作業', NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'Menu', N'LeaveSign', N'2.待簽核假單', NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'Menu', N'User', N'5.用戶管理', NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'Menu', N'UserExt', N'8.用戶經歷維護', NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'Menu', N'UserImport', N'10.匯入用戶資料', NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'Menu', N'XpEasyRpt', N'12.簡單報表維護', NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'Menu', N'XpFlow', N'3.流程維護', NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'Menu', N'XpFlowSign', N'4.簽核資料查詢', NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'Menu', N'XpProg', N'7.功能維護', NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'Menu', N'XpRole', N'6.角色維護', NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'Menu', N'XpTranLog', N'13.異動記錄查詢', NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'NodeLimitType', N'1', N'不限制', NULL, NULL, 1, N'Flow', N'暫不使用')
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'NodeLimitType', N'2', N'立即執行', NULL, NULL, 2, N'Flow', N'暫不使用')
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'NodeLimitType', N'3', N'限制時間', NULL, NULL, 3, N'Flow', N'暫不使用')
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'NodeType', N'A', N'自動', NULL, NULL, 4, N'Flow', N'暫不使用')
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'NodeType', N'E', N'結束', NULL, NULL, 2, N'Flow', N'end')
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'NodeType', N'N', N'一般', NULL, NULL, 3, N'Flow', N'normal')
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'NodeType', N'S', N'開始', NULL, NULL, 1, N'Flow', N'start')
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'PassType', N'1', N'任一人簽核', NULL, NULL, 1, N'Flow', NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'PassType', N'C', N'達簽核人數', NULL, NULL, 2, N'Flow', N'count')
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'SignerType', N'DM', N'部門主管', NULL, NULL, 4, N'Flow', NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'SignerType', N'F', N'指定欄位', NULL, NULL, 2, N'Flow', NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'SignerType', N'U', N'指定用戶', NULL, NULL, 1, N'Flow', NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'SignerType', N'UM', N'用戶主管', NULL, NULL, 3, N'Flow', N'用戶部門主管')
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'SignStatus', N'0', N'未簽核', NULL, NULL, 1, N'Flow', NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'SignStatus', N'1', N'送出', NULL, NULL, 2, N'Flow', NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'SignStatus', N'N', N'拒絶', NULL, NULL, 4, N'Flow', NULL)
INSERT [dbo].[XpCode] ([Type], [Value], [Name_zhTW], [Name_zhCN], [Name_enUS], [Sort], [Ext], [Note]) VALUES (N'SignStatus', N'Y', N'同意', NULL, NULL, 3, N'Flow', NULL)
GO
INSERT [dbo].[XpFlow] ([Id], [Code], [Name], [Portrait], [Status]) VALUES (N'5ZM5H6ED1A', N'Leave', N'請假', 1, 1)
INSERT [dbo].[XpFlow] ([Id], [Code], [Name], [Portrait], [Status]) VALUES (N'5ZMDKNA0CA', N'Test1', N'測試1', 1, 1)
GO
INSERT [dbo].[XpFlowLine] ([Id], [FlowId], [StartNode], [EndNode], [CondStr], [Sort]) VALUES (N'5ZM8EBAEMA', N'5ZM5H6ED1A', N'5ZM5H6EFGA', N'5ZM5H6EGHA', N'', 9)
INSERT [dbo].[XpFlowLine] ([Id], [FlowId], [StartNode], [EndNode], [CondStr], [Sort]) VALUES (N'5ZM8EBAFJA', N'5ZM5H6ED1A', N'5ZM5H6EGHA', N'5ZM5H6EHCA', N'', 9)
INSERT [dbo].[XpFlowLine] ([Id], [FlowId], [StartNode], [EndNode], [CondStr], [Sort]) VALUES (N'5ZM8EBAGPA', N'5ZM5H6ED1A', N'5ZM5H6EHCA', N'5ZM5H6EJBA', N'Hours,ge,24', 1)
INSERT [dbo].[XpFlowLine] ([Id], [FlowId], [StartNode], [EndNode], [CondStr], [Sort]) VALUES (N'5ZM8EBAHJA', N'5ZM5H6ED1A', N'5ZM5H6EHCA', N'5ZM5H6EK3A', N'', 9)
INSERT [dbo].[XpFlowLine] ([Id], [FlowId], [StartNode], [EndNode], [CondStr], [Sort]) VALUES (N'5ZM8EBAJQA', N'5ZM5H6ED1A', N'5ZM5H6EJBA', N'5ZM5H6EK3A', N'', 9)
INSERT [dbo].[XpFlowLine] ([Id], [FlowId], [StartNode], [EndNode], [CondStr], [Sort]) VALUES (N'5ZMDKNA5PA', N'5ZMDKNA0CA', N'5ZMDKNA2VA', N'5ZMDKNA3LA', N'', 9)
INSERT [dbo].[XpFlowLine] ([Id], [FlowId], [StartNode], [EndNode], [CondStr], [Sort]) VALUES (N'5ZMDKNA6NA', N'5ZMDKNA0CA', N'5ZMDKNA3LA', N'5ZMDKNA4HA', N'', 9)
GO
INSERT [dbo].[XpFlowNode] ([Id], [FlowId], [Name], [NodeType], [PosX], [PosY], [SignerType], [SignerValue], [PassType], [PassNum]) VALUES (N'5ZM5H6EFGA', N'5ZM5H6ED1A', N'Start', N'S', 450, 30, N'', N'', N'0', NULL)
INSERT [dbo].[XpFlowNode] ([Id], [FlowId], [Name], [NodeType], [PosX], [PosY], [SignerType], [SignerValue], [PassType], [PassNum]) VALUES (N'5ZM5H6EGHA', N'5ZM5H6ED1A', N'代理人', N'N', 410, 140, N'F', N'AgentId', N'0', NULL)
INSERT [dbo].[XpFlowNode] ([Id], [FlowId], [Name], [NodeType], [PosX], [PosY], [SignerType], [SignerValue], [PassType], [PassNum]) VALUES (N'5ZM5H6EHCA', N'5ZM5H6ED1A', N'主管', N'N', 450, 250, N'UM', N'', N'0', NULL)
INSERT [dbo].[XpFlowNode] ([Id], [FlowId], [Name], [NodeType], [PosX], [PosY], [SignerType], [SignerValue], [PassType], [PassNum]) VALUES (N'5ZM5H6EJBA', N'5ZM5H6ED1A', N'總經理', N'N', 540, 340, N'DM', N'GM', N'0', NULL)
INSERT [dbo].[XpFlowNode] ([Id], [FlowId], [Name], [NodeType], [PosX], [PosY], [SignerType], [SignerValue], [PassType], [PassNum]) VALUES (N'5ZM5H6EK3A', N'5ZM5H6ED1A', N'E', N'E', 410, 400, N'', N'', N'0', NULL)
INSERT [dbo].[XpFlowNode] ([Id], [FlowId], [Name], [NodeType], [PosX], [PosY], [SignerType], [SignerValue], [PassType], [PassNum]) VALUES (N'5ZMDKNA2VA', N'5ZMDKNA0CA', N'Start', N'S', 390, 70, N'', N'', N'0', NULL)
INSERT [dbo].[XpFlowNode] ([Id], [FlowId], [Name], [NodeType], [PosX], [PosY], [SignerType], [SignerValue], [PassType], [PassNum]) VALUES (N'5ZMDKNA3LA', N'5ZMDKNA0CA', N'Node', N'N', 370, 180, N'', N'', N'0', NULL)
INSERT [dbo].[XpFlowNode] ([Id], [FlowId], [Name], [NodeType], [PosX], [PosY], [SignerType], [SignerValue], [PassType], [PassNum]) VALUES (N'5ZMDKNA4HA', N'5ZMDKNA0CA', N'E', N'E', 410, 280, N'', N'', N'0', NULL)
GO
INSERT [dbo].[XpFlowSign] ([Id], [FlowId], [SourceId], [NodeName], [FlowLevel], [TotalLevel], [SignerId], [SignerName], [SignStatus], [SignTime], [Note]) VALUES (N'5ZMJQQQZZA', N'5ZM5H6ED1A', N'5ZMJQQQBYA', N'Start', 0, 2, N'Alex', N'Alex Chen', N'1', CAST(N'2021-03-07T22:19:00.860' AS DateTime), NULL)
INSERT [dbo].[XpFlowSign] ([Id], [FlowId], [SourceId], [NodeName], [FlowLevel], [TotalLevel], [SignerId], [SignerName], [SignStatus], [SignTime], [Note]) VALUES (N'5ZMJQQR6KA', N'5ZM5H6ED1A', N'5ZMJQQQBYA', N'代理人', 1, 2, N'Nick', N'Nick Wang', N'Y', CAST(N'2021-03-07T22:20:10.060' AS DateTime), NULL)
INSERT [dbo].[XpFlowSign] ([Id], [FlowId], [SourceId], [NodeName], [FlowLevel], [TotalLevel], [SignerId], [SignerName], [SignStatus], [SignTime], [Note]) VALUES (N'5ZMJQQRBCA', N'5ZM5H6ED1A', N'5ZMJQQQBYA', N'主管', 2, 2, N'Nick', N'Nick Wang', N'Y', CAST(N'2021-03-07T22:20:28.310' AS DateTime), NULL)
GO
INSERT [dbo].[XpProg] ([Id], [Code], [Name], [Icon], [Url], [Sort], [AuthRow], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'CmsMsg', N'CmsMsg', N'CmsMsg', NULL, N'/CmsMsg/Read', 11, 0, 1, 1, 1, 1, 0, 0, 1, 0)
INSERT [dbo].[XpProg] ([Id], [Code], [Name], [Icon], [Url], [Sort], [AuthRow], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'CustInput', N'CustInput', N'CustInput', NULL, N'/CustInput/Read', 9, 0, 1, 1, 1, 1, 0, 0, 1, 0)
INSERT [dbo].[XpProg] ([Id], [Code], [Name], [Icon], [Url], [Sort], [AuthRow], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'Leave', N'Leave', N'Leave', NULL, N'/Leave/Read', 1, 1, 1, 1, 1, 1, 0, 0, 1, 0)
INSERT [dbo].[XpProg] ([Id], [Code], [Name], [Icon], [Url], [Sort], [AuthRow], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'LeaveSign', N'LeaveSign', N'LeaveSign', NULL, N'/LeaveSign/Read', 2, 1, 0, 1, 1, 0, 0, 0, 1, 0)
INSERT [dbo].[XpProg] ([Id], [Code], [Name], [Icon], [Url], [Sort], [AuthRow], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'TranLog', N'TranLog', N'TranLog', NULL, N'/TranLog/Read', 13, 0, 1, 1, 1, 1, 0, 0, 1, 0)
INSERT [dbo].[XpProg] ([Id], [Code], [Name], [Icon], [Url], [Sort], [AuthRow], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'User', N'User', N'User', NULL, N'/User/Read', 5, 0, 1, 1, 1, 1, 0, 0, 1, 0)
INSERT [dbo].[XpProg] ([Id], [Code], [Name], [Icon], [Url], [Sort], [AuthRow], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'UserExt', N'UserExt', N'UserExt', NULL, N'/UserExt/Read', 8, 0, 1, 1, 1, 1, 0, 0, 1, 0)
INSERT [dbo].[XpProg] ([Id], [Code], [Name], [Icon], [Url], [Sort], [AuthRow], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'UserImport', N'UserImport', N'UserImport', NULL, N'/UserImport/Read', 10, 0, 1, 1, 1, 1, 0, 0, 1, 0)
INSERT [dbo].[XpProg] ([Id], [Code], [Name], [Icon], [Url], [Sort], [AuthRow], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'XpEasyRpt', N'XpEasyRpt', N'XpEasyRpt', NULL, N'/XpEasyRpt/Read', 12, 0, 1, 1, 1, 1, 0, 0, 1, 0)
INSERT [dbo].[XpProg] ([Id], [Code], [Name], [Icon], [Url], [Sort], [AuthRow], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'XpFlow', N'XpFlow', N'XpFlow', NULL, N'/XpFlow/Read', 3, 0, 1, 1, 1, 1, 0, 0, 0, 0)
INSERT [dbo].[XpProg] ([Id], [Code], [Name], [Icon], [Url], [Sort], [AuthRow], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'XpFlowSign', N'XpFlowSign', N'XpFlowSign', NULL, N'/XpFlowSign/Read', 4, 1, 0, 1, 0, 0, 0, 0, 1, 0)
INSERT [dbo].[XpProg] ([Id], [Code], [Name], [Icon], [Url], [Sort], [AuthRow], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'XpProg', N'XpProg', N'XpProg', NULL, N'/XpProg/Read', 7, 0, 1, 1, 1, 1, 0, 0, 1, 0)
INSERT [dbo].[XpProg] ([Id], [Code], [Name], [Icon], [Url], [Sort], [AuthRow], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'XpRole', N'XpRole', N'XpRole', NULL, N'/XpRole/Read', 6, 0, 1, 1, 1, 1, 0, 0, 1, 0)
GO
INSERT [dbo].[XpRole] ([Id], [Name]) VALUES (N'Adm', N'管理者')
INSERT [dbo].[XpRole] ([Id], [Name]) VALUES (N'All', N'所有人員')
INSERT [dbo].[XpRole] ([Id], [Name]) VALUES (N'D57A8Z8R7A', N'部門主管')
GO
INSERT [dbo].[XpRoleProg] ([Id], [RoleId], [ProgId], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'A01', N'Adm', N'User', 1, 1, 1, 1, 1, 1, 1, 1)
INSERT [dbo].[XpRoleProg] ([Id], [RoleId], [ProgId], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'A02', N'Adm', N'XpRole', 1, 1, 1, 1, 1, 1, 1, 1)
INSERT [dbo].[XpRoleProg] ([Id], [RoleId], [ProgId], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'A03', N'Adm', N'XpProg', 1, 1, 1, 1, 1, 1, 1, 1)
INSERT [dbo].[XpRoleProg] ([Id], [RoleId], [ProgId], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'D58A7JDDQA', N'All', N'Leave', 1, 1, 1, 1, 1, 1, 1, 0)
INSERT [dbo].[XpRoleProg] ([Id], [RoleId], [ProgId], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'D58A7JDJ9A', N'All', N'LeaveSign', 0, 1, 1, 0, 0, 0, 1, 0)
INSERT [dbo].[XpRoleProg] ([Id], [RoleId], [ProgId], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'D58A7JDU6A', N'All', N'XpFlowSign', 0, 1, 0, 0, 0, 0, 1, 0)
INSERT [dbo].[XpRoleProg] ([Id], [RoleId], [ProgId], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'D58A7JE9EA', N'All', N'CustInput', 1, 1, 1, 1, 0, 0, 1, 0)
INSERT [dbo].[XpRoleProg] ([Id], [RoleId], [ProgId], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'D58A7JERTA', N'All', N'CmsMsg', 1, 1, 1, 1, 0, 0, 1, 0)
INSERT [dbo].[XpRoleProg] ([Id], [RoleId], [ProgId], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'D58A7JEVVA', N'All', N'XpEasyRpt', 1, 1, 1, 1, 0, 0, 1, 0)
INSERT [dbo].[XpRoleProg] ([Id], [RoleId], [ProgId], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'D58AUNJ8LA', N'D57A8Z8R7A', N'Leave', 0, 2, 0, 0, 0, 2, 0, 0)
INSERT [dbo].[XpRoleProg] ([Id], [RoleId], [ProgId], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'D58AUNJP2A', N'D57A8Z8R7A', N'LeaveSign', 0, 2, 0, 0, 0, 2, 0, 0)
INSERT [dbo].[XpRoleProg] ([Id], [RoleId], [ProgId], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'D58AUNK5DA', N'D57A8Z8R7A', N'XpFlowSign', 0, 2, 0, 0, 0, 2, 0, 0)
INSERT [dbo].[XpRoleProg] ([Id], [RoleId], [ProgId], [FunCreate], [FunRead], [FunUpdate], [FunDelete], [FunPrint], [FunExport], [FunView], [FunOther]) VALUES (N'D58AWMKYTA', N'Adm', N'XpFlow', 1, 1, 1, 1, 1, 1, 1, 0)
GO
INSERT [dbo].[XpUserRole] ([Id], [UserId], [RoleId]) VALUES (N'A01', N'Bruce', N'Adm')
INSERT [dbo].[XpUserRole] ([Id], [UserId], [RoleId]) VALUES (N'D56N9NW7WA', N'Peter', N'Adm')
INSERT [dbo].[XpUserRole] ([Id], [UserId], [RoleId]) VALUES (N'D57A8Z97UA', N'Nick', N'D57A8Z8R7A')
INSERT [dbo].[XpUserRole] ([Id], [UserId], [RoleId]) VALUES (N'D58BCT5HDA', N'Alex', N'All')
INSERT [dbo].[XpUserRole] ([Id], [UserId], [RoleId]) VALUES (N'D58BCT5Z1A', N'Nick', N'All')
INSERT [dbo].[XpUserRole] ([Id], [UserId], [RoleId]) VALUES (N'D58BCT6GNA', N'Peter', N'All')
GO
ALTER TABLE [dbo].[UserJob] ADD  CONSTRAINT [DF_UserJob_CorpUsers]  DEFAULT ((0)) FOR [CorpUsers]
GO
ALTER TABLE [dbo].[XpProg] ADD  CONSTRAINT [DF_XpProg_AuthRow]  DEFAULT ((0)) FOR [AuthRow]
GO
ALTER TABLE [dbo].[XpProg] ADD  CONSTRAINT [DF_XpProg_FunCreate]  DEFAULT ((0)) FOR [FunCreate]
GO
ALTER TABLE [dbo].[XpProg] ADD  CONSTRAINT [DF_XpProg_FunRead]  DEFAULT ((0)) FOR [FunRead]
GO
ALTER TABLE [dbo].[XpProg] ADD  CONSTRAINT [DF_XpProg_FunUpdate]  DEFAULT ((0)) FOR [FunUpdate]
GO
ALTER TABLE [dbo].[XpProg] ADD  CONSTRAINT [DF_XpProg_FunDelete]  DEFAULT ((0)) FOR [FunDelete]
GO
ALTER TABLE [dbo].[XpProg] ADD  CONSTRAINT [DF_XpProg_FunPrint]  DEFAULT ((0)) FOR [FunPrint]
GO
ALTER TABLE [dbo].[XpProg] ADD  CONSTRAINT [DF_XpProg_FunExport]  DEFAULT ((0)) FOR [FunExport]
GO
ALTER TABLE [dbo].[XpProg] ADD  CONSTRAINT [DF_XpProg_FunView]  DEFAULT ((0)) FOR [FunView]
GO
ALTER TABLE [dbo].[XpProg] ADD  CONSTRAINT [DF_XpProg_FunOther]  DEFAULT ((0)) FOR [FunOther]
GO
ALTER TABLE [dbo].[XpRoleProg] ADD  CONSTRAINT [DF_XpRoleProg_FunCreate]  DEFAULT ((0)) FOR [FunCreate]
GO
ALTER TABLE [dbo].[XpRoleProg] ADD  CONSTRAINT [DF_XpRoleProg_FunRead]  DEFAULT ((0)) FOR [FunRead]
GO
ALTER TABLE [dbo].[XpRoleProg] ADD  CONSTRAINT [DF_XpRoleProg_FunUpdate]  DEFAULT ((0)) FOR [FunUpdate]
GO
ALTER TABLE [dbo].[XpRoleProg] ADD  CONSTRAINT [DF_XpRoleProg_FunDelete]  DEFAULT ((0)) FOR [FunDelete]
GO
ALTER TABLE [dbo].[XpRoleProg] ADD  CONSTRAINT [DF_XpRoleProg_FunPrint]  DEFAULT ((0)) FOR [FunPrint]
GO
ALTER TABLE [dbo].[XpRoleProg] ADD  CONSTRAINT [DF_XpRoleProg_FunExport]  DEFAULT ((0)) FOR [FunExport]
GO
ALTER TABLE [dbo].[XpRoleProg] ADD  CONSTRAINT [DF_XpRoleProg_FunView]  DEFAULT ((0)) FOR [FunView]
GO
ALTER TABLE [dbo].[XpRoleProg] ADD  CONSTRAINT [DF_XpRoleProg_FunOther]  DEFAULT ((0)) FOR [FunOther]
GO
USE [master]
GO
ALTER DATABASE [Hr] SET  READ_WRITE 
GO
