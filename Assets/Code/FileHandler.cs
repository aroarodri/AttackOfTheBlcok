using System.IO;
using UnityEngine;

public class FileHandles : MonoBehaviour
{
    public void SaveScore(int score, string fileName)
    {
        ScoreCounter entry = new ScoreCounter(score);
        string json = JsonUtility.ToJson(entry);
        WriteFile(GetPath(), json);
    }
    private string GetPath()
    {
        return Application.persistentDataPath + "/scores.json";
    }

    private void WriteFile(string path, string content)
    {
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(content);
        }
    }

    public void SaveToJsonWithFullPath()
    {
        InputEntry entry = new InputEntry(10);
        string json = JsonUtility.ToJson(entry);
        System.IO.File.WriteAllText(GetPath(), json);
    }
}
