using System.Collections;
using UnityEngine;

public class InstantiateTrigger : MonoBehaviour
{
    public void CreateObject(string name)
    {
        GameObject instance = Instantiate(Resources.Load(name, typeof(GameObject))) as GameObject;
    }
}
