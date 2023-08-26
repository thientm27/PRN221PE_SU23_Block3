USE master
GO

CREATE DATABASE CartoonFilm2023DB
GO

USE CartoonFilm2023DB
GO

CREATE TABLE MemberAccount(
  MemberID int primary key,
  Password nvarchar(40) not null,
  FullName nvarchar(60) not null,
  Email nvarchar(60) unique, 
  Role int
)
GO

INSERT INTO MemberAccount VALUES(23 ,N'@6', N'Administrator', 'admin@CartoonFilmCorp.com', 1);
INSERT INTO MemberAccount VALUES(24 ,N'@6', N'Staff', 'staff@CartoonFilmCorp.com', 2);
INSERT INTO MemberAccount VALUES(25 ,N'@6', N'Manager', 'manager@CartoonFilmCorp.com', 3);
INSERT INTO MemberAccount VALUES(26 ,N'@6', N'Customer', 'customer@CartoonFilmCorp.com', 4);
GO


CREATE TABLE Producer(
  ProducerId nvarchar(30) primary key,
  ProducerName nvarchar(90) not null,
  ProducerDescription nvarchar(250) not null, 
  Country nvarchar(60)
)
GO
INSERT INTO Producer VALUES(N'PC0046', N'Disney Pictures', N'One of the most well-known and influential production companies in the world, Disney Pictures is known for its classic animated films, live-action movies, and family-friendly content.', N'United States')
GO
INSERT INTO Producer VALUES(N'PC0056', N'Pixar Animation Studios', N'Acquired by Disney in 2006, Pixar is renowned for its groundbreaking computer-generated animated films.', N'United States')
GO
INSERT INTO Producer VALUES(N'PC0066', N'DreamWorks Animation', N'Founded by Steven Spielberg, Jeffrey Katzenberg, and David Geffen, DreamWorks Animation is known for its visually stunning animated films with broad appeal. ', N'United States')
GO
INSERT INTO Producer VALUES(N'PC0076', N'Sony Pictures Animation', N'Sony Pictures Animation specializes in creating animated films, both through its own productions and collaborations with other studios.', N'Nertheland')
GO
INSERT INTO Producer VALUES(N'PC0086', N'Studio Ghibli', N'A Japanese animation studio founded by Hayao Miyazaki and Isao Takahata, Studio Ghibli is known for its artistic and imaginative animated films.', N'Japan')
GO
INSERT INTO Producer VALUES(N'PC0096', N'Blue Sky Studios', N'Blue Sky Studios is known for its computer-animated films, including the "Ice Age" franchise.', N'United States')
GO


CREATE TABLE CartoonFilmInformation(
 CartoonFilmId int primary key,
 CartoonFilmName nvarchar(100) not null,
 CartoonFilmDescription nvarchar(250),
 Duration int,
 ReleaseYear int, 
 CreatedDate Datetime,
 ProducerId nvarchar(30) references Producer(ProducerId) on delete cascade on update cascade
)
GO

INSERT INTO CartoonFilmInformation VALUES(664, N'How to Train Your Dragon', N'Set in a Viking world filled with dragons, the film follows a young boy named Hiccup who befriends a fearsome dragon named Toothless.', 140, 2010, CAST(N'2023-08-16' AS DateTime), 'PC0046')
GO
INSERT INTO CartoonFilmInformation VALUES(666, N'Zootopia', N'In a society where animals live peacefully, a determined rabbit named Judy Hopps becomes the first bunny police officer in the city of Zootopia.', 90, 2016, CAST(N'2023-08-16' AS DateTime), 'PC0056')
GO
INSERT INTO CartoonFilmInformation VALUES(667, N'Frozen', N'Set in a magical icy kingdom, "Frozen" tells the story of two sisters, Elsa and Anna. Elsa possesses the power to create ice and snow, but her abilities inadvertently freeze the kingdom.', 120, 2013, CAST(N'2023-08-16' AS DateTime), 'PC0046')
GO
INSERT INTO CartoonFilmInformation VALUES(668, N'Shrek', N'This humorous and unconventional fairytale follows the story of a grumpy ogre named Shrek who embarks on a quest to rescue Princess Fiona. ', 105, 2001, CAST(N'2023-08-16' AS DateTime), 'PC0056')
GO
INSERT INTO CartoonFilmInformation VALUES(669, N'Finding Nemo', N'In this underwater adventure, a clownfish named Marlin searches for his son Nemo, who has been captured by a diver and placed in a fish tank. ', 90, 2003, CAST(N'2023-08-16' AS DateTime), 'PC0046')
GO
INSERT INTO CartoonFilmInformation VALUES(670, N'Toy Story', N'This heartwarming film follows the adventures of a group of toys that come to life when humans are not around.', 112, 2010, CAST(N'2023-08-16' AS DateTime), 'PC0056')
GO
INSERT INTO CartoonFilmInformation VALUES(671, N'The Incredibles', N'This Pixar takes place in a world where superheroes have been forced to live ordinary lives. Followin family of superheroes, "The Incredibles" explores themes of embracing individuality, family bonds, and teamwork', 120, 2004, CAST(N'2023-08-16' AS DateTime), 'PC0046')
GO
INSERT INTO CartoonFilmInformation VALUES(672, N'Kung Fu Panda', N'This action-comedy film follows the journey of Po, a clumsy panda who dreams of becoming a kung fu master.', 110, 2010, CAST(N'2023-08-16' AS DateTime), 'PC0086')
GO
INSERT INTO CartoonFilmInformation VALUES(673, N'The Lion King', N'This iconic Disney film tells the story of a young lion named Simba who must reclaim his throne from his evil uncle Scar. ', 100, 1994, CAST(N'2023-08-16' AS DateTime), 'PC0046')
GO