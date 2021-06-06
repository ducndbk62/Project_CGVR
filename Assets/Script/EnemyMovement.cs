using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    GameObject player;
    Vector3 moveTarget;
    Vector3 distanceVector;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        UpdateMoveTarget();
    }

    void UpdateMoveTarget()
    {
        distanceVector = new Vector3(Random.Range(-7.0f, 7.0f), -0.1f, Random.Range(-7.0f, 7.0f));
    }

    void Move()
    {
        if (player == null)
            return;
        transform.LookAt(moveTarget);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        moveTarget = player.transform.position + distanceVector;
        if (Vector3.Distance(transform.position, moveTarget) > 1.0f)
            Move();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Collision" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            UpdateMoveTarget();
        }        
    }
}