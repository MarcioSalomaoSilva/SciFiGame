using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
public class TriggerStates
{

}
//
[System.Serializable]
public enum TriggerTextState
{
    Text,
    Dialogue,
    NoText
}
//
[System.Serializable]
public enum TriggerTypeState
{
    None, Dialogue, Camera, Item, Door, DoubleDoor, SlidingDoor, DoubleSlidingDoor
}

