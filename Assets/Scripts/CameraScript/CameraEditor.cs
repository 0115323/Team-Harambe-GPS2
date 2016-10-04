using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof (CameraScript))]
public class CameraEditor : Editor {
    void OnSceneGUI()
    {
        CameraScript cs = (CameraScript)target;
        Handles.color = Color.red;
        Handles.DrawWireArc (cs.player.transform.position, Vector3.up, Vector3.forward, 360, cs.renderRadius);    
    }

}
