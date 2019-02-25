using UnityEngine;

public class Collision : MonoBehaviour {

    public Movement Stop;
    

    void OnCollisionEnter (UnityEngine.Collision CollisionInfo)
    {
        if (CollisionInfo.gameObject.tag == "Obstacle")
        {
            Stop.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
            
        }
    }

}
