use DBVENTAS_WEB
go

--REGISTROS EN TABLA ROL
INSERT INTO ROL(Descripcion) VALUES ('ADMINISTRADOR'),('EMPLEADO')
GO

--REGISTROS EN TABLA MENU
INSERT INTO MENU(Nombre,Icono) VALUES
('Acceso','fas fa-lock'),
('Tienda','fas fa-store'),
('Compras','fas fa-cart-arrow-down'),
('Ventas','fas fa-cash-register'),
('Clientes','fas fa-user-friends'),
('Reportes','far fa-clipboard')
GO

--REGISTROS EN TABLA SUBMENU
INSERT INTO SUBMENU(IdMenu,Nombre,Controlador,Vista,Icono) VALUES
((SELECT TOP 1 IdMenu FROM MENU WHERE Nombre = 'Acceso'),'Rol','Rol','Crear','fas fa-user-tag'),
((SELECT TOP 1 IdMenu FROM MENU WHERE Nombre = 'Acceso'),'Asignar Permisos','Permisos','Crear','fas fa-user-lock'),
((SELECT TOP 1 IdMenu FROM MENU WHERE Nombre = 'Acceso'),'Usuarios','Usuario','Crear','fas fa-users-cog'),

((SELECT TOP 1 IdMenu FROM MENU WHERE Nombre = 'Tienda'),'Tiendas','Tienda','Crear','fas fa-store-alt'),
((SELECT TOP 1 IdMenu FROM MENU WHERE Nombre = 'Tienda'),'Categorias','Categoria','Crear','fab fa-wpforms'),
((SELECT TOP 1 IdMenu FROM MENU WHERE Nombre = 'Tienda'),'Productos','Producto','Crear','fas fa-box-open'),

((SELECT TOP 1 IdMenu FROM MENU WHERE Nombre = 'Compras'),'Proveedores','Proveedor','Crear','fas fa-shipping-fast'),
((SELECT TOP 1 IdMenu FROM MENU WHERE Nombre = 'Compras'),'Asignar producto a Tienda','Producto','Asignar','fas fa-dolly'),
((SELECT TOP 1 IdMenu FROM MENU WHERE Nombre = 'Compras'),'Registrar Compra','Compra','Crear','fas fa-cart-arrow-down'),
((SELECT TOP 1 IdMenu FROM MENU WHERE Nombre = 'Compras'),'Consultar Compra','Compra','Consultar','far fa-list-alt'),

((SELECT TOP 1 IdMenu FROM MENU WHERE Nombre = 'Ventas'),'Registrar Venta','Venta','Crear','fas fa-cash-register'),
((SELECT TOP 1 IdMenu FROM MENU WHERE Nombre = 'Ventas'),'Consultar Venta','Venta','Consultar','far fa-clipboard'),

((SELECT TOP 1 IdMenu FROM MENU WHERE Nombre = 'Clientes'),'Registrar Cliente','Cliente','Crear','fas fa-user-shield'),

((SELECT TOP 1 IdMenu FROM MENU WHERE Nombre = 'Reportes'),'Productos por tienda','Reporte','Producto','fas fa-boxes'),
((SELECT TOP 1 IdMenu FROM MENU WHERE Nombre = 'Reportes'),'Ventas','Reporte','Ventas','fas fa-shopping-basket')
GO

--REGISTROS EN TABLA TIENDA
INSERT INTO TIENDA(Nombre,RUC,Direccion,Telefono) VALUES ('Mayisun Tienda','123456789','UCC','89729176')
GO

--REGISTROS USUARIO
insert into usuario(Nombres,Apellidos,Correo,Clave,IdTienda,IdRol)
values('Maria Asuncion','Rocha Gonzalez','admin@gmail.com','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',(select TOP 1 IdTienda from TIENDA where Nombre = 'Mayisun Tienda'),(select TOP 1 IdRol from ROL where Descripcion = 'ADMINISTRADOR'))
GO

