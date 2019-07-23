using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PunctuationControll : MonoBehaviour
{
    public int punt;

    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        punt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.GetComponent<Text>().text = punt.ToString();
    }
}
