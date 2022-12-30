using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Enemy : MonoBehaviour, ITakeDamage
{
    [SerializeField] private EnemyType enemyType;
    [SerializeField] private Bar hpBar;
    private float speed;
    private float hp;
    private Renderer rend;

    private bool canAtk = false;
    public EnemyType EnemyType{get => enemyType;}
    public bool CanAtk{get => canAtk;}
    public float Speed {get => speed;}
   
    public event Action OnEnemyActive;

    private void OnDisable() 
    {
        canAtk = false;
    }

    private void Awake() 
    {
        rend = GetComponentInChildren<Renderer>();
        canAtk = false;
    }
    private void SetupHealthBar() => hpBar.SetMaxBarValue(hp);
   
    public void Init(EnemyData enemyData)
    {
        enemyType = enemyData.EnemyType;
        speed = enemyData.Speed;
        hp = enemyData.Hp;
        rend.sharedMaterial = enemyData.material;

        SetupHealthBar();
        OnEnemyActive?.Invoke();
    }
     public void SetCanAtk(bool value)
    {
        canAtk = value;
    }
    public void TakeDamage(int damage)
    {
       // Debug.Log("Take Damage"+ damage);
        hp -= damage;
        hpBar.SetBarValue(hp);
        if(hp<= 0) Death();
    }
    private void Death()
    {
        gameObject.SetActive(false);
    }
    public void Slow(int slowPercent)
    {
        speed =- (slowPercent/100);
        speed = Mathf.Clamp(speed,1-(slowPercent/100),5);
    }
}
