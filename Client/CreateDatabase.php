<?php include "db.php"; ?>

<?php 

CreateDatabase();

function CreateDatabase(){
global $connection;

//Dropping all Tables
echo "DROPPING ALL TABLES: <br/>";
$query = "SET FOREIGN_KEY_CHECKS = 0;"; //disabling foreign key checks
$query = mysqli_query($connection, $query);
checkQuery($query);

$query = "DROP TABLE `employee`, 
`manager`, `member`, `product`, 
`transactionlineitem`, `transactions`;"; 
$query = mysqli_query($connection, $query);
checkQuery($query);

$query = "SET FOREIGN_KEY_CHECKS = 1;"; //enabling foreign key checks
$query = mysqli_query($connection, $query);
checkQuery($query);
echo "<br/>";

echo "CREATING TABLES: <br/>";
//MANAGER TABLE
echo "Manager:<br/>";
$query = "DROP TABLE IF EXISTS Manager";
$query = mysqli_query($connection, $query);
checkQuery($query);

$query = "CREATE TABLE `ttowncards`.`Manager` 
(`ManagerID`        INT NOT NULL AUTO_INCREMENT , 
`ManagerName`       TEXT NOT NULL ,
`ManagerPhone`      TEXT NOT NULL , 
`ManagerEmail`      TEXT NOT NULL , 
`ManagerAddress`    TEXT NOT NULL , 
PRIMARY KEY         (`ManagerID`)
) ENGINE = InnoDB;";
$query = mysqli_query($connection, $query);
checkQuery($query);
echo "<br/>";

//EMPLOYEE TABLE 
echo "Employee:<br/>";
$query = "DROP TABLE IF EXISTS Employee";
$query = mysqli_query($connection, $query);
checkQuery($query);

$query = "CREATE TABLE `ttowncards`.`employee` 
( `EmployeeID` INT NOT NULL AUTO_INCREMENT , 
`EmployeeName` TEXT NOT NULL , 
`EmployeePhone` TEXT NOT NULL , 
`EmployeeEmail` TEXT NOT NULL ,
`EmployeeAddress` TEXT NOT NULL , 
PRIMARY KEY (`EmployeeID`)) 
ENGINE = InnoDB;";
$query = mysqli_query($connection, $query);
checkQuery($query);

echo "<br/>";

//MEMBER TABLE
echo "Member:<br/>";
$query = "DROP TABLE IF EXISTS `member`";
$query = mysqli_query($connection, $query);
checkQuery($query);

$query = "CREATE TABLE `ttowncards`.`Member`
(`MemberID`         INT NOT NULL     AUTO_INCREMENT ,
`MemberFName`       TEXT NOT NULL ,
`MemberLName`       TEXT NOT NULL ,
`MemberAddress1`    TEXT NOT NULL ,
`MemberEmail`       TEXT NOT NULL ,
`MemberDOB`         TEXT NOT NULL ,
`MemberPhone`       TEXT NOT NULL ,
PRIMARY KEY         (`MemberID`)
) ENGINE = InnoDB;";
$query = mysqli_query($connection, $query);
checkQuery($query);
echo "<br/>";

//PRODUCT TABLE
echo "Product:<br/>";
$query = "DROP TABLE IF EXISTS Product";
$query = mysqli_query($connection, $query);
checkQuery($query);

$query = "CREATE TABLE `ttowncards`.`Product` 
(`ProductID`        INT NOT NULL    AUTO_INCREMENT , 
`ProductName`       TEXT NOT NULL , 
`ProductPrice`      INT NOT NULL , 
`ProductType`       TEXT NOT NULL ,
`ProductStatus`     TEXT NOT NULL , 
`ProductDiscount`   INT , 
`DateOrdered`       TEXT NOT NULL , 
`DateAddedToInv`    TEXT ,
`ManagerID`         INT  , 
`EmployeeID`        INT  ,
PRIMARY KEY         (`ProductID`) , 
FOREIGN KEY         (`ManagerID`)
    REFERENCES `Manager` (`ManagerID`), 
FOREIGN KEY (`EmployeeID`)
    REFERENCES `Employee` (`EmployeeID`)
) ENGINE = InnoDB;";
$query = mysqli_query($connection, $query);
checkQuery($query);
echo "<br/>";
 
//TRANSACTIONS TABLE
echo "Transactions:<br/>";
$query = "DROP TABLE IF EXISTS Transactions";
$query = mysqli_query($connection, $query);
checkQuery($query);

$query = "CREATE TABLE `ttowncards`.`Transactions` 
(`TransactionID`    INT NOT NULL AUTO_INCREMENT ,  
`TransactionDate`   TEXT NOT NULL , 
`TransactionCost`   DOUBLE NOT NULL , 
`ManagerID`         INT NOT NULL , 
`EmployeeID`        INT NOT NULL , 
`MemberID`          INT , 
PRIMARY KEY         (`TransactionID`) , 
FOREIGN KEY         (`ManagerID`)
    REFERENCES `Manager` (`ManagerID`),
FOREIGN KEY         (`EmployeeID`)
    REFERENCES `Employee` (`EmployeeID`),
FOREIGN KEY         (`MemberID`)
    REFERENCES `Member` (`MemberID`)
) ENGINE = InnoDB;";
$query = mysqli_query($connection, $query);
checkQuery($query);
echo "<br/>";

//TRANSACTION LINE ITEM TABLE
echo "TransactionLineItem:<br/>";
$query = "DROP TABLE IF EXISTS TransactionLineItem";
$query = mysqli_query($connection, $query);
checkQuery($query);

$query = "CREATE TABLE `ttowncards`.`transactionlineitem` 
( `TransactionLineID` INT NOT NULL AUTO_INCREMENT , 
`ProductID` INT NOT NULL , `TransactionID` INT NOT NULL , 
PRIMARY KEY (`TransactionLineID`)) ENGINE = InnoDB;";

$query = mysqli_query($connection, $query);
checkQuery($query);
echo "<br/>";

//SEEDING THE DATABASE 
echo "SEEDING THE DATABASE: <br/>";
                //Manager
                echo "Manager: <br/>";
$query = "INSERT INTO `ttowncards`.`Manager` (`ManagerID`, `ManagerName`, `ManagerPhone`, `ManagerEmail`, `ManagerAddress`)
        VALUES(100, 'Preston Gates', '111-111-1111', 'prgates@crimson.ua.edu', '321 Bidgood Ln. Tuscaloosa, AL 35407')";
    $query = mysqli_query($connection, $query);
    checkQuery($query);

$query = "INSERT INTO `ttowncards`.`Manager` (`ManagerID`, `ManagerName`, `ManagerPhone`, `ManagerEmail`, `ManagerAddress`)
        VALUES(200, 'Bobby Smith', '121-121-1221', 'bobsmith@crimson.ua.edu', '330 Bidgood Ln. Tuscaloosa, AL 35407')";
        $query = mysqli_query($connection, $query);
        checkQuery($query);

            //Employee
            echo "<br/> Employee: <br/>";
$query = "INSERT INTO `ttowncards`.`Employee` (`EmployeeName`, `EmployeePhone`, `EmployeeEmail`, `EmployeeAddress`)
        VALUES('Molly', '222-222-2222', 'molly@email.com', '321 Hewson Ln. Tuscaloosa, AL 35407')";
        $query = mysqli_query($connection, $query);
        checkQuery($query);

$query = "INSERT INTO `ttowncards`.`Employee` (`EmployeeName`, `EmployeePhone`, `EmployeeEmail`, `EmployeeAddress`)
        VALUES('Kevin', '212-212-2112', 'kevin@email.com', '330 Hewson Ln. Tuscaloosa, AL 35407')";
        $query = mysqli_query($connection, $query);
        checkQuery($query);

            //Member
            echo "<br/> Member: <br/>";
$query = "INSERT INTO `ttowncards`.`Member` (`MemberFName`, `MemberLName`, `MemberAddress1`, `MemberEmail`, `MemberDOB`, `MemberPhone`)
        VALUES('Johnny', 'Smith', '123 Computer Science Dr., Tuscaloosa, AL 35407', 'jsmith@crimson.ua.edu', '05/18/1999', '333-333-3333')";
        $query = mysqli_query($connection, $query);
        checkQuery($query);

$query = "INSERT INTO `ttowncards`.`Member` (`MemberFName`, `MemberLName`, `MemberAddress1`, `MemberEmail`, `MemberDOB`, `MemberPhone`)
        VALUES('Lisa', 'Jones', '1831 Champions Dr., Tuscaloosa, AL 35407', 'lisaj@crimson.ua.edu', '11/28/1979', '111-111-1111')";
        $query = mysqli_query($connection, $query);
        checkQuery($query);

$query = "INSERT INTO `ttowncards`.`Member` (`MemberFName`, `MemberLName`, `MemberAddress1`, `MemberEmail`, `MemberDOB`, `MemberPhone`)
        VALUES('George', 'Daniels', '678 Oracle Dr., Tuscaloosa, AL 35407', 'gdaniels6@crimson.ua.edu', '01/04/1970', '222-222-2222')";
        $query = mysqli_query($connection, $query);
        checkQuery($query);       

            //Product
            echo "<br/> Product: <br/>";
$query = "INSERT INTO `ttowncards`.`Product` (`ProductName`, `ProductPrice`, `ProductType`, `ProductStatus`, `ProductDiscount`, `DateOrdered`, `DateAddedToInv`, `EmployeeID`)
        VALUES('2020 Albert Pujols - Los Angeles Angels: PSA 7', 10.00, 'Baseball Card', 'Sold', 0, '10/11/2020', '11/03/2020', 1)";
        $query = mysqli_query($connection, $query);
        checkQuery($query);

$query = "INSERT INTO `ttowncards`.`Product` (`ProductName`, `ProductPrice`, `ProductType`, `ProductStatus`, `ProductDiscount`, `DateOrdered`, `DateAddedToInv`, `ManagerID`, `EmployeeID`)
        VALUES('2020 Dylan Bundy - Los Angeles Angels: PSA 6', 9.50, 'Baseball Card', 'In Stock', 0, '10/13/2020', '11/04/2020', 200, 2)";
        $query = mysqli_query($connection, $query);
        checkQuery($query);
        
$query = "INSERT INTO `ttowncards`.`Product` (`ProductName`, `ProductPrice`, `ProductType`, `ProductStatus`, `ProductDiscount`, `DateOrdered`, `DateAddedToInv`, `ManagerID`, `EmployeeID`)
        VALUES('2020 Tommy La Stella - Los Angeles Angels: PSA 6', 9.50, 'Baseball Card', 'In Stock', 0, '10/09/2020', '11/02/2020', 200, 1)";
        $query = mysqli_query($connection, $query);
        checkQuery($query);

$query = "INSERT INTO `ttowncards`.`Product` (`ProductName`, `ProductPrice`, `ProductType`, `ProductStatus`, `ProductDiscount`, `DateOrdered`, `DateAddedToInv`, `ManagerID`, `EmployeeID`)
        VALUES('2020 Matt Thais - Los Angeles Angels: PSA 7', 10.50, 'Baseball Card', 'In Stock', 0, '10/15/2020', '11/02/2020', 100, 2)";
        $query = mysqli_query($connection, $query);
        checkQuery($query);

$query = "INSERT INTO `ttowncards`.`Product` (`ProductName`, `ProductPrice`, `ProductType`, `ProductStatus`, `ProductDiscount`, `DateOrdered`, `DateAddedToInv`, `ManagerID`, `EmployeeID`)
        VALUES('2020 Patrick Sandoval - Los Angeles Angels: PSA 6', 9.50, 'Baseball Card', 'In Stock', 0, '10/06/2020', '11/02/2020', 100, 1)";
        $query = mysqli_query($connection, $query);
        checkQuery($query);

            //Transactions
            echo "<br/> Transactions: <br/>";
$query = "INSERT INTO `ttowncards`.`Transactions`(`TransactionDate`, `TransactionCost`, `ManagerID`, `EmployeeID`, `MemberID`)
        VALUES('10/26/2020', 32.18, 100, 2, 1)";
        $query = mysqli_query($connection, $query);
        checkQuery($query);

$query = "INSERT INTO `ttowncards`.`Transactions`(`TransactionDate`, `TransactionCost`, `ManagerID`, `EmployeeID`, `MemberID`)
        VALUES('10/26/2020', 10.00, 200, 1, 2)";
        $query = mysqli_query($connection, $query);
        checkQuery($query);

$query = "INSERT INTO `ttowncards`.`Transactions`(`TransactionDate`, `TransactionCost`, `ManagerID`, `EmployeeID`, `MemberID`)
        VALUES('10/28/2020', 45.67, 200, 2, 3)";
        $query = mysqli_query($connection, $query);
        checkQuery($query);

            //Transaction Line Item
            echo "<br/> TransactionLineItem: <br/>";
$query = "INSERT INTO `ttowncards`.`TransactionLineItem`(`ProductID`, `TransactionID`)
        VALUES(3, 1)";
        $query = mysqli_query($connection, $query);
        checkQuery($query);

$query = "INSERT INTO `ttowncards`.`TransactionLineItem`(`ProductID`, `TransactionID`)
        VALUES(4, 2)";
        $query = mysqli_query($connection, $query);
        checkQuery($query);

$query = "INSERT INTO `ttowncards`.`TransactionLineItem`(`ProductID`, `TransactionID`)
        VALUES(2, 2)";
        $query = mysqli_query($connection, $query);
        checkQuery($query);
}

function checkQuery($query)
{
    global $connection;
    if($query)
    {
        echo "query was successful <br/>";
    }
    else
    {
        echo "query failed " . mysqli_error($connection) . "<br/>";
    }
};

?>