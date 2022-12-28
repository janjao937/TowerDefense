using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class EnemyMove : MonoBehaviour
{
  [SerializeField] private float speed = 1;
  private List<Tile> path = new List<Tile>();
  private Enemy enemy;
   
  private void Awake() 
  {
    enemy = GetComponent<Enemy>();
    enemy.OnEnemyActive += Move;
  }
 
   private void Move(EnemyData enemyData) 
  {
    this.speed = enemyData.Speed; 
    FindPath();
    ResetPath();
    
    StartCoroutine(FollowPath());
  }

  private void ResetPath()
  {
    transform.position = path[0].transform.position;
  }
  private void FindPath()
  {
    path.Clear();
    GameObject [] waypoints = GameObject.FindGameObjectsWithTag("Path");
    foreach(GameObject waypoint in waypoints)
    {
      path.Add(waypoint.GetComponent<Tile>());
    }
  }

   private IEnumerator FollowPath()
  {
    
    foreach(Tile waypoint in path)
    {
      Vector3 startPos = transform.position;
      Vector3 endPos = waypoint.transform.position;
      float travelPercent = 0f;
      transform.LookAt(endPos);
      while(travelPercent<1)
      {
        travelPercent += Time.deltaTime * (speed/2.5f);
        transform.position =Vector3.Lerp(startPos,endPos,travelPercent);
        yield return new WaitForEndOfFrame();
      }
    }
    //Back To Pool
    gameObject.SetActive(false);

  }

  private void OnTriggerExit(Collider other) 
  {
    enemy.SetCanAtk(true);
  }
}
