create table Zipcode(
	Zipcode int not null,
	City varchar(30) not null,
	primary key (Zipcode),
);

create table Distribution_point(
	Location_ID int identity(1, 1) not null,
	Company varchar(30) not null,
	Address varchar(30) not null,
	Zipcode int not null,
	primary key (Location_ID),
	foreign key (Zipcode) references Zipcode(Zipcode),
);

create table Opening_hour(
	Opening_ID int identity(1,1) not null,
	Location_ID int not null,
	Week_day varchar(30),
	Open_hours varchar(15),
	primary key (Opening_ID),
	foreign key (Location_ID) references Distribution_point(Location_ID) on delete cascade,
);

create table No_of_magazine(
	Magasine_ID int identity(1,1) not null,
	Location_ID int not null,
	Magazine_issue int,
	Supplied_magazine int,
	Delivered_magazine int,
	primary key (Magasine_ID),
	foreign key (Location_ID) references Distribution_point(Location_ID) on delete cascade,
);

create table Contactperson(
	Location_ID int not null,
	Contact_ID int identity(1,1) not null,
	Contactperson varchar (40) not null,
	Email varchar (50),
	Phone varchar(15),
	primary key (Contact_ID),
	foreign key (Location_ID) references Distribution_point(Location_ID) on delete cascade,
);

--create table Koordinater (
--	ID int not null,
--	Location_lat varchar(20) not null,
--	Location_lng varchar(20) not null,
--	primary key (ID),
--	foreign key (ID) references Lokationer(ID),
--);

Insert into Zipcode values (8850,'Bjerringbro');
Insert into Zipcode values (4720,'Præstø');
Insert into Zipcode values (8500,'Grenå');
Insert into Zipcode values (9800,'Hjøring');
Insert into Zipcode values (7500,'Holstrebro');

Insert into Distribution_point values ('Land og Fritid Bjerringbro','Jørgens Allé 33', 8850);
Insert into Distribution_point values ('Land og Fritid Bårse','Korndrevet 4', 4720);
Insert into Distribution_point values ('Land og Fritid Grenå','Djurslandskajen 1', 8500);
Insert into Distribution_point values ('Land og Fritid Hjørring','Johs. E Rasmussens Vej 1', 9800);
Insert into Distribution_point values ('Land og Fritid Holstebro','Mads Bjerres Vej 2', 7500);

Insert into Contactperson values (1,'Lisa Holst Nicolajsen','info-bjerringbro@landogfritid.dk','12345671');
Insert into Contactperson values (2,'Camilla S. Jørgensen','info-præstø@landogfritid.dk','12345672');
Insert into Contactperson values (3,'Anette Alsner','info-grenå@landogfritid.dk','12345673');
Insert into Contactperson values (4,'Charlotte Bach Olsen','info-hjøring@landogfritid.dk','12345674');
Insert into Contactperson values (5,'Nicholaj Simonsen','info-holstebro@landogfritid.dk','12345675');

Insert into No_of_magazine values (1,49,100,0);
Insert into No_of_magazine values (2,49,150,140);
Insert into No_of_magazine values (3,49,150,170);
Insert into No_of_magazine values (4,49,100,110);
Insert into No_of_magazine values (5,49,100,90);

Insert into Opening_hour values (1,'Hverdage','10-18');
Insert into Opening_hour values (1,'Weekend','10-15');
Insert into Opening_hour values (2,'Alle dage','10-18');
Insert into Opening_hour values (3,'Mandag-torsdag','10-18');
Insert into Opening_hour values (3,'Fredag-søndag','10-14');
Insert into Opening_hour values (4,'Mandag-lørdag','10-18');
Insert into Opening_hour values (4,'Søndag','Lukket');
Insert into Opening_hour values (5,'Mandag-torsdag','10-18');
Insert into Opening_hour values (5,'Fredag-søndag','10-15');