--REGISTROS EN TABLA PERMISOS
INSERT INTO PERMISOS(IdRol,IdSubMenu)
SELECT (select TOP 1 IdRol from ROL where Descripcion = 'ADMINISTRADOR'), IdSubMenu FROM SUBMENU
go
INSERT INTO PERMISOS(IdRol,IdSubMenu,Activo)
SELECT (select TOP 1 IdRol from ROL where Descripcion = 'EMPLEADO'), IdSubMenu, 0 FROM SUBMENU 
go

update p set p.Activo = 1 from PERMISOS p
inner join SUBMENU sm on sm.IdSubMenu = p.IdSubMenu
where sm.Controlador in ('Venta') and p.IdRol = (select TOP 1 IdRol from ROL where Descripcion = 'EMPLEADO')
GO

----REGISTRO EN TABLA CATEGORIA
--INSERT INTO CATEGORIA(Descripcion) VALUES
--('Cuadros'),
--('Cuadernos'),
--('Libretas'),
--('Cajas'),
--('Lapiceros')
--GO

--REGISTRO EN TABLA PRODUCTO
--INSERT INTO PRODUCTO(Codigo,ValorCodigo,Nombre,Descripcion,IdCategoria)
--values
--(
--RIGHT('000000' + convert(varchar(max),(select isnull(max(ValorCodigo),0) + 1 from PRODUCTO)),6),
--(select isnull(max(ValorCodigo),0) + 1 from PRODUCTO),
--'El Lider - Cuaderno',
--'200 paginas',
--(select top 1 IdCategoria from CATEGORIA where Descripcion = 'Cuadernos')
--)
--GO

--INSERT INTO PRODUCTO(Codigo,ValorCodigo,Nombre,Descripcion,IdCategoria)
--values
--(
--RIGHT('000000' + convert(varchar(max),(select isnull(max(ValorCodigo),0) + 1 from PRODUCTO)),6),
--(select isnull(max(ValorCodigo),0) + 1 from PRODUCTO),
--'Caja Personalizada',
--'Caja de los Sipmsons',
--(select top 1 IdCategoria from CATEGORIA where Descripcion = 'Cajas')
--)
--GO

--INSERT INTO PRODUCTO(Codigo,ValorCodigo,Nombre,Descripcion,IdCategoria)
--values
--(
--RIGHT('000000' + convert(varchar(max),(select isnull(max(ValorCodigo),0) + 1 from PRODUCTO)),6),
--(select isnull(max(ValorCodigo),0) + 1 from PRODUCTO),
--'Cuadro Personalizado',
--'Pareja michael',
--(select top 1 IdCategoria from CATEGORIA where Descripcion = 'Cuadros')
--)
--GO

--INSERT INTO PRODUCTO(Codigo,ValorCodigo,Nombre,Descripcion,IdCategoria)
--values
--(
--RIGHT('000000' + convert(varchar(max),(select isnull(max(ValorCodigo),0) + 1 from PRODUCTO)),6),
--(select isnull(max(ValorCodigo),0) + 1 from PRODUCTO),
--'Paper Mate - Lapicero',
--'Punta fina',
--(select top 1 IdCategoria from CATEGORIA where Descripcion = 'Lapiceros')
--)
--GO

--Insert into cliente(tipodocumento,numerodocumento,nombre,direccion,telefono) values 
--('DNI','34231223','Jose Perez','av. Test 123','12345342'),
--('DNI','56567878','Maria Paz','av. Test 124','12345343'),
--('DNI','78907878','Thalia Quiñon','av. Test 125','12345344')
--go

--insert into PROVEEDOR(ruc,RazonSocial,Telefono,Correo,Direccion) values
--('88889999','Gomper Librerias','22767188','GomperLib_Nicaragua@gmail.com','Metrocentro'),
--('77775555','Libreria San Jeronimo','22554541','Lib_SanJeronimo@gmail.com','Crrt. Masaya, km9')
