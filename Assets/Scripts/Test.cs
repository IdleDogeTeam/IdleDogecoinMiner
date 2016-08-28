using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Test : MonoBehaviour
{
    private System.Random rand = new System.Random();
    // Use this for initialization
    void Start()
    {
        StartCoroutine(NewCoin(Coins));
    }
    public List<GameObject> Coins = new List<GameObject>();
    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator NewCoin(List<GameObject> L)
    {
        while (true)
        {
            if (rand.Next(0,100) <= 1)
                L.Add((GameObject)Instantiate(Resources.Load("BaseDoge"), new Vector3(-250, 233, 0), new Quaternion(0, 0, 0, 0)));
            yield return new WaitForSeconds(0.50f);   
        }
    }
    
}
