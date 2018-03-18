using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
public class DialogueTrigger : MonoBehaviour
{
    BasicTrigger basicTrigger;
    public Dialogue dialogue;
    [HideInInspector]
    public bool trigger = true;
    //
    private void Awake()
    {
        basicTrigger = this.GetComponent<BasicTrigger>();
    }
    private void OnDrawGizmos()
    {
        if (DebugManager.instance.gizmos)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(this.transform.position, this.GetComponent<BoxCollider>().size);
            Gizmos.color = new Color(0, 0, 1, 0.1f);
            Gizmos.DrawCube(this.transform.position, this.GetComponent<BoxCollider>().size);
        }
    }
}
