using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSequence : MonoBehaviour
{
    public GameObject Cam1;
    public GameObject Cam2;
    public GameObject Cam3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TheSequence());
    }

    IEnumerator TheSequence() 
    { 
        yield return new WaitForSeconds(4);
        Cam2.SetActive(true);
        Cam1.SetActive(false);
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
