using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireController : MonoBehaviour
{
    public int playerDamage;
    public GameObject shellExplosion;
    public GameObject fireEffect;
    public AudioClip shootSound;
    private AudioSource fireAuSource;
    public float gunSize;

    public float fireTime = 0.2f;
    private float lastFireTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        fireAuSource = gameObject.GetComponent<AudioSource>();
        fireAuSource.clip = shootSound;
    }

    void UpdateFireTime()
    {
        lastFireTime = Time.time;
    }

    void Fire()
    {
        if (Time.time >= lastFireTime + fireTime)
        {
            fireAuSource.Play();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 direction = hit.point - transform.position;
                Ray fireRay = new Ray(transform.position, direction);
                RaycastHit fireHit;
                if (Physics.Raycast(fireRay, out fireHit))
                {
                    if (fireHit.collider.tag == "Enemy")
                    {
                        fireHit.collider.gameObject.GetComponent<EnemyController>().GetHit(playerDamage);
                    }
                    else Instantiate(shellExplosion, fireHit.point, Quaternion.identity);
                    Vector3 fireEffectPosition = transform.position + gunSize * direction / direction.magnitude + new Vector3(0, 0.3f, 0);
                    Instantiate(fireEffect, fireEffectPosition, Quaternion.identity);
                }
            }

            UpdateFireTime();
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Fire();
        }
    }
}