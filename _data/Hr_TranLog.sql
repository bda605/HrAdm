/*=== Cms table start ===*/
--trigger Create
if object_id('trc_Cms', 'TR') is not null
   drop trigger trc_Cms;  
go
   
create trigger trc_Cms
   on dbo.[Cms]
   after insert
as begin	

	declare @now datetime
	declare @id varchar(10)
	declare @table varchar(30)
	declare @act varchar(10)
	set @now = getdate()
	set @table = 'Cms'
	set @act = 'Create'
	select @id=Id from inserted

	set nocount on;
	
	insert into dbo.XpTranLog(RowId, TableName, Act, Created) values 
		(@id, @table, @act, @now);
	
end
go

--trigger Update
if object_id('tru_Cms', 'TR') is not null
   drop trigger tru_Cms;  
go
   
create trigger tru_Cms
   on dbo.[Cms]
   after update
as begin	

	declare @now datetime
	declare @id varchar(10)
	declare @table varchar(30)
	declare @act varchar(10)
	set @now = getdate()
	set @table = 'Cms'
	set @act = 'Update'
	select @id=Id from deleted

	set nocount on;	
	
    if update(Id)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'Id', (select[Id] from deleted), (select[Id] from inserted), @act, @now);
    if update(CmsType)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'CmsType', (select[CmsType] from deleted), (select[CmsType] from inserted), @act, @now);
    if update(DataType)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'DataType', (select[DataType] from deleted), (select[DataType] from inserted), @act, @now);
    if update(Title)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'Title', (select[Title] from deleted), (select[Title] from inserted), @act, @now);
    if update(Text)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'Text', (select[Text] from deleted), (select[Text] from inserted), @act, @now);
    if update(Html)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'Html', (select[Html] from deleted), (select[Html] from inserted), @act, @now);
    if update(Note)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'Note', (select[Note] from deleted), (select[Note] from inserted), @act, @now);
    if update(FileName)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'FileName', (select[FileName] from deleted), (select[FileName] from inserted), @act, @now);
    if update(StartTime)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'StartTime', (select[StartTime] from deleted), (select[StartTime] from inserted), @act, @now);
    if update(EndTime)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'EndTime', (select[EndTime] from deleted), (select[EndTime] from inserted), @act, @now);
    if update(Status)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'Status', (select[Status] from deleted), (select[Status] from inserted), @act, @now);
	
end
go

--trigger Delete
if object_id('trd_Cms', 'TR') is not null
   drop trigger trd_Cms;  
go
   
create trigger trd_Cms
   on dbo.[Cms]
   after delete
as begin	

	declare @now datetime
	declare @id varchar(10)
	declare @table varchar(30)
	declare @act varchar(10)
	set @now = getdate()
	set @table = 'Cms'
	set @act = 'Delete'
	select @id=Id from deleted

	set nocount on;
	
	insert into dbo.XpTranLog(RowId, TableName, Act, Created) values 
		(@id, @table, @act, @now);
	
end
go
/*=== Cms table end ===*/

/*=== User table start ===*/
--trigger Create
if object_id('trc_User', 'TR') is not null
   drop trigger trc_User;  
go
   
create trigger trc_User
   on dbo.[User]
   after insert
as begin	

	declare @now datetime
	declare @id varchar(10)
	declare @table varchar(30)
	declare @act varchar(10)
	set @now = getdate()
	set @table = 'User'
	set @act = 'Create'
	select @id=Id from inserted

	set nocount on;
	
	insert into dbo.XpTranLog(RowId, TableName, Act, Created) values 
		(@id, @table, @act, @now);
	
end
go

--trigger Update
if object_id('tru_User', 'TR') is not null
   drop trigger tru_User;  
go
   
create trigger tru_User
   on dbo.[User]
   after update
as begin	

	declare @now datetime
	declare @id varchar(10)
	declare @table varchar(30)
	declare @act varchar(10)
	set @now = getdate()
	set @table = 'User'
	set @act = 'Update'
	select @id=Id from deleted

	set nocount on;	
	
    if update(Id)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'Id', (select[Id] from deleted), (select[Id] from inserted), @act, @now);
    if update(Name)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'Name', (select[Name] from deleted), (select[Name] from inserted), @act, @now);
    if update(Account)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'Account', (select[Account] from deleted), (select[Account] from inserted), @act, @now);
    if update(Pwd)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'Pwd', (select[Pwd] from deleted), (select[Pwd] from inserted), @act, @now);
    if update(DeptId)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'DeptId', (select[DeptId] from deleted), (select[DeptId] from inserted), @act, @now);
    if update(PhotoFile)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'PhotoFile', (select[PhotoFile] from deleted), (select[PhotoFile] from inserted), @act, @now);
    if update(Status)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'Status', (select[Status] from deleted), (select[Status] from inserted), @act, @now);
	
end
go

--trigger Delete
if object_id('trd_User', 'TR') is not null
   drop trigger trd_User;  
go
   
create trigger trd_User
   on dbo.[User]
   after delete
as begin	

	declare @now datetime
	declare @id varchar(10)
	declare @table varchar(30)
	declare @act varchar(10)
	set @now = getdate()
	set @table = 'User'
	set @act = 'Delete'
	select @id=Id from deleted

	set nocount on;
	
	insert into dbo.XpTranLog(RowId, TableName, Act, Created) values 
		(@id, @table, @act, @now);
	
end
go
/*=== User table end ===*/

/*=== XpDept table start ===*/
--trigger Create
if object_id('trc_XpDept', 'TR') is not null
   drop trigger trc_XpDept;  
