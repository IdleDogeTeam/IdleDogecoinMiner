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
        Text mineButton = GameObject.Find("Object-Button").GetComponentInChildren<Text>();
        Text textButton2 = GameObject.Find("UpgradeLevel2").GetComponentInChildren<Text>();
        Text textButton3 = GameObject.Find("UpgradeLevel3").GetComponentInChildren<Text>();
        Text language = GameObject.Find("LanguageDropdown").GetComponentInChildren<Text>();
        Button mineButton2 = GameObject.Find("Object-Button").GetComponentInChildren<Button>();
        if (language.text == "English")
        {
            mineButton.text = "Let's mine some Dogecoin!";
            textPerSec.text = "Per Second : " + dogesPerSec;
        textCPC.text = "CPC : " + CPCDisplay;
        textDoge.text = Math.Round(doges, 2).ToString();
        KHperSText.text = KHperS + " KH/S";
            RectTransform t = mineButton2.transform as RectTransform;
            Vector2 dimension = t.sizeDelta;
            dimension.x = 328;
            dimension.y = 75;
            t.sizeDelta = dimension;
            textButton.text = "DogeCoin Miner"
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
        textButton3.text = "ASIC Miner"
                              + Environment.NewLine
                              + "+0.4 CPC"
                              + Environment.NewLine
                              + "+25 KH/S"
                              + Environment.NewLine
                              + "+0.5 Dogecoins/s"
                              + Environment.NewLine
                              + "Cost : " + UpgradeLvlCost[2] + " DogeCoins";
    }
    else if (language.text == "Français")
    {

            //I don't speak fluent French, so please fix this if I made a mistake :)
            mineButton.text = "Minons quelques dogecoins !";
            textPerSec.text = "Par seconde : " + dogesPerSec;
            textCPC.text = "CPC : " + CPCDisplay;
            textDoge.text = Math.Round(doges, 2).ToString();
            KHperSText.text = KHperS + " KH/S";
            //mineButton.rectTransform.sizeDelta = new Vector2(400,75);
            RectTransform t = mineButton2.transform as RectTransform;
            Vector2 dimension = t.sizeDelta;
            dimension.x = 400;
            dimension.y = 75;
            t.sizeDelta = dimension;
            textButton.text = "Mineur de dogecoin"
                      + Environment.NewLine
                      + "+10 KH/S"
                      + Environment.NewLine
                      + "+0.2 Dogecoins/s"
                      + Environment.NewLine
                      + "Coût : " + UpgradeLvlCost[0] + " DogeCoins";
            textButton2.text = "1-clic-mine v" + version + ".0"
                                  + Environment.NewLine
                                  + "+0.2 CPC"
                                  + Environment.NewLine
                                  + "Coût : " + UpgradeLvlCost[1] + " DogeCoins";
            textButton3.text = "Mineur ASIC"
                                  + Environment.NewLine
                                  + "+0.4 CPC"
                                  + Environment.NewLine
                                  + "+25 KH/S"
                                  + Environment.NewLine
                                  + "+0.5 Dogecoins/s"
                                  + Environment.NewLine
                                  + "Coût : " + UpgradeLvlCost[2] + " DogeCoins";
        }
        else if (language.text == "Deutsche")
        {
            //Google Translate
            mineButton.text = "Lassen Sie uns einige Dogecoin meins!";
            textPerSec.text = "Pro Sekunde : " + dogesPerSec;
            textCPC.text = "CPC : " + CPCDisplay;
            textDoge.text = Math.Round(doges, 2).ToString();
            RectTransform t = mineButton2.transform as RectTransform;
            Vector2 dimension = t.sizeDelta;
            dimension.x = 440;
            dimension.y = 75;
            t.sizeDelta = dimension;
            KHperSText.text = KHperS + " KH/S";
            textButton.text = "DogeCoin Bergmann"
                              + Environment.NewLine
                              + "+10 KH/S"
                              + Environment.NewLine
                              + "+0.2 Dogecoins/s"
                              + Environment.NewLine
                              + "Kosten : " + UpgradeLvlCost[0] + " DogeCoins";
        textButton2.text = "1KlickenBergwerk v" + version + ".0"
                              + Environment.NewLine
                              + "+0.2 CPC"
                              + Environment.NewLine
                              + "Kosten : " + UpgradeLvlCost[1] + " DogeCoins";
        textButton3.text = "ASIC Bergmann"
                              + Environment.NewLine
                              + "+0.4 CPC"
                              + Environment.NewLine
                              + "+25 KH/S"
                              + Environment.NewLine
                              + "+0.5 Dogecoins/s"
                              + Environment.NewLine
                              + "Kosten : " + UpgradeLvlCost[2] + " DogeCoins";
        }
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
    public void OnClickLevel3()
    {
        if (UpgradeLvlCost[2] <= doges)
        {
            doges -= UpgradeLvlCost[2];
            dogesPerSec += 0.40f;
            UpgradeCount[2] += 2;
            dogesPerClick += 0.40f;
            UpgradeLvlCost[2] += (float)Math.Round(UpgradeLvlCost[2] / 10, 2);
            KHperS += 25.00f;
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
