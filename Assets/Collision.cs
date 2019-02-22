using UnityEngine;

public class Collision : MonoBehaviour {

    public Movement Stop;

    void OnCollisionEnter (UnityEngine.Collision CollisionInfo)
    {
        if (CollisionInfo.gameObject.name == "Obstacle")
        {
            Stop.enabled = false;
        }
    }

}
