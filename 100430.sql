
delete tb_Orders
delete tb_PurOrders
delete tb_StockTable
delete tb_Return
delete tb_MateRe
delete tb_GodE
delete tb_SellTable
delete tb_SellRe
delete tb_OrdersSta
delete tb_POrdersSta
delete tb_Inventory
delete tb_StorageCase
delete tb_AcPay
delete tb_AcReceiv
delete tb_PayPart
delete tb_ReceivPart
delete tb_TNSC
delete tb_TNRe
delete tb_TNSe
delete tb_TNSR

delete tb_Verify

delete tb_ClientInfo
delete tb_StokerInfo
delete tb_WareInfo
delete tb_StorageInfo
delete tb_LocationInfo
delete tb_EmployeeInfo
delete tb_User
delete tb_RightList


select *  from tb_TNSe
select *  from tb_TNSR
select * from tb_Verify
SELECT * FROM TB_MateRe  where MateReID='MR10060001' ORDER BY convert(int, SN) ASC