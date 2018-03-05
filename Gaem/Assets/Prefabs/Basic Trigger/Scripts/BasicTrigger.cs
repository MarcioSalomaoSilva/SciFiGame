using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTrigger : MonoBehaviour
{
    //public delegate void BasicTriggerDelegate();
    //public static event BasicTriggerDelegate OnStay;
    //BasicTriggerDelegate mydelegate;
    bool guiActive;
    [Header("Debug Stuff")]
    [Help("This is some help text", UnityEditor.MessageType.None)]//UnityEditor.MessageType.Error UnityEditor.MessageType.Info UnityEditor.MessageType.None UnityEditor.MessageType.Warning
    [Space]
    public bool debug;
    public BoxCollider thisCollider;
    //stuff that can be changed
    [Header("Variables")]
    [Space]
    [TextArea]
    public string text;
    public GameObject applyOn;
    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerMotor.OnAction += DoAction;
        }
    }
    //
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerMotor.OnAction -= DoAction;
            guiActive = false;
        }
    }
    public void DoAction(bool actionWasPressed)
    {
        if (actionWasPressed)
        {
            guiActive = !guiActive;
        }
    }
    private void OnGUI()
    {
        if (guiActive)
        {
            GUI.Box(new Rect(
                (Screen.width / 2) - (Screen.width / 10),
                (Screen.height / 2) - (Screen.height / 10),
                Screen.width / 10,
                Screen.height / 10),
                text);
        }
    }
    private void OnDrawGizmos()
    {
        if (debug)
        {
            //draws camera location
            Gizmos.color = Color.black;
            Gizmos.DrawWireCube(this.transform.position, Vector3.one / 10);
            Gizmos.DrawLine(this.transform.position, applyOn.transform.position);
            Gizmos.DrawWireCube(applyOn.transform.position, Vector3.one / 10);
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(this.transform.position, thisCollider.size);
        }
        else
        {
            GetComponentInChildren<CameraTriggerGizmos>().debug = false;
        }
    }
}
