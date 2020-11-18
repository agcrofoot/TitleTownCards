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

//PRODUCT TABLE
echo "Product:<br/>";
$query = "DROP TABLE IF EXISTS Product";
$query = mysqli_query($connection, $query);
checkQuery($query);

$query = "CREATE TABLE `ttowncards`.`Product` 
( `ProductID` INT NOT NULL AUTO_INCREMENT , 
`ProductName` TEXT NOT NULL , `ProductPrice` 
INT NOT NULL , `ProductStatus` TEXT NOT NULL , 
`ProductDiscount` INT , `DateOrdered` 
TEXT NOT NULL , `DateAddedToInv` TEXT NOT NULL ,
`ManagerID` INT NOT NULL , `ManagerName` 
TEXT NOT NULL , `EmployeeID` INT NOT NULL ,
`EmployeeName` TEXT NOT NULL , PRIMARY KEY 
(`ProductID`) , FOREIGN KEY (`ManagerID`) , FOREIGN KEY (`EmployeeID`)) ENGINE = InnoDB;";
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