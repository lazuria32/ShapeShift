using UnityEngine;
using UnityEngine.UI;
public class SkyChangeButton : MonoBehaviour {
    

    [SerializeField] Material skyboxMaterial;
    [SerializeField] GameObject stage;
    [SerializeField] GameObject blackOut;
    [SerializeField] GameObject menuPanel;
    [SerializeField] StateManager.SkyState changeTo;

    StateManager stateManager;
    Image blackOutImage;
    bool isChangingSky = false;
    bool changed = false;
    float timeCnt = 0.0f;

	// Use this for initialization
	void Start () {
        stateManager = stage.GetComponent<StateManager>();
        blackOutImage = blackOut.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isChangingSky) { ChangeSky(); }
	}

    public void OnClick() {
        StateManager.SkyState skyState = stateManager.GetSkyState();
        if ( skyState != StateManager.SkyState.Changing &&
             skyState != changeTo ) {
            isChangingSky = true;
            stateManager.SetSkyState(StateManager.SkyState.Changing);
        }
    }

    void ChangeSky() {
        timeCnt += Time.deltaTime;
        Color blackOutColor = blackOutImage.color;
        if (timeCnt <= 0.5f) {
            blackOutColor.a = timeCnt * 2;
        } else if (!changed) {
            blackOutColor.a = 1.0f;
            RenderSettings.skybox = skyboxMaterial;
            changed = true;
        } else if (timeCnt <= 1.0f) {
            blackOutColor.a = 1.0f - ( (timeCnt - 0.5f) * 2.0f );
        } else {
            blackOutColor.a = 0.0f;
            changed = false;
            isChangingSky = false;
            timeCnt = 0.0f;
            stateManager.SetSkyState(changeTo);
            stateManager.ReleaseInput();
            menuPanel.SetActive(false);
        }
        blackOutImage.color = blackOutColor;
    }
}
