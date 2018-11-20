using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCell : MonoBehaviour {


    public bool testIncrement;
    public bool testDecrement;

    public GameObject wheelPrefab;
    public Transform wheelHolder;
    public Transform cylinder;
    public List<NumberWheel> wheels;
    public int value;
    private int wheelCount;

    public int Read() {
        return value;
    }

	public void Increment() {
        value += 1;
        Refresh();
    }

    public void Decrement() {
        if (value > 0)
            value -= 1;
        Refresh();
    }

    IEnumerator AddWheel() {
        yield return 0;
    }

    IEnumerator RemoveWheel() {
        yield return 0;
    }

    private void Refresh() {
        wheelCount = Mathf.CeilToInt(Mathf.Log10(value + 1));
        /*while (wheels.Count > 2 && wheels.Count > wheelCount) {
            wheels[wheels.Count - 1].Despawn();
            wheels.RemoveAt(wheels.Count - 1);
        }
        while (wheels.Count < wheelCount || wheels.Count < 2) {
            GameObject newWheel = Instantiate(wheelPrefab, wheelHolder);
            newWheel.transform.localPosition = new Vector3(0, 0, (wheels.Count - 1) * 0.35f);
            newWheel.transform.localScale = new Vector3(0.8f, 0.8f, 1.0f);
            wheels.Add(newWheel.GetComponent<NumberWheel>());
            wheels[wheels.Count - 1].Spawn();
        }*/
        wheelHolder.localPosition = new Vector3(0, 0, -0.175f * (wheels.Count - 1));
        cylinder.localScale = new Vector3(1.5f, 0.175f * (wheels.Count - 1) + 0.3f, 1.5f);
        for (int i = 0; i < wheels.Count; i++) {
            wheels[i].NewTarget((value / (int)Mathf.Pow(10, i)) % 10);
        }
    }

    private void Start() {
        wheels = new List<NumberWheel>();
        Refresh();
    }

    private void Update() {
        if (testDecrement) {
            testDecrement = false;
            Decrement();
        }
        if (testIncrement) {
            testIncrement = false;
            Increment();
        }
    }
}
