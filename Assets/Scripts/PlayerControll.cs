using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControll : MonoBehaviour
{

    public float life;

    public float speed;
    private float offset;

    private Rigidbody2D rb;

    [SerializeField]
    private Transform weaponPos;
    [SerializeField]
    private Transform firePos;

    [SerializeField]
    private GameObject bullet;

    private Image hearth;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        hearth = GameObject.Find("[Hearth]_Vida").GetComponent<Image>();
    }

    private void Start()
    {
        offset = -90f;
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
        float moveX = 0;
        float moveY = 0;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveY = +1f;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveX = +1f;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveX = -1f;
        }

        Vector2 moveDir = new Vector2(moveX,moveY).normalized;
        rb.velocity = moveDir * speed;
    }

    public void PlayerTakeDamage(float damage)
    {
        life -= damage;

        hearth.fillAmount = life;

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
