//Retirieves all products and their information
function getProducts(){
    const getAllProductsApiUrl = "https://localhost:5001/API/Products";
    fetch(getAllProductsApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        let html = "<div class = \"table-responsive\">";
        html +=         "<table class = \"table table-striped\">";
        html +=             "<thead>" +
                                "<tr>" +
                                    "<th scope = \"col\">ProductID</th>" +
                                    "<th scope = \"col\">Name</th>" +
                                    "<th scope = \"col\">Price</th>" +
                                    "<th scope = \"col\">Type</th>" +
                                    "<th scope = \"col\">Status</th>" +
                                    "<th scope = \"col\">Discount</th>" +
                                    "<th scope = \"col\">Date Ordered</th>" +
                                    "<th scope = \"col\">Date Added</th>" +
                                    "<th scope = \"col\">Manager</th>" +
                                    "<th scope = \"col\">Employee</th>" +
                                "</tr>" +
                            "</thead>";
        json.forEach((product)=>{
            html +=         "<tbody>" +
                                "<tr>"+
                                    "<th scope =\"row\">" + product.productID + "</th>" +
                                    "<td>" + product.productName + "</td>" +
                                    "<td>" + product.productPrice + "</td>" +
                                    "<td>" + product.productType + "</td>" +
                                    "<td>" + product.productStatus + "</td>" +
                                    "<td>" + product.productDiscount + "</td>" +
                                    "<td>" + product.dateOrdered + "</td>" +
                                    "<td>" + product.dateAddedToInv + "</td>" +
                                    "<td>" + product.managerName + "</td>" +
                                    "<td>" + product.employeeName + "</td>" +
                                "</tr>"
        });
        html +=             "</tbody>" +
                        "</table>" +
                    "</div>";
        document.getElementById("allProducts").innerHTML = html;
    }).catch(function(error){
        console.log(error);
    });
}

//Retirieves all transactions and their information
function getTransactions(){
    const getAllransactionsApiUrl = "https://localhost:5001/API/Transactions";
    fetch(getAllransactionsApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        let html =  "<div class = \"table-responsive\">";
        html +=         "<table class = \"table table-striped\">";
        html +=             "<thead>" +
                                "<tr>" +
                                    "<th scope = \"col\">Transaction ID</th>" +
                                    "<th scope = \"col\">Date of Transaction</th>" +
                                    "<th scope = \"col\">Total</th>" +
                                    "<th scope = \"col\">Manager ID</th>" +
                                    "<th scope = \"col\">Manager</th>" +
                                    "<th scope = \"col\">Employee ID</th>" +
                                    "<th scope = \"col\">Employee</th>" +
                                    "<th scope = \"col\">Member ID</th>" +
                                "</tr>" +
                            "</thead>";
        json.forEach((transaction)=>{
            html +=         "<tbody>" +
                                "<tr>"+
                                    "<th scope =\"row\">" + transaction.transactionID + "</th>" +
                                    "<td>" + transaction.transactionDate + "</td>" +
                                    "<td>" + transaction.transactionCost + "</td>" +
                                    "<td>" + transaction.managerID + "</td>" +
                                    "<td>" + transaction.managerName + "</td>" +
                                    "<td>" + transaction.employeeID + "</td>" +
                                    "<td>" + transaction.employeeName + "</td>" +
                                    "<td>" + transaction.memberID + "</td>" +
                                "</tr>"
        });
        html +=             "</tbody>" +
                        "</table>" +
                    "</div>";
        document.getElementById("transactions").innerHTML = html;
    }).catch(function(error){
        console.log(error);
    });
}

//Retirieves a single product and its information
function getProduct(ID, tID){
    const getProductApiUrl = "https://localhost:5001/API/Products/" + ID;
    fetch(getProductApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        console.log(tID);
        var html = "<div class = \"container\">";
        html += "<div><p><b>ID: </b></p><p>" + json.productID+ "</p>";
        html += "<p><b>Name: </b></p><p id = \"ProductName\">" + json.productName + "</p>";
        html += "<p><b>Price: </b></p><p>" +  json.productPrice + "</p>";
        html += " <var id = \"ProductType\" style = \"display: none;\">" + json.productType + "</var>";
        html += " <var id = \"ProductDiscount\" style = \"display: none;\">" + json.productDiscount + "</var>";
        html += "<input type=\"submit\" value = \"Add to Cart\" onclick = \"addTLI(" + json.productID + ", " + json.productPrice + ", " + json.productDiscount + "," + tID + ")\"/>";
        html += "</div>";
        document.getElementById("product").innerHTML = html;
    }).catch(function(error){
        console.log(error);
    });
}

