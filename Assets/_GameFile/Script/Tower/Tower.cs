using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private TowerType type;
    [SerializeField] private float radius = default;
    [SerializeField] private GameObject firePos;
    [SerializeField] private GameObject weapon;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private int bulletDamage = default;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private Pooling poolingBullet;
   
    private float fireRateTemp = 0; 
    
    protected float lookSpeed = 0.05f;
    protected float scale = 12f;
    protected GameObject target;
    protected GameObject Weapon{get => weapon;}
    protected float Radius {get => radius;}

   
    private void Update() 
    {
        AimEnemy();
    }
    public void Init()
    {
        Debug.Log("Init Tower");
    }

    protected virtual void AimEnemy()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position,radius * scale);
        float distance = 0;
        Vector3 direction;
        Quaternion rotateTo;

        foreach(Collider collider in colliders)
        {  
           if(collider.GetComponent<Enemy>() && collider.GetComponent<Enemy>().CanAtk && distance < Vector3.Distance(transform.position,collider.transform.position)) //Check Distance
           {
                target = collider.gameObject;
                distance = Vector3.Distance(transform.position,target.transform.position);
                direction = (target.transform.position - weapon.transform.position).normalized;
                rotateTo = Quaternion.LookRotation(direction);
                weapon.transform.rotation = Quaternion.Slerp(weapon.transform.rotation,rotateTo,lookSpeed);
                FireBullet();
           }
          
        }
       // if(target==null) return;
    }
    protected virtual void FireBullet()
    {
        if(fireRateTemp > fireRate)
        {
          
           // Bullet b = Instantiate(bulletPrefab,firePos.transform.position,weapon.transform.rotation);
    
            Bullet b = poolingBullet.GetFromPool().GetComponent<Bullet>(); // Get From Pool

            b.transform.position = firePos.transform.position;
            b.transform.rotation = weapon.transform.rotation;
            b.gameObject.SetActive(true);

            b.Init(firePos,bulletDamage);
            fireRateTemp = 0;
        }
        else fireRateTemp += Time.deltaTime;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos() 
    {
        Gizmos.DrawWireSphere(transform.position,radius*scale);
    }
#endif

}
