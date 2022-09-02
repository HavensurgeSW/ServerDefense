using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimbot : MonoBehaviour
{
    [SerializeField] List<GameObject> targets = new List<GameObject>();
    [SerializeField] CircleCollider2D circleCollider;

    public void SetRange(float range) {
        circleCollider.radius = range;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!targets.Contains(collision.gameObject))
            targets.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (targets.Contains(collision.gameObject))
            targets.Remove(collision.gameObject);
    }


}
