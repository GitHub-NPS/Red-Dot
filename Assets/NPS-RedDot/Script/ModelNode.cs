using System.Collections.Generic;

[System.Serializable]
public class ModelNode
{
    public string Id;
    public List<string> Parents = new List<string>();
    public List<string> Childs = new List<string>();
    public bool IsShow = false;

    public ModelNode()
    {

    }

    public ModelNode(string id, bool isShow = false)
    {
        this.Id = id;
        this.IsShow = isShow;
    }
}
