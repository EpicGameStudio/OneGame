using System.Collections;
using System.Collections.Generic;
using GameDataObject;
using UnityEngine;
using JsonManagerCore;
using System.IO;

public class DataManager : MonoBehaviour {

    private static DataManager instance;
    public static DataManager Instance
    {
        get
        {
            return instance;
        }
    }


    public GameObject player;

    private void Awake()
    {
        instance = this;
        LoadData();
    }
    // Use this for initialization
    void Start ()
    {
		
	}

    private void LoadData()
    {

        //----player data-----
        LoadPlayerData();


    }

    private const string playerDataFileName = @"player.data";
    private const string playerDataFileFolder = @"./Save/";
    private void LoadPlayerData()
    {
        var fullFileName = playerDataFileFolder + playerDataFileName;
        if (File.Exists(fullFileName))
        {
            var json = File.ReadAllText(fullFileName);
            try
            {
                var data = JsonMapper.ToObject<PlayerData>(json);
                if (data != null)
                {
                    playerData = data;
                    if (playerData.Position == null)
                    {
                        playerData.Position = new double[3] { 0, 0, 0 };
                    }

                    player.transform.position = new Vector3((float)playerData.Position[0], (float)playerData.Position[1], (float)playerData.Position[2]);
                }
                    
            }
            catch (System.Exception)
            {
                playerData = new PlayerData();
                var jsonToSave = JsonMapper.ToJson(playerData);
                Write(playerDataFileFolder, playerDataFileName, jsonToSave);
            }
        }
        else
        {
            playerData = new PlayerData();
            var jsonToSave = JsonMapper.ToJson(playerData);
            Write(playerDataFileFolder, playerDataFileName, jsonToSave);
        }
        
    }

    private void Write(string path,string fileName,string content)
    {
        var fullFileName = path + fileName;
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        
        FileStream fs = new FileStream(fullFileName, FileMode.Create);
        byte[] data = System.Text.Encoding.Default.GetBytes(content);
        fs.Write(data, 0, data.Length);
        fs.Flush();
        fs.Close();
    }

    private PlayerData playerData;
    public PlayerData GetPlayerData()
    {
        return playerData;
    }

    public void SavePlayerData()
    {
        var position = player.transform.position;
        playerData.Position =new double[3] { position.x, position.y, position.z } ;
        var jsonToSave = JsonMapper.ToJson(playerData);
        Write(playerDataFileFolder,playerDataFileName, jsonToSave);
    }
}
