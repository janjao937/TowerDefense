using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Enemy : MonoBehaviour, ITakeDamage
{
    private EnemyType enemyType;
    private float speed;
    private float hp;
    private Renderer rend;

    [SerializeField] private bool canAtk = false;

    public bool CanAtk{get => canAtk;}
    public float Speed {get => speed;}
    public event Action<EnemyData> OnEnemyActive;

    private void OnDisable() 
    {
        canAtk = false;
    }
    private void Awake() 
    {
        rend = GetComponentInChildren<Renderer>();
        canAtk = false;
    }
   
    public void Init(EnemyData enemyData)
    {
        enemyType = enemyData.EnemyType;
        speed = enemyData.Speed;
        hp = enemyData.Hp;
        rend.sharedMaterial = enemyData.material;
        OnEnemyActive?.Invoke(enemyData);
    }
     public void SetCanAtk(bool value)
    {
        canAtk = value;
    }
    public void TakeDamage(int damage)
    {
        throw new System.NotImplementedException();
    }
}
