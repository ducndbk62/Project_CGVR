using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunRotation : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mousePosition.y > 226){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 hitPoint = hit.point;
                hitPoint.y = Mathf.Min(hitPoint.y, 1.5f);
                Vector3 look = hitPoint - transform.position;
                transform.rotation = Quaternion.LookRotation(look, Vector3.up);
            }
        }            
    }
}
