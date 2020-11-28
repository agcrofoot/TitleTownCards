//GETs

//Retrieves all products and their information
function getProducts(){
    const getAllProductsApiUrl = "https://title-town-cards-api.herokuapp.com/API/Products";
    fetch(getAllProductsApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){ 
        let html = '';
        json.forEach((product)=>{
            html +=     "<tr>"+
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
        document.getElementById("allProducts").innerHTML = html;
    }).catch(function(error){
        console.log(error);
    });
}

//Retrieves all transactions and their information
function getTransactions(){
    const getAllTransactionsApiUrl = "https://title-town-cards-api.herokuapp.com/API/Transactions";
    fetch(getAllTransactionsApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        let html =  '';
        json.forEach((transaction)=>{
            html +=         "<tr>"+
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
        document.getElementById("transactions").innerHTML = html;
    }).catch(function(error){
        console.log(error);
    });
}

//Retrieves all members and their information
function getMembers(){
    const getAllMembersApiUrl = "https://title-town-cards-api.herokuapp.com/API/Members";
    fetch(getAllMembersApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){ 
        let html = '';
        json.forEach((member)=>{
            html +=     "<tr>"+
                            "<th scope =\"row\">" + member.memberID + "</th>" +
                            "<td>" + member.memberName + "</td>" +
                            "<td>" + member.memberAddress + "</td>" +
                            "<td>" + member.memberEmail + "</td>" +
                            "<td>" + member.memberDOB + "</td>" +
                            "<td>" + member.memberPhone + "</td>" +
                        "</tr>"
        });
        document.getElementById("allMembers").innerHTML = html;
    }).catch(function(error){
        console.log(error);
    });
}

//Retrieves all managers and their information
function getManagers(){
    const getAllManagersApiUrl = "https://title-town-cards-api.herokuapp.com/API/Managers";
    fetch(getAllManagersApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){ 
        let html = '';
        json.forEach((manager)=>{
            html +=     "<tr>"+
                            "<th scope =\"row\">" + manager.managerID + "</th>" +
                            "<td>" + manager.managerName + "</td>" +
                            "<td>" + manager.managerPhone + "</td>" +
                            "<td>" + manager.managerEmail + "</td>" +
                            "<td>" + manager.managerAddress + "</td>" +
                        "</tr>"
        });
        document.getElementById("allManagers").innerHTML = html;
    }).catch(function(error){
        console.log(error);
    });
}

//Retrieves all employees and their information
function getEmployees(){
    const getAllEmployeesApiUrl = "https://title-town-cards-api.herokuapp.com/API/Employees";
    fetch(getAllEmployeesApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){ 
        let html = '';
        json.forEach((employee)=>{
            html +=     "<tr>"+
                            "<th scope =\"row\">" + employee.employeeID + "</th>" +
                            "<td>" + employee.employeeName + "</td>" +
                            "<td>" + employee.employeePhone + "</td>" +
                            "<td>" + employee.employeeEmail + "</td>" +
                            "<td>" + employee.employeeAddress + "</td>" +
                        "</tr>"
        });
        document.getElementById("allEmployees").innerHTML = html;
    }).catch(function(error){
        console.log(error);
    });
}

//Retrieves a single product and its information
function getProduct(ID, managerName, managerID, employeeName, employeeID, TID, memberName, memberID){
    const getProductApiUrl = "https://title-town-cards-api.herokuapp.com/API/Products/" + ID;
   fetch(getProductApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        var html = "<div class = \"container\">";
        html += "<div><p><b>ID: </b></p><p>" + json.productID+ "</p>";
        html += "<p><b>Name: </b></p><p id = \"ProductName\">" + json.productName + "</p>";
        html += "<p><b>Price: </b></p><p>" +  json.productPrice + "</p>";
        html += "<var id = \"ProductType\" style = \"display: none;\">" + json.productType + "</var>";
        html += "<var id = \"ProductDiscount\" style = \"display: none;\">" + json.productDiscount + "</var>";
        html += "<var id = \"TID\" style = \"display: none;\">" + TID + "</var>";
        html += "<var id = \"ManagerName\" style = \"display: none;\">" + managerName + "</var>";
        html += "<var id = \"ManagerID\" style = \"display: none;\">" + managerID + "</var>";
        html += "<var id = \"EmployeeName\" style = \"display: none;\">" + employeeName + "</var>";
        html += "<var id = \"EmployeeID\" style = \"display: none;\">" + employeeID + "</var>";
        html += "<var id = \"MemberName\" style = \"display: none;\">" + memberName + "</var>";
        html += "<var id = \"MemberID\" style = \"display: none;\">" + memberID + "</var>";
        html += "<input type=\"submit\" value = \"Add to Cart\" onclick = \"addTLI(" + json.productID + ", " + json.productPrice + ", " + json.productDiscount + ", " + managerID + ", " + employeeID + ", " + memberID + ")\"/>";
        html += "</div>";
        document.getElementById("product").innerHTML = html;
    }).catch(function(error){
        console.log(error);
        var html = "<p>\"That item could not be found in our system. Please enter a valid ID.\"</p>";
        document.getElementById("product").innerHTML = html;
    });
}

