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
	Lokation_ID int identity(1, 1) not null,
	Firmanavn varchar(30) not null,
	Adresse varchar(30) not null,
	Postnummer int not null,
	Telefonnummer varchar (15),
	primary key (Lokation_ID),
	foreign key (Postnummer) references	Postnumre(Postnummer),
);

create table Åbningerstider(
	Lokation_ID int not null,
	Åbningstider varchar(10) not null,
	primary key (Lokation_ID),
	foreign key (Lokation_ID) references Lokationer(Lokation_ID) on delete cascade,
);

create table Antal_magasiner(
	Lokation_ID int not null,
	Magasin_ID int not null,
	Leveret_magasiner int,
	Afhentet_magasiner int,
	primary key (Lokation_ID),
	foreign key (Lokation_ID) references Lokationer(Lokation_ID) on delete cascade,
);

create table Kontaktpersoner(
	Lokation_ID int not null,
	Kontakt_ID int identity(1,1) not null,
	Kontaktperson varchar (40) not null,
	Email varchar (50) not null,
	Telefonnummer varchar(15),
	primary key (Kontakt_ID),
	foreign key (Lokation_ID) references Lokationer(Lokation_ID) on delete cascade,
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

Insert into Lokationer values ('Land og Fritid Bjerringbro','Jørgens Allé 33', 8850, '12345671');
Insert into Lokationer values ('Land og Fritid Bårse','Korndrevet 4', 4720, '12345672');
Insert into Lokationer values ('Land og Fritid Grenå','Djurslandskajen 1', 8500, '12345673');
Insert into Lokationer values ('Land og Fritid Hjørring','Johs. E Rasmussens Vej 1', 9800, '12345674');
Insert into Lokationer values ('Land og Fritid Holstebro','Mads Bjerres Vej 2', 7500, '12345675');

Insert into Kontaktpersoner values (1,'Lisa Holst Nicolajsen','info-bjerringbro@landogfritid.dk','12345671');
Insert into Kontaktpersoner values (2,'Camilla S. Jørgensen','info-præstø@landogfritid.dk','12345672');
Insert into Kontaktpersoner values (3,'Anette Alsner','info-grenå@landogfritid.dk','12345673');
Insert into Kontaktpersoner values (4,'Charlotte Bach Olsen','info-hjøring@landogfritid.dk','12345674');
Insert into Kontaktpersoner values (5,'Nicholaj Simonsen','info-holstebro@landogfritid.dk','12345675');

Insert into Antal_magasiner values (1,49,100,0);
Insert into Antal_magasiner values (2,49,150,140);
Insert into Antal_magasiner values (3,49,150,170);
Insert into Antal_magasiner values (4,49,100,110);
Insert into Antal_magasiner values (5,49,100,90);

Insert into Åbningerstider values (1,'10-18');
Insert into Åbningerstider values (2,'10-18');
Insert into Åbningerstider values (3,'10-18');
Insert into Åbningerstider values (4,'10-18');
Insert into Åbningerstider values (5,'10-18');