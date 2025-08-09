using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
//[RequireComponent(typeof(Rigidbody2D))]
//[RequireComponent(typeof(CircleCollider2D))]
public class CharacterImpulse : MonoBehaviour
{
    //[SerializeField]
    //int _mustGetKeyNumber;

    [SerializeField, Header("��Ԏ��̃X�P�[��")]
    private float _flyingScale = 1.0f;

    [SerializeField, Header("�ϐ��ȏ�Ȃ�2�Ԃ̉��o")]
    private float _flyingCount = 100;

    [SerializeField, Header("�ϐ��ȏ�Ȃ�3�Ԃ̉��o")]
    private float _blowoffCount = 150;

    [SerializeField ,Header("���o�̃I�u�W�F�N�g")]
    private GameObject smouPerson;

    [SerializeField, Header("�����܂ł̎���")]
    private float delay;

    [SerializeField, Header("���U���g����")]
    private UnityEvent resultEvent;

    private CriticalHit criticalHit;
    public void Start()
    {
        criticalHit = FindAnyObjectByType<CriticalHit>();
    }
    public void SmouMove(int getKeyCount,bool isCommandSuccess)
    {
        if ((getKeyCount >= _flyingCount && getKeyCount < _blowoffCount) && isCommandSuccess)
        {
            FindAnyObjectByType<SoundManager>().SoundPlay("�Ԃ����");
            criticalHit.HitEffect(true);
            Debug.Log("a");
            float characterSize = smouPerson.transform.localScale.x;

            //characterSize -= 0.01f * getKeyCount;
            //smouPerson.transform.localScale = new Vector2(characterSize, characterSize);

            characterSize -= _flyingScale/10;
            smouPerson.transform.DOScale(new Vector3(characterSize, characterSize, characterSize),0.5f).SetDelay(delay)
                .OnComplete(resultEvent.Invoke);
        }
        else if (getKeyCount >= _blowoffCount && isCommandSuccess)
        {
            FindAnyObjectByType<SoundManager>().SoundPlay("�Ǔ˂�����");
            criticalHit.HitEffect(true);
            //int enemyPosition = (int)smouPerson.transform.position.x;   //�Ȃɂ����Ă������킩���
            //for (int j = 0; j > getKeyCount; j++)
            //{
            //    enemyPosition += 1;
            //}
            //smouPerson.transform.position = new Vector2(enemyPosition, enemyPosition);

            float characterSize = smouPerson.transform.localScale.x;
            characterSize -= _flyingScale / 5;
            smouPerson.transform.DOScale(new Vector3(characterSize, characterSize, characterSize), 0.5f).SetDelay(delay);
            Vector3 rote = smouPerson.transform.eulerAngles;
            rote.z -= 200;
            smouPerson.transform.DORotate(rote, 0.5f).SetDelay(delay);
            smouPerson.transform.DOMove(new Vector3(10.8199997f, 7.21999979f, 0), 0.5f).SetDelay(delay)
                .OnComplete(resultEvent.Invoke);
        }
        else
        {
            criticalHit.HitEffect(false);
            DOVirtual.DelayedCall(3, () => resultEvent.Invoke());
            //�O��
        }
    }
}
