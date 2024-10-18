using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class Rocket : MonoBehaviour
{
    //충돌 시 이벤트 등록
    public UnityEvent Oncrash;

    private Rigidbody2D _rb2d;
    
    
    [SerializeField]private Button _button;
    
    private readonly float SPEED = 5f;

    // 처음 GravityScale = 0f;
    private bool gravitySet = false;

    void Awake()
    {
        // TODO : Rigidbody2D 컴포넌트 가져오기 
        _rb2d = GetComponent<Rigidbody2D>();
        // 버튼 리스너 연결
        _button.onClick.AddListener(Shoot);
    }
    
    public void Shoot()
    {
        if (!gravitySet)
        {
            // shoot버튼 누르면 게임 시작하는 식으로
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
