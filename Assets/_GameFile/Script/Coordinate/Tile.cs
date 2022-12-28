using UnityEngine;

public class Tile : MonoBehaviour
{
   [SerializeField] private Tower[] towerPrefab = new Tower[3];
   [SerializeField] private bool canPlace = false;
   private Player player = default;
   private void Awake() 
   {
        player = FindObjectOfType<Player>();
   }

   private void OnMouseDown() 
   {
        if(!canPlace)return;
        CreateTower();
        
   }
   private void CreateTower()
   {
        var tower = Instantiate(towerPrefab[player.SelectionNumber],transform.position,Quaternion.identity);
        tower.Init();
        canPlace = false;
   }
}
