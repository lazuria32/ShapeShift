using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TargetReticle : MonoBehaviour {

    public float rotateSpeed;
    GameObject player;
    GameObject targetedPoint = null;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        targetedPoint = player.GetComponent<Player>().GetTargetOrNull();
        if (targetedPoint != null) {
            Vector2 ReticlePos = RectTransformUtility.WorldToScreenPoint(Camera.main, targetedPoint.transform.position);
            transform.position = new Vector3(ReticlePos.x, ReticlePos.y, 0.0f);
        } else {
            transform.position = new Vector3(10000,10000,0.0f);
        }
        transform.Rotate(new Vector3(0,0, rotateSpeed));
	}


}
