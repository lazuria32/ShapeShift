using UnityEngine;

public class FollowCamera : MonoBehaviour {

    public Transform player;
    public bool IsLocked;
    float pitch;

    // Use this for initialization
    void Start () {
        IsLocked = false;
        pitch = 0;
    }
	
	// Update is called once per frame
	void Update () {
    }

    // 横軸回転
    public void rotateAroundPlayerX(Transform playerTransform, float inputYaw) {
        if (!IsLocked) {
            transform.RotateAround(playerTransform.position, playerTransform.up, inputYaw);
        }
    }

    // 縦軸回転
    public void rotateAroundPlayerY(Transform playerTransform, float inputPitch) {
        if (!IsLocked) {
            const float maxPitch = 90.0f, minPitch = -90.0f;
            if ((pitch + inputPitch) > maxPitch) {
                inputPitch = maxPitch - pitch;
            }
            if ((pitch + inputPitch) < minPitch) {
                inputPitch = minPitch - pitch;
            }
            transform.RotateAround(playerTransform.position, -playerTransform.right, inputPitch);
        }
    }

    

}
