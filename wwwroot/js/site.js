// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
var acteurs = []
var realisateurs = []
var scenaristes = []

function handleAddActor()
{
    let select = document.getElementById("selectActor");
    let acteur = select.value;
    let id = $("#selectActor option:selected").attr("id");
    acteurs.push(id)
    document.getElementById("acteursHidden").value = acteurs;
    let divLIst = document.getElementById("listActeurs")
    console.log(divLIst);
    let newActeur = document.createElement("div");
    let textActeur = document.createTextNode(acteur + "   x");
    newActeur.appendChild(textActeur);
    newActeur.id = id
    newActeur.style.backgroundColor = "rgba(200,100,0,0.3)"
    newActeur.style.color = "rgb(255,255,255)"
    newActeur.style.padding = "5px"
    newActeur.style.width = "max-content"
    newActeur.style.marginBottom = "5px"
    newActeur.addEventListener("click",function (e){
        this.style.display = 'None';
        console.log("ID" + e.target.id);
        acteurs = acteurs.filter(function(f) { return f !== e.target.id });
        console.log("Act" + acteurs);
    },false);
    divLIst.appendChild(newActeur);
}


function handleAddReal()
{
    let select = document.getElementById("selectReal");
    let realName = select.value;
    let id = $("#selectReal option:selected").attr("id");
    realisateurs.push(id)
    document.getElementById("realHidden").value = realisateurs;
    console.log("Real" + realisateurs);
    let divLIst = document.getElementById("listReal")
    let newReal = document.createElement("div");
    let textReal = document.createTextNode(realName + "   x");
    newReal.appendChild(textReal);
    newReal.id = realName
    newReal.style.backgroundColor = "rgba(0,100,200,0.3)"
    newReal.style.color = "rgb(255,255,255)"
    newReal.style.padding = "5px"
    newReal.style.width = "max-content"
    newReal.style.marginBottom = "5px"
    newReal.addEventListener("click",function (e){
        this.style.display = 'None';
        realisateurs = realisateurs.filter(function(f) { return f !== id });
        console.log("Real" + realisateurs);
    },false);
    divLIst.appendChild(newReal);
}

function handleAddScena()
{
    let select = document.getElementById("selectScenariste");
    let scenaName = select.value;
    let id = $("#selectScenariste option:selected").attr("id");
    scenaristes.push(id)
    document.getElementById("scenaHidden").value = scenaristes;
    console.log("Real" + scenaristes);
    let divLIst = document.getElementById("listScena")
    let newScena = document.createElement("div");
    let textScena = document.createTextNode(scenaName + "   x");
    newScena.appendChild(textScena);
    newScena.id = scenaName
    newScena.style.backgroundColor = "rgba(50,200,50,0.3)"
    newScena.style.color = "rgb(255,255,255)"
    newScena.style.padding = "5px"
    newScena.style.width = "max-content"
    newScena.style.marginBottom = "5px"
    newScena.addEventListener("click",function (e){
        this.style.display = 'None';
        scenaristes = scenaristes.filter(function(f) { return f !== id });
        console.log("Scena" + scenaristes);
    },false);
    divLIst.appendChild(newScena);
}
