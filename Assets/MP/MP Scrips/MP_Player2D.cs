using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MP_Player2D : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;

    PhotonView view;

    private Rigidbody2D _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        view = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (view.IsMine)
        {
            var movement = Input.GetAxis("Horizontal");
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

            if (!Mathf.Approximately(0, movement))
            {
                transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
            }

            if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
            {
                _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            }
        }
    }
}