using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] float yawSpd;
    [SerializeField] float pitchSpd;
    [SerializeField] float moveSpeed;
    [SerializeField] FollowCamera followCamera;
    [SerializeField] GameObject currentPoint;
    [SerializeField] GameObject targetTrigger;
    [SerializeField] StageMain stageMain;
    [SerializeField] StateManager stateManager;
    GameObject targetedPoint = null;
    AudioSource moveSound;
    bool isMoving = false;
    float movingTime = 0.0f;

    // Use this for initialization
    void Start () {
        moveSound = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        directionInput();
        moveInput();
        targetPoint();
        // lockOnInput();   // 未実装
	}

    // 方向入力
    void directionInput() {
        if(!this.isMovable()) {
            return;
        }
        // 自身の横軸入力
        float inputYaw = InputUtil.getAxisX() * yawSpd;
        transform.Rotate(Vector3.up, inputYaw);
        followCamera.rotateAroundPlayerX(transform, inputYaw);

        // カメラ側の縦軸入力
        float inputPitch = InputUtil.getAxisY() * pitchSpd;
        followCamera.rotateAroundPlayerY(transform, inputPitch);
        targetTrigger.transform.RotateAround(transform.position, -transform.right, inputPitch);
    }

    void moveInput() {
        if (this.isMovable()) {
            // 右クリック & ターゲット時
            if (targetedPoint && Input.GetMouseButtonDown(0)) {
                // 既に線を引いていなければ移動可
                if (!stageMain.HasLine(currentPoint, targetedPoint)) {
                    isMoving = true;
                    moveSound.Play();
                }
            }
        } else if (isMoving) {
            if(transform.position != targetedPoint.transform.position) {
                Vector3 moveVector = Vector3.MoveTowards(transform.position, targetedPoint.transform.position, moveSpeed);
                Vector3 cameraDiff = followCamera.transform.position - transform.position;
                transform.position = moveVector;
                followCamera.transform.position = moveVector + cameraDiff;
            } else {
                stageMain.drawLine(currentPoint, targetedPoint);
                currentPoint = targetedPoint;
                isMoving = false;
                movingTime = 0.0f;
            }
        }
    }

    // ロックオン機能 未実装
    void lockOnInput(){
        const KeyCode LOCK_ON_KEY = KeyCode.LeftShift;
        if(Input.GetKeyDown(LOCK_ON_KEY)) {
            if(targetedPoint) {          
            } else {
            }
        }

        if(Input.GetKeyUp(LOCK_ON_KEY)) {

        }
    }

    // TargetTriggerの範囲内で、画面中央に近いポイントをターゲット なければNULL
    void targetPoint() {
        if(this.isMoving) { return; }
        var shiftPoints =
            GameObject.FindGameObjectsWithTag("ShiftPoint")
            .Where(shiftPoint => shiftPoint.GetComponent<ShiftPoint>())
            .Where(shiftPoint => shiftPoint.GetComponent<ShiftPoint>().InTargetTrigger == true)
            .Where(shiftPoint => shiftPoint != currentPoint);
        var screenCenter = new Vector2(Screen.height / 2.0f, Screen.width / 2.0f);
        shiftPoints.OrderBy(shiftPoint =>
           Vector2.Distance(screenCenter, Camera.main.WorldToScreenPoint(shiftPoint.transform.position))
        );
        targetedPoint = shiftPoints.FirstOrDefault();
    }

    public GameObject GetTargetOrNull() {
        return targetedPoint;
    }

    public float GetMovingTime() {
        return movingTime;
    }

    public bool isMovable() {
        if(    stateManager.GetInputState() == StateManager.InputState.Avaliable
            && this.isMoving == false) {
            return true;
        } else {
            return false;
        }
    }


}
