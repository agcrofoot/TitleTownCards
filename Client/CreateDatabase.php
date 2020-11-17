<?php include "db.php"; ?>

<?php 
global $connection;

//MANAGER TABLE
echo "Manager:<br/>";
$query = "DROP TABLE IF EXISTS Manager";
$query = mysqli_query($connection, $query);
checkQuery($query);

$query = "CREATE TABLE `ttowncards`.`Manager` 
( `ManagerID` INT NOT NULL AUTO_INCREMENT , 
`ManagerName` TEXT NOT NULL , `ManagerPhone` 
TEXT NOT NULL , `ManagerEmail` TEXT NOT NULL , 
`ManagerAddress` TEXT NOT NULL , PRIMARY KEY 
(`ManagerID`)) ENGINE = InnoDB;";
$query = mysqli_query($connection, $query);
checkQuery($query);


//EMPLOYEE TABLE 
echo "Employee:<br/>";
$query = "DROP TABLE IF EXISTS Employee";
$query = mysqli_query($connection, $query);
checkQuery($query);

$query = "CREATE TABLE `ttowncards`.`Employee` 
( `EmployeeID` INT NOT NULL AUTO_INCREMENT , 
`EmployeeName` TEXT NOT NULL , `EmployeePhone` TEXT NOT NULL , 
`EmployeeAddress` TEXT NOT NULL , `ManagerID` INT NOT NULL , 
PRIMARY KEY (`EmployeeID`)) ENGINE = InnoDB;";
$query = mysqli_query($connection, $query);
checkQuery($query);


//MEMBER TABLE 
echo "Member:<br/>";
$query = "DROP TABLE IF EXISTS Member";
$query = mysqli_query($connection, $query);
checkQuery($query);

$query = "CREATE TABLE `ttowncards`.`Member` 
( `MemberID` INT NOT NULL AUTO_INCREMENT , 
`MemberFName` TEXT NOT NULL , `MemberLName` TEXT NOT NULL , 
`MemberAddress1` TEXT NOT NULL , `MemberAddress2` TEXT , 
`MemberCity` TEXT NOT NULL , `MemberState` TEXT NOT NULL , 
`MemberZip` INT NOT NULL , `MemberCountry` TEXT NOT NULL , 
`MemberEmail` TEXT NOT NULL , `MemberDOB` TEXT NOT NULL , 
`MemberPhone` TEXT NOT NULL , `MemberCardNo` INT NOT NULL , 
PRIMARY KEY (`MemberID`)) ENGINE = InnoDB;";
$query = mysqli_query($connection, $query);
checkQuery($query);



function checkQuery($query)
{
    if($query)
    {
        echo "query was successful <br/>";
    }
    else
    {
        echo "query failed <br/>";
    }
};
    
    ?>