USE [master]
GO
/****** Object:  Database [SchoolDb2]    Script Date: 10/16/2024 7:27:07 PM ******/
CREATE DATABASE [SchoolDb2]
-- CONTAINMENT = NONE
-- ON  PRIMARY 
--( NAME = N'SchoolDb2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SchoolDb2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
-- LOG ON 
--( NAME = N'SchoolDb2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SchoolDb2_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
-- WITH CATALOG_COLLATION = DATABASE_DEFAULT
--GO
--ALTER DATABASE [SchoolDb2] SET COMPATIBILITY_LEVEL = 150
--GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SchoolDb2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SchoolDb2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SchoolDb2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SchoolDb2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SchoolDb2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SchoolDb2] SET ARITHABORT OFF 
GO
ALTER DATABASE [SchoolDb2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SchoolDb2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SchoolDb2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SchoolDb2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SchoolDb2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SchoolDb2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SchoolDb2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SchoolDb2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SchoolDb2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SchoolDb2] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SchoolDb2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SchoolDb2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SchoolDb2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SchoolDb2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SchoolDb2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SchoolDb2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SchoolDb2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SchoolDb2] SET RECOVERY FULL 
GO
ALTER DATABASE [SchoolDb2] SET  MULTI_USER 
GO
ALTER DATABASE [SchoolDb2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SchoolDb2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SchoolDb2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SchoolDb2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SchoolDb2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SchoolDb2] SET QUERY_STORE = OFF
GO
USE [SchoolDb2]
GO
/****** Object:  UserDefinedFunction [dbo].[CheckExistsMobileNumber]    Script Date: 10/16/2024 7:27:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[CheckExistsMobileNumber](@MobileNumber char(11))
returns bit
begin
	if(exists(select Mobile from Tbl_Student where Mobile = @MobileNumber))
		return 1
	return 0
end

GO
/****** Object:  Table [dbo].[Tbl_Error]    Script Date: 10/16/2024 7:27:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Error](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ErrorText] [nvarchar](4000) NOT NULL,
	[ErrorTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Tbl_Error] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Lesson]    Script Date: 10/16/2024 7:27:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Lesson](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[ss] [nvarchar](50) NOT NULL,
	[PcName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tbl_Lesson] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Log]    Script Date: 10/16/2024 7:27:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Log](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tbl_Log] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Register]    Script Date: 10/16/2024 7:27:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Register](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LessonId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[Score] [int] NOT NULL,
 CONSTRAINT [PK_Tbl_StudentLesson] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Student]    Script Date: 10/16/2024 7:27:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Student](
	[Id] [int] IDENTITY(14010,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[NationalCode] [char](10) NULL,
	[Mobile] [char](11) NULL,
	[RegisterDate] [datetime2](3) NOT NULL,
	[BirthDate] [datetime] NULL,
 CONSTRAINT [PK_Tbl_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_Error] ON 

INSERT [dbo].[Tbl_Error] ([Id], [ErrorText], [ErrorTime]) VALUES (1003, N'Procedure or function ''SelectStudents'' expects parameter ''@Search'', which was not supplied.', CAST(N'2024-09-26T09:13:57.577' AS DateTime))
INSERT [dbo].[Tbl_Error] ([Id], [ErrorText], [ErrorTime]) VALUES (1004, N'System.Data.SqlClient.SqlException (0x80131904): Procedure or function ''SelectStudents'' expects parameter ''@Search'', which was not supplied.
   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   at System.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   at System.Data.SqlClient.SqlDataReader.get_MetaData()
   at System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption, Boolean shouldCacheForAlwaysEncrypted)
   at System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   at System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   at System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   at System.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior, String method)
   at System.Data.SqlClient.SqlCommand.ExecuteDbDataReader(CommandBehavior behavior)
   at System.Data.Common.DbCommand.System.Data.IDbCommand.ExecuteReader(CommandBehavior behavior)
   at System.Data.Common.DbDataAdapter.FillInternal(DataSet dataset, DataTable[] datatables, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior)
   at System.Data.Common.DbDataAdapter.Fill(DataTable[] dataTables, Int32 startRecord, Int32 maxRecords, IDbCommand command, CommandBehavior behavior)
   at System.Data.Common.DbDataAdapter.Fill(DataTable dataTable)
   at Schoool.FrmStudents.GetData() in C:\Users\novinsystem\Desktop\Schoool\Schoool\FrmStudents.cs:line 45
ClientConnectionId:6f07deed-9153-4045-ab3b-75a95ab0a8ae
Error Number:201,State:4,Class:16--0', CAST(N'2024-09-26T09:17:45.270' AS DateTime))
SET IDENTITY_INSERT [dbo].[Tbl_Error] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Lesson] ON 

INSERT [dbo].[Tbl_Lesson] ([Id], [Title], [ss], [PcName]) VALUES (64, N't', N'hello     ', N'PCA0')
INSERT [dbo].[Tbl_Lesson] ([Id], [Title], [ss], [PcName]) VALUES (65, N'ss', N'ddd       ', N'xx')
INSERT [dbo].[Tbl_Lesson] ([Id], [Title], [ss], [PcName]) VALUES (68, N'tfh', N'3/12/2023 7:17:34 PM', N'PCA0')
INSERT [dbo].[Tbl_Lesson] ([Id], [Title], [ss], [PcName]) VALUES (69, N'zzzz', N'3/12/2023 7:17:57 PM', N'PCA0')
INSERT [dbo].[Tbl_Lesson] ([Id], [Title], [ss], [PcName]) VALUES (70, N'uuu', N'3/12/2023 7:18:21 PM', N'PCA0')
INSERT [dbo].[Tbl_Lesson] ([Id], [Title], [ss], [PcName]) VALUES (71, N'سلام', N'21/12/1401 07:20:25 ب.ظ', N'PCA2')
INSERT [dbo].[Tbl_Lesson] ([Id], [Title], [ss], [PcName]) VALUES (72, N'سلام', N'21/12/1401 07:20:35 ب.ظ', N'PCA2')
INSERT [dbo].[Tbl_Lesson] ([Id], [Title], [ss], [PcName]) VALUES (73, N'سلام', N'21/12/1401 07:20:48 ب.ظ', N'PCA6')
INSERT [dbo].[Tbl_Lesson] ([Id], [Title], [ss], [PcName]) VALUES (74, N'اسما', N'21/12/1401 07:19:12 ب.ظ', N'PCA4')
INSERT [dbo].[Tbl_Lesson] ([Id], [Title], [ss], [PcName]) VALUES (75, N'ghgh', N'21/12/1401 07:20:40 ب.ظ', N'PCA2')
INSERT [dbo].[Tbl_Lesson] ([Id], [Title], [ss], [PcName]) VALUES (76, N'صلوات', N'21/12/1401 07:20:50 ب.ظ', N'PCA8')
INSERT [dbo].[Tbl_Lesson] ([Id], [Title], [ss], [PcName]) VALUES (77, N'منم خوبم', N'21/12/1401 07:20:58 ب.ظ', N'PCA6')
INSERT [dbo].[Tbl_Lesson] ([Id], [Title], [ss], [PcName]) VALUES (78, N'ااا', N'21/12/1401 07:19:22 ب.ظ', N'PCA4')
INSERT [dbo].[Tbl_Lesson] ([Id], [Title], [ss], [PcName]) VALUES (79, N'سلام', N'21/12/1401 07:20:43 ب.ظ', N'PCA7')
INSERT [dbo].[Tbl_Lesson] ([Id], [Title], [ss], [PcName]) VALUES (80, N'cccc', N'3/12/2023 7:34:05 PM', N'PCA0')
INSERT [dbo].[Tbl_Lesson] ([Id], [Title], [ss], [PcName]) VALUES (81, N'tyy', N'3/12/2023 7:35:23 PM', N'PCA0')
INSERT [dbo].[Tbl_Lesson] ([Id], [Title], [ss], [PcName]) VALUES (82, N'خوبه', N'21/12/1401 07:54:53 ب.ظ', N'PCA8')
INSERT [dbo].[Tbl_Lesson] ([Id], [Title], [ss], [PcName]) VALUES (83, N'اش', N'21/12/1401 07:54:44 ب.ظ', N'PCA7')
INSERT [dbo].[Tbl_Lesson] ([Id], [Title], [ss], [PcName]) VALUES (84, N'سسس', N'21/12/1401 07:54:48 ب.ظ', N'PCA7')
INSERT [dbo].[Tbl_Lesson] ([Id], [Title], [ss], [PcName]) VALUES (85, N'خوبه', N'21/12/1401 07:55:02 ب.ظ', N'PCA8')
INSERT [dbo].[Tbl_Lesson] ([Id], [Title], [ss], [PcName]) VALUES (86, N'رحمان چطوری', N'21/12/1401 07:55:14 ب.ظ', N'PCA6')
INSERT [dbo].[Tbl_Lesson] ([Id], [Title], [ss], [PcName]) VALUES (87, N'سس', N'21/12/1401 07:55:12 ب.ظ', N'PCA7')
INSERT [dbo].[Tbl_Lesson] ([Id], [Title], [ss], [PcName]) VALUES (88, N'ارتتک تتک ', N'21/12/1401 07:55:35 ب.ظ', N'PCA8')
INSERT [dbo].[Tbl_Lesson] ([Id], [Title], [ss], [PcName]) VALUES (89, N'یه دل میگه ', N'21/12/1401 07:55:48 ب.ظ', N'PCA6')
INSERT [dbo].[Tbl_Lesson] ([Id], [Title], [ss], [PcName]) VALUES (90, N'غفور غفور ', N'21/12/1401 07:55:42 ب.ظ', N'PCA8')
INSERT [dbo].[Tbl_Lesson] ([Id], [Title], [ss], [PcName]) VALUES (91, N'دوستان خسته نباشید', N'21/12/1401 07:56:03 ب.ظ', N'PCA6')
INSERT [dbo].[Tbl_Lesson] ([Id], [Title], [ss], [PcName]) VALUES (92, N'ee', N'21/12/1401 07:57:55 ب.ظ', N'PCA7')
INSERT [dbo].[Tbl_Lesson] ([Id], [Title], [ss], [PcName]) VALUES (93, N'ggg', N'21/12/1401 07:59:08 ب.ظ', N'PCA0')
INSERT [dbo].[Tbl_Lesson] ([Id], [Title], [ss], [PcName]) VALUES (94, N'چه خبر', N'21/12/1401 07:59:37 ب.ظ', N'PCA0')
SET IDENTITY_INSERT [dbo].[Tbl_Lesson] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Log] ON 

INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (1, N'1')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (2, N'farsi')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (3, N'math')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (4, N'before : mathafter : shimi')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (5, N'ریاضی deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (6, N'ddd')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (7, N'ddd')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (8, N'fff')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (9, N'fff')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (10, N'fff')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (11, N'fff')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (12, N'zzz')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (13, N'213213466')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (14, N'AliJafari')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (15, N'عارفه')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (16, N'WHO AM I')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (17, N'vahid bagherzadeh')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (18, N'رجای')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (19, N'جعفر زاده')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (20, N'ح')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (21, N'11111')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (22, N'F')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (23, N'111')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (24, N'ذیلایی')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (25, N'111')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (26, N'salam khobi?')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (27, N'D')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (28, N'حیدری')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (29, N'سلام')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (30, N'rahman1400')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (31, N'shemiran')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (32, N'مهندس خواجه')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (33, N'اقای رجایی!!!!')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (34, N'خوشخوان')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (35, N'ا')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (36, N'باقر بیشی')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (37, N'11228')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (38, N'تلاش کن')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (39, N'ارتتک تتک تتک')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (41, N'غفور غفور')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (42, N'111')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (43, N'خوبه')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (44, N'چی میخوری')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (45, N'زاهدی')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (46, N'چیپس میخوری')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (47, N'استراحت   هورااااااااااا')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (48, N'یه دل میگه برم برم')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (49, N'ب')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (50, N'یه دلم میگه نرم نرم ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (51, N'وازی وازی')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (52, N'ss')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (53, N'ss deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (54, N'وازی وازی deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (55, N'یه دلم میگه نرم نرم  deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (56, N'ب deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (57, N'یه دل میگه برم برم deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (58, N'استراحت   هورااااااااااا deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (59, N'چیپس میخوری deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (60, N'زاهدی deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (61, N'چی میخوری deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (62, N'خوبه deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (63, N'111 deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (64, N'غفور غفور deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (65, N'پای تو گیرممممم deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (66, N'ارتتک تتک تتک deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (67, N'تلاش کن deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (68, N'11228 deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (69, N'باقر بیشی deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (70, N'ا deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (71, N'خوشخوان deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (72, N'اقای رجایی!!!! deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (73, N'مهندس خواجه deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (74, N'shemiran deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (75, N'rahman1400 deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (76, N'سلام deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (77, N'حیدری deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (78, N'D deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (79, N'salam khobi? deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (80, N'111 deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (81, N'ذیلایی deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (82, N'111 deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (83, N'F deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (84, N'11111 deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (85, N'ح deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (86, N'جعفر زاده deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (87, N'رجای deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (88, N'vahid bagherzadeh deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (89, N'WHO AM I deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (90, N'عارفه deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (91, N'AliJafari deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (92, N'213213466 deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (93, N'zzz deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (94, N'fff deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (95, N'fff deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (96, N'fff deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (97, N'fff deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (98, N'ddd deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (99, N'ddd deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (100, N'shimi deleted ')
GO
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (101, N'farsi deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (102, N'arabi deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (103, N'عربی deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (104, N'فارسی deleted ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (105, N't')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (106, N'ss')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (109, N'tfh')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (110, N'zzzz')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (111, N'uuu')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (112, N'سلام')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (113, N'سلام')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (114, N'سلام')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (115, N'اسما')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (116, N'ghgh')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (117, N'صلوات')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (118, N'منم خوبم')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (119, N'ااا')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (120, N'سلام')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (121, N'cccc')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (122, N'tyy')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (123, N'خوبه')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (124, N'اش')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (125, N'سسس')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (126, N'خوبه')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (127, N'رحمان چطوری')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (128, N'سس')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (129, N'ارتتک تتک ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (130, N'یه دل میگه ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (131, N'غفور غفور ')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (132, N'دوستان خسته نباشید')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (133, N'ee')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (134, N'ggg')
INSERT [dbo].[Tbl_Log] ([Id], [Text]) VALUES (135, N'چه خبر')
SET IDENTITY_INSERT [dbo].[Tbl_Log] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Student] ON 

INSERT [dbo].[Tbl_Student] ([Id], [FirstName], [LastName], [NationalCode], [Mobile], [RegisterDate], [BirthDate]) VALUES (15118, N'سجاد', N'خواجه', N'116       ', N'0913       ', CAST(N'2023-01-15T16:54:06.6770000' AS DateTime2), CAST(N'2023-01-15T16:54:06.677' AS DateTime))
INSERT [dbo].[Tbl_Student] ([Id], [FirstName], [LastName], [NationalCode], [Mobile], [RegisterDate], [BirthDate]) VALUES (15119, N'علی', N'علوی', N'669       ', N'0912       ', CAST(N'2023-01-15T16:54:16.9970000' AS DateTime2), CAST(N'2023-01-15T16:54:16.997' AS DateTime))
INSERT [dbo].[Tbl_Student] ([Id], [FirstName], [LastName], [NationalCode], [Mobile], [RegisterDate], [BirthDate]) VALUES (15120, N'حسن', N'حسنی', N'116       ', N'0913       ', CAST(N'2023-01-15T16:54:06.6770000' AS DateTime2), CAST(N'2023-01-15T16:54:06.677' AS DateTime))
INSERT [dbo].[Tbl_Student] ([Id], [FirstName], [LastName], [NationalCode], [Mobile], [RegisterDate], [BirthDate]) VALUES (15121, N'حسین', N'حسینی', N'669       ', N'0912       ', CAST(N'2023-01-15T16:54:16.9970000' AS DateTime2), CAST(N'2023-01-15T16:54:16.997' AS DateTime))
INSERT [dbo].[Tbl_Student] ([Id], [FirstName], [LastName], [NationalCode], [Mobile], [RegisterDate], [BirthDate]) VALUES (15122, N'رحمان', N'حسین زاده', N'116       ', N'0913       ', CAST(N'2023-01-15T16:54:06.6770000' AS DateTime2), CAST(N'2023-01-15T16:54:06.677' AS DateTime))
INSERT [dbo].[Tbl_Student] ([Id], [FirstName], [LastName], [NationalCode], [Mobile], [RegisterDate], [BirthDate]) VALUES (15123, N'وحید', N'باقرزاده', N'669       ', N'0912       ', CAST(N'2023-01-15T16:54:16.9970000' AS DateTime2), CAST(N'2023-01-15T16:54:16.997' AS DateTime))
INSERT [dbo].[Tbl_Student] ([Id], [FirstName], [LastName], [NationalCode], [Mobile], [RegisterDate], [BirthDate]) VALUES (15124, N'ali', N'alavi', NULL, N'0912       ', CAST(N'2024-09-26T10:51:18.3970000' AS DateTime2), CAST(N'2024-09-26T10:51:18.397' AS DateTime))
INSERT [dbo].[Tbl_Student] ([Id], [FirstName], [LastName], [NationalCode], [Mobile], [RegisterDate], [BirthDate]) VALUES (15125, N'ali', N'alavi', NULL, N'0912       ', CAST(N'2024-10-10T09:17:09.9330000' AS DateTime2), CAST(N'2024-10-10T09:17:09.933' AS DateTime))
INSERT [dbo].[Tbl_Student] ([Id], [FirstName], [LastName], [NationalCode], [Mobile], [RegisterDate], [BirthDate]) VALUES (15126, N'rsdgt', N'srdgv', NULL, N'srgbf      ', CAST(N'2024-10-10T09:17:17.0430000' AS DateTime2), CAST(N'2024-10-10T09:17:17.043' AS DateTime))
INSERT [dbo].[Tbl_Student] ([Id], [FirstName], [LastName], [NationalCode], [Mobile], [RegisterDate], [BirthDate]) VALUES (15127, N'rsdgt', N'srdgv', NULL, N'srgbf      ', CAST(N'2024-10-10T09:17:23.1770000' AS DateTime2), CAST(N'2024-10-10T09:17:23.177' AS DateTime))
INSERT [dbo].[Tbl_Student] ([Id], [FirstName], [LastName], [NationalCode], [Mobile], [RegisterDate], [BirthDate]) VALUES (15128, N'rsdgt', N'srdgv', NULL, N'srgbf      ', CAST(N'2024-10-10T09:17:24.5800000' AS DateTime2), CAST(N'2024-10-10T09:17:24.580' AS DateTime))
INSERT [dbo].[Tbl_Student] ([Id], [FirstName], [LastName], [NationalCode], [Mobile], [RegisterDate], [BirthDate]) VALUES (15129, N'rsdgt', N'srdgv', NULL, N'srgbf      ', CAST(N'2024-10-10T09:17:24.7200000' AS DateTime2), CAST(N'2024-10-10T09:17:24.720' AS DateTime))
INSERT [dbo].[Tbl_Student] ([Id], [FirstName], [LastName], [NationalCode], [Mobile], [RegisterDate], [BirthDate]) VALUES (15130, N'ali', N'alavi', NULL, N'0912       ', CAST(N'2024-10-10T09:23:09.1670000' AS DateTime2), CAST(N'2024-10-10T09:23:09.167' AS DateTime))
INSERT [dbo].[Tbl_Student] ([Id], [FirstName], [LastName], [NationalCode], [Mobile], [RegisterDate], [BirthDate]) VALUES (15131, N'ali', N'alavi', NULL, N'0912       ', CAST(N'2024-10-10T10:40:42.4070000' AS DateTime2), CAST(N'2024-10-10T10:40:42.407' AS DateTime))
INSERT [dbo].[Tbl_Student] ([Id], [FirstName], [LastName], [NationalCode], [Mobile], [RegisterDate], [BirthDate]) VALUES (15132, N'sxcfad', N'saefaef', NULL, N'sefseaesfc ', CAST(N'2024-10-10T10:44:10.6630000' AS DateTime2), CAST(N'2024-10-10T10:44:10.663' AS DateTime))
INSERT [dbo].[Tbl_Student] ([Id], [FirstName], [LastName], [NationalCode], [Mobile], [RegisterDate], [BirthDate]) VALUES (15133, N'sxcfad', N'saefaef', NULL, N'09132      ', CAST(N'2024-10-10T10:44:34.8300000' AS DateTime2), CAST(N'2024-10-10T10:44:34.830' AS DateTime))
SET IDENTITY_INSERT [dbo].[Tbl_Student] OFF
GO
ALTER TABLE [dbo].[Tbl_Error] ADD  CONSTRAINT [DF_Tbl_Error_ErrorTime]  DEFAULT (getdate()) FOR [ErrorTime]
GO
ALTER TABLE [dbo].[Tbl_Student] ADD  CONSTRAINT [DF_Tbl_Student_RegisterDate]  DEFAULT (getdate()) FOR [RegisterDate]
GO
ALTER TABLE [dbo].[Tbl_Student] ADD  CONSTRAINT [DF_Tbl_Student_BirthDate]  DEFAULT (getdate()) FOR [BirthDate]
GO
ALTER TABLE [dbo].[Tbl_Register]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Register_Tbl_Lesson] FOREIGN KEY([LessonId])
REFERENCES [dbo].[Tbl_Lesson] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tbl_Register] CHECK CONSTRAINT [FK_Tbl_Register_Tbl_Lesson]
GO
ALTER TABLE [dbo].[Tbl_Register]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Register_Tbl_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Tbl_Student] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tbl_Register] CHECK CONSTRAINT [FK_Tbl_Register_Tbl_Student]
GO
/****** Object:  StoredProcedure [dbo].[AddError]    Script Date: 10/16/2024 7:27:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AddError]
@ErrorText nvarchar(4000)
as
insert into Tbl_Error select @ErrorText,getdate()


GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 10/16/2024 7:27:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AddUser]
@fn nvarchar(50),
@ln nvarchar(50),
@nc char(10),
@mo char(11),
@rd datetime,
@bd datetime
as
insert into tbl_student([FirstName],[LastName],[NationalCode],[Mobile],
[RegisterDate],[BirthDate]) 
	values(@fn,@ln,@nc,@mo,@rd,@bd)
GO
/****** Object:  StoredProcedure [dbo].[ExcuteBaseScripts]    Script Date: 10/16/2024 7:27:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ExcuteBaseScripts]
as

declare @Script nvarchar(MAX)  
set @Script = 
'
create or alter proc SelectLessons
as
select * from Tbl_Lesson
'
execute(@Script)

 
GO
/****** Object:  StoredProcedure [dbo].[InsertStudent]    Script Date: 10/16/2024 7:27:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertStudent]
@FirstName nvarchar(4000),
@LastName nvarchar(4000),
@Mobile char(11)
as
insert into Tbl_Student(FirstName,LastName,Mobile)
values (@FirstName,@LastName,@Mobile)
GO
/****** Object:  StoredProcedure [dbo].[SelectLessons]    Script Date: 10/16/2024 7:27:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   proc [dbo].[SelectLessons]
as
select * from Tbl_Lesson
GO
/****** Object:  StoredProcedure [dbo].[SelectStudents]    Script Date: 10/16/2024 7:27:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SelectStudents]
as

select FirstName,LastName,Mobile 
from [dbo].[Tbl_Student] 
GO
/****** Object:  StoredProcedure [dbo].[SelectUser]    Script Date: 10/16/2024 7:27:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SelectUser]
@Search nvarchar(1001)
as
select Id,
	[FirstName],
	[LastName],
	[Mobile]
	from [dbo].[Tbl_Student]
		where [FirstName] like '%'+@Search+'%' or [LastName] like '%'+@Search+'%'
	
GO
/****** Object:  StoredProcedure [dbo].[usp_Select_Students]    Script Date: 10/16/2024 7:27:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_Select_Students]
@LastName nvarchar(1001)
as
select FirstName,Mobile from Tbl_Student
	where LastName like N'%'+@LastName+'%'
GO
USE [master]
GO
ALTER DATABASE [SchoolDb2] SET  READ_WRITE 
GO
