﻿"use strict";

var guid = document.getElementById("baslik").textContent;
console.log(guid);
var connection = new signalR.HubConnectionBuilder().withUrl("/chart").build();




$(document).ready(function () {
    console.log("***********************************************!!!!!!!");
    connection.start().then(function () {
        connection.invoke("AddGroup", guid);
    });
    connection.on(function () {
        connection.invoke("SendMessage", guid);
    });
    connection.on("ReceiveMessage", function (gidecek) {
        //var li = document.createElement("li");
        //document.getElementById("messagesList").appendChild(li);
        //i++;
        console.log('ads');
        console.log(gidecek.timestamp);
        console.log(giedecek.Data);
        console.log(giedecek.DataNumber);
        console.log(giedecek.ClientGUID);

        /*li.textContent = `${deneme}`;*/
    });
    var i = 0;
    var intervalId = setInterval(function () {


        connection.invoke("SendMessage", guid).catch(function (err) {

            return console.error(err.toString());
        });




    }, 1000);




    console.log('başladı');

});