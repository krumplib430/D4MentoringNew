SET TRANSACTION ISOLATION LEVEL SNAPSHOT
BEGIN TRAN
SELECT * FROM Test
WAITFOR DELAY '00:00:15'
SELECT * FROM Test
ROLLBACK