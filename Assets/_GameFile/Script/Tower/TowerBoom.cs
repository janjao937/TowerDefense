using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBoom : Tower
{
    protected override void AimEnemy()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position,Radius * scale);
        float distance = 0;
        Vector3 direction;
        Quaternion rotateTo;
        float hpTemp = 0;

        foreach(Collider collider in colliders)
        {  
           if(collider.GetComponent<Enemy>() && collider.GetComponent<Enemy>().CanAtk && distance > Vector3.Distance(transform.position,collider.transform.position) && collider.GetComponent<Enemy>().Hp > hpTemp) //Check Distance
           {
                target = collider.gameObject;
                hpTemp = collider.GetComponent<Enemy>().Hp;
                distance = Vector3.Distance(transform.position,target.transform.position);
                direction = (target.transform.position - Weapon.transform.position).normalized;
                rotateTo = Quaternion.LookRotation(direction);
                Weapon.transform.rotation = Quaternion.Slerp(Weapon.transform.rotation,rotateTo,lookSpeed);
                FireBullet();
           }
          
        }
        
    }
    protected override void FireBullet()
    {
        base.FireBullet();
    }


}
