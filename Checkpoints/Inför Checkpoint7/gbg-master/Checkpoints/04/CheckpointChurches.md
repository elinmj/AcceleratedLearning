
# Checkpoint - Churches

## Intro

Create a database model from the instructions below.

Add suitable foreign keys and primary keys.

Just hand in one solution. (If you do level 2, just hand in level 2)

Submit three files:
- **diagram.png**: screen dump of your database diagram (the tables should show column information) 
- **create.sql**: SQL-code for creating your database (tables etc + data)
- **query.sql**: SQL-code for querying your database 


## Time

2h


## Level 1

The database should be able to store:

	Oscar-Fredriks church is located in Göteborg and is built 1893
	Masthuggs church is located in Göteborg and is built 1914
	Sankt Georgios church is located in Stockholm and is built 1890
	Matteus church is located in Norrköping and is built 1892

Create SQL-code for getting info about the churches:


	Göteborg	1893	Oscar-Fredriks church
	Göteborg	1914	Masthuggs church
	Stockholm	1890	Sankt Georgios church
	Norrköping	1892	Matteus church


## Level 2

The database should be able to store:

    Linnea lives in Göteborg
    Harry lives in Stockholm

	Oscar-Fredriks church is located in Göteborg and is built 1893
	Masthuggs church is located in Göteborg and is built 1914
	Sankt Georgios church is located in Stockholm and is built 1890
	Matteus church is located in Norrköping and is built 1892

	Linnea likes Oscar-Fredriks church and Matteus church
	Harry likes Matteus church

Write SQL-code to get where the inhabitants lives:

    Linnea      Göteborg
    Harry       Stockholm

Write SQL-code to get all inhabitants and the churches that they like:

	Linnea	Oscar-Fredriks church       1893
	Linnea	Matteus church              1892
	Harry	Matteus church              1892	

## Hint

To script your database to a file **create.sql**

    Tasks => Generate scripts

    Advanced => Type of data to script: Schema and data

To make a screendump of your

    Rightclick on your diagram

    Choose: "Copy Diagram to Clipboard" 