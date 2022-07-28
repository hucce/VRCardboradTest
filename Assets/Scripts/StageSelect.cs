using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    public string stageName;

    public void OnPointerEnter()
    {
        StartCoroutine(CoLook());
    }

    public void OnPointerExit()
    {
        Manager.instance.lookAt = false;
    }

    IEnumerator CoLook()
    {
        yield return StartCoroutine(Manager.instance.Lookat());
        if (Manager.instance.lookAt == true)
        {
            SceneManager.LoadScene(stageName);
        }
    }
}
