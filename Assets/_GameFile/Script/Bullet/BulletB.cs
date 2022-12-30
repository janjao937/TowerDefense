using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletB : Bullet
{
    [SerializeField] private float boomRadius = 15;
    [SerializeField] private int boomDamage = 10;

    private  List<float> distanceEnemyInArea = new List<float>();
    private Dictionary<float,Enemy> getDamageDic = new Dictionary<float, Enemy>();
  

    private void FindArearObject()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position,boomRadius);
       
        getDamageDic.Clear();
        distanceEnemyInArea.Clear();

        foreach(var collider in colliders)
        {
            if(collider.GetComponent<Enemy>())
            {
                float distance = Vector3.Distance(transform.position,collider.GetComponent<Enemy>().transform.position);

                distanceEnemyInArea.Add(distance);
                getDamageDic.Add(distance,collider.GetComponent<Enemy>());
            }
        }
        GiveDamageToEnemy();
    }

    private void GiveDamageToEnemy()
    {
        boomDamage = 10;//Set Boom Damage

        //Sorting List by distance
        distanceEnemyInArea.Sort(SortByDistance);
        //Get Enemy In Dic
        foreach(var i in distanceEnemyInArea)
        {
            Enemy e = getDamageDic[i];

            if(CheckLastEnemyType(e)) boomDamage += 50/100;

            e?.GetComponent<ITakeDamage>()?.TakeDamage(boomDamage);
            SendCurrentEnemyTypeToBulletChecker(e);

            boomDamage -=1;
            boomDamage = Mathf.Clamp(boomDamage,8,10);
        }

        HitObject();
    }
    private int SortByDistance(float distancA,float distancB)
    {
        if(distancA<distancB)
        {
            return -1;
        }
        else if(distancA>distancB)
        {
            return 1;
        }

        return 0;
    }

    private void OnTriggerEnter(Collider other) 
    {
        FindArearObject();
    }


   #if UNITY_EDITOR
    private void OnDrawGizmos() 
    {
        Gizmos.DrawWireSphere(transform.position,boomRadius);
    }
#endif
}
