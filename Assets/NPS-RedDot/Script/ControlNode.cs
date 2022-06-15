using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlNode : MonoBehaviour
{
    public string Id = "";
    public bool IsShow = false;

    [SerializeField] private GameObject content;

    private void OnEnable()
    {
        if (RedDotManager.S && RedDotManager.S.Tree.ContainsKey(Id))
            Set(RedDotManager.S.Tree[Id].IsShow);
    }

    public void Set(bool isShow)
    {
        IsShow = isShow;
        content.SetActive(isShow);
    }

    public void Init(string id, string parent)
    {
        Id = id;

        RedDotManager.S.UpdateTree(id, parent);
        Set(RedDotManager.S.Tree[id].IsShow);
    }
}
