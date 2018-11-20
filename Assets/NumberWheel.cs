using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWheel : MonoBehaviour {

    public int target;
    public float smooth;
    private bool moving = false;
    public float origin;
    private float destination;
    private int state = 1; //0: stable, -1: destroying, 1: spawning
    float velocity;

    public void Spawn() {
        state = 1;
        origin = transform.localPosition.z;
        destination = origin + 0.35f;
    }

    public void Despawn() {
        state = -1;
        destination = origin;
    }

    public void NewTarget(int target) {
        this.target = target;
        moving = true;
    }
    
    void Update() {
        if (moving) {
            transform.eulerAngles = new Vector3(0, 0, Mathf.SmoothDampAngle(transform.localEulerAngles.z, 360 - target * 36, ref velocity, smooth));
            if (velocity == 0)
                moving = false;
        }
        /*if (state != 0) {
            Debug.Log(transform.localPosition.z);
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 0, destination), 0.3f);
            if (state == 1)
                transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, 0.3f);
            else
                transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * 0.8f, 0.3f);
            if (Mathf.Abs(transform.localPosition.z - destination) < 0.001f) {
                transform.localPosition = new Vector3(0, 0, destination);
                transform.localScale = Vector3.one;
                if (state == -1) {
                    Destroy(gameObject);
                }
                state = 0;
            }
        }*/
    }
}
