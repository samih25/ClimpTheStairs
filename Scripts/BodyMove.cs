using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyMove : MonoBehaviour
{
    [SerializeField] Transform _bodyTransform, _sopaTransform;
    [SerializeField] GameObject _gameOverPanel;
    [SerializeField] float _translateDeger, _rotationDeger;
    [SerializeField] float _canZaman;
    [SerializeField] Animator _animator;
    [SerializeField] bool _yuksekBool = false;
    [SerializeField] TextMesh _mesafe;
    [SerializeField] Text _dinlenText, _moneyMiktarText;
    [SerializeField] int _sure = 5;
    [SerializeField] Material _bodyMaterial;
    [SerializeField] Text _recordText;
    Vector3 _vec3 = new Vector3();  
    float _curentTime;
    float timer;
    float _saglamlik = 150;
    bool durdu;
    float _zaman, _yorulmaZaman;
    bool cikiyor;
    int para;
    int _staminaUpgrade = 5;

    public void OnClickSaglamlik()
    {
        para = StairsSpawner._money;

        if (para >= _staminaUpgrade)
        {
            _sure = _sure + 5;
            StairsSpawner._money -= _staminaUpgrade;
            _staminaUpgrade *= 2;

        }

    }
    private void Start()
    {
        _recordText.text = "" + (PlayerPrefs.GetFloat("Rekor").ToString(".###," + " m"));
     
        _bodyMaterial.color = Color.white;
    }
    private void Update()
    {

        if (Input.GetMouseButton(0))
        {
            cikiyor = true;
            durdu = false;
            
            _zaman += Time.deltaTime;
            _canZaman += Time.deltaTime;
            _yuksekBool = true;
            _animator.SetBool("__isBuyume", false);

          if (_canZaman>=_sure )
            {
                _bodyMaterial.color = Color.red;
                _dinlenText.text = "Yoruldum !!";                
            }

            if (_canZaman >= _sure+6)
            {
               
                Time.timeScale = 0;
                if((PlayerPrefs.GetFloat("Rekor")<= (50 * ((_sopaTransform.transform.position.y) + 5.21f))))
                {
                    PlayerPrefs.SetFloat("Rekor", (50 * ((_sopaTransform.transform.position.y) + 5.21f)));
                }
               
                _gameOverPanel.SetActive(true);
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            cikiyor = false;
            _animator.SetBool("__isKosmaUp", false);
            timer = 0;
            _dinlenText.text = "";

            _yuksekBool = false;

            _zaman = 0f;

            if (_canZaman > _sure)
            {
                _animator.SetBool("__isBuyume", true);
                durdu = true;
            }

        }

        if (_canZaman < _sure && durdu)
        {
            _animator.SetBool("__isBuyume", false);
            durdu = true;
            _bodyMaterial.color = Color.white;
        }

    }
    private void FixedUpdate()
    {
        if (cikiyor)
            BodyyMove();
        if (durdu)
        {

            _canZaman -= 0.001f;
        }
    }
    private void LateUpdate()
    {

        Vector3 best;
        best = new Vector3(8.34f, _bodyTransform.position.y - 5.21f - 5.39f, 3.736f);

        if (best.y > _sopaTransform.transform.position.y)
        {
            _sopaTransform.transform.position = new Vector3(8.34f, _bodyTransform.position.y - 5.21f - 5.39f, 3.736f);
            _mesafe.text = (50 * ((_sopaTransform.transform.position.y) + 5.21f)).ToString(".##" + " m");

        }

    }

    IEnumerator Buyume()
    {
        yield return new WaitForSecondsRealtime(4f);

    }

    void BodyyMove()
    {
        timer += Time.deltaTime;
        if (timer >= 0.3f)
        {
            _animator.SetBool("__isKosmaUp", true);
            

        }

        if (timer >= 0.4f)
        {
            _bodyTransform.Translate(Vector3.forward * _translateDeger * (Time.deltaTime));
          
            _bodyTransform.Rotate(0, _rotationDeger, 0);
            

        }
        
    }
    
}
