using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleControll : MonoBehaviour
{
    [SerializeField]
    private Transform rotCenter;

    private float rotRadius;
    private float angSpeed;

    private float posX;
    private float posY;
    private float ang;

    private void Start()
    {
        rotRadius = 1f;
        angSpeed = 2f;

        posX = 0;
        posY = 0;
        ang = 0;
    }

    private void Update()
    {
        RotationCircle();
    }

    void RotationCircle()
    {
        posX = rotCenter.position.x + Mathf.Cos(ang) * rotRadius;
        posY = rotCenter.position.y + Mathf.Sin(ang) * rotRadius;

        transform.position = new Vector2(posX, posY);
        ang = ang + Time.deltaTime * angSpeed;

        if(ang >= 360f)
        {
            ang = 0f;
        }
    }

}
