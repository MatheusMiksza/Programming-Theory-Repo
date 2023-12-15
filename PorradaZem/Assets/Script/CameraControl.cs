using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraControl : MonoBehaviour {

	
	private Transform target;
	

	private GameObject[] players;
	
	void Start()
	{
		
		target = GameObject.FindWithTag("Camera").transform;
		players = GameObject.FindGameObjectsWithTag("Player");

	}
	public float yOffset = 2.0f;
	public float minDistance = 7.5f;

	private float xMin, xMax, yMin, yMax;

    private void LateUpdate()
    {
		MediaPlayers();
		//xMin = xMax = players[0].transform.position.x;
		//yMin = yMax = players[0].transform.position.y;
		//for(int i = 1; i< players.Length; i++)
		//      {
		//	if (players[i].transform.position.z < xMin)
		//		xMin = players[i].transform.position.z;

		//	if (players[i].transform.position.z > xMax)
		//		xMax = players[i].transform.position.z;

		//	if (players[i].transform.position.y < yMin)
		//		yMin = players[i].transform.position.y;

		//	if (players[i].transform.position.x > yMax)
		//		yMax = players[i].transform.position.x;

		//}

		//float xMiddle = (xMin + xMax) / 2;
		//float yMiddle = (yMin + yMax) / 2;
		//float distance = xMax - xMin;
		//if (distance < minDistance)
		//	distance = minDistance;

		//transform.position = new Vector3(xMiddle, yMiddle, -distance);


	}

	private void MediaPlayers()
    {
		Vector3 player1 = players[0].transform.position;
		Vector3 player2 = players[1].transform.position;

		var mid = (player2.z + player1.z) / 2;
		
		var dist = Vector3.Distance(player1, player2);


		transform.position = new Vector3(4,2, mid);
		Debug.Log(dist);
	}
}