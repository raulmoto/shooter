using Godot;
using System;
using System.Collections.Generic;

public partial class Personaje : Node3D
{
	private int id;
	private int velocidad;
	private int salud;
	private List<AnimationPlayer> animaciones;
	[Export] private Camera3D camara;
	
	public Personaje(){
		this.id = 1;
		this.velocidad = 10;
		this.salud = 100;
		this.animaciones = new List<AnimationPlayer>();
		this.camara = new Camera3D();
	}
	/*
		pre: ---
		Post: Recorremos el compuesto del personaje de manera recursiva para obtener los AnimationPlayer
	*/
	public bool rellenarListaAnimaciones(){
	try{
		AnimationPlayer animPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		if (animPlayer != null)
			{
				animaciones.Add(animPlayer);
			}
	}catch(Exception e){
		GD.Print("Error al recorrer los nodos: " + e.Message); 
	}
	return animaciones.Count > 0;
}

	public override void _Ready(){
		GD.Print("hola");
		rellenarListaAnimaciones();
	}
	
	
}
