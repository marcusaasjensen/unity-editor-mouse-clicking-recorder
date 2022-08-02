using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ByMarcusAasJensen))]
public class ByMarcusAasJensenEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        DrawHyperLinkButtons();
    }

    void DrawHyperLinkButtons()
    {
        ByMarcusAasJensen byMarcusAasJensen = (ByMarcusAasJensen)target;
        if (GUILayout.Button("Linktree /marcus_a")) { Application.OpenURL(byMarcusAasJensen.linktreeLink); }
        if (GUILayout.Button("Youtube /MarcusAasJensen_")) { Application.OpenURL(byMarcusAasJensen.youtubeLink); }
        if (GUILayout.Button("Instagram @marcus_aasjensen")) { Application.OpenURL(byMarcusAasJensen.instagramLink); }
        if (GUILayout.Button("Github /marcusaasjensen")) { Application.OpenURL(byMarcusAasJensen.githubLink); }
        if (GUILayout.Button("Itchio /marcus-a")) { Application.OpenURL(byMarcusAasJensen.itchioLink); }
    }
}