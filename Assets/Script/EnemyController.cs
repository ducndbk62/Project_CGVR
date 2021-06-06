using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int hP;
    public int damage;

    public GameObject player;
    public GameObject enemyGun;
    public GameObject fireEffect;
    public GameObject shellExplosion;
    public GameObject tankExplosion;
    public float gunSize;

    public AudioClip shootSound;
    private AudioSource fireAuSource;

    public float fireTime;
    private float lastFireTime;

    private Vector3 fireDirection;

    // Start is called before the first frame update
    void Start()
    {
        fireAuSource = gameObject.GetComponent<AudioSource>();
        fireAuSource.clip = shootSound;

        player = GameObject.FindGameObjectWithTag("Player");
        UpdateFireTime();
        RotateGun();
    }

    public void GetHit(int damage)
    {
        hP -= damage;
        
        if (hP <= 0) Dead();
        else Instantiate(shellExplosion, gameObject.transform.position, Quaternion.identity);
    }

    void Dead()
    {
        Instantiate(tankExplosion, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void UpdateFireTime()
    {
        lastFireTime = Time.time;
        fireTime = Random.Range(2.0f, 5.0f);
    }

    void RotateGun()
    {
        enemyGun.transform.LookAt(player.transform.position);
        fireDirection = player.transform.position - enemyGun.transform.position;
    }

    void Fire()
    {
        if (Time.time >= lastFireTime + fireTime)
        {
            fireAuSource.Play();
            Ray fireRay = new Ray(enemyGun.transform.position, fireDirection);
            RaycastHit fireHit;
            if (Physics.Raycast(fireRay, out fireHit))
            {
                if (fireHit.collider.tag == "Player")
                {
                    fireHit.collider.gameObject.GetComponent<PlayerController>().GetHit(damage);
                }
                Instantiate(shellExplosion, fireHit.point, Quaternion.identity);
                Vector3 fireEffectPosition = enemyGun.transform.position + gunSize * fireDirection / fireDirection.magnitude + new Vector3(0, 0.3f, 0);
                Instantiate(fireEffect, fireEffectPosition, Quaternion.identity);
            }

            UpdateFireTime();
            RotateGun();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }
}