//Checks if the phone number entered is in the system then adds the corresponding ID to MemberTransaction
function getMember(memberPhone){
    const getMemberApiUrl = "https://localhost:5001/API/Members";

    fetch(getMemberApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        json.forEach((member)=>{
            console.log(member.memberPhone);
            console.log(memberPhone);
            if(memberPhone == member.memberPhone)
            {
                console.log("went through");
                addTransaction(member.memberID);
                window.location.href = "MemberPOS.html";
            }
            else
            {
                console.log("didn't go through");
            }
        });
    }).catch(function(error){
        console.log(error);
    });
}

//Retrieves an individual Manager Name from an ID
function getManager(ID){
    const getManagerApiUrl = "https://localhost:5001/API/Managers/" + ID;
    fetch(getManagerApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        if(ID == json.managerID)
        {
            console.log("went through");
            var html = " <var id = \"ManagerName\" style = \"display: none;\">" + json.managerName + "</var>";
            document.getElementById("karen").innerHTML = html;
        }
        else
        {
            console.log("didn't go through");
        }
    }).catch(function(error){
        console.log(error);
    });
}

//Retrieves an individual Employee Name from an ID
function getEmployee(ID){
    const getEmployeeApiUrl = "https://localhost:5001/API/Employees/" + ID;
    fetch(getEmployeeApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        if(ID == json.employeeID)
        {
            console.log("went through");
            var html = " <var id = \"EmployeeName\" style = \"display: none;\">" + json.employeeName + "</var>";
            document.getElementById("emp").innerHTML = html;
        }
        else
        {
            console.log("didn't go through");
        }
    }).catch(function(error){
        console.log(error);
    });
}

//Adds to the Transaction Line Item Table
function addTLI(productID, productPrice, productDiscount, tID){
    const addTLIApiUrl = "https://localhost:5001/API/TransactionLineItems";
    const ID = productID;
    const Name = document.getElementById("ProductName").innerHTML;
    const Price = productPrice;
    const Type = document.getElementById("ProductType").innerHTML;
    const Discount = productDiscount;
    const TID = tID;
    console.log(TID);  
    
    fetch(addTLIApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            productID: ID,
            productName: Name,
            productPrice: Price,
            productType: Type,
            productDiscount: Discount,
            transactionID: TID

        })
    }).then((response)=>{
        console.log(response);
        document.forms['AddToCart'].reset();
    })
}
//Starts a blank transaction
function addTransaction(memberID){
    const addTransactionApiUrl = "https://localhost:5001/API/Transactions";
    const MemberID = memberID;

    fetch(addTransactionApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            memberID: MemberID
        })
    }).then((response)=>{
        console.log(response);
    })
}
//Adds Product to Inventory
function addProduct(price, mgrID, manager, empID, employee){
    const addProductApiUrl = "https://localhost:5001/API/Products";
    const Name = document.getElementById("name").value;
    const Price = price;
    const Type = document.getElementById("type").value;
    const DateOrdered = document.getElementById("ordered").value;
    const managerId = mgrID;
    const mName = manager;
    const employeeId = empID;
    const eName = employee;

    fetch(addProductApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            productName: Name,
            productPrice: parseFloat(Price),
            productType: Type,
            dateOrdered: DateOrdered,
            managerID: parseInt(managerId),
            managerName: mName,
            employeeID: parseInt(employeeId),
            employeeName: eName
        })
    })
    .then((response)=>{
        console.log(response);
        document.forms['AddProducts'].reset();
    })
}

//Generates a Transaction Number
function getTransactionID(){
    const transactionApiUrl = "https://localhost:5001/API/Transactions";
    var TransactionID = 1;
    fetch(transactionApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        json.forEach((transaction)=>{
            console.log(transaction.transactionID);
            console.log(TransactionID);
            while(TransactionID == transaction.transactionID)
            {
                TransactionID++;
                console.log(TransactionID);
            }
            document.getElementById('tID').innerHTML = TransactionID;
        });
    }).catch(function(error){
        console.log(error);
    });
}