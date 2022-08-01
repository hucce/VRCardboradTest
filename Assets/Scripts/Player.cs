using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerHP = 100;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ZombieArm")
        {
            playerHP -= collision.transform.parent.GetComponent<Zombie>().zombieDamage;
            Manager.instance.HPUI(playerHP);
            if(playerHP <= 0)
            {
                Manager.instance.GameOver();
            }
        }
    }
}
