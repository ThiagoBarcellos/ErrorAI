using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

	public const int maxHealth = 100;

	[SyncVar(hook = "OnChangeHealth")]
	public int currentHealth = maxHealth;
	public RectTransform healthBar;

	public void TakeDamage(int amount)
	{
		if (!isServer) 
		{
			return;
		}

		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			currentHealth = maxHealth;
			//called on the Server, but invoked on the clients
			RpcRespawn ();
		}
	}

	void OnChangeHealth(int currentHealth)
	{
		healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
	}

	[ClientRpc]
	void RpcRespawn()
	{
		if (isLocalPlayer) 
		{
			//move back to zero position
			transform.position = Vector3.zero;
		}
	}
}