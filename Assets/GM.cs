using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {

	public List<Player> allPlayer = new List<Player> ();

	public void Login(Player player) {
		allPlayer.Add(player);
		player.RpcSetPlayer(allPlayer.Count);
	}
}
