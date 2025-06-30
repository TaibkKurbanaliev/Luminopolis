#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.IO;

public class AssetPreviewExporter
{
    [MenuItem("Tools/Export Asset Preview")]
    private static void ExportAssetPreview()
    {
        Object obj = Selection.activeObject;

        if (obj == null)
        {
            Debug.LogWarning("�������� ����� � Project!");
            return;
        }

        Texture2D preview = AssetPreview.GetAssetPreview(obj);

        if (preview == null)
        {
            AssetPreview.GetAssetPreview(obj);
            Debug.Log("������ ��� �� ������. ��������� � ���������� �����.");
            return;
        }

        Texture2D exportTexture = new Texture2D(preview.width, preview.height, TextureFormat.RGBA32, false);
        exportTexture.SetPixels(preview.GetPixels());
        exportTexture.Apply();

        string path = Path.Combine(Application.dataPath, obj.name + "_Preview.png");

        File.WriteAllBytes(path, exportTexture.EncodeToPNG());
        Debug.Log("��������������: " + path);

        AssetDatabase.Refresh();
    }
}
#endif