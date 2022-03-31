using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTarget : MonoBehaviour
{
    
    private int health = 100;
   
    public void TakeDamage(int value)
    {
        health -= value;
        if (health <= 0)
        {
            print("GameOver");
        }
    }


}
