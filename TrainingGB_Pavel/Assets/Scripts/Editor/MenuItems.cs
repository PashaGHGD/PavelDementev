using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class MenuItems  {

    [MenuItem("MyWindow/����� ���� �0 %v")]
    private static void MenuOption() {
        EditorWindow.GetWindow(typeof(MyWindow), false, "MyWindow");
    }
}


