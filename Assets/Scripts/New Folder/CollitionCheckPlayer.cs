using Fusion;
using UnityEngine;

public class CollitionCheckPlayer : NetworkBehaviour
{
    public float checkRadius = 1f;
    public LayerMask hitMask;
  
    public NetworkObject ReturnPlayerInsideSphere()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position,checkRadius, hitMask);

        NetworkObject closestTarget = null;
        float closestDistance = Mathf.Infinity;

        foreach(var col in hits)
        {
            var netobj = col.GetComponentInParent<NetworkObject>();
            if (netobj == null || netobj == Object) continue;
            
            float distance = Vector3.Distance(transform.position, col.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTarget = netobj;
            }
        }
        Debug.Log(closestTarget);
        return closestTarget;
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
