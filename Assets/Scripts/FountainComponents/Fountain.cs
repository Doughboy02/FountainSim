using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Fountain : MonoBehaviour {

    //public float Height;
    //public float speed;

    public GameObject Pump;
    public GameObject Nozzel;
    public GameObject Light;
    public ParticleSystem Water;
    public float delay;

    private float _waterDensity = 1000f;
    private float _velocity;    

    // Use this for initialization
    void Start () {
        var shape = Water.shape;
        shape.radius = Nozzel.GetComponent<Nozzel>().Diameter;
    }
	
	// Update is called once per frame
	void Update () {
        //Water.startSpeed = 4.4f * Height * Mathf.Sin(Time.time / speed) + Height * 8f;
        //Water.startSpeed = PatternFunctions.SinWave(Height, speed, delay);
        //Water.startSpeed = PatternFunctions.VShape(Height, speed, delay);

        _velocity = Mathf.Sqrt((Mathf.Pow(Pump.GetComponent<Pump>().MaxFlowRate, 2) * Pump.GetComponent<Pump>().MaxPressure * 135.1473154f) / ((2122089428f * Mathf.Pow(Nozzel.GetComponent<Nozzel>().Diameter, 4) * Pump.GetComponent<Pump>().MaxPressure + (Mathf.Pow(Pump.GetComponent<Pump>().MaxFlowRate, 2) ))* Mathf.Pow(Mathf.PI, 2)));
        Water.startSpeed = _velocity * Pump.GetComponent<Pump>().VelocityPercentage;


    }

    public void AdjustHeight(float percent)
    {
        Pump.GetComponent<Pump>().VelocityPercentage = percent;
    }

    public void ChangeColor(float red, float green, float blue)
    {
        Light.GetComponent<Lighting>().Light.color = new Color(red, green, blue);
    }
}
