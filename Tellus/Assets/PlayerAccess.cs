using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAccess : MonoBehaviour
{
    // Start is called before the first frame update
 public static PlayerAccess Instance { get; private set; }
 public HPSystem hp;
 
private void Awake() 
{ 
    // If there is an instance, and it's not me, delete myself.
    
    if (Instance != null && Instance != this) 
    { 
        Destroy(this); 
    } 
    else 
    { 
        Instance = this; 
    } 
}
}
