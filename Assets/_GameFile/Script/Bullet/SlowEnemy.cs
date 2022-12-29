using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEnemy : MonoBehaviour
{
    private int slowPercent = 35;

    private void OnTriggerEnter(Collider other) 
    {
        Enemy e = other.GetComponent<Enemy>();

        e?.Slow(slowPercent);
    }
}
