using UnityEditor;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] Vector2 range;

    public Collider2D[] EnemiesInRange()
    {
        return Physics2D.OverlapBoxAll(gameObject.transform.position, range, 0, layerMask);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        Gizmos.DrawWireCube(transform.position, range);
    }
}
