using UnityEngine;
using UnityEngine.UI;

public class BouncyDogeCoin : MonoBehaviour
{
    private System.Random rand = new System.Random();
    public readonly float dogive = new System.Random().Next(20, ((int)UpgradeManage.dogesPerSec * 20 + ((int)UpgradeManage.dogesPerClick * 15) + 50));
    // Use this for initialization
    void Start()
    {
        transform.SetParent(GameObject.Find("Canvas").transform, false);
        transform.Translate(rand.Next(0, 600), rand.Next(210, 265), 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private float RandomNumber(float max)
    {
        return (float)new System.Random().NextDouble() * max;
    }
    public void OnMouse()
    {

        UpgradeManage.doges += dogive;
        UpgradeManage.UpdateText();
        GameObject text = (GameObject)Instantiate(Resources.Load("DogeText"));
        text.GetComponent<Text>().text = "+ " + dogive + " dogecoins";
        text.transform.Translate(gameObject.transform.localPosition);
        Destroy(gameObject);
    }
}