//Checks if the phone number entered is in the system then adds the corresponding ID to MemberTransaction
function getMember(memberPhone, managerID, managerName, employeeID, employeeName){
    const getMemberApiUrl = "https://title-town-cards-api.herokuapp.com/API/Members";
    console.log(getMemberApiUrl);
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
                getMemTransactionID(managerID, managerName, employeeID, employeeName, member.memberID, member.memberName);
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

//Retrieves an individual Manager from an ID
function getManager(ID){
    const getManagerApiUrl = "https://title-town-cards-api.herokuapp.com/API/Managers";
    console.log(getManagerApiUrl);
    fetch(getManagerApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        var html = '';
        json.forEach((manager)=>{
            console.log(manager.managerID);
            console.log(ID);
            if(ID == manager.managerID)
            {
                console.log("went through");
                console.log(manager.managerName);
                html += "<var id = \"ManagerID\">" + manager.managerID + "</var>" + 
                        "<var id = \"ManagerName\">" + manager.managerName + "</var>" + 
                        "<var id = \"ManagerPhone\">" + manager.managerPhone + "</var>" + 
                        "<var id = \"ManagerEmail\">" + manager.managerEmail + "</var>" + 
                        "<var id = \"ManagerAddress\">" + manager.managerAddress + "</var>";
            }
            else
            {
                console.log("didn't go through");
            }
        });
        document.getElementById("karen").innerHTML = html;
    }).catch(function(error){
        console.log(error);
    });
}

//Retrieves an individual Employee Name from an ID
function getEmployee(ID){
    const getEmployeeApiUrl = "https://title-town-cards-api.herokuapp.com/API/Employees";
    console.log(getEmployeeApiUrl);
    fetch(getEmployeeApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        var html = '';
        json.forEach((employee)=>{
            console.log(employee.employeeID);
            console.log(ID);
            if(ID == employee.employeeID)
            {
                console.log("went through");
                console.log(employee.employeeName);
                html += "<var id = \"EmployeeID\">" + employee.employeeID + "</var>" + 
                        "<var id = \"EmployeeName\">" + employee.employeeName + "</var>" + 
                        "<var id = \"EmployeePhone\">" + employee.employeePhone + "</var>" + 
                        "<var id = \"EmployeeEmail\">" + employee.employeeEmail + "</var>" + 
                        "<var id = \"EmployeeAddress\">" + employee.employeeAddress + "</var>";
            }
            else
            {
                console.log("didn't go through");
            }
        });
        document.getElementById("emp").innerHTML = html;
    }).catch(function(error){
        console.log(error);
    });
}

//Generates a Transaction Number
function getTransactionID(managerID, managerName, employeeID, employeeName){
    const transactionApiUrl = "https://title-town-cards-api.herokuapp.com/API/Transactions";
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
        });
        transactionCost = 0;
        addTransaction(TransactionID, transactionCost, managerID, managerName, employeeID, employeeName);
    }).catch(function(error){
        console.log(error);
    });
}

//Generates a member transaction ID
function getMemTransactionID(managerID, managerName, employeeID, employeeName, memberID, memberName){
    const memTransactionApiUrl = "https://title-town-cards-api.herokuapp.com/API/Transactions";
    var TransactionID = 1;
    fetch(memTransactionApiUrl).then(function(response){
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
        });
        transactionCost = 0;
        addMemTransaction(TransactionID, transactionCost, managerID, managerName, employeeID, employeeName, memberID, memberName);

    }).catch(function(error){
        console.log(error);
    });
}

