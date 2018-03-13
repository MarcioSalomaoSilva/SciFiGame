using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEditor;
public class DoorTrigger : MonoBehaviour
{
    //BasicTrigger basicTrigger;
    Animator animator;
    public GameObject door;
    public bool pull;
    public bool randomAngleToggle;
    public float angle;
    public float randomAngleMin, randomAngleMax;
    public float rotationSpeed;
    // Use this for initialization
    private void Awake()
    {
        animator = this.gameObject.AddComponent<Animator>();
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerMotor.OnAction += DoAction;
        }
    }
    public void DoAction(bool actionWasPressed)
    {
        if (actionWasPressed)
        {
            if (door != null)
            {
                OpenDoor();
            }
        }
    }
    public void OpenDoor()
    {
    }
    //
    private void OnValidate()
    {
        if (door == null)
        {
            TriggerVariables();
        }
    }
    public void TriggerVariables()
    {
        Debug.LogError("Assign an object to door");
        //
    }
}
