using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class CSaveSystem 
{
    public static void SavePlayer(CPlayer player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        CPlayerData data = new CPlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static CPlayerData LoadPlayer ()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            CPlayerData data = formatter.Deserialize(stream) as CPlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }
}
