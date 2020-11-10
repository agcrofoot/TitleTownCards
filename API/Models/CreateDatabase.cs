using System;
using System.Data.SQLite;

namespace API.Models
{
    public class CreateDatabase
    {
        public void Create()
        {
            string cs = @"URI = file:C:\Users\birdc\source\repos\TitleTownCards\TTCDatabase.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);
        
        //Dropping and Creating the tables

            //Manager Table
            cmd.CommandText = "DROP TABLE IF EXISTS Manager";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE Manager    (
                ManagerID       INTEGER     PRIMARY KEY,
                ManagerName     TEXT        NOT NULL,
                ManagerPhone    TEXT        NOT NULL,
                ManagerEmail    TEXT        NOT NULL,
                ManagerAddress  TEXT        NOT NULL
                )";
            cmd.ExecuteNonQuery();

            //Employee Table
            cmd.CommandText = "DROP TABLE IF EXISTS Employee";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE Employee    (
                EmployeeID      INTEGER     PRIMARY KEY,
                EmployeeName    TEXT        NOT NULL,
                EmployeePhone   TEXT        NOT NULL,
                EmployeeEmail   TEXT        NOT NULL,
                EmployeeAddress TEXT        NOT NULL,
                ManagerID       INTEGER     NOT NULL
                )";
            cmd.ExecuteNonQuery();

            //Member Table
            cmd.CommandText = "DROP TABLE IF EXISTS Member";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE Member    (
                MemberID        INTEGER PRIMARY KEY,
                MemberFName     TEXT    NOT NULL,
                MemberLName     TEXT    NOT NULL,
                MemberAddress1  TEXT    NOT NULL,
                MemberAddress2  TEXT,
                MemberCity      TEXT    NOT NULL,
                MemberState     TEXT    NOT NULL,
                MemberZip       INTEGER NOT NULL,
                MemberCountry   TEXT    NOT NULL,
                MemberEmail     TEXT    NOT NULL,
                MemberDOB       TEXT    NOT NULL,
                MemberPhone     TEXT    NOT NULL,
                MemberCardNo    INTEGER
                )";
            cmd.ExecuteNonQuery();

            //Product Table
            cmd.CommandText = "DROP TABLE IF EXISTS Product";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE Product    (
                ProductID       INTEGER PRIMARY KEY,
                ProductName     TEXT    NOT NULL,
                ProductPrice    INTEGER NOT NULL,
                ProductType     TEXT    NOT NULL,
                ProductStatus   TEXT    NOT NULL,
                ProductDiscount INTEGER,
                DateOrdered     TEXT    NOT NULL,
                DateAddedToInv  TEXT    NOT NULL,
                ManagerID       INTEGER NOT NULL,
                ManagerName     TEXT    NOT NULL,
                EmployeeID      INTEGER NOT NULL,
                EmployeeName    TEXT    NOT NULL,
                FOREIGN KEY (ManagerID)
                    REFERENCES Manager (ManagerID),
                FOREIGN KEY (EmployeeID)
                    REFERENCES Employee (EmployeeID)
                )";
            cmd.ExecuteNonQuery();

            //Transaction
            cmd.CommandText = "DROP TABLE IF EXISTS Transactions";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE Transactions    (
                TransactionID   INTEGER PRIMARY KEY,
                TransactionDate TEXT    NOT NULL,
                ManagerID       INTEGER NOT NULL,
                ManagerName     TEXT    NOT NULL,
                EmployeeID      INTEGER NOT NULL,
                EmployeeName    TEXT    NOT NULL,
                MemberID        INTEGER,
                FOREIGN KEY (ManagerID)
                    REFERENCES Manager (ManagerID),
                FOREIGN KEY (EmployeeID)
                    REFERENCES Employee (EmployeeID),
                FOREIGN KEY (MemberID)
                    REFERENCES Member (MemberID)
                )";
            cmd.ExecuteNonQuery();

            //Transaction Line Item
            cmd.CommandText = "DROP TABLE IF EXISTS TransactionLineItem";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE TransactionLineItem    (
                ProductID       INTEGER PRIMARY KEY,
                ProductName     TEXT    NOT NULL,
                ProductPrice    INTEGER NOT NULL,
                ProductType     TEXT    NOT NULL,
                ProductDiscount INTEGER,
                TransactionID   INTEGER NOT NULL,
                FOREIGN KEY (ProductID)
                    REFERENCES Product (ProductID),
                FOREIGN KEY (TransactionID)
                    REFERENCES Transactions (TransactionID)
                )";
            cmd.ExecuteNonQuery();

        //Inserting data

            //Manager
            cmd.CommandText = @"INSERT INTO Manager(ManagerName, ManagerPhone, ManagerEmail, ManagerAddress)
                VALUES(@ManagerName, @ManagerPhone, @ManagerEmail, @ManagerAddress)";
            cmd.Parameters.AddWithValue("@ManagerName","Preston Gates");
            cmd.Parameters.AddWithValue("@ManagerPhone","111-111-1111");
            cmd.Parameters.AddWithValue("@ManagerEmail","prgates@crimson.ua.edu");
            cmd.Parameters.AddWithValue("@ManagerAddress","321 Bidgood Ln. Tuscaloosa, AL 35407");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Employee
            cmd.CommandText = @"INSERT INTO Employee(EmployeeName, EmployeePhone, EmployeeEmail, EmployeeAddress, ManagerID)
                VALUES(@EmployeeName, @EmployeePhone, @EmployeeEmail, @EmployeeAddress, @ManagerID)";
            cmd.Parameters.AddWithValue("@EmployeeName","Molly");
            cmd.Parameters.AddWithValue("@EmployeePhone","222-222-2222");
            cmd.Parameters.AddWithValue("@EmployeeEmail","molly@email.com");
            cmd.Parameters.AddWithValue("@EmployeeAddress","321 Hewson Ln. Tuscaloosa, AL 35407");
            cmd.Parameters.AddWithValue("@ManagerID","1");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Member
            cmd.CommandText = @"INSERT INTO Member(MemberFName, MemberLName, MemberAddress1, MemberAddress2, MemberCity, MemberState, MemberZip, MemberCountry, MemberEmail, MemberDOB, MemberPhone, MemberCardNo)
                VALUES(@MemberFName, @MemberLName, @MemberAddress1, @MemberAddress2, @MemberCity, @MemberState, @MemberZip, @MemberCountry, @MemberEmail, @MemberDOB, @MemberPhone, @MemberCardNo)";
            cmd.Parameters.AddWithValue("@MemberFName","Johnny");
            cmd.Parameters.AddWithValue("@MemberLName","Smith");
            cmd.Parameters.AddWithValue("@MemberAddress1","123 Computer Science Dr.");
            cmd.Parameters.AddWithValue("@MemberAddress2","Apt 15");
            cmd.Parameters.AddWithValue("@MemberCity","Tuscaloosa");
            cmd.Parameters.AddWithValue("@MemberState","AL");
            cmd.Parameters.AddWithValue("@MemberZip","35407");
            cmd.Parameters.AddWithValue("@MemberCountry","United States");
            cmd.Parameters.AddWithValue("@MemberEmail","jsmith@crimson.ua.edu");
            cmd.Parameters.AddWithValue("@MemberDOB","05/18/1999");
            cmd.Parameters.AddWithValue("@MemberPhone","333-333-3333");
            cmd.Parameters.AddWithValue("@MemberCardNo","1234");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Product
            cmd.CommandText = @"INSERT INTO Product(ProductName, ProductPrice, ProductType, ProductStatus, ProductDiscount, DateOrdered, DateAddedToInv, ManagerID, ManagerName, EmployeeID, EmployeeName)
                VALUES(@ProductName, @ProductPrice, @ProductType, @ProductStatus, @ProductDiscount, @DateOrdered, @DateAddedToInv, @ManagerID, @ManagerName, @EmployeeID, @EmployeeName)";
            cmd.Parameters.AddWithValue("@ProductName","Babe Ruth Card");
            cmd.Parameters.AddWithValue("@ProductPrice","100000");
            cmd.Parameters.AddWithValue("@ProductType","Baseball Card");
            cmd.Parameters.AddWithValue("@ProductStatus","Sold");
            cmd.Parameters.AddWithValue("@ProductDiscount","0");
            cmd.Parameters.AddWithValue("@DateOrdered","10/11/2020");
            cmd.Parameters.AddWithValue("@DateAddedToInv","11/03/2020");
            cmd.Parameters.AddWithValue("@ManagerID","1");
            cmd.Parameters.AddWithValue("@ManagerName","Preston Gates");
            cmd.Parameters.AddWithValue("@EmployeeID","1");
            cmd.Parameters.AddWithValue("@EmployeeName","Molly");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"INSERT INTO Product(ProductName, ProductPrice, ProductType, ProductStatus, ProductDiscount, DateOrdered, DateAddedToInv, ManagerID, ManagerName, EmployeeID, EmployeeName)
                VALUES(@ProductName, @ProductPrice, @ProductType, @ProductStatus, @ProductDiscount, @DateOrdered, @DateAddedToInv, @ManagerID, @ManagerName, @EmployeeID, @EmployeeName)";
            cmd.Parameters.AddWithValue("@ProductName","Jackie Robinson Card");
            cmd.Parameters.AddWithValue("@ProductPrice","10000");
            cmd.Parameters.AddWithValue("@ProductType","Baseball Card");
            cmd.Parameters.AddWithValue("@ProductStatus","In Stock");
            cmd.Parameters.AddWithValue("@ProductDiscount","0");
            cmd.Parameters.AddWithValue("@DateOrdered","10/13/2020");
            cmd.Parameters.AddWithValue("@DateAddedToInv","11/04/2020");
            cmd.Parameters.AddWithValue("@ManagerID","1");
            cmd.Parameters.AddWithValue("@ManagerName","Preston Gates");
            cmd.Parameters.AddWithValue("@EmployeeID","1");
            cmd.Parameters.AddWithValue("@EmployeeName","Molly");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"INSERT INTO Product(ProductName, ProductPrice, ProductType, ProductStatus, ProductDiscount, DateOrdered, DateAddedToInv, ManagerID, ManagerName, EmployeeID, EmployeeName)
                VALUES(@ProductName, @ProductPrice, @ProductType, @ProductStatus, @ProductDiscount, @DateOrdered, @DateAddedToInv, @ManagerID, @ManagerName, @EmployeeID, @EmployeeName)";
            cmd.Parameters.AddWithValue("@ProductName","Lou Gehrig Card");
            cmd.Parameters.AddWithValue("@ProductPrice","200000");
            cmd.Parameters.AddWithValue("@ProductType","Baseball Card");
            cmd.Parameters.AddWithValue("@ProductStatus","Sold");
            cmd.Parameters.AddWithValue("@ProductDiscount","0");
            cmd.Parameters.AddWithValue("@DateOrdered","10/09/2020");
            cmd.Parameters.AddWithValue("@DateAddedToInv","11/02/2020");
            cmd.Parameters.AddWithValue("@ManagerID","1");
            cmd.Parameters.AddWithValue("@ManagerName","Preston Gates");
            cmd.Parameters.AddWithValue("@EmployeeID","1");
            cmd.Parameters.AddWithValue("@EmployeeName","Molly");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Transactions
            cmd.CommandText = @"INSERT INTO Transactions(TransactionDate, ManagerID, ManagerName, EmployeeID, EmployeeName, MemberID)
                VALUES(@TransactionDate, @ManagerID, @ManagerName, @EmployeeID, @EmployeeName, @MemberID)";
            cmd.Parameters.AddWithValue("@TransactionDate","10/26/2020");
            cmd.Parameters.AddWithValue("@ManagerID","1");
            cmd.Parameters.AddWithValue("@ManagerName","Preston Gates");
            cmd.Parameters.AddWithValue("@EmployeeID","1");
            cmd.Parameters.AddWithValue("@EmployeeName","Molly");
            cmd.Parameters.AddWithValue("@MemberID","1");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            //Transaction Line Item
            cmd.CommandText = @"INSERT INTO TransactionLineItem(ProductID, ProductName, ProductPrice, ProductType, ProductDiscount, TransactionID)
                VALUES(@ProductID, @ProductName, @ProductPrice, @ProductType, @ProductDiscount, @TransactionID)";
            cmd.Parameters.AddWithValue("@ProductID","1");
            cmd.Parameters.AddWithValue("@ProductName","Babe Ruth Card");
            cmd.Parameters.AddWithValue("@ProductPrice","100000");
            cmd.Parameters.AddWithValue("@ProductType","Baseball Card");
            cmd.Parameters.AddWithValue("@ProductDiscount","0");
            cmd.Parameters.AddWithValue("@TransactionID","1");
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
    
}