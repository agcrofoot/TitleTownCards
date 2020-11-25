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
    const getAllransactionsApiUrl = "https://title-town-cards-api.herokuapp.com/API/Transactions";
    fetch(getAllransactionsApiUrl).then(function(response){
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
function getProduct(ID){
    const getProductApiUrl = "https://title-town-cards-api.herokuapp.com/API/Products/" + ID;
    fetch(getProductApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        var html = "<div><p><b>ID: </b></p><p>" + json.productID+ "</p>";
        html += "<p><b>Name: </b></p><p id = \"ProductName\">" + json.productName + "</p>";
        html += "<p><b>Price: </b></p><p>" +  json.productPrice + "</p>";
        html += " <var id = \"ProductType\" style = \"display: none;\">" + json.productType + "</var>";
        html += " <var id = \"ProductDiscount\" style = \"display: none;\">" + json.productDiscount + "</var>";
        html += "<input type=\"submit\" value = \"Add to Cart\" onclick = \"addTLI(" + json.productID + ", " + json.productPrice + ", " + json.productDiscount + ")\"/>";
        document.getElementById("product").innerHTML = html;
    }).catch(function(error){
        console.log(error);
        var html = "<p>\"That item could not be found in our system. Please enter a valid ID.\"</p>";
        document.getElementById("product").innerHTML = html;
    });
}

//Checks if the phone number entered is in the system then adds the corresponding ID to MemberTransaction
function getMember(memberPhone){
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
                getMemTransactionID(member.memberID);
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
    const getManagerApiUrl = "https://title-town-cards-api.herokuapp.com/API/Managers/" + ID;
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

function getManagerID(ID){
    const getManagerIDApiUrl = "https://title-town-cards-api.herokuapp.com/API/Managers/" + ID;
    console.log(getManagerIDApiUrl);
    fetch(getManagerIDApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        if(ID == json.managerID)
        {
            console.log("went through");
            window.location.href = "ManagerView.html";
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
    const getEmployeeApiUrl = "https://title-town-cards-api.herokuapp.com/API/Employees/" + ID;
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

//Generates a Transaction Number
function getTransactionID(){
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
        addTransaction(TransactionID, 0, 0);
        sessionStorage.setItem("TID", TransactionID);
        window.location.href = "CustomerPOS.html";
    }).catch(function(error){
        console.log(error);
    });
}

//Generates a member transaction ID
function getMemTransactionID(memberID){
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
        addTransaction(TransactionID, 0, memberID);
        sessionStorage.setItem("TID", TransactionID);
        window.location.href = "MemberPOS.html";
    }).catch(function(error){
        console.log(error);
    });
}


//Shows transaction line items in the person's cart
function getTLI(tID){
    const getTLIApiUrl = "https://title-town-cards-api.herokuapp.com/API/TransactionLineItems";
    fetch(getTLIApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        var html =  "<ul class=\"list-group mb-3\" style = \"max-width: 300px; justify-content: left;\">";
        var discount = 0;
        var Total = 0;
        json.forEach((lineItem) => {
            console.log(tID);
            console.log(lineItem.transactionID);
            if(tID == lineItem.transactionID)
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
                            "<button class=\"btn btn-primary btn-block\" type=\"submit\" onsubmit = \"goToCheckOut(" + tID + ")\">" + 'Continue to checkout' + "</button>" +
                        "</li>" +
                    "</ul>";
        document.getElementById("cart").innerHTML = html;     
    }).catch(function(error){
        console.log(error);
        var html = "<p>\"That item could not be found in our system. Please enter a valid ID.\"</p>";
        document.getElementById("product").innerHTML = html;
    });

}

//Goes to Checkout
function goToCheckOut(tID){
    sessionStorage.setItem("tID", tID);
    window.location.href = "MemberCheckOut.html";
}


//Readies Cart for checkout
function getTransaction(){
    const getTransactionApiUrl = "https://title-town-cards-api.herokuapp.com/API/TransactionLineItems";
    const tID = sessionStorage.getItem("tID");
    fetch(getTransactionApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        var html =  "<ul class=\"list-group mb-3\" style = \"max-width: 300px; justify-content: left;\">";
        var discount = 0;
        var Total = 0;
        json.forEach((lineItem) => {
            console.log(tID);
            console.log(lineItem.transactionID);
            if(tID == lineItem.transactionID)
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
                        "</li>" +
                    "</ul>";
        document.getElementById("fullCart").innerHTML = html;  
    }).catch(function(error){
        console.log(error);
    });

}

//POSTs

//Adds to the Transaction Line Item Table
function addTLI(productID, productPrice, productDiscount){
    const addTLIApiUrl = "https://title-town-cards-api.herokuapp.com/API/TransactionLineItems";
    const TID = sessionStorage.getItem("TID");    
    const ID = productID;
    const Name = document.getElementById("ProductName").innerHTML;
    const Price = productPrice;
    const Type = document.getElementById("ProductType").innerHTML;
    const Discount = productDiscount;
    console.log(TID);  
    
    fetch(addTLIApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            transactionID: parseFloat(TID),
            productID: ID,
            productName: Name,
            productPrice: Price,
            productType: Type,
            productDiscount: Discount
        })
    }).then((response)=>{
        console.log(response);
        document.forms['AddToCart'].reset();
        getTLI(TID);
    })
}
//Starts a transaction
function addTransaction(tID, tCost, memberID){
    const addTransactionApiUrl = "https://title-town-cards-api.herokuapp.com/API/Transactions";
    const TransactionID = tID;
    const TransactionCost = tCost;
    const MemberID = memberID;
    
    fetch(addTransactionApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            transactionID: TransactionID,
            transactionCost: TransactionCost,
            memberID: MemberID
        })
    }).then((response)=>{
        console.log(response);
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