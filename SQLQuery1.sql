SELECT @@VERSION VersionInfo
GO

EXEC xp_msver
GO

select * from WVCCDev.dbo.UserInfo WHERE VHAWindowsID = 'VHACANSILVEE';

EXEC WVCCDev.dbo.GetSessionID 'VHACANSILVEE', NULL;
