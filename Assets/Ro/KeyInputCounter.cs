using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class KeyInputCounter : MonoBehaviour
{
    [Header("����4�L�[")]
    // ���葤�̓��͂Ƃ��Ďg���L�[�i4�S�ē���������1�X�e�b�v�����j
    [SerializeField] private KeyCode[] leftKeys = { KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F };

    [Header("�E��4�L�[")]

    [SerializeField] private KeyCode[] rightKeys = { KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.Semicolon };


    // ���݂̗݌v�J�E���g
    [Header("�J�E���g����")]
    [SerializeField] public int totalCount;

    [SerializeField, Header("���̎�")]
    private GameObject leftHand;
    [SerializeField, Header("�E�̎�")]
    private GameObject rightHand;
    [SerializeField, Header("���������̃X�P�[��")]
    private float pushScale;

    [SerializeField, Header("�����G�t�F�N�g")]
    private HariteHitEffect hariteFX;

    private Vector3 opponentCenterPos = new Vector3(-0.3f, -0.52f, -4.379f);
    public int TotalCount => totalCount;


    // �ǂ���̑��ōŌ�ɃJ�E���g�������������񋓌^
    private enum Side { None, Left, Right }
    private Side lastSide = Side.None; // �O��J�E���g�������i���ݔ���p�j

    // �O�t���[����4�S��������Ă������ǂ���
    private bool prevLeftAll, prevRightAll;
    private Vector3 defaultScale;

    public void Start()
    {
        defaultScale = leftHand.transform.localScale;
    }
    void Update()
    {
        // --- ���݂̑S������Ԃ��擾 ---
        bool leftAll = AllHeld(leftKeys);
        bool rightAll = AllHeld(rightKeys);


        // �u������Ă��Ȃ������v���u�S�����ɂȂ����v�u�Ԃ������肷��
        if (leftAll && !prevLeftAll) CountIfAlternate(Side.Left);
        if (rightAll && !prevRightAll) CountIfAlternate(Side.Right);

        // --- ���̃t���[���̏�Ԃ�ۑ��i���t���[���̔�r�p�j ---
        prevLeftAll = leftAll;
        prevRightAll = rightAll;

        if (AllHeld(leftKeys))
        {
            leftHand.transform.localScale = defaultScale / pushScale;
        }
        else
        {
            leftHand.transform.localScale = defaultScale;
        }
        if (AllHeld(rightKeys))
        {
            rightHand.transform.localScale = defaultScale / pushScale;
        }
        else
        {
            rightHand.transform.localScale = defaultScale;
        }

    }

    // �w�肳�ꂽ�L�[�z�񂪑S�ĉ�����Ă��邩�𔻒�
    bool AllHeld(KeyCode[] keys)
    {
        foreach (var k in keys)
        {
            if (!Input.GetKey(k))
            {
                return false; // 1�ł�������Ă��Ȃ��L�[�������false
            }

        }
        return true; // �S�ĉ�����Ă���ꍇtrue
    }

    // �O��ƈقȂ鑤�Ȃ�J�E���g����i���݉������[���j
    void CountIfAlternate(Side current)
    {
        if (current == lastSide) return; // ���������A�������ꍇ�͖���
        lastSide = current;              // ����̑����L�^
        totalCount++;                    // �J�E���g�����Z

        if (current == Side.Left) PushLeftHand();
        if (current == Side.Right) PushRightHand();
    }

    // �J�E���g�Ə�Ԃ����Z�b�g
    public void ResetCount()
    {
        totalCount = 0;                         // �J�E���g��0��
        lastSide = Side.None;                   // �Ō�ɉ�����������������
        prevLeftAll = prevRightAll = false;     // ������ԗ�����������
    }
    public void ScaleReset()
    {
        leftHand.transform.localScale = defaultScale;
        rightHand.transform.localScale = defaultScale;
    }
    public void Push()
    {
        FindAnyObjectByType<SoundManager>().SoundPlay("�����");
        rightHand.transform.DOScale(defaultScale / (pushScale * 1.2f), 0.3f)
            .OnComplete(() => rightHand.transform.DOScale(defaultScale, 0.5f).SetDelay(0.5f));
    }
    public void TimeUp()
    {
        totalCount = 0;
    }
    public void PushLeftHand()
    {
        FindAnyObjectByType<SoundManager>()?.SoundPlay("�����");

        // ����͎m�̈ʒu�Ƀq�b�g���o
        if (hariteFX != null)
        {
            var pos = opponentCenterPos;
            pos.z = hariteFX.transform.position.z;
            hariteFX.PlayAt(pos);
        }

        leftHand.transform.DOScale(defaultScale / (pushScale * 1.2f), 0.3f)
            .OnComplete(() => leftHand.transform.DOScale(defaultScale, 0.5f).SetDelay(0.5f));
    }
    public void PushRightHand()
    {
        FindAnyObjectByType<SoundManager>().SoundPlay("�����");


        if (hariteFX != null)
        {
            var pos = opponentCenterPos;
            pos.z = hariteFX.transform.position.z;
            hariteFX.PlayAt(pos);
        }

        rightHand.transform.DOScale(defaultScale / (pushScale * 1.2f), 0.3f)
            .OnComplete(() => rightHand.transform.DOScale(defaultScale, 0.5f).SetDelay(0.5f));
    }
}