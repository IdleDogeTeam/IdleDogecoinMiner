using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
using System;

public class SaveManager : MonoBehaviour
{
    public GameSave Save = new GameSave();
    [Serializable]
    public class GameSave
    {
        public double doges = 0;
        public float dogesPerClick = 1;
        public float[] UpgradeLvlCost = new float[3] { 25, 100, 200 };
        public short version = 1;
        public float KHperS = 0;
        public int[] UpgradeCount = { 0, 0, 0 };
        public int a = 1;

        //[OnDeserializing]
        //internal void OnDeserializingMethod(StreamingContext context)
        //{

        //    GameSave temp;
        //    temp = (GameSave)context.Context;
        //    temp.doges = doges;
        //    UpgradeManage.doges = doges;
        //    UpgradeManage.dogesPerClick = dogesPerClick;
        //    UpgradeManage.KHperS = KHperS;
        //    UpgradeManage.UpgradeLvlCost = UpgradeLvlCost;
        //    UpgradeManage.version = version;
        //    UpgradeManage.UpgradeCount = UpgradeCount;
        //}

    }
    /// <summary>
    /// Sauvegarde le jeu
    /// </summary>
    /// <param name="gameSave">Le GameSave</param>
    public void SaveGame(GameSave gameSave)
    {
        try
        {
            gameSave.doges = UpgradeManage.doges;
            gameSave.dogesPerClick = UpgradeManage.dogesPerClick;
            gameSave.KHperS = UpgradeManage.KHperS;
            gameSave.UpgradeLvlCost = UpgradeManage.UpgradeLvlCost;
            gameSave.version = UpgradeManage.version;
            gameSave.UpgradeCount = UpgradeManage.UpgradeCount;
        }
        catch (NullReferenceException e)
        {
            Debug.Log("God dammit, rip my data : " + e.Message);

        }
        // BinaryFormatter bf = new BinaryFormatter();
        // FileStream file = File.Create(Application.persistentDataPath + "/save_game.dat");
        // bf.Serialize(file, gameSave);
        using (StreamWriter output = new StreamWriter(Application.persistentDataPath + "/save_game.json", false))
        {
            output.WriteLine(JsonUtility.ToJson(gameSave));
        }
        Debug.Log("Game Saved at : " + Application.persistentDataPath);
    }
    public GameSave LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/save_game.dat"))
        {
            // BinaryFormatter bf = new BinaryFormatter();
            // FileStream file = File.Open(Application.persistentDataPath + "/save_game.json", FileMode.Open);
            GameSave gameSave;
            using (StreamReader input = new StreamReader(Application.persistentDataPath + "/save_game.json"))
            {
                gameSave = JsonUtility.FromJson<GameSave>(input.ReadToEnd());
            }


            return gameSave;
        }
        else
        {
            Debug.Log(string.Format("File doesn't exist at path: {0}{1}, Loading defaults.", Application.persistentDataPath, "/save_game.dat"));
            return new GameSave();
        }

    }
    public void Extract()
    {
        UpgradeManage.doges = Save.doges;
        UpgradeManage.dogesPerClick = Save.dogesPerClick;
        UpgradeManage.KHperS = Save.KHperS;
        UpgradeManage.UpgradeLvlCost = Save.UpgradeLvlCost;
        UpgradeManage.version = Save.version;
        UpgradeManage.UpgradeCount = Save.UpgradeCount;
    }
    // Use this for initialization
    void Start()
    {
        Save = new GameSave();
        Save = LoadGame();
        Extract();
    }
    public void OnApplicationQuit()
    {
        SaveGame(Save);

    }

    // Update is called once per frame
    void Update()
    {


    }
}
