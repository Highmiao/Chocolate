using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicFrameUpdate : MonoBehaviour {
    public static LogicFrameUpdate s_instance;

    public delegate void OnLogicUpdate(float delta_time);
    public event OnLogicUpdate on_logic_update;

    public delegate void OnTurnUpdate(float delta_time);
    public event OnTurnUpdate on_turn_update;

    public int logic_frame_rate;            // 逻辑帧率
    public float turn_delta_time;        // 轮间隔时间
    public int logic_frame_count;           // 逻辑帧计数
    public int turn_count;                  // 轮计数

    private float m_render_frame_delta_time;
    private float m_logic_frame_delta_time;
    private int m_turn_delta_frames;

    private void Awake() {
        if (s_instance == null) {
            s_instance = this;
        }
        else if (s_instance != this) {
            Destroy(this.gameObject);
        }
    }

    void Start () {
        m_logic_frame_delta_time = 1.0f / logic_frame_rate;
        m_turn_delta_frames = Mathf.CeilToInt(turn_delta_time / m_logic_frame_delta_time);
    }
	
	void Update () {
        m_render_frame_delta_time += Time.deltaTime;
        while (m_render_frame_delta_time > m_logic_frame_delta_time) {
            m_render_frame_delta_time -= m_logic_frame_delta_time;
            logic_frame_count++;
            if (on_logic_update != null) on_logic_update(m_logic_frame_delta_time);
            int yu = logic_frame_count % m_turn_delta_frames;
            if (yu == 0) {
                turn_count++;
                if (on_turn_update != null) on_turn_update(turn_delta_time);
            }
        }
    }
}
