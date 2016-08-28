using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class UpgradeManage : MonoBehaviour
{
    public static double doges = 0;
    public static float dogesPerClick = 1;
    public static float CPCDisplay { get { return (float)Math.Round(dogesPerClick, 3); } set { ; } }

    public static float dogesPerSec
    {
        get { return (0.2f * UpgradeCount[0]); }
        set {; }
    }

    public static float[] UpgradeLvlCost = new float[3] { 25, 100, 200 };
    public static short version = 1;
    public static float KHperS = 0;
    public static int[] UpgradeCount = { 0, 0, 0 };

    // private System.Random random = new System.Random();

    // Use this for initialization
    void Start()
    {
        Debug.Log(Application.persistentDataPath);
        Application.targetFrameRate = 60;
        InvokeRepeating("AddDogesPerSec", 1, 1);

    }
    /// <summary>
    /// Met à jour le texte.
    /// </summary>
    public static void UpdateText()
    {
        Text textDoge = GameObject.FindGameObjectWithTag("DogeCount").GetComponent<Text>();
        Text textCPC = GameObject.FindGameObjectWithTag("CPCCount").GetComponent<Text>();
        Text textPerSec = GameObject.FindGameObjectWithTag("PerSecCount").GetComponent<Text>();
        Text KHperSText = GameObject.FindGameObjectWithTag("KHPerS").GetComponent<Text>();
        Text textButton = GameObject.FindGameObjectWithTag("UpgradeLvl1Text").GetComponent<Text>();
        Text textButton2 = GameObject.Find("UpgradeLevel2").GetComponentInChildren<Text>();
        textPerSec.text = "Per Second " + dogesPerSec;
        textCPC.text = "CPC : " + CPCDisplay;
        textDoge.text = Math.Round(doges, 2).ToString();
        KHperSText.text = KHperS + " KH/S";

        textButton.text = "An DogeCoin Miner"
                              + Environment.NewLine
                              + "+10 KH/S"
                              + Environment.NewLine
                              + "+0.2 Dogecoins/s"
                              + Environment.NewLine
                              + "Cost : " + UpgradeLvlCost[0] + " DogeCoins";
        textButton2.text = "1ClickMine v" + version + ".0"
                              + Environment.NewLine
                              + "+0.2 CPC"
                              + Environment.NewLine
                              + "Cost : " + UpgradeLvlCost[1] + " DogeCoins";
    }
    public void OnClickLevel1()
    {
        if (UpgradeLvlCost[0] <= doges)
        {
            doges -= UpgradeLvlCost[0];
            UpgradeCount[0] += 1;
            dogesPerSec += 0.20f;
            KHperS += 10.00f;
            UpgradeLvlCost[0] += (float)Math.Round(UpgradeLvlCost[0] / 10, 2);
            UpdateText();
        }
    }
    public void OnClickLevel2()
    {
        if (UpgradeLvlCost[1] <= doges)
        {
            doges -= UpgradeLvlCost[1];
            UpgradeCount[1] += 1;
            dogesPerClick += 0.20f;
            UpgradeLvlCost[1] += (float)Math.Round(UpgradeLvlCost[1] / 10, 2);
            version++;
            UpdateText();
        }
    }
    public static void AddDoges()
    {
        doges += dogesPerSec;
    }

    private void AddDogesPerSec()
    {
        doges += dogesPerSec;
        Text textPerSec = GameObject.FindGameObjectWithTag("PerSecCount").GetComponent<Text>();
        textPerSec.text = "Per second : " + dogesPerSec;
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
