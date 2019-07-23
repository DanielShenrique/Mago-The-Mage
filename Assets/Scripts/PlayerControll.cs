using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public int life;

    public float speed;
    private float offset;

    private Rigidbody2D rb;

    [SerializeField]
    private Transform weaponPos;
    [SerializeField]
    private Transform firePos;

    [SerializeField]
    private GameObject bullet;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        offset = -90f;

        life = 1;
    }

    private void Update()
    {
        Shoot();
    }

    private void FixedUpdate()
    {
        Walk();
    }

    private void Walk()
    {
        float h = Input.GetAxisRaw("Horizontal") * speed;
        float v = Input.GetAxisRaw("Vertical") * speed;

        Vector2 mov = new Vector2(h, v);

        rb.velocity = mov;
    }

    public void PlayerTakeDamage(int damage)
    {
        life -= damage;

        if(life <= 0) { Destroy(gameObject); }
    }

    private void Shoot()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - weaponPos.position;
        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        weaponPos.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, firePos.position, weaponPos.rotation);
        }
    }

}
