using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
[System.Serializable]
public class BasicTrigger : MonoBehaviour
{
    public TriggerTypeState triggerState;
    //public delegate void BasicTriggerDelegate();
    //public static event BasicTriggerDelegate OnStay;
    //BasicTriggerDelegate mydelegate;
    bool guiActive;
    //stuff that can be changed
    [Header("Variables")]
    [Space]
    public TriggerText triggerText;
    //for debugging
    [Header("Debug Stuff")]
    [Space]
    BoxCollider boxCollider;
    public bool toggleGizmos;
    // Use this for initialization
    private void OnValidate()
    {
        boxCollider = this.GetComponent<BoxCollider>();
    }
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
    public void ToggleGizmos()
    {
        toggleGizmos = !toggleGizmos;
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
                triggerText.title);
        }
    }
    private void OnDrawGizmos()
    {
        if (toggleGizmos)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(this.transform.position, boxCollider.size);
            Gizmos.color = new Color(0,1,0,0.1f);
            Gizmos.DrawCube(this.transform.position, boxCollider.size);
        }
    }
}
