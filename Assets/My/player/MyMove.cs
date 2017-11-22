using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyMove : NetworkBehaviour
{

    AudioSource damageAudio;
    Rigidbody rb;
    private float distance;
    private float power;
    void Awake()
    {
        //Set current lives and get audio component reference
        rb = rb = GetComponent<Rigidbody>();
        damageAudio = GetComponent<AudioSource>();
    }

    //如果被球打中
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball")
        {

            //damageAudio.Stop ();
            //CmdHitPlayer(this.transform.gameObject);
            //damageAudio.Play ();
        }
        if (other.gameObject.tag == "Sword")
        {

            //damageAudio.Stop ();
            //CmdHitPlayer(this.transform.gameObject);
            //damageAudio.Play ();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wind")
        {
            distance = (gameObject.transform.position.x - other.transform.position.x) * (gameObject.transform.position.x - other.transform.position.x)
                     + (gameObject.transform.position.x - other.transform.position.x) * (gameObject.transform.position.x - other.transform.position.x)
                     + (gameObject.transform.position.x - other.transform.position.x) * (gameObject.transform.position.x - other.transform.position.x);
            //CmdMovePlayer(this.transform.gameObject, other.transform.position);
            if (distance < 1)
            {
                power = 1500.0f;
            }
            else
            {
                power = 1000.0f;
            }
                gameObject.GetComponent<Rigidbody>().AddForce((gameObject.transform.position - other.transform.position ) *power / distance );
            //print("distance = " + distance);
            //print("vectir1 = " + gameObject.transform.position+" vector2 = " + other.transform.position);
        }
    }
   /* private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Wind")
        {

            distance = (gameObject.transform.position.x - other.transform.position.x) * (gameObject.transform.position.x - other.transform.position.x)
                    + (gameObject.transform.position.x - other.transform.position.x) * (gameObject.transform.position.x - other.transform.position.x)
                    + (gameObject.transform.position.x - other.transform.position.x) * (gameObject.transform.position.x - other.transform.position.x);
            //CmdMovePlayer(this.transform.gameObject , other.transform.position);
            gameObject.GetComponent<Rigidbody>().AddForce((gameObject.transform.position - other.transform.position ) / distance);
            
        }
    }*/

    //通知伺服器我被打中了
    [Command]
    void CmdHitPlayer(GameObject hit)
    {
        hit.GetComponent<MyMove>().RpcResolveHit();
    }

    void CmdMovePlayer(GameObject move, Vector3 other)
    {
        move.GetComponent<MyMove>().RpcResolvMove(other);
    }

    //通知所有的玩家這個玩家被打中了
    [ClientRpc]
    public void RpcResolveHit()
    {

        if (isLocalPlayer)
        {
            Transform spawn = NetworkManager.singleton.GetStartPosition();
            transform.position = spawn.position;
            transform.rotation = spawn.rotation;
            damageAudio.Play();

        }
    }

    public void RpcResolvMove(Vector3 other)
    {
        Vector3 direction = (gameObject.transform.position - other) * 0.0001f;
        if (isLocalPlayer)
        {
            float age = 0.0f;
            while (age <= 10)
            {
                age += Time.deltaTime;
                transform.position = transform.position + direction;
                damageAudio.Play();
            }

        }

    }
}
