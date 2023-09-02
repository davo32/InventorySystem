using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatSlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Stat;
    [SerializeField] private TextMeshProUGUI Number;

    public void SetStat(string StatName, int number)
    { 
        Stat.text = StatName;
        Number.text = number.ToString();
    }


}
