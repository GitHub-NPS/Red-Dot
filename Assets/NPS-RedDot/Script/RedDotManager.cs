using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;

public class RedDotManager : MonoBehaviour
{
    public static RedDotManager S;

    [ShowInInspector] public Dictionary<string, ModelNode> Tree = new Dictionary<string, ModelNode>();

    [SerializeField] private bool isLog = false;

    private void Awake()
    {
        if (!S) S = this;
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateTree(string id, string parent)
    {
        if (!Tree.ContainsKey(id))
        {
            if (isLog) Debug.Log("[Red-Dot] Create Node: " + id);
            Tree.Add(id, new ModelNode(id));
        }

        if (!Tree[id].Parents.Contains(parent))
        {
            if (isLog) Debug.Log("[Red-Dot] Add Parent: " + id + " => " + parent);
            Tree[id].Parents.Add(parent);
        }

        if (Tree.ContainsKey(parent) && !Tree[parent].Childs.Contains(id))
        {
            if (isLog) Debug.Log("[Red-Dot] Add Child: " + parent + " => " + id);
            Tree[parent].Childs.Add(id);

            if (Tree[id].IsShow) UpdateNode(parent, true);
        }
    }

    private void UpdateNode(string id, bool isShow, bool checkShow = true)
    {
        if (id != null && id != "" && Tree.ContainsKey(id) && (checkShow && Tree[id].IsShow != isShow || !checkShow))
        {
            if (isShow)
            {
                if (isLog) Debug.Log("[Red-Dot] RS: " + id + " => true");
                Tree[id].IsShow = true;

                UpdateUI(id, true);

                Tree[id].Parents.ForEach(x => UpdateNode(x, true));
            }
            else
            {
                if (Tree[id].Childs.Any(x => Tree[x].IsShow)) return;

                Tree[id].IsShow = false;

                UpdateUI(id, false);

                if (isLog) Debug.Log("[Red-Dot] RS: " + id + " => false");
                Tree[id].Parents.ForEach(x => UpdateNode(x, false));
            }
        }
    }

    private void UpdateUI(string id, bool isShow)
    {
        GameObject[] Nodes = GameObject.FindGameObjectsWithTag("ControlNode");
        foreach (GameObject Node in Nodes)
        {
            ControlNode ctl = Node.GetComponent<ControlNode>();
            if (ctl != null && ctl.Id == id) ctl.Set(isShow);
        }
    }
}
