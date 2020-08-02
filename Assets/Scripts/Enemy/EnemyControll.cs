using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyControll : MonoBehaviour
{
    public float life;

    public float damage;

    private float speed;

    private Text text;

    private GameObject player;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        text = GameObject.Find("[Placar]_Pontuacao").GetComponent<Text>();

        damage = 0.1f;

        speed = 5f;
    }

    void Update()
    {
        FollowPlayer();
    }


    void FollowPlayer()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.GetComponent<Transform>().position, speed * Time.deltaTime);
        }
    }

    public void EnemyTakeDamage(float damage)
    {
        life -= damage;
        if (life <= 0)
        {
            text.GetComponent<PunctuationControll>().ponts += 1;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            if (player != null)
            {
                player.GetComponent<PlayerControll>().PlayerTakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
