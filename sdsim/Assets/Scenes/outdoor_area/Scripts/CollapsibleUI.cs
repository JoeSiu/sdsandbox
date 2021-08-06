using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsibleUI : MonoBehaviour
{
   public List<GameObject> UIGroup = new List<GameObject>();

   private bool toggle = true;

   public void ToggleUI()
   {
       toggle = !toggle;

       foreach (GameObject UI in UIGroup)
       {
           UI.SetActive(toggle);
       }
   }
}
