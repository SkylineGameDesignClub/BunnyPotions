using UnityEditor;
using UnityEngine;

public class CameraEditorMacro : EditorWindow
{
    [MenuItem("Tools/Reposition Camera")]
    static void RepositionCamera()
    {
        if (SceneView.lastActiveSceneView != null)
        {
            SceneView.lastActiveSceneView.pivot = new Vector3(0, -10, -10);
            SceneView.lastActiveSceneView.rotation = Quaternion.Euler(-45, 0, 0);
            SceneView.lastActiveSceneView.Repaint();
        }
    }
}
