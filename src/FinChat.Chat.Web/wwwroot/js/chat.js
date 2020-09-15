"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    var messageList = document.getElementById("messagesList");

    if (!!messageList.firstChild) {
        messageList.insertBefore(li, messageList.firstChild);
    } else {
        messageList.appendChild(li);
    }

    if (messageList.childElementCount >= 50) {
        messageList.removeChild(messageList.lastChild);
    }
});

connection.start().then(function () {
    var room = document.getElementById("chatRoomId").value;
    connection.invoke("JoinRoom", room).then(() =>
        {
            document.getElementById("sendButton").disabled = false;
        }).catch(function (err) {
        return console.error(err.toString());
    });
}).catch(function (err) {
    return console.error(err.toString());
});

$('#messageForm').submit(function () {
    var $theForm = $(this);
    // send xhr request
    $.ajax({
        type: $theForm.attr('method'),
        url: $theForm.attr('action'),
        data: $theForm.serialize(),
        success: function (data) {
        }
    });

    // prevent submitting again
    return false;
});