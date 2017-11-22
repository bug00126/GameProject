using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HaneExplosion : NetworkBehaviour
{

    AudioSource damageAudio;

    void Awake()
    {
        //Set current lives and get audio component reference
        damageAudio = GetComponent<AudioSource>();
    }

    //如果被球打中
    void OnCollisionEnter(Collision other)
    {
        if (this.tag == "Balloon")
        {
            if (other.gameObject.tag == "Ball")
            {

                //damageAudio.Stop ();
                //CmdHitPlayer(this.transform.gameObject);
                //damageAudio.Play ();
                CmdOpenWind();
                Destroy(gameObject);

            }
            if (other.collider.gameObject.tag == "Sword")
            {

                //damageAudio.Stop ();
                //CmdHitPlayer(this.transform.gameObject);
                //damageAudio.Play ();
                CmdOpenWind();

            }
        }
        

    }

    //通知伺服器我被打中了
    [Command]
    void CmdOpenWind()
    {
        //we instantiate one from Resources

        Destroy(gameObject);
        GameObject instance = Instantiate(Resources.Load("Wind")) as GameObject;
        //Let's name it
        instance.name = "Wind";
        //Let's position it at the player
        instance.transform.position = gameObject.transform.position;
        //
        NetworkServer.Spawn(instance);
    }
    void CmdHitPlayer(GameObject hit)
    {
        hit.GetComponent<DamageScript>().RpcResolveHit();
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
}
