using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonOnClick : MonoBehaviour {

	// Use this for initialization
	void Start() {}   
    public void OnClick()
    {
        //Text textDoge = GameObject.FindGameObjectWithTag("DogeCount").GetComponent<Text>();
        //Text textCPC = GameObject.FindGameObjectWithTag("CPCCount").GetComponent<Text>();
        UpgradeManage.doges += UpgradeManage.dogesPerClick;
        //textDoge.text = "Dogecoins : " + UpgradeManage.doges;
        //textCPC.text = "CPC : " + UpgradeManage.dogesPerClick;
        UpgradeManage.UpdateText();
        gameObject.GetComponent<ParticleSystem>().Emit(1);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
