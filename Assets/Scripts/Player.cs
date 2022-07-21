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
            playerHP -= collision.gameObject.GetComponent<Zombie>().zombieDamage;
        }
    }
}
