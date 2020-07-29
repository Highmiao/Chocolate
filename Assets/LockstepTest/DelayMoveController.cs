using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayMoveController : MonoBehaviour {

    public float dist;
    public int delay_frames;

    private List<Vector3> movements;

    void Start() {
        movements = new List<Vector3>();
        LogicFrameUpdate.s_instance.on_logic_update += OnLogicUpdate;
    }

    void Update() {
        
    }

    public void OnLogicUpdate(float delta_time) {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        float speed = dist * delta_time;
        Vector3 movement = new Vector3(h * speed, 0, v * speed);
        movements.Add(movement);
        if(movements.Count > delay_frames) {
            transform.Translate(movements[movements.Count - delay_frames - 1], Space.Self);
        }
    }
}
