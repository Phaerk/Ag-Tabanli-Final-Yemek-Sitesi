USE [YemekTarifleriDB]
GO
/****** Object:  Table [dbo].[users]    Script Date: 16/01/2025 22:53:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[u_id] [int] IDENTITY(1,1) NOT NULL,
	[u_name] [varchar](50) NULL,
	[u_email] [varchar](50) NULL,
	[u_key] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[u_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([u_id], [u_name], [u_email], [u_key]) VALUES (3, N'ata', N'atakan.ibis@gmail.com', N'96cae35ce8a9b0244178bf28e4966c2ce1b8385723a96a6b838858cdd6ca0a1e')
INSERT [dbo].[users] ([u_id], [u_name], [u_email], [u_key]) VALUES (9, N'selinay', N'celin@gmail.com', N'96cae35ce8a9b0244178bf28e4966c2ce1b8385723a96a6b838858cdd6ca0a1e')
INSERT [dbo].[users] ([u_id], [u_name], [u_email], [u_key]) VALUES (10, N'deneme', N'deneme@gmail.com', N'96cae35ce8a9b0244178bf28e4966c2ce1b8385723a96a6b838858cdd6ca0a1e')
INSERT [dbo].[users] ([u_id], [u_name], [u_email], [u_key]) VALUES (11, N'ahmet', N'ahmet@gmail.com', N'96cae35ce8a9b0244178bf28e4966c2ce1b8385723a96a6b838858cdd6ca0a1e')
SET IDENTITY_INSERT [dbo].[users] OFF
GO
