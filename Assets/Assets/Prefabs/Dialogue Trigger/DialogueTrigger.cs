using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
public class DialogueTrigger : MonoBehaviour
{
    BasicTrigger basicTrigger;
    public Dialogue dialogue;
    bool toggleGizmos;
    //
    private void Awake()
    {
        basicTrigger = this.GetComponent<BasicTrigger>();
        toggleGizmos = basicTrigger.toggleGizmos;
    }
    private void OnDrawGizmos()
    {
        if (toggleGizmos)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(this.transform.position, this.GetComponent<BoxCollider>().size);
            Gizmos.color = new Color(0, 0, 0, 1.1f);
            Gizmos.DrawCube(this.transform.position, this.GetComponent<BoxCollider>().size);
        }
    }
}
