"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    var date;
    date = new Date();
    date = ('00' + date.getUTCDate()).slice(-2)+ '/' +
        ('00' + (date.getUTCMonth() + 1)).slice(-2) + '/' +
        date.getUTCFullYear()+ ' ' +
        ('00' + (date.getUTCHours()+7)).slice(-2) + ':' +
        ('00' + date.getUTCMinutes()).slice(-2) + ':' +
        ('00' + date.getUTCSeconds()).slice(-2);
    console.log("date: " + date)

    li.textContent = `${globalname} ${message} ${date}`;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    var data = {
        userid: user,
        text: message
    };

    
    
    $.post("/Chat/Create", { user, message }, function (err) { console.log(user + " " + message + " " + err) });

    //configure endpoint here
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});