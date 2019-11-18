# TBackend


>Trabajo Final de WEB Parte Backend
>Para instalar

```
https://dev.mysql.com/downloads/installer/ - workbench y mysql
[8:33 PM] FerLuis: ALTER USER 'root'@'localhost' IDENTIFIED WITH mysql_native_password BY 'admin';
[8:33 PM] FerLuis: create schema tournamentdb;
use tournamentdb;
CREATE TABLE __EFMigrationsHistory 
( 
    MigrationId nvarchar(150) NOT NULL, 
    ProductVersion nvarchar(32) NOT NULL, 
     PRIMARY KEY (MigrationId) 
);
[8:34 PM] FerLuis:
`create schema tournamentdb;
use tournamentdb;
CREATE TABLE `__EFMigrationsHistory` 
( 
    `MigrationId` nvarchar(150) NOT NULL, 
    `ProductVersion` nvarchar(32) NOT NULL, 
     PRIMARY KEY (`MigrationId`) 
);
``
[8:34 PM] FerLuis:
create schema tournamentdb;
use tournamentdb;
CREATE TABLE `__EFMigrationsHistory` 
( 
    `MigrationId` nvarchar(150) NOT NULL, 
    `ProductVersion` nvarchar(32) NOT NULL, 
     PRIMARY KEY (`MigrationId`) 
);
[8:35 PM] FerLuis:
Attachment file type: archive
TrabajoFinalWeb.zip
308.14 KB
[3:29 AM] FerLuis: Siempre dropeen todas las tablas que el MySQL y netcore no se llevan bien
[3:29 AM] FerLuis: tendre que buscar otra dependencia pero por ahora ersta bien
[3:30 AM] FerLuis: solo borren las tablas , la carpeta migrations
[3:30 AM] FerLuis: luego en el repository :
[3:30 AM] FerLuis:
dotnet ef --startup-project ..\TBackend.Api\ migrations add up2
[3:30 AM] FerLuis: y luego
[3:30 AM] FerLuis:
dotnet ef --startup-project ..\TBackend.Api\ database update

```
