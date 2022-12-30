using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public  class Bullet : MonoBehaviour
{   
    private BulletChecker bulletChecker;
    protected int damage = default;
    private float bulletForce = 5000;
    private Rigidbody rb;

    private void Awake() 
    {
        bulletChecker = FindObjectOfType<BulletChecker>();
        rb = GetComponent<Rigidbody>();   
    }
    
    public virtual void Init(GameObject firePos,int damage)
    {
        rb.AddForce(firePos.transform.forward * bulletForce * Time.deltaTime ,ForceMode.Impulse);
        this.damage = damage;
        Destroy(gameObject,5);//Test
    }

    protected void HitObject()
    {
        //Back To Pool
        Destroy(gameObject);
    }
    protected void SendCurrentEnemyTypeToBulletChecker(Enemy enemy)
    {
        bulletChecker.SetLastestEnemyType(enemy.EnemyType);
    }
    protected bool CheckLastEnemyType(Enemy enemy)
    {
        if(enemy.EnemyType == bulletChecker.LastestEnemtType) return true;
        return false;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(!other?.gameObject?.GetComponent<Enemy>()) return;
        Enemy e = other?.gameObject?.GetComponent<Enemy>();
       

        if(CheckLastEnemyType(e)) damage += 50/100;
        e.GetComponent<ITakeDamage>().TakeDamage(damage);

        SendCurrentEnemyTypeToBulletChecker(e);

        HitObject();
    }
    
   
}
