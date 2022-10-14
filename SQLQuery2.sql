create view vw_getallproducts as
select tblproducts.pid, tblproducts.name, tblcategories.catname, tblproducts.name, tblproducts.qty, tblproducts.pimage
from tblproducts
inner join tblcategories on tblcategories.catid = tblproducts.catid