//Shows transaction line items in the person's cart
function getTLI(TID, managerName, managerID, employeeName, employeeID, memberName, memberID){
    const getTLIApiUrl = "https://title-town-cards-api.herokuapp.com/API/TransactionLineItems";
    fetch(getTLIApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        var html =  "<ul class=\"list-group mb-3\" style = \"max-width: 300px; justify-content: left;\">";
        var discount = 0;
        var Total = 0;
        json.forEach((lineItem) => {
            console.log(TID);
            console.log(lineItem.transactionID);
            sessionStorage.setItem("TID", TID);
            sessionStorage.setItem("managerName", managerName);
            sessionStorage.setItem("managerID", managerID);
            sessionStorage.setItem("employeeName", employeeName);
            sessionStorage.setItem("employeeID", employeeID);
            sessionStorage.setItem("memberName", memberName);
            sessionStorage.setItem("memberID", memberID);
            if(TID == lineItem.transactionID)
            {
                html += "<li class=\"list-group-item d-flex justify-content-between lh-condensed\">" +
                            "<div>" +
                                "<h6 class=\"my-0\">" + lineItem.productName + "</h6>" +
                            " </div>" +
                            " <span class = \"text-muted\"> $" + lineItem.productPrice + "</span>" + 
                        "</li>"
                discount += lineItem.productDiscount;
                Total += lineItem.productPrice;
            }
        })
        html +=         "<li class=\"list-group-item d-flex justify-content-between lh-condensed\">" +
                            "<div>" +
                                "<h6 class = \"my-0\">" + 'Discount' + "</h6>" +
                            "</div>" + 
                            "<span> $" + discount + "</span>" +
                        "</li>" +
                        "<li class = \"list-group-item d-flex justify-content-between\">" +
                            "<span>" + 'Total' + "</span>" +
                            "<strong> $" + Total + "</strong>" +
                            "<hr class=\"mb-4\">" +
                            "<button class=\"btn btn-secondary btn-block\" type=\"submit\" onclick = \"goToCheckOut(" + Total + ")\">" + 'Continue to checkout' + "</button>" +
                        "</li>" +
                    "</ul>";
        document.getElementById("cart").innerHTML = html;     
    }).catch(function(error){
        console.log(error);
        var html = "<p>\"That item could not be found in our system. Please enter a valid ID.\"</p>";
        document.getElementById("product").innerHTML = html;
    });

}


//Goes to Member Checkout
function goToCheckOut(Total){
    console.log("here");
    var TID = sessionStorage.getItem("TID");
    var managerName = sessionStorage.getItem("managerName");
    var managerID = sessionStorage.getItem("managerID");
    var employeeName = sessionStorage.getItem("employeeName");
    var employeeID = sessionStorage.getItem("employeeID");
    var memberName = sessionStorage.getItem("memberName");
    var memberID = sessionStorage.getItem("memberID");
    var para = "?TID=" + TID + "&managerName=" + managerName + "&managerID=" + managerID + "&employeeName=" + employeeName + "&employeeID=" + employeeID + "&memberID=" + memberID + "&memberName=" + memberName + "&Total=" + Total;
    window.location.href = "CheckOut.html" + para;
}

//POSTs

//Adds to the Transaction Line Item Table
function addTLI(productID, productPrice, productDiscount, managerID, employeeID, memberID){
    const addTLIApiUrl = "https://title-town-cards-api.herokuapp.com/API/TransactionLineItems";    
    const ID = productID;
    const Name = document.getElementById("ProductName").innerHTML;
    const Price = productPrice;
    const Type = document.getElementById("ProductType").innerHTML;
    const Discount = productDiscount;
    const TID = document.getElementById("TID").innerHTML;
    const managerName = document.getElementById("ManagerName").innerHTML;
    const employeeName = document.getElementById("EmployeeName").innerHTML;
    const memberName = document.getElementById("MemberName").innerHTML;
    console.log(TID);  
    
    fetch(addTLIApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            transactionID: parseInt(TID),
            productID: parseInt(ID),
            productName: Name,
            productPrice: parseFloat(Price),
            productType: Type,
            productDiscount: parseFloat(Discount)
        })
    }).then((response)=>{
        console.log(response);
        document.forms['AddToCart'].reset();
        getTLI(TID, managerName, managerID, employeeName, employeeID, memberName, memberID);
    })
}
//Starts a transaction
function addMemTransaction(TID, transactionCost, managerID, managerName, employeeID, employeeName, memberID, memberName){
    const addMemTransactionApiUrl = "https://title-town-cards-api.herokuapp.com/API/Transactions";
    const TransactionID = TID;
    const TransactionCost = transactionCost;
    const ManagerID = managerID;
    const ManagerName = managerName;
    const EmployeeID = employeeID;
    const EmployeeName = employeeName;
    const MemberID = memberID;


    fetch(addMemTransactionApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            transactionID: TransactionID,
            transactionCost: parseFloat(TransactionCost),
            managerID: parseInt(ManagerID),
            managerName: ManagerName,
            employeeID: parseInt(EmployeeID),
            employeeName: EmployeeName,
            memberID: parseInt(MemberID)
        })
    })
    .then((response)=>{
        console.log(response);
        var para = "?member=" + memberName + "&memberID=" + memberID + "&managerName=" + managerName + "&managerID=" + managerID + "&employeeName=" + employeeName + "&employeeID=" + employeeID + "&TID=" + TID;
        window.location.href = "MemberPOS.html" + para;
    })
}

