using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorDeactivator : MonoBehaviour
{

    void Awake()
    {
        Cursor.visible = false;
    }

}
