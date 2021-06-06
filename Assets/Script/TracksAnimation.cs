using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracksAnimation : MonoBehaviour
{
    Animator anima;
    // Start is called before the first frame update
    void Start()
    {
        anima = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            anima.SetBool("isMoving", true);
        else if (Input.GetKey(KeyCode.DownArrow))
            anima.SetBool("isMoving", true);
        else anima.SetBool("isMoving", false);
    }
}
