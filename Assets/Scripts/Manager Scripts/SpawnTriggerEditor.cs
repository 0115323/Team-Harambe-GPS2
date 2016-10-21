
#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(SpawnTrigger))]
public class SpawnTriggerEditor : Editor {

    void OnSceneGUI()
    {
        SpawnTrigger ct = (SpawnTrigger)target;
        Handles.color = Color.green;
        Handles.DrawWireArc(ct.transform.position, Vector3.up, Vector3.forward,360,ct.checkRadius);
    }
}
#endif