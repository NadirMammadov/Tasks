"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
//document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function ( message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.textContent = `says ${message}`;
});

connection.start();

document.getElementById("sendButton").addEventListener("click", function (event) {
    connectionId
    var message = document.getElementById("messageInput").value;
    var connectionId = document.getElementById("connectionId").value;
    connection.invoke("SendMessage", connectionId, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});