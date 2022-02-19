"use strict";


var connection = new signalR.HubConnectionBuilder().withUrl("/clientlist").build();



connection.on("ReceiveMessage", function (clientNos) {
    

    $('#mytable tr:not(:first)').remove();
    var SetData = $("#SetClientList");
    var table = document.getElementById("mytable");

    for (var i = 0; i <= clientNos.length; i++) {
        var currentRow = table.rows[i];
        var createClickHandler = function (row) {
            return function () {
                var cell = row.getElementsByTagName("td")[1];
                var id = cell.textContent;
              
                // window.location.pathname = url.replace('__id__', id);
                /* window.open(url.replace('__id__', id), '_blank');*/
                window.open('/clientchart/' + id, '_blank');
               
            };
        };
        currentRow.onclick = createClickHandler(currentRow);
        var date = clientNos[i].timestamp;
        var Data = "<tr class='row_" + clientNos[i].clientGUID + "'>" +
            "<td>" + i + "</td>" +
            "<td>" + clientNos[i].clientGUID + "</td>" +
            "<td>" + date + "</td>" +

            "</tr>";
        SetData.append(Data);
        $("#LoadingStatus").html(" ");
        console.log(JSON.stringify(clientNos));
        
    }

});

$(document).ready(function () {
    
    connection.start().then(function () {
        connection.invoke("SendMessage");
    }).catch(function (err) {
        return console.error(err.toString());
    });

  

    var intervalId = setInterval(function () {
      
        connection.invoke("SendMessage").catch(function (err) {
            return console.error(err.toString());
        });

        
    }, 3000);

});