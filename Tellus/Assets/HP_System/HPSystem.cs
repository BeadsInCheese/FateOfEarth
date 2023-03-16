using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHp;
    int hp;
    void Start()
    {
        hp=maxHp;
    }
    public bool takeDamage(int amount){
        hp-=amount;
        if(hp<0){return false;}
        return true;
    }
    public void heal(int amount){
        hp+=amount;
        if(hp>maxHp){
            hp=maxHp;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
