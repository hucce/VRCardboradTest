using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerHP = 100;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.tag == "ZombieArm")
        {
            playerHP -= collision.transform.parent.GetComponent<Zombie>().zombieDamage;
            if(playerHP <= 0)
            {
                Manager.instance.GameOver();
            }
        }
    }
}
