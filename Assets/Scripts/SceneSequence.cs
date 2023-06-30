using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSequence : MonoBehaviour
{
    public GameObject Cam4;
    public GameObject Cam2;
    public GameObject Cam5;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TheSequence());
    }

    IEnumerator TheSequence() 
    { 
        yield return new WaitForSeconds(4);
        Cam2.SetActive(true);
        Cam4.SetActive(false);
        yield return new WaitForSeconds(4);
        Cam5.SetActive(true);
        Cam2.SetActive(false);
        yield return new WaitForSeconds(4);
        Cam5.SetActive(false);
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
