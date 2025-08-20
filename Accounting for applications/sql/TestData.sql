USE Dem04DB

DELETE FROM EquipmentForRequest
DELETE FROM Equipment
DELETE FROM Requests
DBCC CHECKIDENT('Requests',RESEED,0)
DELETE FROM Workers
DBCC CHECKIDENT('Workers',RESEED,0)
DELETE FROM LOGINS
DELETE FROM Clients
DBCC CHECKIDENT('Clients',RESEED,0)
DELETE FROM RequestStates
DBCC CHECKIDENT('RequestStates',RESEED,0)
DELETE FROM Roles
DBCC CHECKIDENT('Roles',RESEED,0)

INSERT Roles
VALUES('WORKER',0),('ADMIN',1)

INSERT RequestStates
VALUES('������'),('� ������'),('��������')

INSERT LOGINS
VALUES
('ffde','1554',1),
('asd','asd',2),
('ffeeff','15599551',2)

INSERT Clients
VALUES('����','������','9878476295')

INSERT Workers VALUES
('����','������','9878476295','ffde'),
('�������','��������','9878476295','asd'),
('����','������','5486781548','ffeeff')

INSERT Requests VALUES
('01.01.2012','02.01.2012','02.01.2012','ffffff',3,1,2,0),
('01.01.2012', NULL,NULL,'����',1,1,1,0),
('01.01.2012','02.01.2012',NULL,'������������',2,1,2,0)

select * from Requests
--INSERT Equipment Values
--INSERT EquipmentForRequest
