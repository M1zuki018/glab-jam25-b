using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(CircleCollider2D))]
public class CharacterImpulse : MonoBehaviour
{
    Rigidbody2D _rb;
    Transform _tr;
    int _getKeyCount;
    bool _isCommandSuccess;
    float _characterSize;
    Vector2 _force;

    [SerializeField]
    KeyInputCounter _kIC;
    [SerializeField]
    int _mustGetKeyNumber;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _tr = transform;
        _kIC = GetComponent<KeyInputCounter>();
        _getKeyCount = _kIC.TotalCount;
    }

    // Update is called once per frame
    void Update()
    {
        if ((_getKeyCount >= 100 || _getKeyCount < 150) && _isCommandSuccess)
        {
            for(int i = 0; i > _getKeyCount; i++)
            {
                _characterSize -= 0.01f;
            }
            _tr.localScale = new Vector2(_characterSize,_characterSize);
        }
        else if(_getKeyCount >= 150 && _isCommandSuccess)
        {

        }
    }
}