go
   
create trigger trc_XpDept
   on dbo.[XpDept]
   after insert
as begin	

	declare @now datetime
	declare @id varchar(10)
	declare @table varchar(30)
	declare @act varchar(10)
	set @now = getdate()
	set @table = 'XpDept'
	set @act = 'Create'
	select @id=Id from inserted

	set nocount on;
	
	insert into dbo.XpTranLog(RowId, TableName, Act, Created) values 
		(@id, @table, @act, @now);
	
end
go

--trigger Update
if object_id('tru_XpDept', 'TR') is not null
   drop trigger tru_XpDept;  
go
   
create trigger tru_XpDept
   on dbo.[XpDept]
   after update
as begin	

	declare @now datetime
	declare @id varchar(10)
	declare @table varchar(30)
	declare @act varchar(10)
	set @now = getdate()
	set @table = 'XpDept'
	set @act = 'Update'
	select @id=Id from deleted

	set nocount on;	
	
    if update(Id)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'Id', (select[Id] from deleted), (select[Id] from inserted), @act, @now);
    if update(Name)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'Name', (select[Name] from deleted), (select[Name] from inserted), @act, @now);
    if update(MgrId)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'MgrId', (select[MgrId] from deleted), (select[MgrId] from inserted), @act, @now);
	
end
go

--trigger Delete
if object_id('trd_XpDept', 'TR') is not null
   drop trigger trd_XpDept;  
go
   
create trigger trd_XpDept
   on dbo.[XpDept]
   after delete
as begin	

	declare @now datetime
	declare @id varchar(10)
	declare @table varchar(30)
	declare @act varchar(10)
	set @now = getdate()
	set @table = 'XpDept'
	set @act = 'Delete'
	select @id=Id from deleted

	set nocount on;
	
	insert into dbo.XpTranLog(RowId, TableName, Act, Created) values 
		(@id, @table, @act, @now);
	
end
go
/*=== XpDept table end ===*/

/*=== XpProg table start ===*/
--trigger Create
if object_id('trc_XpProg', 'TR') is not null
   drop trigger trc_XpProg;  
go
   
create trigger trc_XpProg
   on dbo.[XpProg]
   after insert
as begin	

	declare @now datetime
	declare @id varchar(10)
	declare @table varchar(30)
	declare @act varchar(10)
	set @now = getdate()
	set @table = 'XpProg'
	set @act = 'Create'
	select @id=Id from inserted

	set nocount on;
	
	insert into dbo.XpTranLog(RowId, TableName, Act, Created) values 
		(@id, @table, @act, @now);
	
end
go

--trigger Update
if object_id('tru_XpProg', 'TR') is not null
   drop trigger tru_XpProg;  
go
   
create trigger tru_XpProg
   on dbo.[XpProg]
   after update
as begin	

	declare @now datetime
	declare @id varchar(10)
	declare @table varchar(30)
	declare @act varchar(10)
	set @now = getdate()
	set @table = 'XpProg'
	set @act = 'Update'
	select @id=Id from deleted

	set nocount on;	
	
    if update(Id)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'Id', (select[Id] from deleted), (select[Id] from inserted), @act, @now);
    if update(Code)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'Code', (select[Code] from deleted), (select[Code] from inserted), @act, @now);
    if update(Name)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'Name', (select[Name] from deleted), (select[Name] from inserted), @act, @now);
    if update(Icon)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'Icon', (select[Icon] from deleted), (select[Icon] from inserted), @act, @now);
    if update(Url)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'Url', (select[Url] from deleted), (select[Url] from inserted), @act, @now);
    if update(Sort)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'Sort', (select[Sort] from deleted), (select[Sort] from inserted), @act, @now);
    if update(FunCreate)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'FunCreate', (select[FunCreate] from deleted), (select[FunCreate] from inserted), @act, @now);
    if update(FunRead)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'FunRead', (select[FunRead] from deleted), (select[FunRead] from inserted), @act, @now);
    if update(FunUpdate)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'FunUpdate', (select[FunUpdate] from deleted), (select[FunUpdate] from inserted), @act, @now);
    if update(FunDelete)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'FunDelete', (select[FunDelete] from deleted), (select[FunDelete] from inserted), @act, @now);
    if update(FunPrint)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'FunPrint', (select[FunPrint] from deleted), (select[FunPrint] from inserted), @act, @now);
    if update(FunExport)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'FunExport', (select[FunExport] from deleted), (select[FunExport] from inserted), @act, @now);
    if update(FunView)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'FunView', (select[FunView] from deleted), (select[FunView] from inserted), @act, @now);
    if update(FunOther)        
        insert into dbo.XpTranLog(RowId, TableName, ColName, OldValue, NewValue, Act, Created) values
            (@id, @table, 'FunOther', (select[FunOther] from deleted), (select[FunOther] from inserted), @act, @now);
	
end
go

--trigger Delete
if object_id('trd_XpProg', 'TR') is not null
   drop trigger trd_XpProg;  
go
   
create trigger trd_XpProg
   on dbo.[XpProg]
   after delete
as begin	

	declare @now datetime
	declare @id varchar(10)
	declare @table varchar(30)
	declare @act varchar(10)
	set @now = getdate()
	set @table = 'XpProg'
	set @act = 'Delete'
	select @id=Id from deleted

	set nocount on;
	
	insert into dbo.XpTranLog(RowId, TableName, Act, Created) values 
		(@id, @table, @act, @now);
	
end
go
/*=== XpProg table end ===*/

