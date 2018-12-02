using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Pattern
{
    Linear,
    SinWave,
    VShape
}

public class PatternFunctions : MonoBehaviour {

	public float Linear()
    {


        return 0;
    }

    public static float SinWave(float height, float speed, float delay)
    {
        return 4.4f * height * Mathf.Sin(Time.time / speed + delay) + height * 8f;
    }

    public static float VShape(float height, float speed, float delay)
    {
        return Mathf.Abs(Time.time / speed - delay);
    }
}
