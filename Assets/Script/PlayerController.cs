using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int hP;
    public GameObject playerTank;
    public GameObject tankExplosion;
    public Slider hPBar;

    private int currentHP;
    private GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = hP;
        hPBar.maxValue = hP;
        hPBar.value = currentHP;
        hPBar.minValue = 0;
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    public void GetHit(int damage)
    {
        currentHP -= damage;
        hPBar.value = currentHP;

        if (currentHP <= 0) Dead();
    }

    void Dead()
    {
        Instantiate(tankExplosion, gameObject.transform.position, Quaternion.identity);
        Destroy(playerTank);
        gameController.GetComponent<GameController>().EndGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
