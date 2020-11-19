<?php include "db.php"; ?>

<?php 
global $connection;

// //MANAGER TABLE
// echo "Manager:<br/>";
// $query = "DROP TABLE IF EXISTS Manager";
// $query = mysqli_query($connection, $query);
// checkQuery($query);

// $query = "CREATE TABLE `ttowncards`.`Manager` 
// (`ManagerID`        INT NOT NULL , 
// `ManagerName`       TEXT NOT NULL ,
// `ManagerPhone`      TEXT NOT NULL , 
// `ManagerEmail`      TEXT NOT NULL , 
// `ManagerAddress`    TEXT NOT NULL , 
// PRIMARY KEY         (`ManagerID`)
// ) ENGINE = InnoDB;";
// $query = mysqli_query($connection, $query);
// checkQuery($query);

// //EMPLOYEE TABLE 
// echo "Employee:<br/>";
// $query = "DROP TABLE IF EXISTS Employee";
// $query = mysqli_query($connection, $query);
// checkQuery($query);

// $query = "CREATE TABLE `ttowncards`.`Employee` 
// (`EmployeeID`       INT NOT NULL , 
// `EmployeeName`      TEXT NOT NULL , 
// `EmployeePhone`     TEXT NOT NULL , 
// `EmployeeAddress`   TEXT NOT NULL , 
// `ManagerID`         INT NOT NULL , 
// PRIMARY KEY         (`EmployeeID`),
// FOREIGN KEY         (`ManagerID`)
//     REFERENCES `Manager` (`ManagerID`)
// ) ENGINE = InnoDB;";
// $query = mysqli_query($connection, $query);
// checkQuery($query);

// //MEMBER TABLE
// echo "Member:<br/>";
// $query = "DROP TABLE IF EXISTS Member";
// $query = mysqli_query($connection, $query);
// checkQuery($query);

// $query = "CREATE TABLE `ttowncards`.`Member`
// (`MemberID`         INT NOT NULL     AUTO_INCREMENT ,
// `MemberFName`       TEXT NOT NULL ,
// `MemberLName`       TEXT NOT NULL ,
// `MemberAddress1`    TEXT NOT NULL ,
// `MemberAddress2`    TEXT ,
// `MemberCity`        TEXT NOT NULL ,
// `MemberState`       TEXT NOT NULL ,
// `MemberZip`         INT NOT NULL ,
// `MemberCountry`     TEXT NOT NULL ,
// `MemberEmail`       TEXT NOT NULL ,
// `MemberDOB`         TEXT NOT NULL ,
// `MemberPhone`       TEXT NOT NULL ,
// `MemberCardNo`      INT ,
// PRIMARY KEY         (`MemberID`)
// ) ENGINE = InnoDB;";
// $query = mysqli_query($connection, $query);
// checkQuery($query);

// //PRODUCT TABLE
// echo "Product:<br/>";
// $query = "DROP TABLE IF EXISTS Product";
// $query = mysqli_query($connection, $query);
// checkQuery($query);

// $query = "CREATE TABLE `ttowncards`.`Product` 
// (`ProductID`        INT NOT NULL    AUTO_INCREMENT , 
// `ProductName`       TEXT NOT NULL , 
// `ProductPrice`      INT NOT NULL , 
// `ProductStatus`     TEXT NOT NULL , 
// `ProductDiscount`   INT , 
// `DateOrdered`       TEXT NOT NULL , 
// `DateAddedToInv`    TEXT NOT NULL ,
// `ManagerID`         INT NOT NULL , 
// `ManagerName`       TEXT NOT NULL , 
// `EmployeeID`        INT NOT NULL ,
// `EmployeeName`      TEXT NOT NULL , 
// PRIMARY KEY         (`ProductID`) , 
// FOREIGN KEY         (`ManagerID`)
//     REFERENCES `Manager` (`ManagerID`), 
// FOREIGN KEY (`EmployeeID`)
//     REFERENCES `Employee` (`EmployeeID`)
// ) ENGINE = InnoDB;";
// $query = mysqli_query($connection, $query);
// checkQuery($query);
 
// //TRANSACTIONS TABLE
// echo "Transactions:<br/>";
// $query = "DROP TABLE IF EXISTS Transactions";
// $query = mysqli_query($connection, $query);
// checkQuery($query);

