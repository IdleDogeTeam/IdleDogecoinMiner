using UnityEngine;
using System.Collections;

public class TextBaiBai : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        transform.SetParent(GameObject.Find("Canvas").transform, false);
        // Old formula : 
        // RectTransform rt = GameObject.Find("Canvas").transform as RectTransform;
        // transform.Translate(rand.Next((int)-rt.rect.width / 2, (int)rt.rect.width / 2),rand.Next((int)-rt.rect.height / 2,(int)rt.rect.height / 2),0);
        InvokeRepeating("Move", 0.01F, 0.01F);
        StartCoroutine(GodBye());
        
        
    }
    private void Move()
    {
        RectTransform rect = GetComponent<RectTransform>();
        // Debug.Log("rect : " + rect.anchoredPosition.x + " , " + rect.anchoredPosition.y);
        rect.localPosition = new Vector2(rect.anchoredPosition.x, rect.anchoredPosition.y + 0.5F);
    }
    private IEnumerator GodBye()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
