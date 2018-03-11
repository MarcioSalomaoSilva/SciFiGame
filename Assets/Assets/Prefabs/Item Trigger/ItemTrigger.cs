using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    BasicTrigger basicTrigger;
    bool toggleGizmos;
    // Use this for initialization
    private void Awake()
    {
        basicTrigger = this.GetComponent<BasicTrigger>();
        toggleGizmos = basicTrigger.toggleGizmos;
    }
    private void OnDrawGizmos()
    {
        if (toggleGizmos)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(this.transform.position, this.GetComponent<BoxCollider>().size);
            Gizmos.color = new Color(1, 0, 0, 0.1f);
            Gizmos.DrawCube(this.transform.position, this.GetComponent<BoxCollider>().size);
        }
    }
}
