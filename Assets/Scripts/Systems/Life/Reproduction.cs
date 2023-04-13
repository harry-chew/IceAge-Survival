using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reproduction : MonoBehaviour
{
    //reproduction system
    [SerializeField] private int reproduceCost;
    private float reproduceTimer;
    [SerializeField]
    private float reproduceInterval;
    [SerializeField]
    private int maxReproduction;
    private int totalReproduced;
    [SerializeField] private float reproductionPercent;

    //object spawning
    [SerializeField] private GameObject prefabToReproduce;
    private void ReproduceTimer()
    {
        reproduceTimer += Time.deltaTime;

        if (reproduceTimer >= reproduceInterval)
        {
            if (CanReproduce() && reproduceCost < 10)
            {
                Reproduce();
                reproduceTimer = 0.0f;
            }
        }
    }


    private void Reproduce()
    {
        if (totalReproduced > maxReproduction)
        {
            return;
        }
        //pick random spawn point for seedling near original
        Vector3 offset = new Vector3(Random.Range(-3f, 3f), 0, Random.Range(-3f, 3f));
        GameObject smallPlant = Instantiate(prefabToReproduce, transform.position + offset, Quaternion.identity);
        smallPlant.name = "Small Plant";
        smallPlant.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        totalReproduced++;

    }

    private bool CanReproduce()
    {
        if (Random.Range(0.0f, 1.0f) < reproductionPercent / 100)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
