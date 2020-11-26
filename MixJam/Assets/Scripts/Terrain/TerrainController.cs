using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour
{
	GameObject terrain;

	private void Start()
	{
		CenterTerrain();
	}

	public void CenterTerrain()
	{
		foreach (Transform child in transform)
		{
			if (child.CompareTag("TerrainModel"))
			{
				terrain = child.gameObject;
			}
		}

		float xPos =  ( MemoryController.Instance.board.x - 1 ) * MemoryController.Instance.cardRatio / 2f;
		float zPos = MemoryController.Instance.board.y / 2;
		terrain.transform.position = new Vector3(xPos, 0.55f, zPos);

		terrain.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
	}
}
