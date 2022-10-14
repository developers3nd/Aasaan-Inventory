create view myinvoice as 
select tblorder.orderid, tblproducts.name,  tblorder.customername, tblorder.qty, tblorder.total, tblorder.date
from tblorder
inner join tblproducts on tblproducts.pid = tblorder.pid