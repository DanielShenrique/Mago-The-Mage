using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PunctuationControll : MonoBehaviour
{
    public int punt;

    public Text text;

    void Start()
    {
        punt = 0;
    }

    void Update()
    {
        text.GetComponent<Text>().text = punt.ToString();
    }
}
