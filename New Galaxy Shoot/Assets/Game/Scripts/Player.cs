using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool canTripleShot = false;
    public bool canSpeed = false;
    public bool canShields = false;
    public int lives = 3;

    [SerializeField]
    private GameObject shieldGameObject;

    [SerializeField]
    private GameObject _explosionPrefab;

    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private GameObject _tripleShotPrefab;

    [SerializeField]
    private float _fireRate = 0.25f;
    private float _canFire = 0.0f;

    [SerializeField]
    private float _speed = 5.0f;

    private UIManager _uiManager;
    private void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if( _uiManager != null)
        {
            _uiManager.UpdateLives(lives);
        }
    }

    private void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            Shoot();
            
        }

    }
    private void Shoot()
    {
        if (Time.time > _canFire)
        {
            if(canTripleShot == true)
            {
                Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.7f, 0), Quaternion.identity);
            }
            
            _canFire = Time.time + _fireRate;
        }
    }
    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Di chuyen 
        if (canSpeed == true)
        {
            transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime * 1.5f);
            transform.Translate(Vector3.up * _speed * verticalInput * Time.deltaTime * 1.5f);
        }
        else
        {
            transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.up * _speed * verticalInput * Time.deltaTime);
        }
        

        //Gioi han di chuyen object
        if (transform.position.y > 2.51f)
        {
            transform.position = new Vector3(transform.position.x, 2.51f, 0);
        }
        else if (transform.position.y < -2.51f)
        {
            transform.position = new Vector3(transform.position.x, -2.51f, 0);
        }

        if (transform.position.x > 6.0f)
        {
            transform.position = new Vector3(-6, transform.position.y, 0);
        }
        else if (transform.position.x < -6.0f)
        {
            transform.position = new Vector3(6, transform.position.y, 0);
        }
    }
    public void Damage()
    {
        if(canShields == true)
        {
            canShields = false;
            shieldGameObject.SetActive(false);
            return;
        }
        lives--;
        _uiManager.UpdateLives(lives);

        if (lives < 1)
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            _uiManager.ShowTitleScreen();
            Destroy(this.gameObject);
        }
    }

    public void TripleShotPowerOn()
    {
        canTripleShot = true;
        StartCoroutine(TripleShotDownRoutine());
    }
    public IEnumerator TripleShotDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShot = false;
    }
    public void CanSpeedPowerOn()
    {
        canSpeed = true;
        StartCoroutine(CanSpeedDownRoutine());
    }
    public IEnumerator CanSpeedDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canSpeed = false;
    }
    public void CanShieldsPowerOn()
    {
        canShields = true;
        shieldGameObject.SetActive(true);
        StartCoroutine(CanShieldsDownRoutine());
    }
    public IEnumerator CanShieldsDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canShields = false;
        shieldGameObject.SetActive(false);
    }
}
