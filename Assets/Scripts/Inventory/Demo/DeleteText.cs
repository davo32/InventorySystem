using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeleteText : MonoBehaviour
{
    TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        InvokeRepeating("DeleteT",4,2);
    }

    void DeleteT()
    {
        if (text.text != null)
        { 
            text.text = "";
        }
    }

    
}
