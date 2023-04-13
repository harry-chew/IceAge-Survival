using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerC
{
    internal IEnumerator TimeToWait(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
    }
}
