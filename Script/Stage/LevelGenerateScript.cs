using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerateScript : MonoBehaviour
{
    public static LevelGenerateScript instance;

    public float span = 3f;
    public float spanHigh = 3f;
    public float spanLow = 3f;
    public float High = 3f;
    public float Low = 0f;
    public float PosXHigh = 20f;
    public float PosXLow = 20f;
    public float ScaleHigh = 1f;
    public float ScaleLow = 1f;
    public float RotationHigh = 0;
    public float RotationLow = 0;
    private float currentTime = 0f;
    public GameObject HBlockPosSetObj, HBlockPosObj1, HBlockPosObj2, HBlockPosObj3, HBlockPosObj4, HBlockPosObj5, HBlockPosObj6, HBlockPosObj7, HBlockPosObj8, HBlockPosObj9, HBlockPosObj10, HBlockPosObj11, 
        BCT1Pos1, BCT1Pos2, BCT1Pos3, BCT1Pos4, BCT1Pos5, BCT1Pos6, BCT1Pos7, BCT1Pos8, BCT1Pos9,
        BCH1Pos1, BCH1Pos2, BCH1Pos3, BCH1Pos4, BCH1Pos5, BCH1Pos6, BCH1Pos7, BCH1Pos8, BCH1Pos9, BCH1Pos10, BCH1Pos11, BCH1Pos12, BCH1Pos13, 
        BCA1Pos1, BCA1Pos2, BCA1Pos3, BCA1Pos4, BCA1Pos5, BCA1Pos6, BCA1Pos7, BCA1Pos8, BCA1Pos9, BCA1Pos10, BCA1Pos11, BCA1Pos12, 
        BCN1Pos1, BCN1Pos2, BCN1Pos3, BCN1Pos4, BCN1Pos5, BCN1Pos6, BCN1Pos7, BCN1Pos8, BCN1Pos9, BCN1Pos10, BCN1Pos11, BCN1Pos12, BCN1Pos13,
        BCK1Pos1, BCK1Pos2, BCK1Pos3, BCK1Pos4, BCK1Pos5, BCK1Pos6, BCK1Pos7, BCK1Pos8, BCK1Pos9, BCK1Pos10, BCK1Pos11, BCK1Pos12,
        BCY1Pos1, BCY1Pos2, BCY1Pos3, BCY1Pos4, BCY1Pos5, BCY1Pos6, BCY1Pos7,
        BCO1Pos1, BCO1Pos2, BCO1Pos3, BCO1Pos4, BCO1Pos5, BCO1Pos6, BCO1Pos7, BCO1Pos8,
        BCU1Pos1, BCU1Pos2, BCU1Pos3, BCU1Pos4, BCU1Pos5, BCU1Pos6, BCU1Pos7, BCU1Pos8, BCU1Pos9,
        BCF1Pos1, BCF1Pos2, BCF1Pos3, BCF1Pos4, BCF1Pos5, BCF1Pos6, BCF1Pos7, BCF1Pos8, BCF1Pos9, BCF1Pos10, BCF1Pos11, BCF1Pos12,
        BCO2Pos1, BCO2Pos2, BCO2Pos3, BCO2Pos4, BCO2Pos5, BCO2Pos6, BCO2Pos7, BCO2Pos8,
        BCR1Pos1, BCR1Pos2, BCR1Pos3, BCR1Pos4, BCR1Pos5, BCR1Pos6, BCR1Pos7, BCR1Pos8, BCR1Pos9, BCR1Pos10, BCR1Pos11, BCR1Pos12, BCR1Pos13, BCR1Pos14, BCR1Pos15, BCR1Pos16,
        BCP1Pos1, BCP1Pos2, BCP1Pos3, BCP1Pos4, BCP1Pos5, BCP1Pos6, BCP1Pos7, BCP1Pos8, BCP1Pos9, BCP1Pos10, BCP1Pos11, BCP1Pos12, BCP1Pos13, BCP1Pos14,
        BCL1Pos1, BCL1Pos2, BCL1Pos3, BCL1Pos4, BCL1Pos5, BCL1Pos6, BCL1Pos7, BCL1Pos8, BCL1Pos9,
        BCA2Pos1, BCA2Pos2, BCA2Pos3, BCA2Pos4, BCA2Pos5, BCA2Pos6, BCA2Pos7, BCA2Pos8, BCA2Pos9, BCA2Pos10, BCA2Pos11, BCA2Pos12,
        BCI1Pos1, BCI1Pos2, BCI1Pos3, BCI1Pos4, BCI1Pos5,
        BCY2Pos1, BCY2Pos2, BCY2Pos3, BCY2Pos4, BCY2Pos5, BCY2Pos6, BCY2Pos7,
        BCN2Pos1, BCN2Pos2, BCN2Pos3, BCN2Pos4, BCN2Pos5, BCN2Pos6, BCN2Pos7, BCN2Pos8, BCN2Pos9, BCN2Pos10, BCN2Pos11, BCN2Pos12, BCN2Pos13,
        BCG1Pos1, BCG1Pos2, BCG1Pos3, BCG1Pos4, BCG1Pos5, BCG1Pos6, BCG1Pos7, BCG1Pos8, BCG1Pos9, BCG1Pos10, BCG1Pos11, 
        BCPeriodPos,
        BCB1Pos1, BCB1Pos2, BCB1Pos3, BCB1Pos4, BCB1Pos5, BCB1Pos6, BCB1Pos7, BCB1Pos8, BCB1Pos9, BCB1Pos10, BCB1Pos11, BCB1Pos12, BCB1Pos13, BCB1Pos14, BCB1Pos15, BCB1Pos16,
        BCY3Pos1, BCY3Pos2, BCY3Pos3, BCY3Pos4, BCY3Pos5, BCY3Pos6, BCY3Pos7,
        BCY4Pos1, BCY4Pos2, BCY4Pos3, BCY4Pos4, BCY4Pos5, BCY4Pos6, BCY4Pos7,
        BCO3Pos1, BCO3Pos2, BCO3Pos3, BCO3Pos4, BCO3Pos5, BCO3Pos6, BCO3Pos7, BCO3Pos8,
        BCM1Pos1, BCM1Pos2, BCM1Pos3, BCM1Pos4, BCM1Pos5, BCM1Pos6, BCM1Pos7, BCM1Pos8, BCM1Pos9, BCM1Pos10, BCM1Pos11, BCM1Pos12, BCM1Pos13, 
        BCI2Pos1, BCI2Pos2, BCI2Pos3, BCI2Pos4, BCI2Pos5,
        BCR2Pos1, BCR2Pos2, BCR2Pos3, BCR2Pos4, BCR2Pos5, BCR2Pos6, BCR2Pos7, BCR2Pos8, BCR2Pos9, BCR2Pos10, BCR2Pos11, BCR2Pos12, BCR2Pos13, BCR2Pos14, BCR2Pos15, BCR2Pos16,
        BCE1Pos1, BCE1Pos2, BCE1Pos3, BCE1Pos4, BCE1Pos5, BCE1Pos6, BCE1Pos7, BCE1Pos8, BCE1Pos9, BCE1Pos10, BCE1Pos11, BCE1Pos12, BCE1Pos13, BCE1Pos14, BCE1Pos15, BCE1Pos16, BCE1Pos17, 
        CoinBlockPosT1, CoinBlockPosT2, CoinBlockPosT3, CoinBlockPosT4, CoinBlockPosT5, CoinBlockPosT6, CoinBlockPosT7, CoinBlockPosT8, CoinBlockPosT9,
        CoinBlockPosH1, CoinBlockPosH2, CoinBlockPosH3, CoinBlockPosH4, CoinBlockPosH5, CoinBlockPosH6, CoinBlockPosH7, CoinBlockPosH8, CoinBlockPosH9, CoinBlockPosH10, CoinBlockPosH11, CoinBlockPosH12, CoinBlockPosH13,
        CoinBlockPosA1, CoinBlockPosA2, CoinBlockPosA3, CoinBlockPosA4, CoinBlockPosA5, CoinBlockPosA6, CoinBlockPosA7, CoinBlockPosA8, CoinBlockPosA9, CoinBlockPosA10, CoinBlockPosA11, CoinBlockPosA12,
        CoinBlockPosN1, CoinBlockPosN2, CoinBlockPosN3, CoinBlockPosN4, CoinBlockPosN5, CoinBlockPosN6, CoinBlockPosN7, CoinBlockPosN8, CoinBlockPosN9, CoinBlockPosN10, CoinBlockPosN11, CoinBlockPosN12, CoinBlockPosN13,
        CoinBlockPosK1, CoinBlockPosK2, CoinBlockPosK3, CoinBlockPosK4, CoinBlockPosK5, CoinBlockPosK6, CoinBlockPosK7, CoinBlockPosK8, CoinBlockPosK9, CoinBlockPosK10, CoinBlockPosK11, CoinBlockPosK12;
    public string flag;
    public int Number, DisableCount;
    void Start()
    {
        instance = this;
    }
    public void LevelOnEnableTGGB()
    {
        flag = "TGGB";
        DisableCount = 0;
    }
    public void LevelOnEnableLeaf()
    {
        flag = "Leaf";
        DisableCount = 0;
    }
    public void LevelOnEnableMix1()
    {
        flag = "Mix1";
        DisableCount = 0;
    }
    public void LevelOnEnableLock()
    {
        flag = "Lock";
        DisableCount = 0;
    }
    public void LevelOnEnableMix2()
    {
        flag = "Mix2";
        DisableCount = 0;
    }
    public void LevelOnEnableSkyMix()
    {
        flag = "SkyMix";
        DisableCount = 0;
    }
    public void LevelOnEnableMix3()
    {
        flag = "Mix3";
        DisableCount = 0;
    }
    public void LevelOnEnableBonus()
    {
        flag = "Bonus";
        DisableCount = 0;
        Number = 0;
    }
    public void LevelOnEnableBonusBlock()
    {
        flag = "BonusBlock";
        DisableCount = 0;
        Number = 0;
    }

    public void RandomMethod()
    {
        if(flag == "TGGB")
        {
            Number = Random.Range(1, 6);
            if(DisableCount >= 20)
            {
                this.gameObject.SetActive(false);
            }
        }
        if (flag == "Leaf")
        {
            Number = Random.Range(1, 5);
            if (DisableCount >= 40)
            {
                this.gameObject.SetActive(false);
            }
        }
        if (flag == "Mix1")
        {
            Number = Random.Range(1, 7);
            if (DisableCount >= 20)
            {
                this.gameObject.SetActive(false);
            }
        }
        if (flag == "Lock")
        {
            Number = Random.Range(1, 7);
            if (DisableCount >= 20)
            {
                this.gameObject.SetActive(false);
            }
        }
        if (flag == "Mix2")
        {
            Number = Random.Range(1, 11);
            if (DisableCount >= 40)
            {
                this.gameObject.SetActive(false);
            }
        }
        if (flag == "SkyMix")
        {
            Number = Random.Range(1, 9);
            if (DisableCount >= 20)
            {
                this.gameObject.SetActive(false);
            }
        }
        if (flag == "Mix3")
        {
            Number = Random.Range(1, 15);
            if (DisableCount >= 80)
            {
                this.gameObject.SetActive(false);
            }
        }
        if (flag == "Bonus")
        {
            Number++;
            if (Number >= 28)
            {
                this.gameObject.SetActive(false);
            }
        }
        if (flag == "BonusBlock")
        {
            Number++;
            if (Number >= 10)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
    public void ChoiceMethod() 
    {
        if(flag == "TGGB")
        {
            if (Number == 1)
            {
                TerrorNearGenerate();
            }
            if (Number == 2)
            {
                TGGBGenerateUpOnly();
                TerrorNearGenerate();
            }
            if (Number == 3)
            {
                TGGBGenerateUp();
                TGGBGenerateDown();
            }
            if (Number == 4)
            {
                BatGenerateLeft();
                BatGenerateRight();
            }
            if (Number == 5)
            {
                BatGenerateLeft();
                TerrorNearGenerate();
            }
        }
        if (flag == "Leaf")
        {
            if (Number == 1)
            {
                TerrorNearGenerate();
            }
            if (Number == 2)
            {
                LeafGenerate1();
                LeafGenerate2();
                LeafGenerate3();
                BlockSetGenerate();
            }
            if (Number == 3)
            {
                LeafGenerate1();
                LeafGenerate1();
                LeafGenerate2();
                LeafGenerate3();
                LeafGenerate1();
                LeafGenerate2();
                LeafGenerate3();
                LockBlock2Generate();
            }
            if (Number == 4)
            {
                LeafGenerate2();
                LeafGenerate3();
                LeafGenerate1();
                LeafGenerate2();
                LeafGenerate3();
                LeafGenerate1();
                LeafGenerate2();
                LeafGenerate3();
                LeafGenerate1();
                LeafGenerate2();
                LeafGenerate3();
                BatGenerateLeft();
                BatGenerateRight();
                TGGBGenerateUp();
                TGGBGenerateDown();
            }
        }
        if (flag == "Mix1")
        {
            if (Number == 1)
            {
                TerrorNearGenerate();
            }
            if (Number == 2)
            {
                TGGBGenerateUpOnly();
            }
            if (Number == 3)
            {
                TGGBGenerateUp();
                TGGBGenerateDown();
            }
            if (Number == 4)
            {
                BlockSetGenerate();
            }
            if (Number == 5)
            {
                BlockGenerate();
            }
        }
        if (flag == "Lock")
        {
            if (Number == 2)
            {
                LockBombGenerate();
            }
            if (Number == 3)
            {
                LockWallGenerate();
            }
            if (Number == 4)
            {
                LockBlock1Generate();
            }
            if (Number == 5)
            {
                LockBlock2Generate();
            }
        }
        if (flag == "Mix2")
        {
            if (Number == 1)
            {
                TerrorNearGenerate();
            }
            if (Number == 2)
            {
                LockBombGenerate();
            }
            if (Number == 3)
            {
                LockWallGenerate();
            }
            if (Number == 4)
            {
                LockBlock1Generate();
            }
            if (Number == 5)
            {
                LockBlock2Generate();
            }
            if (Number == 6)
            {
                BatGenerateLeft();
                BatGenerateRight();
            }
            if (Number == 7)
            {
                LeafGenerate1();
                LeafGenerate2();
                LeafGenerate3();
            }
            if (Number == 8)
            {
                LeafGenerate1();
            }
            if (Number == 9)
            {
                LeafGenerate2();
                LeafGenerate3();
            }
        }
        if (flag == "SkyMix")
        {
            if (Number == 2)
            {
                TGGBGenerateDown();
            }
            if (Number == 3)
            {
                TGGBGenerateUp();
            }
            if (Number == 4)
            {
                BatGenerateRight();
            }
            if (Number == 5)
            {
                BatGenerateLeft();
            }
            if (Number == 6)
            {
                TerrorNearGenerate();
            }
        }
        if (flag == "Mix3")
        {
            if (Number == 2)
            {
                TGGBGenerateUpOnly();
            }
            if (Number == 3)
            {
                TGGBGenerateUp();
                TGGBGenerateDown();
            }
            if (Number == 4)
            {
                BlockSetGenerate();
            }
            if (Number == 5)
            {
                BlockGenerate();
            }
            if (Number == 6)
            {
                HammerBlockGenerate();
            }
            if (Number == 7)
            {
                HBlockSetGenerate();
            }
            if (Number == 8)
            {
                LeafGenerate1();
                LeafGenerate2();
            }
            if (Number == 9)
            {
                LeafGenerate2();
                LeafGenerate3();
            }
            if (Number == 10)
            {
                LockWallGenerate();
            }
            if (Number == 11)
            {
                LockBlock1Generate();
            }
            if (Number == 12)
            {
                LockBlock2Generate();
            }
            if (Number == 13)
            {
                CoinBlockGenerate();
            }
        }
        if (flag == "Bonus")
        {
            if (Number == 1)
            {
                BonusCoinT1Method1();
                BonusCoinT1Method2();
                BonusCoinT1Method3();
                BonusCoinT1Method4();
                BonusCoinT1Method5();
                BonusCoinT1Method6();
                BonusCoinT1Method7();
                BonusCoinT1Method8();
                BonusCoinT1Method9();
            }
            if (Number == 2)
            {
                BonusCoinH1Method1();
                BonusCoinH1Method2();
                BonusCoinH1Method3();
                BonusCoinH1Method4();
                BonusCoinH1Method5();
                BonusCoinH1Method6();
                BonusCoinH1Method7();
                BonusCoinH1Method8();
                BonusCoinH1Method9();
                BonusCoinH1Method10();
                BonusCoinH1Method11();
                BonusCoinH1Method12();
                BonusCoinH1Method13();
            }
            if (Number == 3)
            {
                BonusCoinA1Method1();
                BonusCoinA1Method2();
                BonusCoinA1Method3();
                BonusCoinA1Method4();
                BonusCoinA1Method5();
                BonusCoinA1Method6();
                BonusCoinA1Method7();
                BonusCoinA1Method8();
                BonusCoinA1Method9();
                BonusCoinA1Method10();
                BonusCoinA1Method11();
                BonusCoinA1Method12();
            }
            if (Number == 4)
            {
                BonusCoinN1Method1();
                BonusCoinN1Method2();
                BonusCoinN1Method3();
                BonusCoinN1Method4();
                BonusCoinN1Method5();
                BonusCoinN1Method6();
                BonusCoinN1Method7();
                BonusCoinN1Method8();
                BonusCoinN1Method9();
                BonusCoinN1Method10();
                BonusCoinN1Method11();
                BonusCoinN1Method12();
                BonusCoinN1Method13();
            }
            if (Number == 5)
            {
                BonusCoinK1Method1();
                BonusCoinK1Method2();
                BonusCoinK1Method3();
                BonusCoinK1Method4();
                BonusCoinK1Method5();
                BonusCoinK1Method6();
                BonusCoinK1Method7();
                BonusCoinK1Method8();
                BonusCoinK1Method9();
                BonusCoinK1Method10();
                BonusCoinK1Method11();
                BonusCoinK1Method12();
            }
            if (Number == 6)
            {
                BonusCoinY1Method1();
                BonusCoinY1Method2();
                BonusCoinY1Method3();
                BonusCoinY1Method4();
                BonusCoinY1Method5();
                BonusCoinY1Method6();
                BonusCoinY1Method7();
            }
            if (Number == 7)
            {
                BonusCoinO1Method1();
                BonusCoinO1Method2();
                BonusCoinO1Method3();
                BonusCoinO1Method4();
                BonusCoinO1Method5();
                BonusCoinO1Method6();
                BonusCoinO1Method7();
                BonusCoinO1Method8();
            }
            if (Number == 8)
            {
                BonusCoinU1Method1();
                BonusCoinU1Method2();
                BonusCoinU1Method3();
                BonusCoinU1Method4();
                BonusCoinU1Method5();
                BonusCoinU1Method6();
                BonusCoinU1Method7();
                BonusCoinU1Method8();
                BonusCoinU1Method9();
            }
            if (Number == 9)
            {
                BonusCoinF1Method1();
                BonusCoinF1Method2();
                BonusCoinF1Method3();
                BonusCoinF1Method4();
                BonusCoinF1Method5();
                BonusCoinF1Method6();
                BonusCoinF1Method7();
                BonusCoinF1Method8();
                BonusCoinF1Method9();
                BonusCoinF1Method10();
                BonusCoinF1Method11();
                BonusCoinF1Method12();
            }
            if (Number == 10)
            {
                BonusCoinO2Method1();
                BonusCoinO2Method2();
                BonusCoinO2Method3();
                BonusCoinO2Method4();
                BonusCoinO2Method5();
                BonusCoinO2Method6();
                BonusCoinO2Method7();
                BonusCoinO2Method8();
            }
            if (Number == 11)
            {
                BonusCoinR1Method1();
                BonusCoinR1Method2();
                BonusCoinR1Method3();
                BonusCoinR1Method4();
                BonusCoinR1Method5();
                BonusCoinR1Method6();
                BonusCoinR1Method7();
                BonusCoinR1Method8();
                BonusCoinR1Method9();
                BonusCoinR1Method10();
                BonusCoinR1Method11();
                BonusCoinR1Method12();
                BonusCoinR1Method13();
                BonusCoinR1Method14();
                BonusCoinR1Method15();
                BonusCoinR1Method16();
            }
            if (Number == 12)
            {
                BonusCoinP1Method1();
                BonusCoinP1Method2();
                BonusCoinP1Method3();
                BonusCoinP1Method4();
                BonusCoinP1Method5();
                BonusCoinP1Method6();
                BonusCoinP1Method7();
                BonusCoinP1Method8();
                BonusCoinP1Method9();
                BonusCoinP1Method10();
                BonusCoinP1Method11();
                BonusCoinP1Method12();
                BonusCoinP1Method13();
                BonusCoinP1Method14();
            }
            if (Number == 13)
            {
                BonusCoinL1Method1();
                BonusCoinL1Method2();
                BonusCoinL1Method3();
                BonusCoinL1Method4();
                BonusCoinL1Method5();
                BonusCoinL1Method6();
                BonusCoinL1Method7();
                BonusCoinL1Method8();
                BonusCoinL1Method9();
            }
            if (Number == 14)
            {
                BonusCoinA2Method1();
                BonusCoinA2Method2();
                BonusCoinA2Method3();
                BonusCoinA2Method4();
                BonusCoinA2Method5();
                BonusCoinA2Method6();
                BonusCoinA2Method7();
                BonusCoinA2Method8();
                BonusCoinA2Method9();
                BonusCoinA2Method10();
                BonusCoinA2Method11();
                BonusCoinA2Method12();
            }
            if (Number == 15)
            {
                BonusCoinY2Method1();
                BonusCoinY2Method2();
                BonusCoinY2Method3();
                BonusCoinY2Method4();
                BonusCoinY2Method5();
                BonusCoinY2Method6();
                BonusCoinY2Method7();
            }
            if (Number == 16)
            {
                BonusCoinI1Method1();
                BonusCoinI1Method2();
                BonusCoinI1Method3();
                BonusCoinI1Method4();
                BonusCoinI1Method5();
            }
            if (Number == 17)
            {
                BonusCoinN2Method1();
                BonusCoinN2Method2();
                BonusCoinN2Method3();
                BonusCoinN2Method4();
                BonusCoinN2Method5();
                BonusCoinN2Method6();
                BonusCoinN2Method7();
                BonusCoinN2Method8();
                BonusCoinN2Method9();
                BonusCoinN2Method10();
                BonusCoinN2Method11();
                BonusCoinN2Method12();
                BonusCoinN2Method13();
            }
            if (Number == 18)
            {
                BonusCoinG1Method1();
                BonusCoinG1Method2();
                BonusCoinG1Method3();
                BonusCoinG1Method4();
                BonusCoinG1Method5();
                BonusCoinG1Method6();
                BonusCoinG1Method7();
                BonusCoinG1Method8();
                BonusCoinG1Method9();
                BonusCoinG1Method10();
                BonusCoinG1Method11();
            }
            if (Number == 19)
            {
                BonusCoinPeriodMethod();
            }
            if (Number == 20)
            {
                BonusCoinB1Method1();
                BonusCoinB1Method2();
                BonusCoinB1Method3();
                BonusCoinB1Method4();
                BonusCoinB1Method5();
                BonusCoinB1Method6();
                BonusCoinB1Method7();
                BonusCoinB1Method8();
                BonusCoinB1Method9();
                BonusCoinB1Method10();
                BonusCoinB1Method11();
                BonusCoinB1Method12();
                BonusCoinB1Method13();
                BonusCoinB1Method14();
                BonusCoinB1Method15();
                BonusCoinB1Method16();
            }
            if (Number == 21)
            {
                BonusCoinY3Method1();
                BonusCoinY3Method2();
                BonusCoinY3Method3();
                BonusCoinY3Method4();
                BonusCoinY3Method5();
                BonusCoinY3Method6();
                BonusCoinY3Method7();
            }
            if (Number == 22)
            {
                BonusCoinY4Method1();
                BonusCoinY4Method2();
                BonusCoinY4Method3();
                BonusCoinY4Method4();
                BonusCoinY4Method5();
                BonusCoinY4Method6();
                BonusCoinY4Method7();
            }
            if (Number == 23)
            {
                BonusCoinO3Method1();
                BonusCoinO3Method2();
                BonusCoinO3Method3();
                BonusCoinO3Method4();
                BonusCoinO3Method5();
                BonusCoinO3Method6();
                BonusCoinO3Method7();
                BonusCoinO3Method8();
            }
            if (Number == 24)
            {
                BonusCoinM1Method1();
                BonusCoinM1Method2();
                BonusCoinM1Method3();
                BonusCoinM1Method4();
                BonusCoinM1Method5();
                BonusCoinM1Method6();
                BonusCoinM1Method7();
                BonusCoinM1Method8();
                BonusCoinM1Method9();
                BonusCoinM1Method10();
                BonusCoinM1Method11();
                BonusCoinM1Method12();
                BonusCoinM1Method13();
            }
            if (Number == 25)
            {
                BonusCoinI2Method1();
                BonusCoinI2Method2();
                BonusCoinI2Method3();
                BonusCoinI2Method4();
                BonusCoinI2Method5();
            }
            if (Number == 26)
            {
                BonusCoinR2Method1();
                BonusCoinR2Method2();
                BonusCoinR2Method3();
                BonusCoinR2Method4();
                BonusCoinR2Method5();
                BonusCoinR2Method6();
                BonusCoinR2Method7();
                BonusCoinR2Method8();
                BonusCoinR2Method9();
                BonusCoinR2Method10();
                BonusCoinR2Method11();
                BonusCoinR2Method12();
                BonusCoinR2Method13();
                BonusCoinR2Method14();
                BonusCoinR2Method15();
                BonusCoinR2Method16();
            }
            if (Number == 27)
            {
                BonusCoinE1Method1();
                BonusCoinE1Method2();
                BonusCoinE1Method3();
                BonusCoinE1Method4();
                BonusCoinE1Method5();
                BonusCoinE1Method6();
                BonusCoinE1Method7();
                BonusCoinE1Method8();
                BonusCoinE1Method9();
                BonusCoinE1Method10();
                BonusCoinE1Method11();
                BonusCoinE1Method12();
                BonusCoinE1Method13();
                BonusCoinE1Method14();
                BonusCoinE1Method15();
                BonusCoinE1Method16();
                BonusCoinE1Method17();
            }            
        }
        if (flag == "BonusBlock")
        {
            if (Number == 1)
            {
                //Debug.Log("test");
                BonusCoinBlockMethodT1();
                BonusCoinBlockMethodT2();
                BonusCoinBlockMethodT3();
                BonusCoinBlockMethodT4();
                BonusCoinBlockMethodT5();
                BonusCoinBlockMethodT6();
                BonusCoinBlockMethodT7();
                BonusCoinBlockMethodT8();
                BonusCoinBlockMethodT9();
            }
            if (Number == 2)
            {
                BonusCoinBlockMethodH1();
                BonusCoinBlockMethodH2();
                BonusCoinBlockMethodH3();
                BonusCoinBlockMethodH4();
                BonusCoinBlockMethodH5();
                BonusCoinBlockMethodH6();
                BonusCoinBlockMethodH7();
                BonusCoinBlockMethodH8();
                BonusCoinBlockMethodH9();
                BonusCoinBlockMethodH10();
                BonusCoinBlockMethodH11();
                BonusCoinBlockMethodH12();
                BonusCoinBlockMethodH13();
            }
            if (Number == 3)
            {
                BonusCoinBlockMethodA1();
                BonusCoinBlockMethodA2();
                BonusCoinBlockMethodA3();
                BonusCoinBlockMethodA4();
                BonusCoinBlockMethodA5();
                BonusCoinBlockMethodA6();
                BonusCoinBlockMethodA7();
                BonusCoinBlockMethodA8();
                BonusCoinBlockMethodA9();
                BonusCoinBlockMethodA10();
                BonusCoinBlockMethodA11();
                BonusCoinBlockMethodA12();
            }
            if (Number == 4)
            {
                BonusCoinBlockMethodN1();
                BonusCoinBlockMethodN2();
                BonusCoinBlockMethodN3();
                BonusCoinBlockMethodN4();
                BonusCoinBlockMethodN5();
                BonusCoinBlockMethodN6();
                BonusCoinBlockMethodN7();
                BonusCoinBlockMethodN8();
                BonusCoinBlockMethodN9();
                BonusCoinBlockMethodN10();
                BonusCoinBlockMethodN11();
                BonusCoinBlockMethodN12();
                BonusCoinBlockMethodN13();
            }
            if (Number == 5)
            {
                BonusCoinBlockMethodK1();
                BonusCoinBlockMethodK2();
                BonusCoinBlockMethodK3();
                BonusCoinBlockMethodK4();
                BonusCoinBlockMethodK5();
                BonusCoinBlockMethodK6();
                BonusCoinBlockMethodK7();
                BonusCoinBlockMethodK8();
                BonusCoinBlockMethodK9();
                BonusCoinBlockMethodK10();
                BonusCoinBlockMethodK11();
                BonusCoinBlockMethodK12();
            }
            if (Number == 6)
            {
                BonusCoinBlockMethodY1();
                BonusCoinBlockMethodY2();
                BonusCoinBlockMethodY3();
                BonusCoinBlockMethodY4();
                BonusCoinBlockMethodY5();
                BonusCoinBlockMethodY6();
                BonusCoinBlockMethodY7();
            }
            if (Number == 7)
            {
                BonusCoinBlockMethodO1();
                BonusCoinBlockMethodO2();
                BonusCoinBlockMethodO3();
                BonusCoinBlockMethodO4();
                BonusCoinBlockMethodO5();
                BonusCoinBlockMethodO6();
                BonusCoinBlockMethodO7();
                BonusCoinBlockMethodO8();
            }
            if (Number == 8)
            {
                BonusCoinBlockMethodU1();
                BonusCoinBlockMethodU2();
                BonusCoinBlockMethodU3();
                BonusCoinBlockMethodU4();
                BonusCoinBlockMethodU5();
                BonusCoinBlockMethodU6();
                BonusCoinBlockMethodU7();
                BonusCoinBlockMethodU8();
                BonusCoinBlockMethodU9();
            }
        }
    }

    public void DisableCountMethod()
    {
        DisableCount++;
    }

    public void TGGBGenerateUp()
    {
        GameObject obj = ObjectPooler6.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = new Vector2(Random.Range(PosXLow, PosXHigh), Random.Range(0, High));
        obj.SetActive(true);
    }
    public void TGGBGenerateDown()
    {
        GameObject obj = ObjectPooler7.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = new Vector2(Random.Range(PosXLow, PosXHigh), Random.Range(Low, 1));
        obj.SetActive(true);
    }
    public void TGGBGenerateUpOnly()
    {
        GameObject obj = ObjectPooler6.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = new Vector2(Random.Range(PosXLow, PosXHigh), Random.Range(Low, High));
        obj.SetActive(true);
    }
    public void LeafGenerate1()
    {
        GameObject obj = ObjectPooler51.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = new Vector2(Random.Range(11, 17), Random.Range(1, 10));
        obj.SetActive(true);
    }
    public void LeafGenerate2()
    {
        GameObject obj = ObjectPooler52.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = new Vector2(Random.Range(11, 17), Random.Range(1, 10));
        obj.SetActive(true);
    }
    public void LeafGenerate3()
    {
        GameObject obj = ObjectPooler53.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = new Vector2(Random.Range(11, 17), Random.Range(1, 10));
        obj.SetActive(true);
    }
    public void BlockGenerate()
    {
        GameObject obj = ObjectPooler54.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = new Vector2(PosXLow, Random.Range(-3.5f, 1));
        obj.SetActive(true);
    }
    public void BlockSetGenerate()
    {
        HBlockPosSetObj.transform.position = new Vector2(PosXLow, Random.Range(-3.5f, 1));
        Invoke("BlockGenerate1", 0.01f);
        Invoke("BlockGenerate2", 0.01f);
        Invoke("BlockGenerate3", 0.01f);
        Invoke("BlockGenerate4", 0.01f);
        Invoke("BlockGenerate5", 0.01f);
        Invoke("BlockGenerate6", 0.01f);
        Invoke("BlockGenerate7", 0.01f);
        Invoke("BlockGenerate8", 0.01f);
        Invoke("BlockGenerate9", 0.01f);
        Invoke("BlockGenerate10", 0.01f);
        Invoke("BlockGenerate11", 0.01f);
        Invoke("BlockGenerate12", 0.01f);
    }
    public void BlockGenerate1()
    {
        GameObject obj = ObjectPooler54.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = HBlockPosSetObj.transform.position;
        obj.SetActive(true);
    }
    public void BlockGenerate2()
    {
        GameObject obj = ObjectPooler54.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = HBlockPosObj1.transform.position;
        obj.SetActive(true);
    }
    public void BlockGenerate3()
    {
        GameObject obj = ObjectPooler54.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = HBlockPosObj2.transform.position;
        obj.SetActive(true);
    }
    public void BlockGenerate4()
    {
        GameObject obj = ObjectPooler54.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = HBlockPosObj3.transform.position;
        obj.SetActive(true);
    }
    public void BlockGenerate5()
    {
        GameObject obj = ObjectPooler54.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = HBlockPosObj4.transform.position;
        obj.SetActive(true);
    }
    public void BlockGenerate6()
    {
        GameObject obj = ObjectPooler54.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = HBlockPosObj5.transform.position;
        obj.SetActive(true);
    }
    public void BlockGenerate7()
    {
        GameObject obj = ObjectPooler54.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = HBlockPosObj6.transform.position;
        obj.SetActive(true);
    }
    public void BlockGenerate8()
    {
        GameObject obj = ObjectPooler54.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = HBlockPosObj7.transform.position;
        obj.SetActive(true);
    }
    public void BlockGenerate9()
    {
        GameObject obj = ObjectPooler54.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = HBlockPosObj8.transform.position;
        obj.SetActive(true);
    }
    public void BlockGenerate10()
    {
        GameObject obj = ObjectPooler54.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = HBlockPosObj9.transform.position;
        obj.SetActive(true);
    }
    public void BlockGenerate11()
    {
        GameObject obj = ObjectPooler54.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = HBlockPosObj10.transform.position;
        obj.SetActive(true);
    }
    public void BlockGenerate12()
    {
        GameObject obj = ObjectPooler54.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = HBlockPosObj11.transform.position;
        obj.SetActive(true);
    }
    public void HammerBlockGenerate()
    {
        GameObject obj = ObjectPooler55.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = new Vector2(PosXLow, Random.Range(-3.5f, 1));
        obj.SetActive(true);
    }
    public void HBlockSetGenerate()
    {
        HBlockPosSetObj.transform.position = new Vector2(PosXLow, Random.Range(-3.5f, 1));
        Invoke("HBlockGenerate1", 0.01f);
        Invoke("HBlockGenerate2", 0.01f);
        Invoke("HBlockGenerate3", 0.01f);
        Invoke("HBlockGenerate4", 0.01f);
        Invoke("HBlockGenerate5", 0.01f);
        Invoke("HBlockGenerate6", 0.01f);
        Invoke("HBlockGenerate7", 0.01f);
        Invoke("HBlockGenerate8", 0.01f);
        Invoke("HBlockGenerate9", 0.01f);
        Invoke("HBlockGenerate10", 0.01f);
        Invoke("HBlockGenerate11", 0.01f);
        Invoke("HBlockGenerate12", 0.01f);
    }
    public void HBlockGenerate1()
    {
        GameObject obj = ObjectPooler55.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = HBlockPosSetObj.transform.position;
        obj.SetActive(true);
    }
    public void HBlockGenerate2()
    {
        GameObject obj = ObjectPooler55.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = HBlockPosObj1.transform.position;
        obj.SetActive(true);
    }
    public void HBlockGenerate3()
    {
        GameObject obj = ObjectPooler55.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = HBlockPosObj2.transform.position;
        obj.SetActive(true);
    }
    public void HBlockGenerate4()
    {
        GameObject obj = ObjectPooler55.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = HBlockPosObj3.transform.position;
        obj.SetActive(true);
    }
    public void HBlockGenerate5()
    {
        GameObject obj = ObjectPooler55.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = HBlockPosObj4.transform.position;
        obj.SetActive(true);
    }
    public void HBlockGenerate6()
    {
        GameObject obj = ObjectPooler55.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = HBlockPosObj5.transform.position;
        obj.SetActive(true);
    }
    public void HBlockGenerate7()
    {
        GameObject obj = ObjectPooler55.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = HBlockPosObj6.transform.position;
        obj.SetActive(true);
    }
    public void HBlockGenerate8()
    {
        GameObject obj = ObjectPooler55.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = HBlockPosObj7.transform.position;
        obj.SetActive(true);
    }
    public void HBlockGenerate9()
    {
        GameObject obj = ObjectPooler55.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = HBlockPosObj8.transform.position;
        obj.SetActive(true);
    }
    public void HBlockGenerate10()
    {
        GameObject obj = ObjectPooler55.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = HBlockPosObj9.transform.position;
        obj.SetActive(true);
    }
    public void HBlockGenerate11()
    {
        GameObject obj = ObjectPooler55.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = HBlockPosObj10.transform.position;
        obj.SetActive(true);
    }
    public void HBlockGenerate12()
    {
        GameObject obj = ObjectPooler55.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = HBlockPosObj11.transform.position;
        obj.SetActive(true);
    }
    public void CoinBlockGenerate()
    {
        GameObject obj = ObjectPooler56.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = new Vector2(PosXLow, Random.Range(-3.5f, 1));
        obj.SetActive(true);
    }
    public void LockBombGenerate()
    {
        //LockBombScript.instance.RendTrueMethod();
        //Invoke("LockRendMethod", 0.1f);
        GameObject obj = ObjectPooler8.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = new Vector2(PosXLow, -3.5f);
        obj.SetActive(true);
    }
    /*
    public void LockRendMethod()
    {
        LockBombScript.instance.RendTrueMethod();
    }
    */
    public void LockWallGenerate()
    {        
        GameObject obj = ObjectPooler9.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = new Vector2(PosXLow, Random.Range(-1.5f, 1));
        obj.SetActive(true);
    }
    public void LockBlock1Generate()
    {
        GameObject obj = ObjectPooler23.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = new Vector2(20, Random.Range(-3, 4));
        obj.SetActive(true);
    }
    public void LockBlock2Generate()
    {
        GameObject obj = ObjectPooler24.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = new Vector2(20, Random.Range(-3, 4));
        obj.SetActive(true);
    }
    public void BatGenerateRight()
    {
        GameObject obj = ObjectPooler11.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = new Vector2(20, Random.Range(-3, 12));
        obj.SetActive(true);
    }
    public void BatGenerateLeft()
    {
        GameObject obj = ObjectPooler11.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = new Vector2(-20, Random.Range(-3, 12));
        obj.SetActive(true);
    }
    public void TerrorNearGenerate()
    {
        GameObject obj = ObjectPooler10.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = new Vector2(18, Random.Range(-3, 3));
        obj.SetActive(true);
    }


    public void BonusCoinT1Method1()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCT1Pos1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinT1Method2()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCT1Pos2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinT1Method3()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCT1Pos3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinT1Method4()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCT1Pos4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinT1Method5()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCT1Pos5.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinT1Method6()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCT1Pos6.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinT1Method7()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCT1Pos7.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinT1Method8()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCT1Pos8.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinT1Method9()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCT1Pos9.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinH1Method1()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCH1Pos1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinH1Method2()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCH1Pos2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinH1Method3()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCH1Pos3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinH1Method4()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCH1Pos4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinH1Method5()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCH1Pos5.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinH1Method6()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCH1Pos6.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinH1Method7()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCH1Pos7.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinH1Method8()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCH1Pos8.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinH1Method9()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCH1Pos9.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinH1Method10()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCH1Pos10.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinH1Method11()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCH1Pos11.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinH1Method12()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCH1Pos12.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinH1Method13()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCH1Pos13.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinA1Method1()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCA1Pos1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinA1Method2()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCA1Pos2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinA1Method3()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCA1Pos3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinA1Method4()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCA1Pos4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinA1Method5()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCA1Pos5.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinA1Method6()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCA1Pos6.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinA1Method7()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCA1Pos7.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinA1Method8()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCA1Pos8.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinA1Method9()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCA1Pos9.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinA1Method10()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCA1Pos10.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinA1Method11()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCA1Pos11.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinA1Method12()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCA1Pos12.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinN1Method1()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCN1Pos1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinN1Method2()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCN1Pos2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinN1Method3()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCN1Pos3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinN1Method4()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCN1Pos4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinN1Method5()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCN1Pos5.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinN1Method6()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCN1Pos6.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinN1Method7()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCN1Pos7.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinN1Method8()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCN1Pos8.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinN1Method9()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCN1Pos9.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinN1Method10()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCN1Pos10.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinN1Method11()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCN1Pos11.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinN1Method12()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCN1Pos12.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinN1Method13()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCN1Pos13.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinK1Method1()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCK1Pos1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinK1Method2()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCK1Pos2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinK1Method3()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCK1Pos3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinK1Method4()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCK1Pos4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinK1Method5()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCK1Pos5.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinK1Method6()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCK1Pos6.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinK1Method7()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCK1Pos7.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinK1Method8()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCK1Pos8.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinK1Method9()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCK1Pos9.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinK1Method10()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCK1Pos10.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinK1Method11()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCK1Pos11.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinK1Method12()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCK1Pos12.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinY1Method1()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY1Pos1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinY1Method2()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY1Pos2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinY1Method3()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY1Pos3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinY1Method4()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY1Pos4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinY1Method5()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY1Pos5.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinY1Method6()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY1Pos6.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinY1Method7()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY1Pos7.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinO1Method1()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCO1Pos1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinO1Method2()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCO1Pos2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinO1Method3()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCO1Pos3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinO1Method4()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCO1Pos4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinO1Method5()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCO1Pos5.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinO1Method6()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCO1Pos6.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinO1Method7()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCO1Pos7.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinO1Method8()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCO1Pos8.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinU1Method1()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCU1Pos1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinU1Method2()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCU1Pos2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinU1Method3()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCU1Pos3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinU1Method4()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCU1Pos4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinU1Method5()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCU1Pos5.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinU1Method6()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCU1Pos6.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinU1Method7()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCU1Pos7.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinU1Method8()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCU1Pos8.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinU1Method9()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCU1Pos9.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinF1Method1()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCF1Pos1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinF1Method2()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCF1Pos2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinF1Method3()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCF1Pos3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinF1Method4()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCF1Pos4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinF1Method5()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCF1Pos5.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinF1Method6()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCF1Pos6.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinF1Method7()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCF1Pos7.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinF1Method8()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCF1Pos8.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinF1Method9()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCF1Pos9.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinF1Method10()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCF1Pos10.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinF1Method11()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCF1Pos11.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinF1Method12()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCF1Pos12.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinO2Method1()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCO2Pos1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinO2Method2()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCO2Pos2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinO2Method3()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCO2Pos3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinO2Method4()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCO2Pos4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinO2Method5()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCO2Pos5.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinO2Method6()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCO2Pos6.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinO2Method7()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCO2Pos7.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinO2Method8()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCO2Pos8.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinR1Method1()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCR1Pos1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinR1Method2()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCR1Pos2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinR1Method3()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCR1Pos3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinR1Method4()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCR1Pos4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinR1Method5()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCR1Pos5.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinR1Method6()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCR1Pos6.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinR1Method7()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCR1Pos7.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinR1Method8()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCR1Pos8.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinR1Method9()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCR1Pos9.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinR1Method10()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCR1Pos10.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinR1Method11()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCR1Pos11.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinR1Method12()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCR1Pos12.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinR1Method13()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCR1Pos13.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinR1Method14()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCR1Pos14.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinR1Method15()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCR1Pos15.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinR1Method16()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCR1Pos16.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinP1Method1()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCP1Pos1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinP1Method2()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCP1Pos2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinP1Method3()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCP1Pos3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinP1Method4()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCP1Pos4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinP1Method5()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCP1Pos5.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinP1Method6()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCP1Pos6.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinP1Method7()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCP1Pos7.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinP1Method8()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCP1Pos8.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinP1Method9()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCP1Pos9.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinP1Method10()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCP1Pos10.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinP1Method11()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCP1Pos11.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinP1Method12()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCP1Pos12.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinP1Method13()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCP1Pos13.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinP1Method14()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCP1Pos14.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinL1Method1()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCL1Pos1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinL1Method2()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCL1Pos2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinL1Method3()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCL1Pos3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinL1Method4()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCL1Pos4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinL1Method5()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCL1Pos5.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinL1Method6()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCL1Pos6.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinL1Method7()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCL1Pos7.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinL1Method8()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCL1Pos8.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinL1Method9()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCL1Pos9.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinA2Method1()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCA2Pos1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinA2Method2()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCA2Pos2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinA2Method3()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCA2Pos3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinA2Method4()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCA2Pos4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinA2Method5()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCA2Pos5.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinA2Method6()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCA2Pos6.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinA2Method7()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCA2Pos7.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinA2Method8()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCA2Pos8.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinA2Method9()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCA2Pos9.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinA2Method10()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCA2Pos10.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinA2Method11()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCA2Pos11.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinA2Method12()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCA2Pos12.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinY2Method1()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY2Pos1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinY2Method2()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY2Pos2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinY2Method3()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY2Pos3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinY2Method4()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY2Pos4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinY2Method5()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY2Pos5.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinY2Method6()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY2Pos6.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinY2Method7()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY2Pos7.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinI1Method1()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCI1Pos1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinI1Method2()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCI1Pos2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinI1Method3()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCI1Pos3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinI1Method4()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCI1Pos4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinI1Method5()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCI1Pos5.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinN2Method1()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCN2Pos1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinN2Method2()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCN2Pos2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinN2Method3()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCN2Pos3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinN2Method4()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCN2Pos4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinN2Method5()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCN2Pos5.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinN2Method6()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCN2Pos6.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinN2Method7()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCN2Pos7.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinN2Method8()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCN2Pos8.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinN2Method9()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCN2Pos9.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinN2Method10()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCN2Pos10.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinN2Method11()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCN2Pos11.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinN2Method12()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCN2Pos12.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinN2Method13()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCN2Pos13.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinG1Method1()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCG1Pos1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinG1Method2()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCG1Pos2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinG1Method3()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCG1Pos3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinG1Method4()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCG1Pos4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinG1Method5()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCG1Pos5.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinG1Method6()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCG1Pos6.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinG1Method7()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCG1Pos7.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinG1Method8()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCG1Pos8.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinG1Method9()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCG1Pos9.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinG1Method10()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCG1Pos10.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinG1Method11()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCG1Pos11.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinPeriodMethod()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCPeriodPos.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinB1Method1()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCB1Pos1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinB1Method2()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCB1Pos2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinB1Method3()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCB1Pos3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinB1Method4()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCB1Pos4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinB1Method5()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCB1Pos5.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinB1Method6()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCB1Pos6.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinB1Method7()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCB1Pos7.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinB1Method8()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCB1Pos8.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinB1Method9()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCB1Pos9.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinB1Method10()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCB1Pos10.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinB1Method11()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCB1Pos11.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinB1Method12()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCB1Pos12.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinB1Method13()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCB1Pos13.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinB1Method14()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCB1Pos14.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinB1Method15()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCB1Pos15.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinB1Method16()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCB1Pos16.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinY3Method1()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY3Pos1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinY3Method2()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY3Pos2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinY3Method3()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY3Pos3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinY3Method4()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY3Pos4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinY3Method5()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY3Pos5.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinY3Method6()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY3Pos6.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinY3Method7()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY3Pos7.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinY4Method1()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY4Pos1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinY4Method2()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY4Pos2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinY4Method3()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY4Pos3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinY4Method4()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY4Pos4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinY4Method5()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY4Pos5.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinY4Method6()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY4Pos6.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinY4Method7()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY4Pos7.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinO3Method1()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCO3Pos1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinO3Method2()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCO3Pos2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinO3Method3()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCO3Pos3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinO3Method4()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCO3Pos4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinO3Method5()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCO3Pos5.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinO3Method6()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCO3Pos6.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinO3Method7()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCO3Pos7.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinO3Method8()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCO3Pos8.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinM1Method1()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCM1Pos1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinM1Method2()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCM1Pos2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinM1Method3()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCM1Pos3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinM1Method4()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCM1Pos4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinM1Method5()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCM1Pos5.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinM1Method6()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCM1Pos6.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinM1Method7()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCM1Pos7.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinM1Method8()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCM1Pos8.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinM1Method9()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCM1Pos9.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinM1Method10()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCM1Pos10.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinM1Method11()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCM1Pos11.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinM1Method12()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCM1Pos12.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinM1Method13()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCM1Pos13.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinI2Method1()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCI2Pos1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinI2Method2()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCI2Pos2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinI2Method3()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCI2Pos3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinI2Method4()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCI2Pos4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinI2Method5()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCI2Pos5.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinR2Method1()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCR2Pos1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinR2Method2()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCR2Pos2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinR2Method3()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCR2Pos3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinR2Method4()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCR2Pos4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinR2Method5()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCR2Pos5.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinR2Method6()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCR2Pos6.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinR2Method7()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCR2Pos7.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinR2Method8()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCR2Pos8.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinR2Method9()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCR2Pos9.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinR2Method10()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCR2Pos10.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinR2Method11()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCR2Pos11.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinR2Method12()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCR2Pos12.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinR2Method13()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCR2Pos13.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinR2Method14()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCR2Pos14.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinR2Method15()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCR2Pos15.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinR2Method16()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCR2Pos16.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinE1Method1()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCE1Pos1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinE1Method2()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCE1Pos2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinE1Method3()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCE1Pos3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinE1Method4()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCE1Pos4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinE1Method5()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCE1Pos5.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinE1Method6()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCE1Pos6.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinE1Method7()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCE1Pos7.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinE1Method8()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCE1Pos8.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinE1Method9()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCE1Pos9.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinE1Method10()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCE1Pos10.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinE1Method11()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCE1Pos11.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinE1Method12()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCE1Pos12.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinE1Method13()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCE1Pos13.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinE1Method14()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCE1Pos14.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinE1Method15()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCE1Pos15.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinE1Method16()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCE1Pos16.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinE1Method17()
    {
        GameObject obj = ObjectPooler25.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCE1Pos17.transform.position;
        obj.SetActive(true);
    }


    public void BonusCoinBlockMethodT1()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosT1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodT2()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosT2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodT3()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosT3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodT4()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosT4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodT5()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosT5.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodT6()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosT6.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodT7()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosT7.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodT8()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosT8.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodT9()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosT9.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinBlockMethodH1()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosH1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodH2()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosH2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodH3()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosH3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodH4()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosH4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodH5()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosH5.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodH6()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosH6.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodH7()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosH7.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodH8()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosH8.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodH9()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosH9.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodH10()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosH10.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodH11()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosH11.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodH12()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosH12.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodH13()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosH13.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinBlockMethodA1()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosA1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodA2()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosA2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodA3()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosA3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodA4()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosA4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodA5()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosA5.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodA6()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosA6.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodA7()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosA7.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodA8()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosA8.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodA9()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosA9.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodA10()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosA10.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodA11()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosA11.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodA12()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosA12.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinBlockMethodN1()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosN1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodN2()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosN2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodN3()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosN3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodN4()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosN4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodN5()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosN5.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodN6()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosN6.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodN7()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosN7.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodN8()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosN8.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodN9()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosN9.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodN10()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosN10.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodN11()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosN11.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodN12()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosN12.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodN13()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosN13.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinBlockMethodK1()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosK1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodK2()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosK2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodK3()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosK3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodK4()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosK4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodK5()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosK5.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodK6()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosK6.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodK7()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosK7.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodK8()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosK8.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodK9()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosK9.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodK10()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosK10.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodK11()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosK11.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodK12()
    {
        GameObject obj = ObjectPooler26.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = CoinBlockPosK12.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinBlockMethodY1()
    {
        GameObject obj = ObjectPooler56.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY1Pos1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodY2()
    {
        GameObject obj = ObjectPooler56.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY1Pos2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodY3()
    {
        GameObject obj = ObjectPooler56.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY1Pos3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodY4()
    {
        GameObject obj = ObjectPooler56.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY1Pos4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodY5()
    {
        GameObject obj = ObjectPooler56.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY1Pos5.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodY6()
    {
        GameObject obj = ObjectPooler56.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY1Pos6.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodY7()
    {
        GameObject obj = ObjectPooler56.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCY1Pos7.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinBlockMethodO1()
    {
        GameObject obj = ObjectPooler56.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCO1Pos1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodO2()
    {
        GameObject obj = ObjectPooler56.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCO1Pos2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodO3()
    {
        GameObject obj = ObjectPooler56.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCO1Pos3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodO4()
    {
        GameObject obj = ObjectPooler56.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCO1Pos4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodO5()
    {
        GameObject obj = ObjectPooler56.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCO1Pos5.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodO6()
    {
        GameObject obj = ObjectPooler56.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCO1Pos6.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodO7()
    {
        GameObject obj = ObjectPooler56.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCO1Pos7.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodO8()
    {
        GameObject obj = ObjectPooler56.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCO1Pos8.transform.position;
        obj.SetActive(true);
    }

    public void BonusCoinBlockMethodU1()
    {
        GameObject obj = ObjectPooler56.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCU1Pos1.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodU2()
    {
        GameObject obj = ObjectPooler56.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCU1Pos2.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodU3()
    {
        GameObject obj = ObjectPooler56.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCU1Pos3.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodU4()
    {
        GameObject obj = ObjectPooler56.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCU1Pos4.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodU5()
    {
        GameObject obj = ObjectPooler56.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCU1Pos5.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodU6()
    {
        GameObject obj = ObjectPooler56.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCU1Pos6.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodU7()
    {
        GameObject obj = ObjectPooler56.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCU1Pos7.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodU8()
    {
        GameObject obj = ObjectPooler56.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCU1Pos8.transform.position;
        obj.SetActive(true);
    }
    public void BonusCoinBlockMethodU9()
    {
        GameObject obj = ObjectPooler56.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = BCU1Pos9.transform.position;
        obj.SetActive(true);
    }
}
