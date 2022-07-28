using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    private static Manager _instance = null;
    public static Manager instance { get { return _instance;} }

    public float WaitTime = 2f;

    public RectTransform circleObj = null;

    public bool lookAt = false;

    private void Awake()
    {
        _instance = this;
    }

    public IEnumerator Lookat()
    {
        float _time = 0;
        lookAt = true;
        while (_time < WaitTime && lookAt)
        {
            float time = 0;
            time += _time / WaitTime;
            float t = Mathf.Lerp(0, 25, time);
            Vector2 vector2 = new Vector2(t, t);
            circleObj.sizeDelta = vector2;

            yield return new WaitForSeconds(0.1f);
            _time += 0.1f;
        }
    }

    public GameObject bulletObj = null;
    public Transform bulletPos = null;
    public ParticleSystem bulletParticle = null;
    public float bulletSpeed = 300;
    public float shootTime = 0.2f;
    private bool shot = false;

    public void Fire(bool _shot)
    {
        shot = _shot;
        StartCoroutine(CoFire());
    }

    public IEnumerator CoFire()
    {
        while(shot == true)
        {
            GameObject bullet =  GameObject.Instantiate(bulletObj);
            bullet.transform.position = bulletPos.position;
            bullet.transform.forward = bulletPos.forward;
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bulletSpeed);
            bulletParticle.Play();
            bulletPos.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(shootTime);
        }
    }

    public List<GameObject> zombies = new List<GameObject>();

    public GameObject gameUI = null;
    public Text gameText = null;

    public void CheckZombies()
    {
        bool allZombiesDead = true;
        for (int i =0; i<zombies.Count; i++)
        {
            if (zombies[i].GetComponent<Zombie>().dead == false)
            {
                allZombiesDead = false;
                break;
            }
        }

        if (allZombiesDead)
        {
            gameUI.SetActive(true);
            gameText.text = "Game Clear";
        }
    }

    public void GameOver()
    {
        gameUI.SetActive(true);
        gameText.text = "Game Over";
    }
}
