using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.GetComponent<Rigidbody>().velocity > 0)
        //{

        //}
        SoundManager.s_instance.PlayBounce();
    }

}
