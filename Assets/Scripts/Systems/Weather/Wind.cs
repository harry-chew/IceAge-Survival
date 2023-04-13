using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public Vector3 position;
    public float windSpeed;
    public Vector2 windDirection;

    public Vector2 CalculateWind(float windSpeed, Vector2 windDirection)
    {
        return new Vector2(windDirection.x * windSpeed, windDirection.y * windSpeed);
    }
}
