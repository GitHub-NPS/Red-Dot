using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoNode : MonoBehaviour
{
    [SerializeField] private ControlNode node;

    public void Click()
    {
        RedDotManager.S.Ping(!node.IsShow, node.Id);
    }
}