// $query = "CREATE TABLE `ttowncards`.`Transactions` 
// (`TransactionID`    INT NOT NULL , 
// `TransactionDate`   TEXT NOT NULL , 
// `TransactionCost`   INT NOT NULL , 
// `ManagerID`         INT NOT NULL , 
// `ManagerName`       TEXT NOT NULL , 
// `EmployeeID`        INT NOT NULL , 
// `EmployeeName`      TEXT NOT NULL ,
// `MemberID`          INT , 
// PRIMARY KEY         (`TransactionID`) , 
// FOREIGN KEY         (`ManagerID`)
//     REFERENCES `Manager` (`ManagerID`),
// FOREIGN KEY         (`EmployeeID`)
//     REFERENCES `Employee` (`EmployeeID`),
// FOREIGN KEY         (`MemberID`)
//     REFERENCES `Member` (`MemberID`)
// ) ENGINE = InnoDB;";
// $query = mysqli_query($connection, $query);
// checkQuery($query);

// //TRANSACTION LINE ITEM TABLE
// echo "TransactionLineItem:<br/>";
// $query = "DROP TABLE IF EXISTS TransactionLineItem";
// $query = mysqli_query($connection, $query);
// checkQuery($query);

// $query = "CREATE TABLE `ttowncards`.`TransactionLineItem` 
// (`ProductID`        INT NOT NULL ,
// `ProductName`       TEXT NOT NULL ,
// `ProductPrice`      INT NOT NULL ,
// `ProductType`       TEXT NOT NULL ,
// `ProductDiscount`   INT ,
// `TransactionID`     INT NOT NULL ,
// PRIMARY KEY         (`ProductID`) ,
// FOREIGN KEY         (`ProductID`)
//     REFERENCES `Product` (`ProductID`) ,
// FOREIGN KEY         (`TransactionID`)
//     REFERENCES `Transactions` (`TransactionID`)
// ) ENGINE = InnoDB;";
// $query = mysqli_query($connection, $query);
// checkQuery($query);

// $query = "INSERT INTO `ttowncards`.`Manager` (`ManagerID`, `ManagerName`, `ManagerPhone`, `ManagerEmail`, `ManagerAddress`)
//         VALUES(100, 'Preston Gates', '111-111-1111', 'prgates@crimson.ua.edu', '321 Bidgood Ln. Tuscaloosa, AL 35407')";
//     $query = mysqli_query($connection, $query);
//     checkQuery($query);

// $query = "INSERT INTO `ttowncards`.`Manager` (`ManagerID`, `ManagerName`, `ManagerPhone`, `ManagerEmail`, `ManagerAddress`)
//         VALUES(200, 'Bobby Smith', '121-121-1221', 'bobsmith@crimson.ua.edu', '330 Bidgood Ln. Tuscaloosa, AL 35407')";
//         $query = mysqli_query($connection, $query);
//         checkQuery($query);

//             //Employee
// $query = "INSERT INTO `ttowncards`.`Employee` (`EmployeeID`, `EmployeeName`, `EmployeePhone`, `EmployeeEmail`, `EmployeeAddress`, `ManagerID`)
//         VALUES(10, 'Molly', '222-222-2222', 'molly@email.com', '321 Hewson Ln. Tuscaloosa, AL 35407', 100)";
//         $query = mysqli_query($connection, $query);
//         checkQuery($query);

// $query = "INSERT INTO `ttowncards`.`Employee` (`EmployeeID`, `EmployeeName`, `EmployeePhone`, `EmployeeEmail`, `EmployeeAddress`, `ManagerID`)
//         VALUES(20, 'Kevin', '212-212-2112', 'kevin@email.com', '330 Hewson Ln. Tuscaloosa, AL 35407', 200)";
//         $query = mysqli_query($connection, $query);
//         checkQuery($query);

//             //Member
// $query = "INSERT INTO `ttowncards`.`Member` (`MemberFName`, `MemberLName`, `MemberAddress1`, `MemberAddress2`, `MemberCity`, `MemberState`, `MemberZip`, `MemberCountry`, `MemberEmail`, `MemberDOB`, `MemberPhone`, `MemberCardNo`)
//         VALUES('Johnny', 'Smith', '123 Computer Science Dr.', 'Apt 15', 'Tuscaloosa', 'AL', 35407, 'United States', 'jsmith@crimson.ua.edu', '05/18/1999', '333-333-3333', 1234)";
//         $query = mysqli_query($connection, $query);
//         checkQuery($query);

            //Product
