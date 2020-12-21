//Loads the scene to the scene name and sets the transition color as well as speed.
using UnityEngine;
using System.Collections;

public class Transition : MonoBehaviour {
    //name of the scene you want to load
    public string scene;
	public Color color;
	
	public void Fade()
    {
        Initiate.Fade(scene, color, 1.0f);
    }
}
