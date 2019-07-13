using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class StageMain : MonoBehaviour {


    Stage currentStage;
    float skyboxAngle = 0.0f;

    // Use this for initialization
    void Start () {
        List<Vector3> initialPointPositions = new List<Vector3>();
        initialPointPositions.Add(new Vector3(0, 0, 20));
        initialPointPositions.Add(new Vector3(10, 10, 10));
        currentStage = new Stage(initialPointPositions);
    }
	
	// Update is called once per frame
	void Update () {
		ResetInput();
        RotateSkyBox();
    }

    public bool HasLine(GameObject point1, GameObject point2) {
        return currentStage.HasLine(point1, point2);
    }

    public bool drawLine(GameObject point1, GameObject point2) {
        return currentStage.drawLine(point1, point2);
    }

    void ResetInput() {
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void RotateSkyBox() {
        skyboxAngle += 0.01f;
        RenderSettings.skybox.SetFloat("_Rotation", skyboxAngle);
    }
}
