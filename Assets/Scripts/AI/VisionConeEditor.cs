#if UNITY_EDITOR

using UnityEngine;
using System.Collections;
using UnityEditor;


//D Declaring a scustom editor
[CustomEditor (typeof (ConeOfVision))]
public class VisionConeEditor : Editor 
{

    public Transform player;
	
	//D shows the andle and radius for the stalker on scene tab
	void OnSceneGUI()
	{
		ConeOfVision cov = (ConeOfVision)target;
		Handles.color = Color.red;
		Handles.DrawWireArc (cov.transform.position, Vector3.up, Vector3.forward, 360, cov.viewRadius);
		Vector3 viewAngleA = cov.DirecFromAngle (-cov.viewAngle / 2, false);
		Vector3 viewAngleB = cov.DirecFromAngle (cov.viewAngle / 2, false);

		Handles.DrawLine(cov.transform.position, cov.transform.position + viewAngleA * cov.viewRadius);
		Handles.DrawLine(cov.transform.position, cov.transform.position + viewAngleB * cov.viewRadius);

		Handles.color = Color.red;
		foreach(Transform visibleTarget in cov.visibleTargets)
			{
				Handles.DrawLine (cov.transform.position, visibleTarget.position);
			}

	}

}
#endif