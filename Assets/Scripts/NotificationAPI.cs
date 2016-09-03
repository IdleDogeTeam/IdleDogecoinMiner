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
    public static void NewNotification(string text, Color coulour)
    {
        GameObject notif = GameObject.FindGameObjectWithTag("Notification");
        notif.GetComponent<Text>().text = text;
        notif.GetComponent<Text>().color = coulour;
        notif.GetComponent<Animation>().Play("okeke");
    }

    public class NotifEditor : EditorWindow {
        [MenuItem("Window/Notification Control")]
        static void Init() { NotifEditor window = (NotifEditor)GetWindow(typeof(NotifEditor));}
        public void OnGUI()
        {
            if(GUILayout.Button("Invoke a test notification")) {
                
                NewNotification("This is a test notification, hello there !");
            }
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}
