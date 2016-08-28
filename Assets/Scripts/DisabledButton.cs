using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisabledButton : MonoBehaviour
{
    private int isUnlocked = 0;
    public int costLevelIndex = 1;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isUnlocked == 0)
            gameObject.GetComponent<CanvasGroup>().alpha = 0.25F;
        else
        gameObject.GetComponent<CanvasGroup>().alpha = isUnlocked;

        if (UpgradeManage.UpgradeLvlCost[(costLevelIndex - 1)] >= UpgradeManage.doges)
        {
            if (isUnlocked == 0)
                isUnlocked = 0;
            else
                gameObject.GetComponent<CanvasGroup>().alpha = 0.30F;

            gameObject.GetComponent<Button>().enabled = false;
        }
        else { gameObject.GetComponent<Button>().enabled = true; isUnlocked = 1; }
    }
}
