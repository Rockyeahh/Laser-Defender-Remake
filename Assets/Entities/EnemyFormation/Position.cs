using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1);       // Draws that wire sphere that you can see around them in the Editor.
    }
}
