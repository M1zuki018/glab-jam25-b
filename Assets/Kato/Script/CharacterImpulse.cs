using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
//[RequireComponent(typeof(Rigidbody2D))]
//[RequireComponent(typeof(CircleCollider2D))]
public class CharacterImpulse : MonoBehaviour
{
    [SerializeField, Header("アニメーション時間")]
    private float duration = 0.5f;

    //[SerializeField]
    //int _mustGetKeyNumber;

    [SerializeField, Header("飛ぶ時のスケール")]
    private float _flyingScale = 1.0f;

    [SerializeField, Header("変数以上なら2番の演出")]
    private float _flyingCount = 100;

    [SerializeField, Header("変数以上なら3番の演出")]
    private float _blowoffCount = 150;

    [SerializeField ,Header("相撲のオブジェクト")]
    private GameObject smouPerson;

    [SerializeField, Header("動くまでの時間")]
    private float delay;

    [SerializeField]
    private Vector3 endPosition;

    [SerializeField, Header("リザルト処理")]
    private UnityEvent resultEvent;

    [SerializeField, Header("相撲の表情")]
    private Sprite[] _sprites;

    [SerializeField,Header("きらーんのオブジェクト")]
    private　GameObject _obj;

    [SerializeField, Header("きらーんの時間")]
    private float _direction;

    [SerializeField]
    private KeyInputCounter _inputCount;

    private SpriteRenderer _getSprite;
    private CriticalHit criticalHit;
    private Animator _animator;

    private int _sumouCount;
    public void Start()
    {
        _getSprite = gameObject.GetComponent<SpriteRenderer>();
        criticalHit = FindAnyObjectByType<CriticalHit>();
       _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _sumouCount = _inputCount.TotalCount;
        _animator.SetInteger("SumouCount", _sumouCount);
        
    }
    public void SmouMove(int getKeyCount,bool isCommandSuccess)
    {
        if ((getKeyCount >= _flyingCount && getKeyCount < _blowoffCount) && isCommandSuccess)
        {   
            _getSprite.sprite = _sprites[1];
            FindAnyObjectByType<SoundManager>().SoundPlay("ぶっ飛ぶ");
            criticalHit.HitEffect(true);
            Debug.Log("a");
            float characterSize = smouPerson.transform.localScale.x;

            //characterSize -= 0.01f * getKeyCount;
            //smouPerson.transform.localScale = new Vector2(characterSize, characterSize);

            characterSize -= _flyingScale/10;
            smouPerson.transform.DOScale(new Vector3(characterSize, characterSize, characterSize), duration).SetDelay(delay)
                .OnComplete(resultEvent.Invoke);
        }
        else if (getKeyCount >= _blowoffCount && isCommandSuccess)
        {
            _getSprite.sprite= _sprites[2];
            FindAnyObjectByType<SoundManager>().SoundPlay("壁突き抜け");
            criticalHit.HitEffect(true);
            //int enemyPosition = (int)smouPerson.transform.position.x;   //なにを入れていいかわからん
            //for (int j = 0; j > getKeyCount; j++)
            //{
            //    enemyPosition += 1;
            //}
            //smouPerson.transform.position = new Vector2(enemyPosition, enemyPosition);

            float characterSize = smouPerson.transform.localScale.x;
            characterSize -= _flyingScale / 5;
            smouPerson.transform.DOScale(new Vector3(characterSize, characterSize, characterSize), duration).SetDelay(delay);
            Vector3 rote = smouPerson.transform.eulerAngles;
            rote.z -= 200;
            smouPerson.transform.DORotate(rote, duration).SetDelay(delay);
            smouPerson.transform.DOMove(endPosition, duration).SetDelay(delay);
            _obj.transform.DOScale(new Vector3(1,1,1),duration).SetDelay(_direction)
                .OnComplete(resultEvent.Invoke);
        }
        else
        {
            _getSprite.sprite = _sprites[0];
            criticalHit.HitEffect(false);
            DOVirtual.DelayedCall(3, () => resultEvent.Invoke());
            //外す
        }
    }
}
