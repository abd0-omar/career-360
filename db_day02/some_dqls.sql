-- filling at least two rows per table for the tables that are not filled yet
-- dependent
insert into Dependent values(1, 'hoda', 'female', '5-5-2005', 'daughter')
insert into dependent(essn, name, sex, bdate, Relationship) values (2, 'soha', 'female', '4-4-2004', 'daughter');
-- project
insert into project values(1, 'rust', 'ba7ary', 10);
insert into project values(2, 'gleam', 'borsa3eed', 20);
-- dept_locations
-- could be written in one line with "," seperated
insert into Dept_Locations values(10, '3zba sa3d');
insert into Dept_Locations values(10, 'elmriotria');
-- demployee_projects, works on
insert into Employee_Projects values(1, 1, 6), (1, 2, 3);
-- all filled الحمدلله

-- select all employees
select * from employee;
-- 2.	Display the employee First name, last name, Salary and Department number.
select fname, lname, salary, deptid from employee;
-- 3.	Display all the projects names, locations and the department which is responsible about it.
select projname, plocation, deptid from project
-- 4.	If you know that the company policy is to pay an annual commission for each employee with specific percent equals 10% of his/her annual salary .Display each employee full name and his annual commission in an ANNUAL COMM column (alias).
select concat(fname, ' ', lname) as [full name], (salary * 0.10) as [annual com] from employee;
-- 5.	Display the employees Id, name who earns more than 1000 LE monthly.
select ssn from employee where salary > 1000;
-- 6.	Display the employees Id, name who earns more than 10000 LE annually.
select ssn, concat(fname, ' ', lname) as [full name] from employee where salary * 12 > 10000;
-- Select * from Employee where salary*12>10000
-- 7.	Display the names and salaries of the female employees 
select concat(fname, ' ', lname) from employee where sex = 'female';
-- 8.	Display each department id, name which managed by a manager with id equals from u entered.
select deptid, deptname from department where mgrssn = 1;
-- 9.	Dispaly the ids, names and locations of  the pojects which controled with department 10.
select projid, projname, plocation from project where deptid = 10;
