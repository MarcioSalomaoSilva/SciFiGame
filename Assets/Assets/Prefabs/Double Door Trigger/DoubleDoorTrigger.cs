using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoorTrigger : MonoBehaviour
{
    BasicTrigger basicTrigger;
    [HideInInspector]
    public bool trigger = true;
    // Use this for initialization
    private void Awake()
    {
        basicTrigger = this.GetComponent<BasicTrigger>();
    }
    private void OnDrawGizmos()
    {
        if (DebugManager.instance.gizmos)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(this.transform.position, this.GetComponent<BoxCollider>().size);
            Gizmos.color = new Color(0, 1, 0, 0.1f);
            Gizmos.DrawCube(this.transform.position, this.GetComponent<BoxCollider>().size);
        }
    }
}
