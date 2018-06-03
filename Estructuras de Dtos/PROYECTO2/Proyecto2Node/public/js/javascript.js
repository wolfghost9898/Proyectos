const button=document.getElementById('boton-enviar');
button.addEventListener('click',function(e){
	var nombre=document.getElementById("usuario").value;
	var contraseña=document.getElementById("contraseña").value;
	if(nombre=="201612118" && contraseña=="201612118-edd-b-1s2018"){
			console.log("Logueado");
			window.location.replace("pages/admin.html");
	}else{
		alert('Usuario o contraseña erronea');
	}
});