function addTransaction(TID, transactionCost, managerID, managerName, employeeID, employeeName){
    const addTransactionApiUrl = "https://title-town-cards-api.herokuapp.com/API/Transactions";
    const TransactionID = TID;
    const TransactionCost = transactionCost;
    const ManagerID = managerID;
    const ManagerName = managerName;
    const EmployeeID = employeeID;
    const EmployeeName = employeeName;


    fetch(addTransactionApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            transactionID: TransactionID,
            transactionCost: parseFloat(TransactionCost),
            managerID: parseFloat(ManagerID),
            managerName: ManagerName,
            employeeID: parseFloat(EmployeeID),
            employeeName: EmployeeName
        })
    })
    .then((response)=>{
        console.log(response);
        var para = "?managerName=" + managerName + "&managerID=" + managerID + "&employeeName=" + employeeName + "&employeeID=" + employeeID + "&TID=" + TID;
        window.location.href = "CustomerPOS.html" + para;
    })
}

//Adds Product to Inventory
function addProduct(price, mgrID, manager, empID, employee){
    const addProductApiUrl = "https://title-town-cards-api.herokuapp.com/API/Products";
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

//Adds Manager
function addManager(email){
    const addManagerApiUrl = "https://title-town-cards-api.herokuapp.com/API/Managers";
    const Name = document.getElementById("name").value;
    const Phone = document.getElementById("phone").value;
    const Email = email;
    const Address = document.getElementById("address").value;

    fetch(addManagerApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            managerName: Name,
            managerPhone: Phone,
            managerEmail: Email,
            managerAddress: Address
        })
    })
    .then((response)=>{
        console.log(response);
        document.forms['AddManagers'].reset();
    })
}

//Adds Employee
function addEmployee(email){
    const addEmployeeApiUrl = "https://title-town-cards-api.herokuapp.com/API/Employees";
    const Name = document.getElementById("name").value;
    const Phone = document.getElementById("phone").value;
    const Email = email;
    const Address = document.getElementById("address").value;

    fetch(addEmployeeApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            employeeName: Name,
            employeePhone: Phone,
            employeeEmail: Email,
            employeeAddress: Address
        })
    })
    .then((response)=>{
        console.log(response);
        document.forms['AddEmployees'].reset();
    })
}

//Adds Member
function addMember(email){
    const addMemberApiUrl = "https://title-town-cards-api.herokuapp.com/API/Members";
    const Name = document.getElementById("name").value;
    const Address = document.getElementById("address").value;
    const Email = email;
    const DOB = document.getElementById("dob").value;
    const Phone = document.getElementById("phone").value;

    fetch(addMemberApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            memberName: Name,
            memberAddress: Address,
            memberEmail: Email,
            memberDOB: DOB,
            memberPhone: Phone
        })
    })
    .then((response)=>{
        console.log(response);
        document.forms['AddMembers'].reset();
    })
}

//UPDATES
function updateTransaction(TID, Total){
    const tranactionID = TID;
    const updateTransactionApiUrl = "https://title-town-cards-api.herokuapp.com/API/Transactions/" + tranactionID;
    const TransactionCost = Total;
    console.log(Total);
    fetch(updateTransactionApiUrl, {
        method: "PUT",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            transactionID: parseInt(tranactionID),
            transactionCost: parseFloat(TransactionCost)
        })
    }).then((response)=>{
        console.log(response);
        getTransactionLineItem(TID);
    })
}

function getTransactionLineItem(TID){
    const getTransactionLineItemApiUrl = "https://title-town-cards-api.herokuapp.com/API/TransactionLineItems";

    fetch(getTransactionLineItemApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        json.forEach((lineItem)=>{
            console.log(TID);
            console.log(lineItem.transactionID);
            if(TID == lineItem.transactionID)
            {
                updateProductStatus(lineItem.productID)
            }
        })
    })
}

function updateProductStatus(ID){
    const updateProductStatusApiUrl = "https://title-town-cards-api.herokuapp.com/API/Products/" + ID;
    const statusUpdate = "Sold";
    const productID = ID;
    fetch(updateProductStatusApiUrl, {
    method: "PUT",
    headers: {
        "Accept": 'application/json',
        "Content-Type": 'application/json'
    },
    body: JSON.stringify({
        productID: parseInt(productID),
        productStatus: statusUpdate
    })
    }).then((response)=>{
        console.log(response);
        
    })
}