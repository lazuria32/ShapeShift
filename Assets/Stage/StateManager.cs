using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {
    public enum InputState { Avaliable, Disable }
    public enum SkyState { DayTime, AfterNoon, Night, Changing }
    InputState inputState = InputState.Avaliable;
    SkyState skyState = SkyState.DayTime;
    int inputLockCnt;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public InputState GetInputState() {
        return inputState;
    }

    public SkyState GetSkyState() {
        return skyState;
    }

    public void LockInput() {
        inputLockCnt++;
        inputState = InputState.Disable;
    }

    public void ReleaseInput() {
        inputLockCnt--;
        if(inputLockCnt <= 0) {
            inputState = InputState.Avaliable;
            inputLockCnt = 0;
        }
    }

    public void SetSkyState(SkyState skyState) {
        this.skyState = skyState;
    }
}
