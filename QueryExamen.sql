create database BdiExamen
use BdiExamen
create table tblExamen (
idExamen int primary key not null,
Nombre varchar(255),
Descripcion varchar(255));

create procedure spAgregar( 
@Id int,
@Nombre varchar(255),
@Descripcion varchar (255))
as
if exists (select * from tblExamen where idExamen=3)
begin
print 'la id esta duplicada '
return (2)
end 
if not exists (select * from tblExamen where idExamen=@Id)
begin
insert tblExamen (idExamen,Nombre,Descripcion)
values (@Id,@Nombre,@Descripcion);
print 'Registro insertado satisfactoriamente'
return (0)
end


create procedure spActualizar(
@Id int,
@Nombre varchar(255),
@Descripcion varchar (255))
as
if exists (select * from tblExamen where idExamen=@Id)
begin
update tblExamen set Nombre=@Nombre, Descripcion=@Descripcion where idExamen=@Id;
print 'Registro insertado satisfactoriamente'
return (0)
end
if not exists (select * from tblExamen where idExamen=@Id) 
begin
print ' la ID no existe'
return (1)
end

create procedure spEliminar (
@Id int )
as 
if exists (select * from tblExamen where idExamen=@Id)
begin
delete from tblExamen where idExamen=@Id;
print 'Registro insertado satisfactoriamente' 
return (0)
end 
if not exists (select * from tblExamen where idExamen=@Id)
begin
print 'la ID no existe'
return (1)
end

create procedure spConsultar (
@Nombre varchar(255),
@Descripcion varchar(255))
as
if exists (select * from tblExamen where Nombre=@Nombre or Descripcion=@Descripcion)
begin
select * from tblExamen where Nombre=@Nombre or Descripcion=@Descripcion;
end 
if not exists (select * from tblExamen where Nombre=@Nombre or Descripcion=@Descripcion)
begin 
print 'no existe ningun nombre o descripcion que coincida con los datos introducidos'
return (1)
end
