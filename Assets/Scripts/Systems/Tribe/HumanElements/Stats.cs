using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [Range(5, 15)]
    [SerializeField] private int strength;

    [Range(5, 15)]
    [SerializeField] private int constitution;

    [Range(5, 15)]
    [SerializeField] private int agility;

    [Range(5, 15)]
    [SerializeField] private int wisdom;

    [Range(5, 15)]
    [SerializeField] private int intellect;

    [Range(5, 15)]
    [SerializeField] private int charisma;
}
