using Godot;
using System;
using System.Collections.Generic;

public partial class Escena : Node3D
{
	private int id;
	[Export] private DirectionalLight3D sol;
	[Export] private Camera3D camara;
	private List<string> musicas;
	private float gravedad;
	[Export] private MeshInstance3D suelo;
	private CollisionShape3D colision;
	
	public Escena(){
		this.id = 1;
		this.gravedad = 2;
		this.sol = new DirectionalLight3D();
		this.musicas = new List<string>();
		this.suelo = new MeshInstance3D();
	}
	/*
		pre: ---
		Post: definimos los componentes que deinien el suelo
	*/
	public void definirSuelo(){
		int x = 200;
		int y = 2;
		int z = 200;
		try{
			var mesh = new BoxMesh();
			mesh.Size = new Vector3(2, 2, 2); 
			
			suelo.Mesh = mesh;
			suelo.Scale = new Vector3(x, y, z);
			AddChild(suelo);
		}catch(Exception  e){
			 GD.Print("Se produjo un error: " + e.Message);
		}
	}
	/*
		pre: ---
		Post: definimos los elementos que componen el cielo
	*/
	public void definimosElcielo(){
		if (sol == null)
		{
			GD.PushWarning("⚠️ La luz solar no fue asignada en el editor, creando una nueva instancia.");	
		}
		sol.Rotation = new Vector3(-1, 0, 0);
		// Añadimos el sol a la escena
		AddChild(sol);
	}
	/*
		pre: ---
		Post: este es el método principal de la clase, es lo mirmero que se ejecuta
	*/
		
	public override void _Ready()
	{
		GD.Print("⚠️ La luz solar no fue asignada en el editor, creando una nueva instancia.\n");
		Console.WriteLine("⚠️ Esto es un mensaje de depuración.");
		try{
			definimosElcielo();
			definirSuelo();
		}catch( Exception e){
			GD.Print("Se produjo un error: " + e.Message);
			GD.Print("Se produjo un error: " + e.ToString());
		}
	}
}
