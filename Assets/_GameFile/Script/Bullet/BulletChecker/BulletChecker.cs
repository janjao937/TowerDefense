using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletChecker : MonoBehaviour
{
    [SerializeField] private EnemyType lastestEnemyType = EnemyType.TypeDefault;
    public EnemyType LastestEnemtType {get => lastestEnemyType;}

    public void SetLastestEnemyType(EnemyType enemyType)
    {
        lastestEnemyType = enemyType;
    }
}
