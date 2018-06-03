 var nodesBloque; 
 var direcciones;
 var contador=0;
 var btree
 var btree2
  $(function() {
		$('#chooseFile').bind('change', function () {
			  var filename = $("#chooseFile").val();
	  		if (/^\s*$/.test(filename)) {
	    		$(".file-upload").removeClass('active');
	    		$("#noFile").text("No file chosen..."); 
	  		}
	  		else {
	    		$(".file-upload").addClass('active');
	    		$("#noFile").text(filename.replace("C:\\fakepath\\", "")); 
	  		}		
		});
  });

function leerArchivo(){
 btree= new BTree();
 btree2=new BTree();

	alert("Archivo cargado, procediendo a cargar en arbol B");
	var file=document.getElementById('chooseFile').files[0];
	var reader=new FileReader();
	 reader.onloadend = function(evt) {
      //console.log(this.result);
      var lines=this.result.split('\n');
      for(var i=0;i<lines.length;i++){
      	var tipo=lines[i].split(':');
      	if(tipo[1]=="Bloque"){
      		var datos=tipo[3].split(",");
      		datos=eliminarDuplicados(datos);
      		for(var j=0;j<datos.length;j++){
      			if(datos[j]!="vyd"){
      				btree.insert(datos[j],datos[j]);
      			}
      		}

      	}else if(tipo[1]=="Ruta"){
      		var datos=tipo[3].split(",");
      		datos=eliminarDuplicados(datos);
      		for(var j=0;j<datos.length;j++){
      			if(datos[j]!="vyd"){
      				btree2.insert(datos[j],datos[j]);
      			}
      		}
      	}
      }
     

    };

    reader.readAsText(file);
}

function eliminarDuplicados(lista){
	var i,len=lista.length,
	 out=[],
	 obj={};
	for(i=0;i<len;i++){
		obj[lista[i]]=0;
	}
	for(i in obj){
		out.push(i);
	}
	return out;
}

function generarBloque(){
	  nodesBloque=[];
      direcciones=[];
	console.log(btree.traverse(0));
	var container = document.getElementById('mynetwork');
    var data = {
        nodes: nodesBloque,
        edges: direcciones
    };
    var network = new vis.Network(container, data, {});
}

function generarRuta(){
	  nodesBloque=[];
      direcciones=[];
	console.log(btree2.traverse(0));
	var container = document.getElementById('mynetwork');
    var data = {
        nodes: nodesBloque,
        edges: direcciones
    };
    var network = new vis.Network(container, data, {});
}

/*--------------------------------------------------ARBOL B------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------*/
class BTree {
  constructor(degree) {
    this.root = new Node(4);
  }
  find(key) {
    return this._find(key, this.root);
  }
  _find(key, node) {
    let i = 0;
    for(; i<node.size && key > node.keys[i]; i++);
    if(i<node.size && node.keys[i]==key) return node.data[i];
    if(node.isLeaf) return null;
    return this._find(key, node.children[i]);
  }

  traverse(key, count) {
    var buffer = [];
    this._traverse(key, count, this.root, buffer);
    return buffer;
  }
  _traverse(key, count, node, buffer) {

  	var s="";
   let i = 0;
   var a="Nodo"+contador;
    for(; i<node.size && key > node.keys[i]; i++);
    for(; i<node.size && buffer.length != count; i++) {
      if(!node.isLeaf) {
      	var b="Nodo"+(contador+1);
      	contador++;
        direcciones.push({from:a,to:b});
        this._traverse(key, count, node.children[i], buffer);
      }
      buffer.push(node.data[i]);
      s=s+"|"+node.data[i];
    }
    if(!node.isLeaf){ this._traverse(key, count, node.children[i], buffer);
      	
      	nodesBloque.push({id:a,label:s});
	}
  }

  insert(key, value) {
    if(this.root.size==this.root.keys.length) {
      this._splitRoot();
    }
    return this._insertWithSpace(key, value, this.root);
  }
  _splitRoot() {
    // truncate old root
    let left = this.root;
    left.size = Math.floor(left.size/2);

    // copy left of old root to right
    let right = new Node(left.keys.length);
    right.isLeaf = left.isLeaf;
    right.size = left.keys.length-left.size-1;
    let i = 0;
    for(; i<right.size; i++) {
      right.keys[i] = left.keys[i+left.size+1];
      right.data[i] = left.data[i+left.size+1];
      right.children[i] = left.children[i+left.size+1];
    }
    right.children[i] = left.children[i+left.size+1];

    // make new root
    this.root = new Node(left.keys.length);
    this.root.isLeaf = false;
    this.root.size = 1;
    this.root.keys[0] = left.keys[left.size];
    this.root.data[0] = left.data[left.size];
    this.root.children[0] = left;
    this.root.children[1] = right;
  }
  _insertWithSpace(key, value, node) {
    if(node.isLeaf) {
      // Insert new key in leaf
      let i = node.size;
      for(;i>0 && node.keys[i-1]>key;i--) {
        node.keys[i] = node.keys[i-1];
        node.data[i] = node.data[i-1];
        node.children[i+1] = node.children[i];
      }
      node.keys[i] = key;
      node.data[i] = value;
      node.size++;
    } else {
      // Descend tree to find right leaf, preemptively splitting nodes as we go along
      let i = 0;
      for(; i<node.size && node.keys[i]<key;i++);
      if(node.children[i].size==node.children[i].keys.length) {
        this._splitNode(node.children[i], node);
        this._insertWithSpace(key, value, node);
      } else {
        this._insertWithSpace(key, value, node.children[i]);
      }
    }
  }
  _splitNode(left, parent) {
    let i;
    left.size = Math.floor(left.size/2);

    // copy left to right
    let right = new Node(left.keys.length);
    right.isLeaf = left.isLeaf;
    right.size = left.keys.length-left.size-1;
    for(i=0; i<right.size; i++) {
      right.keys[i] = left.keys[i+left.size+1];
      right.data[i] = left.data[i+left.size+1];
      right.children[i] = left.children[i+left.size+1];
    }
    right.children[i] = left.children[i+left.size+1];

    // make space in parent
    var medianKey = left.keys[left.size+1];
    for(i=parent.size; i>0 && parent.keys[i-1]>medianKey; i--) {
      parent.keys[i] = parent.keys[i-1];
      parent.data[i] = parent.data[i-1];
      parent.children[i+1] = parent.children[i];
    }

    // Insert median into parent
    parent.keys[i] = left.keys[left.size];
    parent.data[i] = left.data[left.size];
    parent.children[i+1] = right;
    parent.size++;

    // wipe right side of left
    for(i=left.size; i<left.keys.length; i++) {
      delete left.keys[i];
      delete left.data[i];
      delete left.children[i+1];
    }
  }
}

class Node {
  constructor(degree = 4) {
    this.isLeaf = true
    this.size = 0;
    this.data = new Array(4);
    this.keys = new Array(4);
    this.children = new Array(4+1);
  }
}

