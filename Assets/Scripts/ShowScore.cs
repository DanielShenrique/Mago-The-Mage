using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    [SerializeField] private Text text; 

    void Update()
    {
        int getPoints = PlayerPrefs.GetInt("Pontuation");
        text.GetComponent<Text>().text = getPoints.ToString();
    }
}
