using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoEquipment : MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private DemoItem itemPrb;

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            var item = Instantiate(itemPrb, content);
            item.Set(i);
        }
    }
}
