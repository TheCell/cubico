using System.IO;
using UnityEngine;

public static class PersistanceManager
{
    private static string basicPath = Application.persistentDataPath;

    public static void SaveFile(string fileName, SaveFile saveFile)
    {
        string fullPath = Path.Combine(basicPath, fileName);
        Debug.Log(fullPath);

        var cubicoSaveFile = JsonUtility.ToJson(saveFile);
        StreamWriter sw = File.CreateText(fullPath);
        sw.Close();

        File.WriteAllText(fullPath, cubicoSaveFile);
        Debug.Log($"saved {fullPath}");
    }

    public static SaveFile LoadFile(string fileName)
    {
        string fullPath = Path.Combine(basicPath, fileName);

        if (File.Exists(fullPath))
        {
            var json = File.ReadAllText(fullPath);
            Debug.Log($"loaded {fullPath}");
            return JsonUtility.FromJson<SaveFile>(json);
        }

        return new SaveFile();
    }

    public static bool FileExists(string fileName)
    {
        string fullPath = Path.Combine(basicPath, fileName);

        return File.Exists(fullPath);
    }
}
