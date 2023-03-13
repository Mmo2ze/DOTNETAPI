let groub = document.getElementById("namegroub");
let sentgroub = document.getElementById("sentgroub");

sentgroub.addEventListener("click",()=>{

if(groub.value != ""){
$.ajax({
  url: "https://localhost:7210/Group",
  type: "Post",
  data: JSON.stringify({
    name: groub.value,
  }),
  contentType: "application/json; charset=utf-8",
  success: function (data) {
    console.log(data);
  },
  error: function () {
    alert("error");
  },
});


}


})



let getdata = document.getElementById("getgroub");
let showdata = document.getElementById("showdata")
let x 
getdata.addEventListener("click", () => {

$.ajax({
    url: "https://localhost:7210/Group",
    type: "Get",
    data: '', //{ Name: name, 
     // Address: address, DOB: dob },
    contentType: 'application/json; charset=utf-8',
    success: function (data) { console.log(data)
        x = data},
    error: function () { alert('error'); }
});

for(let i = 0 ; i < x.length ; i++){
    showdata.innerHTML = x[i].name
}

});

// get all groups


