--drop table Telefonnumre
--drop table Emails
--drop table Antal_magasiner
--drop table Kontaktpersoner
--drop table Åbningstider
--drop table Lokationer
--drop table Postnumre

create table Postnumre(
	Postnummer int not null,
	Bynavn varchar(30) not null,
	primary key (Postnummer),
);

create table Lokationer(
	ID int identity(1, 1) not null,
	Firmanavn varchar(30) not null,
	Addresse varchar(30) not null,
	Postnummer int not null,
	primary key (ID),
	foreign key (Postnummer) references	Postnumre(Postnummer),
);

create table Åbningerstider(
	ID int not null,
	Åbningstider varchar(10) not null,
	primary key (ID),
	foreign key (ID) references Lokationer(ID),
);

create table Telefonnumre(
	ID int not null,
	Telefonnummer varchar (15) not null,
	primary key (ID),
	foreign key (ID) references Lokationer(ID),
);

create table Emails(
	ID int not null,
	Email varchar (50) not null,
	primary key (ID),
	foreign key (ID) references Lokationer(ID),
);


create table Antal_magasiner(
	ID int not null,
	Antal_magasiner int not null,
	primary key (ID),
	foreign key (ID) references Lokationer(ID),
);


create table Kontaktpersoner(
	ID int not null,
	Kontaktperson varchar (40) not null,
	primary key (ID),
	foreign key (ID) references Lokationer(ID),
);

--create table Koordinater (
--	ID int not null,
--	Location_lat varchar(20) not null,
--	Location_lng varchar(20) not null,
--	primary key (ID),
--	foreign key (ID) references Lokationer(ID),
--);

Insert into Postnumre values (8850,'Bjerringbro');
Insert into Postnumre values (4720,'Præstø');
Insert into Postnumre values (8500,'Grenå');
Insert into Postnumre values (9800,'Hjøring');
Insert into Postnumre values (7500,'Holstrebro');

Insert into Lokationer values ('Land og Fritid Bjerringbro','Jørgens Allé 33', 8850);
Insert into Lokationer values ('Land og Fritid Bårse','Korndrevet 4', 4720);
Insert into Lokationer values ('Land og Fritid Grenå','Djurslandskajen 1', 8500);
Insert into Lokationer values ('Land og Fritid Hjørring','Johs. E Rasmussens Vej 1', 9800);
Insert into Lokationer values ('Land og Fritid Holstebro','Mads Bjerres Vej 2', 7500);

Insert into Telefonnumre values (1,'12345671');
Insert into Telefonnumre values (2,'12345672');
Insert into Telefonnumre values (3,'12345673');
Insert into Telefonnumre values (4,'12345674');
Insert into Telefonnumre values (5,'12345675');

Insert into Kontaktpersoner values (1,'Lisa Holst Nicolajsen');
Insert into Kontaktpersoner values (2,'Camilla S. Jørgensen');
Insert into Kontaktpersoner values (3,'Anette Alsner');
Insert into Kontaktpersoner values (4,'Charlotte Bach Olsen');
Insert into Kontaktpersoner values (5,'Nicholaj Simonsen');

Insert into Emails values (1,'info-bjerringbro@landogfritid.dk');
Insert into Emails values (2,'info-præstø@landogfritid.dk');
Insert into Emails values (3,'info-grenå@landogfritid.dk');
Insert into Emails values (4,'info-hjøring@landogfritid.dk');
Insert into Emails values (5,'info-holstebro@landogfritid.dk');

Insert into Antal_magasiner values (1,100);
Insert into Antal_magasiner values (2,150);
Insert into Antal_magasiner values (3,150);
Insert into Antal_magasiner values (4,100);
Insert into Antal_magasiner values (5,100);

Insert into Åbningerstider values (1,'10-18');
Insert into Åbningerstider values (2,'10-18');
Insert into Åbningerstider values (3,'10-18');
Insert into Åbningerstider values (4,'10-18');
Insert into Åbningerstider values (5,'10-18');