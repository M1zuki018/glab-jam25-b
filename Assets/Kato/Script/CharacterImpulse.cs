using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(CircleCollider2D))]
public class CharacterImpulse : MonoBehaviour
{
    Transform _tr;
    int _getKeyCount;
    bool _isCommandSuccess;
    float _characterSize;

    [SerializeField]
    KeyInputCounter _kIC;
    [SerializeField]
    int _mustGetKeyNumber;
    int _enemyPosition;
    // Start is called before the first frame update
    void Start()
    {
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
            for(int j = 0; j > _getKeyCount; j++)
            {
                _enemyPosition += 1;
            }
            _tr.position = new Vector2(_enemyPosition,_enemyPosition);
        }
    }
}
