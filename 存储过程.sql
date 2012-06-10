if Exists (Select * from sysobjects where name = 'usp_Shop_Sell_Cash')
  drop proc usp_Shop_Sell_Cash
go
Create Proc usp_Shop_Sell_Cash
(
  @AccountID uniqueidentifier,
  @ShopID uniqueidentifier,
  @BillNo VarChar(20)
)
as
begin
  Declare @BillDate DateTime
  Select @BillDate = BillDate From Shop_SellList Where BillNo = @BillNo

  Select ProInfo_ID as ProID,Amount As Qty Into #Temp1 From Shop_SellDetail where BillNo = @BillNO
  Select * Into #Temp2 From #Temp1
  --写入库存表
  UpDate Shop_Store Set ExpQty = IsNull(ExpQty,0) + B.Qty,CurrQty = CurrQty - B.Qty
  From Shop_Store A,#Temp1 B 
  where a.Account_Period_id = @AccountID And ShopInfo_ID = @ShopID And ProInfo_Id = B.ProID

  Delete #Temp1 From #Temp1 Where ProID in (Select ProInfo_ID From Shop_Store where Account_Period_id = @AccountID And ShopInfo_ID = @ShopID)
  
  insert into Shop_Store (CurrQty,ExpQty,Account_Period_ID,ProInfo_ID,ShopInfo_ID)
	Select -Qty,Qty,@AccountID,ProID,@ShopID From #Temp1
  --写入明细账
  Insert Into Shop_AccountDetail (CurrQty,ExpQty,ProInfo_ID,ShopInfo_ID,Account_Period_ID,BillNo,BillDate)
  Select  A.CurrQty,B.Qty,B.ProID,@ShopID,@AccountID,@BillNo,@BillDate
  From Shop_Store A,#Temp2 B 
  where a.Account_Period_id = @AccountID And ShopInfo_ID = @ShopID And ProInfo_Id = B.ProID

  --写入要货表
  UpDate Shop_AskData Set Qty = IsNull(A.Qty,0) + B.Qty
  From Shop_AskData A,#Temp2 B 
  where A.ProInfo_ID = B.ProID And A.ShopInfo_ID = @ShopID

  Delete #Temp2 From #Temp2 Where ProID in (Select ProInfo_ID From Shop_AskData where ShopInfo_ID = @ShopID)
  
  insert into Shop_AskData (Qty,ProInfo_ID,ShopInfo_ID)
	Select Qty,ProID,@ShopID From #Temp2
end
Go

if Exists (Select * from sysobjects where name = 'usp_Shop_AskListCreate')
  Drop Proc usp_Shop_AskListCreate
Go
Create Proc usp_Shop_AskListCreate
(  
  @ShopID uniqueidentifier,
  @AskBillNo VarChar(20)
)
as
begin
  insert Into Shop_AskDetail (Qty,ProInfo_ID,AskBillNo)
    Select Qty,ProInfo_ID,@AskBillNo From Shop_AskData Where ShopInfo_ID = @ShopID
  Delete Shop_AskData Where ShopInfo_ID= @ShopID

end
go