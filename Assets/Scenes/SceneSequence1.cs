using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSequence1 : MonoBehaviour
{
    public GameObject Cam10;
    public GameObject Cam11;
    public GameObject Cam12;
    void Start()
    {
        StartCoroutine (TheSequence());
    }

    IEnumerator TheSequence()
    {
        yield return new WaitForSeconds(4);
        Cam11.SetActive(true);
        Cam10.SetActive(false);
        yield return new WaitForSeconds(4); 
        Cam12.SetActive(true);
        Cam11.SetActive(false);
        yield return new WaitForSeconds(4);
        Cam12.SetActive(false);
    }
}
