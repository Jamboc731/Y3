using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// <param name="Entity">Abstract Class of all entities</param>
/// </summary>
[RequireComponent(typeof(Rigidbody))]
abstract public class Entity : MonoBehaviour
{
    /// <summary>
    /// <param name="health">Health of entitiy</param>
    /// </summary>
    protected int i_health;
    /// <summary>
    /// <param name="RigidBody">Rigid body component</param>
    /// </summary>
    protected Rigidbody rb;
    public EPlayerEnum example = EPlayerEnum.idle;

    public virtual void Init()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }



    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Physics calculations happen here
    private void FixedUpdate()
    {
        
    }

    public virtual void ChangeHealth(int _i_delta)
    {
        i_health += _i_delta;
        if(i_health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        gameObject.SetActive(false);
    }
}
