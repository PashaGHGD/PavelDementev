using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class MenuUI : MonoBehaviour
{
    public abstract void Execute();
    public abstract void Cancel();

}


internal enum StateUI {
    None = 0,
    PanelOne = 1,
    PanelTwo = 2,
}