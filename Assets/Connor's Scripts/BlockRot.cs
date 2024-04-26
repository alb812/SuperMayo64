using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Blocks the rotation of a child attached to a parent, band-aid script,
// but feel free to use for a temporary fix
public class BlockRot : MonoBehaviour {

	void LateUpdate()
	{
		transform.rotation = Quaternion.identity;
	}
}
