using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour {
    public Transform progressBar;
    public Transform subLabel;
    public Transform textIndicator;
    public static float currentAmount;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (currentAmount < 100)
        {
            textIndicator.GetComponent<Text>().text = ((int)currentAmount).ToString() + "%";
            textIndicator.gameObject.SetActive(true);
        }
        else
        {
            // Pops something to says the data path.
            gameObject.SetActive(false);
        }
        progressBar.GetComponent<Image>().fillAmount = currentAmount / 100;
	}
    


}
