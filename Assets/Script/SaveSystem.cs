
using UnityEngine;
using System.IO;

public static class SaveSystem
{
    public static void SavePlayer(Player player)
    {
        //Laitetaan arvot playerdata luokkaan, ja tallennetaan tiedot binary formatterilla persistent data path polkuun.
        string path = Application.persistentDataPath + "/player.json";
        PlayerData data = new PlayerData(player);
        File.WriteAllText(path, JsonUtility.ToJson(data));
    }
    public static PlayerData LoadPlayer()
    {
        //Avataan Bin��ritiedosto ja ladataan sielt� arvot playerdata luokkaan, josta ne ladataan pelaajalle..
        string path = Application.persistentDataPath + "/player.json";
        if (File.Exists(path))
        {
            return JsonUtility.FromJson<PlayerData>(File.ReadAllText(path));
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
    public static void Deleteall()
    {
        //Poistetaan kaikki tiedot

        foreach (string name in new[] { "/player.json", "/player.fun" })
        {
            string path = Application.persistentDataPath + name;
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
            
    }
}
