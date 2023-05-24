using System;
using System.IO;
using System.Runtime;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class BinaryFile {

    

    public static void SavePlayer (Player player) {
        BinaryFormatter bf = new BinaryFormatter ();
        FileStream stream = new FileStream (Application.persistentDataPath + "/player.sav", FileMode.Create);
        
        Debug.Log(Application.persistentDataPath + "/player.sav");
        PlayerData data = new PlayerData (player);
        bf.Serialize(stream, data);
        
        stream.Close ();
    }

    public static int[] LoadPlayer() {
        if (File.Exists (Application.persistentDataPath + "/player.sav")) {
            BinaryFormatter bf = new BinaryFormatter ();
            FileStream stream = new FileStream (Application.persistentDataPath + "/player.sav", FileMode.Open);

            PlayerData data = bf.Deserialize(stream) as PlayerData;

            stream.Close ();
            return data.stats;
        } else {
            Debug.Log("O arquivo não existe");
            return null;
        }
    }

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
}

[Serializable]

public class PlayerData {
    public int[] stats;

    public PlayerData (Player player) {
        stats = new int[3];
        stats[0] = player.life;
        stats[1] = player.attack;
        stats[2] = player.defense;

    }
}