using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoad 
{
    public static void SavePlayer(PlayerController player)
    { 
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.data";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("Save file not found");
            return null;
        }
    }

    public static void SaveAudio(AudioManager1 audio)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/audio.data";
        FileStream stream = new FileStream(path, FileMode.Create);
        AudioData data = new AudioData(audio);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static AudioData LoadAudio()
    {
        string path = Application.persistentDataPath + "/audio.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            AudioData data = formatter.Deserialize(stream) as AudioData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("Save file not found");
            return null;
        }
    }
}
