using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traits : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] private int beauty;

    [Range(0, 100)]
    [SerializeField] private int acumen;

    [Range(0, 100)]
    [SerializeField] private int morality;

    [Range(0, 100)]
    [SerializeField] private int geneticPurity;
    //genetic maximum age
    //how mixed the race/genes are

    [Range(0, 2)]
    [SerializeField] private int gigantism;
    //0 = dwarism
    //1 = normal
    //2 = gigantism

    [Range(0, 100)]
    [SerializeField] private int speechImpediment;

    [Range(0, 1)]
    [SerializeField] private int hunchBack;

    [Range(0, 1)]
    [SerializeField] private int dysmorphia;
    //random body part is shaped different
    //if too large, cannot use bodypart

    [Range(0, 1)]
    [SerializeField] private int scoliosis;

    [Range(0, 1)]
    [SerializeField] private int deafness;

    [Range(0, 1)]
    [SerializeField] private int blindness;

    [Range(0, 100)]
    [SerializeField] private int hairiness;

    [Range(0, 1)]
    [SerializeField] private int albino;

    [Range(0, 2)]
    [SerializeField] private int wheeziness;

    [Range(0, 100)]
    [SerializeField] private int fertility;

    [Range(0, 100)]
    [SerializeField] private int horniness;

    [Range(0, 1)]
    [SerializeField] private int haemophilia;

    [Range(0, 1)]
    [SerializeField] private int berserk;

    [Range(0, 100)]
    [SerializeField] private int transness;

    [Range(0, 100)]
    [SerializeField] private int loyalty;

    [Range(0, 1)]
    [SerializeField] private int schitzo;

    [Range(0, 100)]
    [SerializeField] private int depression;

    [Range(0, 100)]
    [SerializeField] private int spirituality;
    
}   
