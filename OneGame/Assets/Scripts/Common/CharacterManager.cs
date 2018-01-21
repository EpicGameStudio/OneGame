using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class CharacterManager : MonoBehaviour {

    private static CharacterManager instance;
    public static CharacterManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = new GameObject();
                obj.AddComponent<CharacterManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;        
        Load();
    }


    private const string NPCDataJsonPath = "/Data/NPC.json";
    private const string NPC_DATA_PREFS = "NPC_DATA";
    private Dictionary<string, NPCBase> Items;

    // Use this for initialization
    void Start ()
    {
        
        

    }

    private void Load()
    {
        //var jsonText = File.ReadAllText(NPCDataJsonPath);
        var jsonText = PlayerPrefs.GetString(NPC_DATA_PREFS);
        if (string.IsNullOrEmpty(jsonText))
        {
            Items = new Dictionary<string, NPCBase>();
            return;
        }
        var obj = JsonConvert.DeserializeObject<Dictionary<string, NPCBase>>(jsonText);
        try
        {
            if (!Equals(obj, null))
            {
                Items = obj;
            }
        }
        catch (System.Exception)
        {
            Items = new Dictionary<string, NPCBase>();
        }
    }

    public int Count
    {
        get
        {
            return Items.Count;
        }
    }

    public NPCBase GetNPC(string id)
    {
        if (Equals(Items, null))
            throw new System.Exception("NPC object is null");
        if (Items.ContainsKey(id))
        {
            return Items[id];
        }
        throw new System.Exception("NPC id is not found");
    }

    public void AddNPC(NPCBase item)
    {
        if (string.IsNullOrEmpty(item.Id))
            throw new System.Exception("id of npc cannot be empty");

        if (Items.ContainsKey(item.Id))
            throw new System.Exception("the is you provide has already exist");

        Items[item.Id] = item;
    }

    public void Save()
    {
        var json = JsonConvert.SerializeObject(Items);
        PlayerPrefs.SetString(NPC_DATA_PREFS, json);
    }

}