$query = "INSERT INTO `ttowncards`.`Product` (`ProductName`, `ProductPrice`, `ProductType`, `ProductStatus`, `ProductDiscount`, `DateOrdered`, `DateAddedToInv`, `ManagerID`, `ManagerName`, `EmployeeID`, `EmployeeName`)
        VALUES('2020 Albert Pujols - Los Angeles Angels: PSA 7', 10.00, 'Baseball Card', 'Sold', 0, '10/11/2020', '11/03/2020', 100, 'Preston Gates', 10, 'Molly')";
        $query = mysqli_query($connection, $query);
        checkQuery($query);

$query = "INSERT INTO `ttowncards`.`Product` (`ProductName`, `ProductPrice`, `ProductType`, `ProductStatus`, `ProductDiscount`, `DateOrdered`, `DateAddedToInv`, `ManagerID`, `ManagerName`, `EmployeeID`, `EmployeeName`)
        VALUES('2020 Dylan Bundy - Los Angeles Angels: PSA 6', 9.50, 'Baseball Card', 'In Stock', 0, '10/13/2020', '11/04/2020', 200, 'Bobby Smith', 20, 'Kevin')";
        $query = mysqli_query($connection, $query);
        checkQuery($query);
        
$query = "INSERT INTO `ttowncards`.`Product` (`ProductName`, `ProductPrice`, `ProductType`, `ProductStatus`, `ProductDiscount`, `DateOrdered`, `DateAddedToInv`, `ManagerID`, `ManagerName`, `EmployeeID`, `EmployeeName`)
        VALUES('2020 Tommy La Stella - Los Angeles Angels: PSA 6', 9.50, 'Baseball Card', 'In Stock', 0, '10/09/2020', '11/02/2020', 200, 'Bobby Smith', 10, 'Molly')";
        $query = mysqli_query($connection, $query);
        checkQuery($query);

$query = "INSERT INTO `ttowncards`.`Product` (`ProductName`, `ProductPrice`, `ProductType`, `ProductStatus`, `ProductDiscount`, `DateOrdered`, `DateAddedToInv`, `ManagerID`, `ManagerName`, `EmployeeID`, `EmployeeName`)
        VALUES('2020 Matt Thais - Los Angeles Angels: PSA 7', 10.50, 'Baseball Card', 'In Stock', 0, '10/15/2020', '11/02/2020', 100, 'Preston Gates', 20, 'Kevin')";
        $query = mysqli_query($connection, $query);
        checkQuery($query);

$query = "INSERT INTO `ttowncards`.`Product` (`ProductName`, `ProductPrice`, `ProductType`, `ProductStatus`, `ProductDiscount`, `DateOrdered`, `DateAddedToInv`, `ManagerID`, `ManagerName`, `EmployeeID`, `EmployeeName`)
        VALUES('2020 Patrick Sandoval - Los Angeles Angels: PSA 6', 9.50, 'Baseball Card', 'In Stock', 0, '10/06/2020', '11/02/2020', 100, 'Preston Gates', 10, 'Molly')";
        $query = mysqli_query($connection, $query);
        checkQuery($query);

            //Transactions
$query = "INSERT INTO `ttowncards`.`Transactions`(`TransactionID`, `TransactionDate`, `TransactionCost`, `ManagerID`, `ManagerName`, `EmployeeID`, `EmployeeName`, `MemberID`)
        VALUES(1, '10/26/2020', 10.00, 100, 'Preston Gates', 20, 'Kevin', 1)";
        $query = mysqli_query($connection, $query);
        checkQuery($query);

            //Transaction Line Item
$query = "INSERT INTO `ttowncards`.`TransactionLineItem`(`ProductID`, `ProductName`, `ProductPrice`, `ProductType`, `ProductDiscount`, `TransactionID`)
        VALUES(1, '2020 Albert Pujols - Los Angeles Angels: PSA 7', 10.00, 'Baseball Card', 0, 1)";
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