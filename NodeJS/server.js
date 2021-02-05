var websocket = require('ws');

var callbackinitserver = ()=>{
    console.log("Server is running");
}

var wss = new websocket.Server({port:25500},callbackinitserver);

var wslist = [];

wss.on("connection" , (ws)=>{

    console.log("client connected.");
    wslist.push(ws);
    
    ws.on("message" , (data)=>{
        console.log("send form cliant :"+ data);
        Boardcast(data);
    });
    
    ws.on("close" , ()=>{
        console.log("client disconnected");
        wslist = ArryRemove(wslist, ws)
    })

});

function ArryRemove(arr,value)
{
    return arr.filter((element)=>{
        return element != value;
    });
}

function Boardcast(data)
{
    for(var i = 0; i < wslist.length; i++)
    {
        wslist[i].send(data);
    }
}