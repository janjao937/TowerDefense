using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   // [SerializeField] private bool isSpawn = true;
    [SerializeField] private Pooling pooling;
    [SerializeField] private EnemyData[] enemyDatas = new EnemyData[3];
    [SerializeField] private Enemy enemyPrefab;
    private float timeDistanceBetweenWave = 60;
    private int maxEnemyInWave = 10;
    private float spawnTimeInWave = 2f;
   

    private int countEnemyInGame = 0;

    //SerializeField For Watch in Inspacetor
    [SerializeField] private float timeTempDistanceBetweenWave = 0;
 
    [SerializeField] private int currentWave = 1;
  
    private void Awake() 
    {
        timeTempDistanceBetweenWave = timeDistanceBetweenWave;
        //timeTempToUpgradeEnemy = 0;
        currentWave = 0;
        countEnemyInGame = 0;
    }
    private void Update() 
    {
        WaveSpawn();
       // CountTimeForUpgradeEnemy();
    }

    private void WaveSpawn()
    {
        //if(!isSpawn) return;
        if(timeTempDistanceBetweenWave >= timeDistanceBetweenWave)
        {
            currentWave++;
            StartCoroutine(SpawnEnemyInWave());
          
        }
        else  timeTempDistanceBetweenWave += Time.deltaTime;
       
    }

    private void UpgradeEnemy()
    {
        Debug.Log("Upgrade Enemy | Speed and Hp + 0.5%");
        foreach(EnemyData enemyData in enemyDatas)
        {
            enemyData.Speed += (float)(0.5/100);
        }
    }
    
    private void RandomEnemyType()
    {
        int i = Random.Range(0,enemyDatas.Length);
        
        //Enemy enemy = Instantiate(enemyPrefab,transform);
        Enemy enemy = pooling.GetFromPool()?.GetComponent<Enemy>();
        enemy.gameObject.SetActive(true);
        enemy.Init(enemyDatas[i]);
    }

    IEnumerator SpawnEnemyInWave()
    {
        int currentEnemyInwave = 0;
        Debug.Log("new Wave");
        while(currentEnemyInwave < maxEnemyInWave)
        {
           // if(!isSpawn) yield return null;

            RandomEnemyType();
            currentEnemyInwave++;
            countEnemyInGame++;
            timeTempDistanceBetweenWave = 0;
            yield return new WaitForSeconds(spawnTimeInWave);
        }
        Debug.Log("End Wave");
        UpgradeEnemy();
    }
}


   // private float timeToUpgradeEnemy = 60;
    //[SerializeField] private float timeTempToUpgradeEnemy = 0;
    /*

    private void CountTimeForUpgradeEnemy()
    {
        if(timeTempToUpgradeEnemy >= timeToUpgradeEnemy)
        {
            UpgradeEnemy();
            timeTempToUpgradeEnemy = 0;
        }
        else timeTempToUpgradeEnemy += Time.deltaTime;
    }
*/