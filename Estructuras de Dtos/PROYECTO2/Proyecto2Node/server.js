var express=require('express');
var app=express();
var fileUpload=require('express-fileupload');
var server=require('http').createServer(app);
var io=require('socket.io')(server);

app.set("view engine","jade");

app.use(express.static("public"));
app.use(fileUpload());

app.post('/upload', function(req, res) {
  if (!req.files)
    return res.status(400).send('No files were uploaded.');
 
  let sampleFile = req.files.sampleFile;
	sampleFile.mv('public/files/bitacora.txt', function(err) {
    if (err)
      return res.status(500).send(err);
  	res.send();
 	});
});

app.get("/",function(solictud,respuesta){
  respuesta.render("index");
});

io.on('connection',function(client){
	console.log('Cliente Conectado');
	client.on('join',function(data){
		console.log(data);
	});

});

app.post('/',function(req,res){
	console.log(req.body.usuario);
	res.send('Post page');
});


server.listen(8080);