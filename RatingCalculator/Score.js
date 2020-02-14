var SelectGameMode = document.getElementById("GameMode");
var PlayerInput1 = document.getElementById("pl-input-1");
var PlayerInput2 = document.getElementById("pl-input-2");
var PlayerOutput1 = document.getElementById("pl-output-1");
var PlayerOutput2 = document.getElementById("pl-output-2");
var Score1 = document.getElementById("Score1");
var Score2 = document.getElementById("Score2");
var WinCount = document.getElementById("winCount");
var table = document.getElementById("ScoreTable");

var ShortScoreArray = new Array('1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12');
var LongScoreArray = new Array('1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12', '13', '14', '15', '16', '17', '18', '19', '20', '21', '22');

function AddName() {
    PlayerOutput1.value = PlayerInput1.value;
    PlayerOutput2.value = PlayerInput2.value;

}
function AddScore() {
    table.innerHTML += "<tr>" + "<td>" + SelectGameMode.value + "</td>" + "<td>" + Score1.value + "</td>" + "<td>" + Score2.value + "</td>" + "<td>" + PlayerInput1.value + "</td>" + "<td>" + PlayerInput2.value + "</td>" + "<td>" + WinCount.value + "</td>" + "</tr>"
}