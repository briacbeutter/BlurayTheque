// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
var acteurs = []
function handleAddActor()
{
    let select = document.getElementById("selectActor");
    let acteur = select.value;
    acteurs.push(acteur)
    document.getElementById("test").value = acteurs;
    console.log(acteurs);
    let divLIst = document.getElementById("listActeurs")
    let newActeur = document.createElement("div");
    let textActeur = document.createTextNode(acteur + "   x");
    newActeur.appendChild(textActeur);
    newActeur.id = acteur
    newActeur.style.backgroundColor = "rgba(0,100,200,0.3)"
    newActeur.style.color = "rgb(255,255,255)"
    newActeur.style.padding = "5px"
    newActeur.style.width = "max-content"
    newActeur.style.marginBottom = "5px"
    newActeur.addEventListener("click",function (e){
        console.log(e.target.id);
        document.getElementById(e.target.id).style.display = 'None'
        
    },false);
    divLIst.appendChild(newActeur);
}
