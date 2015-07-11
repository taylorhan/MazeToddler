using UnityEngine;
using System.Collections;

public class playerCtrl : MonoBehaviour {

	private Animator _animator;
    private Transform _transform;

    void Awake()
    {
        _transform = this.transform;
        if(this.GetComponent<Animator>())
        {
            _animator = this.GetComponent<Animator>();
        }
    }

    void Update()
    {
        float fX = Input.GetAxisRaw("Horizontal");
        float fY = Input.GetAxisRaw("Vertical");

        bool bWalking = Mathf.Abs(fX) + Mathf.Abs(fY) > 0;

        _animator.SetBool("isWalking", bWalking);

        if(bWalking)
        {
            _animator.SetFloat("x", fX);
            _animator.SetFloat("y", fY);

            _transform.position += new Vector3(fX, fY, 0.0f).normalized * 0.01f;
        }
    }
    void OnCollisionEnter2D(Collision2D enterColl)
    {
        GameObject targetObj = enterColl.gameObject;
        if(enterColl.collider.tag == Tags.Item)
        {
            Destroy(targetObj);
        }
    }
}
