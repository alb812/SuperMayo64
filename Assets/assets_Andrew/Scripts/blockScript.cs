using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Put this on exclamation mark blocks
//Lets Mario break blocks to generate items
public class blockScript : MonoBehaviour
{

	public float raycastDist = 0.6f; //long enough so raycast extends slightly below the block, 0.6f for scale 1
	public GameObject item; //assign in inspector with the item that you want to spawn when the block breaks
	public float objectThrowPower; //power of impulse force applied on item when block breaks
	
	void Update () {
		
		Ray ray = new Ray(transform.position, Vector3.down);
		RaycastHit hit;
		//shoot raycast just below block, check if it hits a collider
		if (Physics.SphereCast(ray, 0.4f,out hit, raycastDist))
		{
			//if the raycast hits a collider, check that it is the player through its "tag"
			if (hit.collider.gameObject.CompareTag("Player"))
			{
				BreakBlock();
			}
		}
		Debug.DrawRay(transform.position, Vector3.down * raycastDist, Color.yellow);
	}

	//spawns item then destroys block
	void BreakBlock()
	{
		if (item != null)
		{
			GameObject spawnedItem = Instantiate(item, transform.position + Vector3.up/2, Quaternion.identity);
			spawnedItem.GetComponent<Rigidbody>().AddForce(Vector3.up * objectThrowPower, ForceMode.Impulse);
		}
		
		AudioManager.Instance.PlayBoxBreakSound();
		Destroy(this.gameObject);
	}
	
}
