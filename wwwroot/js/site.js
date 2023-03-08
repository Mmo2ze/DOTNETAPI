

console.log('app.js');
function getdata(){ 
    let datas = new XMLHttpRequest()

datas.onreadystatechange = function (){
    
    if(this.readyState === 4 && this.status === 200){
        console.log(this.responseText)
    }
}

datas.open("POST", "https://localhost:7210/api/APIconteroller", true);
datas.send()

}


let input = document.querySelector("#name");
let send = document.querySelector("#post");
$(send).click(function(){
    data = {
        id: 0,
        name : input.value
    }
    xx = JSON.stringify(data)
    console.log(xx)
    console.log("fjsdlkfjdlskf")
    $.post("https://localhost:7210/Group",data);
  }); 






