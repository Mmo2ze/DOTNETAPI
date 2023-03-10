

let id = document.getElementById("id")
let names = document.getElementById("name");
let email = document.getElementById("email");
let numbergroub = document.getElementById("numbergroub");
let button = document.getElementById("post");

button.onclick(){
    console.log("asda")
}
$.ajax({
  url: "https://localhost:7210/Student",
  type: "Post",
  data: JSON.stringify({
    "id": 0,
    "name": "laith",
    "email": "fsklfsf",
    "groupId": 1

  }), //{ Name: name,
  // Address: address, DOB: dob },
  contentType: "application/json; charset=utf-8",
  success: function (data) {},
  error: function () {
    alert("error");
  },
});

