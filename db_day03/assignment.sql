-- 1. Display the Department id, name, and id,  
--    and the name of its manager.  
with
    manager
    as
    (
        select concat(fname, ' ', lname) as [full name], e.ssn
        from Employee e
        where e.superSSN is null
    )
-- select * from manager
select e.SSN, e.DeptId, concat(e.fname, ' ', e.lname) as [full name emp],
    m.[full name]
from Employee e, manager m
where m.ssn = e.superSSN
--SSN	DeptId	full name emp	full name
--3	20	7ag kebda	abood omar
--6	10	Marwan Ali	Ahmed Hossam
--9	20	sayed 	abood omar

-- 2. Display the name of the departments and  
--    the name of the projects under its control.  
select d.DeptId, p.ProjName
from Department d, Project p
where p.DeptId = d.DeptId;
-- 3. Display the full data about all the dependents  
--    associated with the name of the employee  
--    they depend on him/her.  

select *
from Dependent d
    inner join Employee e on ssn = essn;
-- 4. Display the Id, name, and location of the projects  
--    in Cairo or Alex city.  
select p.projId, p.ProjName, PLocation
from Project p
where PLocation = 'cairo' or PLocation = 'alex'
-- 5. Display the Projects full data of the projects  
--    with a name that starts with the "a" letter.  
select *
from project
where projname like 'a%'
-- 6. Display all the employees in department 30  
--    whose salary ranges from 1000 to 2000 LE monthly.  
select *
from Employee e
where e.salary >= 1000 and e.salary <= 2000 and e.DeptId = 30
-- 7. Retrieve the names of all employees in department 10  
--    who work more than or equal to 10 hours per week  
--    on the "AL Rabwah" project.  
select concat(e.fname, ' ', e.lname) as [full name]
from employee e, Employee_Projects ep, Project p
where e.DeptId = 10 and ep.hours >= 10 and ep.ProjNo = p.projId and p.projname = 'rust'
-- 8. Find the names of the employees who are directly  
--    supervised by Kamel Mohamed.  
with
    cte_kamel
    as
    (
        select ssn
        from Employee
        where
	fname = 'abood' and lname = 'omar'
    )
select concat(e.fname, ' ', e.lname) as [full name]
from employee e, cte_kamel cte
where e.superSSN = cte.SSN
-- 9. Retrieve the names of all employees and the names  
--    of the projects they are working on,  
--    sorted by the project name.  
select concat(e.fname, ' ', e.lname) as [full name], p.ProjName
from employee e, Project p
order by p.ProjName
-- 10. For each project located in Cairo City,  
--     find the project number, the controlling  
--     department name, the department manager's  
--     last name, address, and birthdate.  
select p.projId, d.DeptName, e.lname, e.BirthDate
from Project p, Department d, Employee e
where p.PLocation = 'cairo'
    and p.DeptId = d.DeptId and d.MgrSSN = e.SSN
-- 11. Display all data of the managers.  
select *
from Employee
where superSSN is null
-- 12. Display all employees' data and the data  
--     of their dependents even if they have no dependents.  
select *
from Employee, Dependent;