CREATE TABLE sqlite_sequence(name,seq);

CREATE TABLE "Clients" (
	"Id"	TEXT NOT NULL UNIQUE,
	"Name"	TEXT NOT NULL,
	"Email"	TEXT NOT NULL,
	PRIMARY KEY("Id")
);

CREATE TABLE "Products" (
	"Id"	TEXT NOT NULL UNIQUE,
	"Name"	TEXT NOT NULL,
	"Brand"	TEXT NOT NULL,
	"Price"	REAL NOT NULL,
	"ClientId"	TEXT NOT NULL,
	PRIMARY KEY("Id"),
	FOREIGN KEY("ClientId") REFERENCES "Clients"("Id") ON DELETE CASCADE
);

