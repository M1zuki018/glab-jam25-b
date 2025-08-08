using UnityEngine;
using UnityEngine.Events;

public class KeyInputCounter : MonoBehaviour
{
    [Header("����4�L�[")]
    // ���葤�̓��͂Ƃ��Ďg���L�[�i4�S�ē���������1�X�e�b�v�����j
    [SerializeField] private KeyCode[] leftKeys = { KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F };
    
    [Header("�E��4�L�[")]

    [SerializeField] private KeyCode[] rightKeys = { KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.Semicolon };


    [Header("�J�E���g����")]
    // ���݂̗݌v�J�E���g
    [SerializeField] private int totalCount;

    public int TotalCount => totalCount;


    // �ǂ���̑��ōŌ�ɃJ�E���g�������������񋓌^
    private enum Side { None, Left, Right }
    private Side lastSide = Side.None; // �O��J�E���g�������i���ݔ���p�j

    // �O�t���[����4�S��������Ă������ǂ���
    private bool prevLeftAll, prevRightAll;

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
    }

    // �w�肳�ꂽ�L�[�z�񂪑S�ĉ�����Ă��邩�𔻒�
    bool AllHeld(KeyCode[] keys)
    {
        foreach (var k in keys)
            if (!Input.GetKey(k)) return false; // 1�ł�������Ă��Ȃ��L�[�������false
        return true; // �S�ĉ�����Ă���ꍇtrue
    }

    // �O��ƈقȂ鑤�Ȃ�J�E���g����i���݉������[���j
    void CountIfAlternate(Side current)
    {
        if (current == lastSide) return; // ���������A�������ꍇ�͖���
        lastSide = current;              // ����̑����L�^
        totalCount++;                    // �J�E���g�����Z
       
    }

    // �J�E���g�Ə�Ԃ����Z�b�g
    public void ResetCount()
    {
        totalCount = 0;                         // �J�E���g��0��
        lastSide = Side.None;                   // �Ō�ɉ�����������������
        prevLeftAll = prevRightAll = false;     // ������ԗ�����������
    }
}