using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public GameObject playerObj = null;
    public float attackDistance = 5f;
    public int zombieHP = 100;
    public int zombieDamage = 10;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<NavMeshAgent>().SetDestination(playerObj.transform.position);
    }

    public void OnPointerEnter()
    {
        Manager.instance.Fire(true);
    }

    public void OnPointerExit()
    {
        Manager.instance.Fire(false);
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(playerObj.transform.position, transform.position);
        
        if (dis < attackDistance)
        {
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<Animator>().SetTrigger("Attack");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            zombieHP -= collision.gameObject.GetComponent<Bullet>().damage;
            if(zombieHP <= 0)
            {
                GetComponent<NavMeshAgent>().enabled = false;
                GetComponent<Animator>().SetTrigger("Dead");
            }
        }
    }
}
