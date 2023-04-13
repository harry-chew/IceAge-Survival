using UnityEngine;

public abstract class ResourceAbstract: MonoBehaviour
{
    private float collectionTime;
    private int resourceAmount;
    private float spoilTime;

    //public abstract void Gather();

    public float GetCollectionTime()
    {
        return collectionTime;
    }

    public int GetResourceAmount()
    {
        return resourceAmount;
    }

    public float GetSpoilTime()
    {
        return spoilTime;
    }
}
