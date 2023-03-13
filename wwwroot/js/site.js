let groub = document.getElementById("namegroub");
let sentgroub = document.getElementById("sentgroub");

sentgroub.addEventListener("click", () => {

  if (groub.value != "") {
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
      error: function (er) {
        console.log(er)
      },
    });


  }


})


let x = [];

let getdata = document.getElementById("getgroub");
let showdata = document.getElementById("showdata")
let d = document.getElementById("d");



function delet(){


}


getdata.addEventListener("click", async () => {

  await $.ajax({
    url: "https://localhost:7210/Group",
    type: "Get",
    data: '', //{ Name: name, 
    // Address: address, DOB: dob },
    contentType: 'application/json; charset=utf-8',
    success: function (data) {
      x = data
    },
    error: function (e) {
      console.log(e)
    }
  });
  for (let i = 0; i < x.length; i++) {

    head = document.createElement("tr");
    head.className = "he"
    infodata = document.createElement("td");
    infodataloop = document.createTextNode(x[i].name);
    infodata.appendChild(infodataloop);
    head.appendChild(infodata)
    
    d.appendChild(head)
    
    // showdata.innerHTML = x[i].name
  }
  getdata.addEventListener("click",()=>{
  head.innerHTML = " "
    d.innerHTML = " "
})

});

// get all groups


// let tabel = document.createElement("table")
// let head = document.createElement("tr")
// let info = document.createElement("tr");
// let infodata = document.createElement("th");
// let infodataloop = document.createTextNode(x[i].name);
// let n = document.createElement("th")
// let cont = document.createTextNode("Name")
// n.appendChild(cont)
// head.appendChild(n)
// infodata.appendChild(infodataloop)
// info.appendChild(infodata)
// tabel.appendChild(head)
// tabel.appendChild(info)