using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States
{
	standing,
	jumping,
	ducking,
	diving
}
public interface IPlayerState
{
	void Execute(Player player);
}

public class Standing: IPlayerState
{
	public void Execute(Player player)
	{
		Debug.Log("Standing");
		player.transform.localScale = Vector3.Lerp(player.transform.localScale, new Vector3(1, 1.5f, 1), 0.5f);
	}
}

public class Jumping : IPlayerState
{
	public void Execute(Player player)
	{
		Debug.Log("Jumping");
		player.transform.localScale = Vector3.Lerp(player.transform.localScale, new Vector3(.85f, 1.65f, .85f), 0.5f);
		Rigidbody playerRB = player.GetComponent<Rigidbody>();
		playerRB.velocity += new Vector3(0, player.jumpSpeed, 0);
	}
}

public class Diving : IPlayerState
{
	public void Execute(Player player)
	{
		Debug.Log("Diving");
		player.transform.localScale = Vector3.Lerp(player.transform.localScale, new Vector3(.7f, 2, .7f), 0.5f);
		Rigidbody playerRB = player.GetComponent<Rigidbody>();
		playerRB.velocity += new Vector3(0, -(player.jumpSpeed/2), 0);
	}
}

public class Ducking : IPlayerState
{
	public void Execute(Player player)
	{
		Debug.Log("Ducking");
		player.transform.localScale = Vector3.Lerp(player.transform.localScale, new Vector3(1, .75f, 1), 0.5f);
	}
}
