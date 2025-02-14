using UnityEngine;
using UnityEditor;
using System.IO;

public class ModifySpritePixelsPerUnit : EditorWindow
{
    [MenuItem("Custom/Change Sprite Pixels To Units")]
    static void ChangePixelsPerUnit()
    {
        float newPixelsToUnits = 16;

        string[] guids = AssetDatabase.FindAssets("t:Sprite");

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            string metaPath = path + ".meta";

            if (File.Exists(metaPath) && metaPath.StartsWith("Assets"))
            {
                Debug.Log(metaPath);
                string metaContent = File.ReadAllText(metaPath);
                metaContent = metaContent.Replace("spritePixelsToUnits: 100", "spritePixelsToUnits: " + newPixelsToUnits);
                File.WriteAllText(metaPath, metaContent);
            }
        }

        AssetDatabase.Refresh();
    }
}