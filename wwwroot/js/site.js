


function getdata(){ 
    let datas = new XMLHttpRequest()

datas.onreadystatechange = function (){
    
    if(this.readyState === 4 && this.status === 200){
        console.log(this.responseText)
    }
}

datas.open("GET", "https://localhost:7210/api/APIconteroller", true);
datas.send()

 }

