using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Damage : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private string otherTag;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(otherTag) && other.isTrigger)
        {
            GenHealth temp = other.GetComponent<GenHealth>();
            if(temp)
            {
                temp.GetDamage(damage);
            }
        }
    }
}
