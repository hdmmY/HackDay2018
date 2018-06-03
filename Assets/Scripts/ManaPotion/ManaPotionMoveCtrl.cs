using UnityEngine;

[RequireComponent (typeof (ManaPotionProperty))]
[RequireComponent (typeof (Collider2D))]
public class ManaPotionMoveCtrl : MonoBehaviour
{
    public Transform Target;

    private ManaPotionProperty _manaPotion;
    private Vector2 _velocity;

    private void OnEnable ()
    {
        _manaPotion = GetComponent<ManaPotionProperty> ();
    }

    private void LateUpdate ()
    {
        if (Target != null)
        {
            Vector2 newPos;

            float dist = (Target.position - transform.position).magnitude;

            if (dist > 2f)
            {
                newPos = Vector2.SmoothDamp (transform.position, Target.position,
                    ref _velocity, 0.2f, 20f, Time.deltaTime);
            }
            else
            {
                newPos = Vector2.MoveTowards (transform.position, Target.position,
                    Mathf.Clamp (_velocity.magnitude * Time.deltaTime * 1, 0, dist));
            }

            transform.position = new Vector3 (newPos.x, newPos.y, transform.position.z);
        }
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.GetComponent<PlayerColliderBody> ())
        {
            other.GetComponentInParent<PlayerProperty> ().Power += _manaPotion.ManaPoint;
            gameObject.SetActive (false);
            Destroy (gameObject);
        }
    }
}