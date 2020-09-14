"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

connection.start().then(function () {
    var room = document.getElementById("chatRoomId").value;
    var user = document.getElementById("authorId").value;
    connection.invoke("JoinRoom", user, room).then(() =>
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
    console.log('got here')
    // send xhr request
    $.ajax({
        type: $theForm.attr('method'),
        url: $theForm.attr('action'),
        data: $theForm.serialize(),
        success: function (data) {
            console.log('Yay! Form sent.');
            console.log(data);
        }
    });

    // prevent submitting again
    return false;
});