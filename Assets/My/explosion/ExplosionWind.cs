using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ExplosionWind : NetworkBehaviour {

    private float age;
    public float maxAge = 2.0f;

    // Use this for initialization
    //初始化
    void Start()
    {
        age = 0.0f;
    }

    // Update is called once per frame
    //每顆球的生命週期為maxAge秒，超過就刪除
    [ServerCallback]
    void Update()
    {
        
        age += Time.deltaTime;
        if (age <= maxAge-2 )
            gameObject.transform.localScale = gameObject.transform.localScale + new Vector3(0.5f, 0.5f, 0.5f);
        if (age > maxAge)
        {
            NetworkServer.Destroy(gameObject);
        }
    }
}
