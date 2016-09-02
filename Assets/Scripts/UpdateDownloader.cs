using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class UpdateDownloader : MonoBehaviour
{
    public static readonly int versionNumber = 2;
    
    public bool forceUpdateShow = false;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(VersionCheck());
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private static string getVersionURL(RuntimePlatform runtime)
    {
        try
        {
            if (Application.platform == RuntimePlatform.WindowsPlayer || GameObject.Find("Variable Manager").GetComponent<UpdateDownloader>().forceUpdateShow)
                return "http://10doge.ga/latest/windows/v.txt";
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
    }
    
}
