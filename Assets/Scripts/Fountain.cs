using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Fountain : MonoBehaviour {

    //public float Height;
    //public float speed;

    public float VelocityPercentage;
    public float Diameter;
    public float Velocity;
    public float MaxFlowRate;
    public float MaxPressure;
    public float WaterDensity;


    public Color Color;
    public Light SpotLight;

    public ParticleSystem Water;

    public float delay;

    public UnityEvent Pattern;
    

    // Use this for initialization
    void Start () {
        var shape = Water.shape;
        shape.radius = Diameter;
    }
	
	// Update is called once per frame
	void Update () {
        //Water.startSpeed = 4.4f * Height * Mathf.Sin(Time.time / speed) + Height * 8f;
        //Water.startSpeed = PatternFunctions.SinWave(Height, speed, delay);
        //Water.startSpeed = PatternFunctions.VShape(Height, speed, delay);

        Velocity = Mathf.Sqrt((Mathf.Pow(MaxFlowRate, 2) * MaxPressure * 135.1473154f) / ((2122089428f * Mathf.Pow(Diameter, 4) * MaxPressure + (Mathf.Pow(MaxFlowRate, 2) ))* Mathf.Pow(Mathf.PI, 2)));
        Water.startSpeed = Velocity * VelocityPercentage;


    }

    public void AdjustHeight(float percent)
    {
        VelocityPercentage = percent;
    }

    public void ChangeColor(float red, float green, float blue)
    {
        SpotLight.color = new Color(red, green, blue);
    }
}
