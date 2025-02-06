using Godot;
using System;
using System.Collections.Generic;

public partial class Escena : Node3D
{
	private int id;
	[Export] private DirectionalLight3D sol;
	[Export] private Camera3D camara;
	private List<string> musicas = new List<string>();
	private float gravedad;
	[Export] private MeshInstance3D suelo;
	private CollisionShape3D colision;
	public Escena(){
		this.id = 1;
		this.gravedad = 2;//normal
	}
	
	public void definirSuelo(){
		int x = 200;
		int y = 2;
		int z = 200;
		try{
			var mesh = new BoxMesh();
			mesh.Size = new Vector3(2, 2, 2); 
			//Asignamos la malla al MeshInstance3D
			suelo = new MeshInstance3D();
			suelo.Mesh = mesh;
			suelo.Scale = new Vector3(x, y, z);
			// Añadimos el suelo a la escena
			AddChild(suelo);
		}catch(Exception  e){
			 GD.Print("Se produjo un error: " + e.Message);
		}
	}
	public void definimosElcielo(){
		// Creamos el sol (DirectionalLight3D)
		// Asignamos la orientación del sol (por ejemplo, apuntando hacia abajo)
		sol = new DirectionalLight3D();
		sol.Rotation = new Vector3(-1, 0, 0);
		// Añadimos el sol a la escena
		AddChild(sol);
		AddChild(camara);
	}
	public override void _Ready()
	{
		try{
			definimosElcielo();
			definirSuelo();
		}catch( Exception e){
			GD.Print("Se produjo un error: " + e.Message);
			GD.Print("Se produjo un error: " + e.ToString());
		}
	}
}
