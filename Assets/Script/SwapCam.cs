using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCam : MonoBehaviour
{
    public GameObject vcam1, vcam2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            vcam2.SetActive(true);
            vcam1.SetActive(false);
        }
        if (Input.GetMouseButtonUp(1))
        {
            vcam2.SetActive(false);
            vcam1.SetActive(true);
        }
    }
}
