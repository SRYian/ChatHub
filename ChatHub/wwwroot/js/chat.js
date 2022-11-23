"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    var h5 = document.createElement("h5");
    var msgcontainer = document.createElement("div");
    var msg = document.createElement("div");
    var timestamp = document.createElement("small")
    var date;
    date = new Date();
    date = ('00' + date.getUTCDate()).slice(-2)+ '/' +
        ('00' + (date.getUTCMonth() + 1)).slice(-2) + '/' +
        date.getUTCFullYear()+ ' ' +
        ('00' + (date.getUTCHours()+7)).slice(-2) + ':' +
        ('00' + date.getUTCMinutes()).slice(-2) + ':' +
        ('00' + date.getUTCSeconds()).slice(-2);
    console.log("date: " + date)
    li.appendChild(h5);
    
    document.getElementById("messagesList").appendChild(li);
    console.log(li);
    //h5.textContent = `${user} ${message} ${date}`;
    h5.textContent = `${user}`;
    li.appendChild(msgcontainer);
     msgcontainer.appendChild(msg);
     msg.textContent = `${message}`;
     msgcontainer.appendChild(timestamp);
     timestamp.textContent = `${date}`;
    li.classList.add("msglist");
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    //var user = document.getElementById("userInput").value;
    var user = globalname;
    var message = document.getElementById("messageInput").value;
    var data = {
        userid: globalname,
        text: message
    };

    
    
    $.post("/Chat/Create", { user, message }, function () { console.log(user + " " + message) });

    //configure endpoint here
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});