using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    [SerializeField] private List<Waypoint> path = default;
    public  List<Waypoint> Path {get => path;}
}
