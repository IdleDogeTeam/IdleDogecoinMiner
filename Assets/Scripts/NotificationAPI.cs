using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;

public class NotificationAPI : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        // NewNotification("TopKEK");
	}
    /// <summary>
    ///     Creates a new notification from text.
    /// </summary>
    /// <param name="text">The text to be displayed.</param>
	public static void NewNotification(string text) {
        GameObject.FindGameObjectWithTag("Notification").GetComponent<NotificationAPI>().StartCo(text);
    }
    public void StartCo(string hello)
    {
        StartCoroutine(NotificationQueue(hello));
    }
    private IEnumerator NotificationQueue(string hoi)
    {
        GameObject notif = GameObject.FindGameObjectWithTag("Notification");
        yield return new WaitUntil(() => Inverse(GameObject.FindGameObjectWithTag("Notification").GetComponent<Animation>().isPlaying));
        notif.GetComponent<Text>().text = hoi;

        notif.GetComponent<Animation>().Play("okeke");
    }
    public static bool Inverse(bool lel)
    {
        if (lel)
            return false;
        else
            return true;
    }
    

    public class NotifEditor : EditorWindow {
        private string[] lolStrings = new string[8] { "Hello World !", "Much test,wow", "SO TEST OMG", "I didn't know you liked testing these a lot !", "The wowest test" , "Of course, why not", "You keep testing :o","Ok now get some doge-milk then see u later"};
        [MenuItem("Window/Notification Control")]
        static void Init() { NotifEditor window = (NotifEditor)GetWindow(typeof(NotifEditor));}
        public void OnGUI()
        {
            if(GUILayout.Button("Invoke a test notification")) {
                
                NewNotification(lolStrings[new System.Random().Next(0,lolStrings.Length)]);
            }
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}
