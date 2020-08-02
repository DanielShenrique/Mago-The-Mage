using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PunctuationControll : MonoBehaviour
{
    public int ponts;
    public Text text;
    void Start()
    {
        ponts = 0;
    }
    void Update()
    {
        text.GetComponent<Text>().text = ponts.ToString();
        PlayerPrefs.SetInt("Pontuation", ponts);
    }
}
