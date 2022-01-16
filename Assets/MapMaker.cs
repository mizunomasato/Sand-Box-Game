using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMaker : MonoBehaviour
{
    private float SeedX, SeedZ; //�}�b�v�̐����������_���ɂ��邽�߂̕ϐ�
    [SerializeField]
    private float Width = 90;//�}�b�v�̉���
    [SerializeField]
    private float Depth = 90;//�}�b�v�̉��s��

    [SerializeField]
    private bool NeedToCollider = false;�@//�����蔻������邩�ǂ���

    [SerializeField]
    private float MaxHeight = 5;�@//�ő�̍���

    [SerializeField]
    private float Relief = 13f; //�N��̌�����

    private int PositionY; //�����𐮐��ɕϊ����邽�߂̕ϐ�

    private void Awake()
    {
        SeedX = Random.value * 100f; // �����l�ɂȂ�Ȃ��悤��x���W�������_���ɂ���
        SeedZ = Random.value * 100f; // �����l�ɂȂ�Ȃ��悤��z���W�������_���ɂ���

        //�L���[�u����
        for (int x = 0; x < Width; x++) // �w�肵�������ɂȂ�܂ŌJ��Ԃ�
        {
            for (int z = 0; z < Depth; z++) // �w�肵�����s���ɂȂ�܂ŌJ��Ԃ�
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);�@// �V�����L���[�u�쐬
                cube.transform.localPosition = new Vector3(x, 0, z); // �n�ʂɒu��
                cube.transform.SetParent(transform); // �L���[�u���q�I�u�W�F�N�g�ɂ���

                if (!NeedToCollider) // �����A�R���C�_�[�����Ȃ��Ȃ�A
                {
                    Destroy(cube.GetComponent<BoxCollider>()); // �R���C�_�[������
                }

                SetY(cube); // �����̐ݒ������
            }
        }
    }

    private void SetY(GameObject cube) // �L���[�u��Y���W��ݒ肷��֐�
    {
        float y = 0; // y��0�ɂ���
        float xSample = (cube.transform.localPosition.x + SeedX) / Relief; // �p�[�����m�C�Y�Ŏg���l�����߂� 
        float zSample = (cube.transform.localPosition.z + SeedZ) / Relief; // �p�[�����m�C�Y�Ŏg���l�����߂�
        float noise = Mathf.PerlinNoise(xSample, zSample); // �m�C�Y���p�[�����m�C�Y�ŏo�����l�ɂ���
        y = MaxHeight * noise; // y���ő�̍���*noise�̒l�ɂ���
        PositionY = Mathf.RoundToInt(y); // PositionY��y���l�̌ܓ������l�ɂ���
        cube.transform.localPosition = new Vector3(cube.transform.localPosition.x, PositionY, cube.transform.localPosition.z); // �L���[�u��ݒu����

        Color color = Color.black;//��Ղ��ۂ��F

        if (y > MaxHeight * 0.3f)
        {
            ColorUtility.TryParseHtmlString("#006400", out color);//�����ۂ��F
        }

        else if (y > MaxHeight * 0.2f)
        {
            ColorUtility.TryParseHtmlString("#4169e1", out color);//�����ۂ��F
        }

        else if (y > MaxHeight * 0.1f)
        {
            ColorUtility.TryParseHtmlString("#d2691e", out color);//�}�O�}���ۂ��F
        }

        cube.GetComponent<MeshRenderer>().material.color = color;



        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}