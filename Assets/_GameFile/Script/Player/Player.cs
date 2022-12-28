using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  [SerializeField] private int selectionNumber = 0;

   public int SelectionNumber{get => selectionNumber;}

   public void SelectTower(int towerNum)
   {
        selectionNumber = towerNum;
   }
}
