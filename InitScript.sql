--部门
insert into departinfo values('579DB312-956F-4491-ACEF-75395321EDC8',0,1,'办公室')
go

--区域
insert into areainfo values('48475A37-A6AB-4C0B-B34A-A06601206FDE','城东',0,1)

go
--门店
insert into shopinfo values('58475A37-AaAB-4C0B-B34A-d06631206FDE'
	,0
	,'fax'
	,0
	,'门店1'
	,1
	,'tel'
	,'address'
	,'48475A37-A6AB-4C0B-B34A-A06601206FDE'
	)
go
--用户
insert into userinfo values('admin',0,'',1,'1111',1,'管理员','',1,1,'579DB312-956F-4491-ACEF-75395321EDC8',null)
insert into userinfo values('cahser1'
,0,
'',
1,
'1111'
,1
,'收银员1'
,''
,1
,1
,'579DB312-956F-4491-ACEF-75395321EDC8'
,'58475A37-AaAB-4C0B-B34A-d06631206FDE')
go
--产品
declare @index int
select @index=1
while(@index<=1000)
begin
  declare @proName varchar(20)
  select @proname='proname'+convert(varchar(10),@index)
  declare @cateName varchar(20)
  declare @cateIndex int
  select @cateIndex=@index%5+1
  select @cateName='cate'+convert(varchar(10),@cateIndex)
  declare @proid uniqueidentifier 
  select @proid=newid()
  insert into ProInfo values(@proid,0,@proname,'',@cateName,'斤',getdate())
  --产品价格
  insert into proPrice(price,proinfo_id,areainfo_id) values(
  10
  ,@proid
  ,'48475A37-A6AB-4C0B-B34A-A06601206FDE')
  select @index=@index+1
end

