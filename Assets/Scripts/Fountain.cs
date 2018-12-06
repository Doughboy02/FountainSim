using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Fountain : MonoBehaviour {

    public float Height;
    public float speed;
    public Color Color;
    public Light SpotLight;

    public ParticleSystem Water;

    public float delay;

    public UnityEvent Pattern;
    

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        //Water.startSpeed = 4.4f * Height * Mathf.Sin(Time.time / speed) + Height * 8f;
        Water.startSpeed = PatternFunctions.SinWave(Height, speed, delay); 
        //Water.startSpeed = PatternFunctions.VShape(Height, speed, delay);



    }

    public void WaterPattern()
    {

    }

    public void AdjustHeight(float height)
    {
        Height = height;
    }

    public void ChangeColor(float red, float green, float blue)
    {
        SpotLight.color = new Color(red, green, blue);
    }
}
