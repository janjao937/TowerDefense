using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Bullet : MonoBehaviour
{   
    protected int damage = default;
    private float bulletForce = 5000;
    private Rigidbody rb;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();   
    }
    
    public virtual void Init(GameObject firePos,int damage)
    {
        rb.AddForce(firePos.transform.forward * bulletForce * Time.deltaTime ,ForceMode.Impulse);
        
        Destroy(gameObject,5);//Test
    }

    protected void HitObject()
    {
        //Back To Pool
        Destroy(gameObject);
    }
    protected abstract void BulletEffect(GameObject target);

    private void OnTriggerEnter(Collider other) 
    {
        if(!other?.gameObject?.GetComponent<Enemy>()) return;

        HitObject();
    }
   
}
