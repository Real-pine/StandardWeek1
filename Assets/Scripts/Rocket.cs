using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class Rocket : MonoBehaviour
{
    //�浹 �� �̺�Ʈ ���
    public UnityEvent Oncrash;

    private Rigidbody2D _rb2d;
    
    
    [SerializeField]private Button _button;
    
    private readonly float SPEED = 5f;

    // ó�� GravityScale = 0f;
    private bool gravitySet = false;

    void Awake()
    {
        // TODO : Rigidbody2D ������Ʈ �������� 
        _rb2d = GetComponent<Rigidbody2D>();
        // ��ư ������ ����
        _button.onClick.AddListener(Shoot);
    }
    
    public void Shoot()
    {
        if (!gravitySet)
        {
            // shoot��ư ������ ���� �����ϴ� ������
            _rb2d.gravityScale = 0.7f;
            gravitySet = true;
        }

        _rb2d.AddForce(Vector2.up * SPEED, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Oncrash.Invoke();
        }
    }

}
