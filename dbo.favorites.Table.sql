USE [YemekTarifleriDB]
GO
/****** Object:  Table [dbo].[favorites]    Script Date: 16/01/2025 22:53:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[favorites](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserKey] [nvarchar](450) NOT NULL,
	[RecipeId] [int] NOT NULL,
	[RecipeName] [nvarchar](450) NOT NULL,
	[RecipeImgUrl] [nvarchar](450) NOT NULL,
	[CreatedAt] [datetime] NULL,
 CONSTRAINT [PK__Favorite__3214EC07D8992CED] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[favorites] ON 

INSERT [dbo].[favorites] ([Id], [UserKey], [RecipeId], [RecipeName], [RecipeImgUrl], [CreatedAt]) VALUES (9, N'3', 53026, N'Tamiya', N'https://www.themealdb.com/images/media/meals/n3xxd91598732796.jpg', CAST(N'2024-12-13T15:32:42.670' AS DateTime))
INSERT [dbo].[favorites] ([Id], [UserKey], [RecipeId], [RecipeName], [RecipeImgUrl], [CreatedAt]) VALUES (11, N'3', 52980, N'Stamppot', N'https://www.themealdb.com/images/media/meals/hyarod1565090529.jpg', CAST(N'2024-12-13T15:46:45.120' AS DateTime))
INSERT [dbo].[favorites] ([Id], [UserKey], [RecipeId], [RecipeName], [RecipeImgUrl], [CreatedAt]) VALUES (13, N'3', 52977, N'Corba', N'https://www.themealdb.com/images/media/meals/58oia61564916529.jpg', CAST(N'2024-12-13T15:46:57.117' AS DateTime))
INSERT [dbo].[favorites] ([Id], [UserKey], [RecipeId], [RecipeName], [RecipeImgUrl], [CreatedAt]) VALUES (15, N'3', 52873, N'Beef Dumpling Stew', N'https://www.themealdb.com/images/media/meals/uyqrrv1511553350.jpg', CAST(N'2024-12-13T15:47:11.230' AS DateTime))
INSERT [dbo].[favorites] ([Id], [UserKey], [RecipeId], [RecipeName], [RecipeImgUrl], [CreatedAt]) VALUES (16, N'3', 53065, N'Sushi', N'https://www.themealdb.com/images/media/meals/g046bb1663960946.jpg', CAST(N'2024-12-13T16:28:57.527' AS DateTime))
INSERT [dbo].[favorites] ([Id], [UserKey], [RecipeId], [RecipeName], [RecipeImgUrl], [CreatedAt]) VALUES (19, N'3', 52854, N'Pancakes', N'https://www.themealdb.com/images/media/meals/rwuyqx1511383174.jpg', CAST(N'2024-12-13T16:38:14.017' AS DateTime))
INSERT [dbo].[favorites] ([Id], [UserKey], [RecipeId], [RecipeName], [RecipeImgUrl], [CreatedAt]) VALUES (20, N'3', 52887, N'Kedgeree', N'https://www.themealdb.com/images/media/meals/utxqpt1511639216.jpg', CAST(N'2024-12-13T16:43:52.870' AS DateTime))
INSERT [dbo].[favorites] ([Id], [UserKey], [RecipeId], [RecipeName], [RecipeImgUrl], [CreatedAt]) VALUES (21, N'3', 52906, N'Flamiche', N'https://www.themealdb.com/images/media/meals/wssvvs1511785879.jpg', CAST(N'2024-12-13T16:49:03.670' AS DateTime))
INSERT [dbo].[favorites] ([Id], [UserKey], [RecipeId], [RecipeName], [RecipeImgUrl], [CreatedAt]) VALUES (22, N'3', 52978, N'Kumpir', N'https://www.themealdb.com/images/media/meals/mlchx21564916997.jpg', CAST(N'2024-12-13T16:49:22.327' AS DateTime))
INSERT [dbo].[favorites] ([Id], [UserKey], [RecipeId], [RecipeName], [RecipeImgUrl], [CreatedAt]) VALUES (23, N'3', 52791, N'Eton Mess', N'https://www.themealdb.com/images/media/meals/uuxwvq1483907861.jpg', CAST(N'2024-12-13T16:50:42.817' AS DateTime))
INSERT [dbo].[favorites] ([Id], [UserKey], [RecipeId], [RecipeName], [RecipeImgUrl], [CreatedAt]) VALUES (24, N'9', 52887, N'Kedgeree', N'https://www.themealdb.com/images/media/meals/utxqpt1511639216.jpg', CAST(N'2024-12-13T16:52:50.780' AS DateTime))
INSERT [dbo].[favorites] ([Id], [UserKey], [RecipeId], [RecipeName], [RecipeImgUrl], [CreatedAt]) VALUES (25, N'9', 53052, N'Roti john', N'https://www.themealdb.com/images/media/meals/hx335q1619789561.jpg', CAST(N'2024-12-13T17:02:03.467' AS DateTime))
INSERT [dbo].[favorites] ([Id], [UserKey], [RecipeId], [RecipeName], [RecipeImgUrl], [CreatedAt]) VALUES (26, N'9', 52886, N'Spotted Dick', N'https://www.themealdb.com/images/media/meals/xqvyqr1511638875.jpg', CAST(N'2024-12-13T17:02:10.983' AS DateTime))
INSERT [dbo].[favorites] ([Id], [UserKey], [RecipeId], [RecipeName], [RecipeImgUrl], [CreatedAt]) VALUES (27, N'9', 52977, N'Corba', N'https://www.themealdb.com/images/media/meals/58oia61564916529.jpg', CAST(N'2024-12-13T17:02:14.733' AS DateTime))
INSERT [dbo].[favorites] ([Id], [UserKey], [RecipeId], [RecipeName], [RecipeImgUrl], [CreatedAt]) VALUES (28, N'9', 53013, N'Big Mac', N'https://www.themealdb.com/images/media/meals/urzj1d1587670726.jpg', CAST(N'2024-12-13T17:02:17.640' AS DateTime))
INSERT [dbo].[favorites] ([Id], [UserKey], [RecipeId], [RecipeName], [RecipeImgUrl], [CreatedAt]) VALUES (29, N'9', 52791, N'Eton Mess', N'https://www.themealdb.com/images/media/meals/uuxwvq1483907861.jpg', CAST(N'2024-12-13T17:02:21.633' AS DateTime))
INSERT [dbo].[favorites] ([Id], [UserKey], [RecipeId], [RecipeName], [RecipeImgUrl], [CreatedAt]) VALUES (32, N'10', 52978, N'Kumpir', N'https://www.themealdb.com/images/media/meals/mlchx21564916997.jpg', CAST(N'2024-12-31T07:10:11.943' AS DateTime))
SET IDENTITY_INSERT [dbo].[favorites] OFF
GO
ALTER TABLE [dbo].[favorites] ADD  CONSTRAINT [DF_favorites_CreatedAt1]  DEFAULT (getdate()) FOR [CreatedAt]
GO
