using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesManager : MonoBehaviour {

    private GameObject battleScene;
    private static ScenesManager instance;
    private GameObject scenes;
    public static ScenesManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject("ScenesManger");
                obj.AddComponent<ScenesManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
        scenes = GameObject.Find("Scenes");
        battleScene = scenes.transform.Find("BattleScene").gameObject;
        battleScene.SetActive(false);
    }

    // Use this for initialization
    void Start ()
    {
        
    }

    public void LoadBattleScene()
    {
        battleScene.SetActive(true);
        var manager = battleScene.GetComponent<BattleManager>();
        manager.StartBattle();
    }
    public void ExitBattleScene()
    {
        battleScene.SetActive(false);
    }


}
