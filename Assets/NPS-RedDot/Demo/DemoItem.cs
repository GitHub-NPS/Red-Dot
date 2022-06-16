using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoItem : MonoBehaviour
{
    [SerializeField] private ControlNode redDot;
    [SerializeField] private Text txtName;

    public void Set(int id)
    {
        txtName.text = "Item: " + id;

        redDot.Init("equipment#" + id, "equipment");
    }
}
