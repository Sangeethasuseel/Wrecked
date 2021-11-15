using UnityEngine;

/// <summary>
/// This class inherits from TargetObject and represents a CrashObject.
/// </summary>
public class CollisionObject : MonoBehaviour
{
    [Header("CrashObject")]
    [Tooltip("The VFX prefab spawned when the object is collected")]
    public ParticleSystem CollectVFX;

    [Tooltip("The position of the centerOfMass of this rigidbody")]
    public Vector3 centerOfMass;

    [Tooltip("Apply a force to the crash object to make it fly up onTrigger")]
    public float forceUpOnCollide;

    public bool destroyOnCollide = true;

    Rigidbody m_rigid;

    void Start()
    {
        m_rigid = GetComponent<Rigidbody>();
        m_rigid.centerOfMass = centerOfMass; 
    }
    private bool firstHit = true;
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Player")
        {
            if (firstHit) { 
            gameObject.GetComponent<AudioSource>().Play();
            if (CollectVFX) CollectVFX.Play();
                firstHit = false;
            }
            if (m_rigid) m_rigid.AddForce(forceUpOnCollide * Vector3.up, ForceMode.Impulse);
            if (destroyOnCollide) Destroy(this.gameObject, 2);

        }

    }





}
