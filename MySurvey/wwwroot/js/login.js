// Autor: Oscar Huber
// Objetivo: Validar el formulario de login
function validarFormulario() {
    var email = document.getElementById("email").value;
    var pwd = document.getElementById("pwd").value;
    if (email == "" || pwd == "") {
        alert("Campo vacio!");
        return false;
    }
    return true;
}