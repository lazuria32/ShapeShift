using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputUtil {

    public static float getAxisX(){
        return getAxis("Mouse X");
    }

    public static float getAxisY() {
        return getAxis("Mouse Y");
    }

    private static float getAxis(string axisName) {
        if (Input.GetMouseButton(1)) {
            return Input.GetAxis(axisName);
        } else {
            return 0.0f;
        }
    }
}
