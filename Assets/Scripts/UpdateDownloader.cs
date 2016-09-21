using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class UpdateDownloader : MonoBehaviour
{
    public static readonly int versionNumber = 4;
    public static string SysInf {get; private set;}
    public bool forceUpdateShow = false;
    // Use this for initialization
    void Start()
    {SysInf = SystemInfo.operatingSystem

        StartCoroutine(VersionCheck());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private static RuntimePlatform[] compatibleVersions = { RuntimePlatform.OSXPlayer, RuntimePlatform.WindowsPlayer, RuntimePlatform.LinuxPlayer };
    private static string getVersionURL(RuntimePlatform runtime)
    {
        try
        {
            bool isCompatible = false;
            foreach (var item in compatibleVersions)
            {
                if (item == Application.platform)
                    isCompatible = true;
            }
            if (isCompatible || GameObject.Find("Variable Manager").GetComponent<UpdateDownloader>().forceUpdateShow)
                return "https://github.com/IdleDogeTeam/IdleDogecoinMiner/raw/gh-pages/latest/v.txt";
            else
            {
                throw new RuntimeNotValidException("Your actual build isn't able to install updates.");

            }
        }
        catch (Exception)
        {
            return null;
        }


    }
    public void startIt()
    {
        StartCoroutine(DownloadUpdate());
    }
    public IEnumerator DownloadUpdate()
    {
        WWW down = null;
        Debug.Log(SysInf);
        bool[] Win64 = new bool[2] { false, false }; // bool[0] = windows or not, bool[1] = 32bit (false) 64 bit (true)
        if (SysInf.Contains("Windows") && SysInf.Contains("64bit"))
        {
            Debug.Log("Windows 64");
            Win64[0] = true;
            Win64[1] = true;
        }
        else if (SysInf.Contains("Windows"))
        {
            Win64[0] = true;
            Win64[1] = false;
        }


        if ((Application.platform == RuntimePlatform.WindowsPlayer && Win64[0] && Win64[1]) || forceUpdateShow)
        {
            down = new WWW("https://idledogeteam.github.io/IdleDogecoinMiner/latest/IdleDogecoinMiner-Win64.zip?raw=true");
        }
        else if ((Application.platform == RuntimePlatform.WindowsPlayer && Win64[0] && !Win64[1]))
            down = new WWW("https://idledogeteam.github.io/IdleDogecoinMiner/latest/IdleDogecoinMiner-Win32.zip?raw=true");
        else if (Application.platform == RuntimePlatform.LinuxPlayer)
            down = new WWW("https://idledogeteam.github.io/IdleDogecoinMiner/latest/IdleDogecoinMiner-Linux.zip?raw=true");
        else if (Application.platform == RuntimePlatform.OSXPlayer)
            down = new WWW("https://idledogeteam.github.io/IdleDogecoinMiner/latest/IdleDogecoinMiner-Mac.zip?raw=true");
        else
            yield break;
        GameObject.FindGameObjectWithTag("Update").GetComponent<Canvas>().enabled = false;
        GameObject progress = (GameObject)Instantiate(Resources.Load("Canvas"));


        while (!down.isDone)
        {
            Debug.Log(down.progress);
            LoadingBar.currentAmount = (down.progress * 100);
            yield return down.progress;
        }
        string savePath = Application.persistentDataPath + "/Update" + new System.Random().Next(1, 1000) + ".zip";
        byte[] data = down.bytes;
        File.WriteAllBytes(savePath, data);
        Application.OpenURL(savePath);
        Destroy(progress);
        // GameObject.FindGameObjectWithTag("Update").GetComponent<Canvas>().enabled = false;
        Destroy(GameObject.FindGameObjectWithTag("Update"));
        Debug.Log(down.responseHeaders);
        NotificationAPI.NewNotification("The update has been downloaded.");
        yield break;
    }
    [Serializable]
    private class RuntimeNotValidException : Exception
    {
        public RuntimeNotValidException(string message = "Your OS can't install updates") : base(message) { }
        public RuntimeNotValidException(RuntimeNotValidException inner, string message = "Your OS can't install updates") : base(message, inner) { }
    }
    private static bool IsDownloadFinished(WWW www)
    {
        return www.isDone;
    }
    // private static WWW version = new WWW(getVersionURL(Application.platform));
    //private IEnumerator TestDownload()
    //{
    //    if (!(Application.platform != RuntimePlatform.Android || Application.platform != RuntimePlatform.IPhonePlayer || Application.platform != RuntimePlatform.WebGLPlayer))
    //    {
    //        string url;
    //        if (Application.platform == RuntimePlatform.WindowsPlayer)
    //        {
    //            url = "http://10doge.ga/latest/windows";
    //            WWW Temp = new WWW(url);
    //        }
    //        WWW www = new WWW("BuildURL");
    //        yield return www;
    //        string savePath = Application.persistentDataPath + "/build.zip";

    //        byte[] bytes = www.bytes;
    //        File.WriteAllBytes(savePath, bytes);
    //        Application.OpenURL(savePath);
    //    }
    //}
    private IEnumerator VersionCheck()
    {

        WWW temp = null;
        try
        {

            temp = new WWW(getVersionURL(Application.platform));
            if (getVersionURL(Application.platform) == null)
                throw new RuntimeNotValidException();
        }
        catch (Exception)
        {
            Debug.Log("Updates aren't available for this OS : " + Application.platform.ToString());
            StopAllCoroutines();
        }

        yield return new WaitUntil(() => IsDownloadFinished(temp));
        if (int.Parse(temp.text) > versionNumber || GameObject.Find("Variable Manager").GetComponent<UpdateDownloader>().forceUpdateShow)
        {
            Debug.Log("A new version is available !");
            GameObject UpdateUI = GameObject.FindGameObjectWithTag("Update");
            UpdateUI.GetComponent<Canvas>().enabled = true;

        }
        yield break;
    }

}
