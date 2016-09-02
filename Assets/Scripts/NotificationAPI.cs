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
        GameObject notif = GameObject.FindGameObjectWithTag("Notification");
        notif.GetComponent<Text>().text = text;
        
        notif.GetComponent<Animation>().Play("okek");
    }
    
    public static void NewNotification(string text, Color coulour)
    {
        GameObject notif = GameObject.FindGameObjectWithTag("Notification");
        notif.GetComponent<Text>().text = text;
        notif.GetComponent<Text>().color = coulour;
        notif.GetComponent<Animation>().Play("okek");
    }

    public class NotifEditor : EditorWindow {
        [MenuItem("Window/Notification Control")]
        static void Init() { NotifEditor window = (NotifEditor)GetWindow(typeof(NotifEditor));}
        public void OnGUI()
        {
            string hello = "this is a thing";
            string kek = GUI.TextField(new Rect(0, 50, 120, 15),hello,30);
            if(GUILayout.Button("Test")) {
                
                NewNotification(kek);
            }
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}
