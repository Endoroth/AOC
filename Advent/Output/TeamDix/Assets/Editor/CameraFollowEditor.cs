using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CameraFollow))]
public class CameraFollowEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var script = (CameraFollow)target;

        if (GUILayout.Button("Set Minimum Camera Position"))
        {
            script.SetMinCamPosition();
        }

        if (GUILayout.Button("Set Maximum Camera Position"))
        {
            script.SetMaxCamPosition();
        }
    }
}
