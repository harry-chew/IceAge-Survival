using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personality : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] private int extroversion;

    [Range(0, 100)]
    [SerializeField] private int intuition;

    [Range(0, 100)]
    [SerializeField] private int brainpower;

    [Range(0, 100)]
    [SerializeField] private int order;
}
