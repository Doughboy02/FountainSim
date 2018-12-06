using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Fountain : MonoBehaviour {

    //public float Height;
    //public float speed;

    public float NozzleRadius;
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
        shape.radius = NozzleRadius;
    }
	
	// Update is called once per frame
	void Update () {
        //Water.startSpeed = 4.4f * Height * Mathf.Sin(Time.time / speed) + Height * 8f;
        //Water.startSpeed = PatternFunctions.SinWave(Height, speed, delay);
        //Water.startSpeed = PatternFunctions.VShape(Height, speed, delay);

        Velocity = Mathf.Sqrt((2* Mathf.Pow(MaxFlowRate, 2) * MaxPressure) / (WaterDensity * Mathf.Pow(MaxFlowRate, 2) + 2 * MaxPressure * Mathf.Pow(Mathf.PI, 2) * Mathf.Pow(NozzleRadius, 4)));
        Water.startSpeed = Velocity;


    }

    public void AdjustHeight(float nozzleRadius)
    {
        NozzleRadius = nozzleRadius;
    }

    public void ChangeColor(float red, float green, float blue)
    {
        SpotLight.color = new Color(red, green, blue);
    }
}
