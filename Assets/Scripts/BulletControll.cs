using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControll : MonoBehaviour
{
    private float bulletSpeed;

    private GameObject eCon;

    public int damage;

    private void Start()
    {
        bulletSpeed = 15f;
    }

    void Update()
    {
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            eCon = coll.gameObject;
            eCon.GetComponent<EnemyControll>().EnemyTakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
