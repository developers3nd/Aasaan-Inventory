drop view myinvoice

create view myinvoice as 
select tblorder.orderid, tblcategories.catname, tblproducts.name, tblproducts.price,  tblorder.customername, tblorder.qty, tblorder.total, tblorder.date
from tblorder
inner join tblproducts on tblproducts.pid = tblorder.pid
inner join tblcategories on tblcategories.catid = tblproducts.catid