# Alchemit-Inscripcion-Universidad

## Instalación de aplicaciones
 - [Ide](https://visualstudio.microsoft.com/es/vs/community/)
 - [.Net Framework](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net472)
 - [SQL Server Management Studio](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)

Al momento de instalar el Ide:
 - Desarrollo de Asp.Net y web
 - Desarrollo de escritorio de .Net
 - Almacenamiento y procesamiento de datos
 - Desarrollo multiplataforma de .Net

## Levantar entorno Local
  Primero tenenos que crear la migracion para eso necesitamos contruir la migracion por consola.
~~~
Enable-Migrations
~~~

Una vez creada necesitamos crear la migración
~~~
`Add-Migration InitialMigrations`
~~~
Cómo ultimo debemos actualizar la base de datos
~~~
`Update-Database`
~~~


