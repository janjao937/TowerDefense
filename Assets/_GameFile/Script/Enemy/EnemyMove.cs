using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
   [SerializeField] private EnemyPath path;
   [SerializeField] private float speed = 1;

   public void Init(EnemyPath path)
   {
        this.path = path;
        StartCoroutine(FollowPath());
   }

   private void Start() 
   {
     StartCoroutine(FollowPath());
   }
   private IEnumerator FollowPath()
   {
        foreach(Waypoint waypoint in path.Path)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = waypoint.transform.position;
            float travelPercent = 0f;
            transform.LookAt(endPos);
            while(travelPercent<1)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position =Vector3.Lerp(startPos,endPos,travelPercent);
                yield return new WaitForEndOfFrame();
            }
           
         
        }

   }
}
