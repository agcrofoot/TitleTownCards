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