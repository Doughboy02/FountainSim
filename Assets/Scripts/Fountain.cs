using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fountain : MonoBehaviour {

    public float Height;
    public float speed;
    public Color Color;

    public ParticleSystem Water;

    private ParticleSystem.ColorOverLifetimeModule colorOverLifetime;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        Water.startSpeed = 4.4f * Height * Mathf.Sin(Time.time / speed) + Height * 8f;
        Debug.Log(Water.startSpeed);

    }

    public void AdjustHeight(float height)
    {
        //Water.startSpeed = height * 4.4f;
        //Water.startLifetime = 10 + Water.startSpeed;
        Height = height;
    }

    public void ChangeColor(float red, float green, float blue)
    {
        Color newColor = new Color(red, green, blue);
        Color = newColor;

        var col = Water.colorOverLifetime;
        col.enabled = true;

        Gradient grad = new Gradient();
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(newColor, 0.0f), new GradientColorKey(Color.white, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });

        col.color = grad;
    }
}
