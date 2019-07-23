using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyControll : MonoBehaviour
{
    public int life; 

    private int damage;

    private float speedE;

    private Text text;

    private PlayerControll player;

    private Transform playerT;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControll>();
        playerT = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
       
        text = GameObject.Find("[Placar]_Pontuacao").GetComponent<Text>();

        damage = 1;

        speedE = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }


    void FollowPlayer()
    {
        if (playerT != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerT.position, speedE * Time.deltaTime);
        }    
    }

    public void EnemyTakeDamage(int damage)
    {
        life -= damage;
        if(life <= 0)
        {
            text.GetComponent<PunctuationControll>().punt += 1;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            if (player != null)
            {
                player.PlayerTakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
