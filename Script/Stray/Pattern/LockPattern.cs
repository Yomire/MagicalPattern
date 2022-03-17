using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;
public class LockPattern : MonoBehaviour
{
    //[
    public string input, Epi9Flag, ResonanceFlag;
    public GameObject LineParent;
    public GameObject PanelResetPos;
    public RectTransform GekiButton, BladeButton, ShieldButton, LockButton, ShotButton, BombButton, ArrowButton, BoomerangButton, YoyoButton, ScytheButton, HammerButton, FishButton,
        StraySoul, MonaSoul, MonaSoulLine, MonaUI, ButterflyButton, ThunderButton;
    public GameObject PlayerObject;
    public MonaScript MonaScript;
    public Animator HeartAni, MonaSoulAni;
    public Image SPGage, SPGageB;
    public AudioClip HeartSound, PhoenixSound;
    public AudioSource audioSource;
    public Text PatternName1, PatternName2, PatternName3;
    //]

    public GameObject linePrefab;
    //public Canvas canvas;

    private Dictionary<int, CircleIdentifier> circles;

    private List<CircleIdentifier> lines;

    private GameObject lineOnEdit;
    private RectTransform lineOnEditRcTs;
    private CircleIdentifier circleOnEdit;

    private bool unlocking;

    new bool enabled = true;

    // Start is called before the first frame update
    void Start()
    {
        circles = new Dictionary<int, CircleIdentifier>();
        lines = new List<CircleIdentifier>();

        for (int i = 0; i < transform.childCount; i++)
        {
            var circle = transform.GetChild(i);

            var identifier = circle.GetComponent<CircleIdentifier>();

            identifier.id = i;

            circles.Add(i, identifier);

            //   circles.Add(circle.gameObject);

            //int num = PlayerObject.GetComponent<Player>().number;
        }
        PatternName1.text = "";
        PatternName2.text = "";
        PatternName3.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (enabled == false)
        {
            return;
        }

        if (unlocking)
        {
            Vector3 mousePos = LineParent.transform.InverseTransformPoint(Input.mousePosition);

            lineOnEditRcTs.sizeDelta = new Vector2(lineOnEditRcTs.sizeDelta.x, Vector3.Distance(mousePos, circleOnEdit.transform.localPosition));

            lineOnEditRcTs.rotation = Quaternion.FromToRotation(
                Vector3.up,
                (mousePos - circleOnEdit.transform.localPosition).normalized);
        }
    }

    IEnumerator Release()
    {
        enabled = false;

        yield return new WaitForSeconds(1);

        foreach (var circle in circles)
        {
            circle.Value.GetComponent<UnityEngine.UI.Image>().color = Color.blue;
            circle.Value.GetComponent<Animator>().enabled = false;
            MonaSoulAni.enabled = false;
            HeartAni.enabled = false;
        }

        foreach (var line in lines)
        {
            Destroy(line.gameObject);
        }

        lines.Clear();

        lineOnEdit = null;
        lineOnEditRcTs = null;
        circleOnEdit = null;

        enabled = true;
    }

    GameObject CreateLine(Vector3 pos, int id)
    {
        var line = GameObject.Instantiate(linePrefab, LineParent.transform); //+　LinePrefabをCircleと位置情報をまとめるため改変

        line.transform.localPosition = pos;

        var lineIdf = line.AddComponent<CircleIdentifier>();

        lineIdf.id = id;

        lines.Add(lineIdf);

        return line;
    }


    void TrySetLineEdit(CircleIdentifier circle)
    {
        foreach (var line in lines)
        {
            if (line.id == circle.id)
            {
                return;
            }
        }

        lineOnEdit = CreateLine(circle.transform.localPosition, circle.id);
        lineOnEditRcTs = lineOnEdit.GetComponent<RectTransform>();
        circleOnEdit = circle;
    }

    void EnableColorFade(Animator anim)
    {
        anim.enabled = true;
        anim.Rebind();
    }

    public void OnMouseEnterCircle(CircleIdentifier idf)
    {
        //[
        //Debug.Log(input);
        //]

        if (enabled == false)
        {
            return;
        }

        //Debug.Log(idf.id);

        if (unlocking)
        {
            lineOnEditRcTs.sizeDelta = new Vector2(lineOnEditRcTs.sizeDelta.x, Vector3.Distance(circleOnEdit.transform.localPosition, idf.transform.localPosition));
            lineOnEditRcTs.rotation = Quaternion.FromToRotation(
                Vector3.up,
                (idf.transform.localPosition - circleOnEdit.transform.localPosition).normalized);

            TrySetLineEdit(idf);
        }

        //[
        if (idf.id == 0)
        {
            //Debug.Log("0取得");
            if (input.Contains("0") == false)
            {
                input = input + "0";
            }
        }

        if (idf.id == 1)
        {
            //Debug.Log("1取得");
            if (input.Contains("1") == false)
            {
                input = input + "1";
            }
        }

        if (idf.id == 2)
        {
            //Debug.Log("2取得");
            if (input.Contains("2") == false)
            {
                input = input + "2";
            }
        }

        if (idf.id == 3)
        {
            //Debug.Log("3取得");
            if (input.Contains("3") == false)
            {
                input = input + "3";
            }
        }

        if (idf.id == 4)
        {
            //Debug.Log("4取得");
            if (input.Contains("4") == false)
            {
                input = input + "4";
            }
        }

        if (idf.id == 5)
        {
            //Debug.Log("5取得");
            if (input.Contains("5") == false)
            {
                input = input + "5";
            }
        }

        if (idf.id == 6)
        {
            //Debug.Log("6取得");
            if (input.Contains("6") == false)
            {
                input = input + "6";
            }
        }

        if (idf.id == 7)
        {
            //Debug.Log("7取得");
            if (input.Contains("7") == false)
            {
                input = input + "7";
            }
        }

        if (idf.id == 8)
        {
            //Debug.Log("8取得");
            if (input.Contains("8") == false)
            {
                input = input + "8";
            }
        }
        //]
    }

    public void OnMouseExitCircle(CircleIdentifier idf)
    {
        if (enabled == false)
        {
            return;
        }

        //Debug.Log(idf.id);
    }

    public void OnMouseDownCircle(CircleIdentifier idf)
    {
        if (enabled == false)
        {
            return;
        }

        //Debug.Log(idf.id);

        unlocking = true;

        TrySetLineEdit(idf);
    }

    public void OnMouseUpCircle(CircleIdentifier idf)
    {
        if (enabled == false)
        {
            return;
        }

        //Debug.Log(idf.id);

        if (unlocking)
        {
            foreach (var line in lines)
            {
                EnableColorFade(circles[line.id].gameObject.GetComponent<Animator>());
            }

            Destroy(lines[lines.Count - 1].gameObject);
            lines.RemoveAt(lines.Count - 1);

            foreach (var line in lines)
            {
                EnableColorFade(line.GetComponent<Animator>());
            }

            StartCoroutine(Release());
        }

        unlocking = false;

        /*if (input == "50481623")
        {
            Debug.Log("EventA");
            script.StarKick();
            StarHolder.GetComponent<CircleCollider2D>().enabled = true;
            Invoke("ComponentMethod2", 3.0f);
            //SeachCollider.GetComponent<BoxCollider2D>().enabled = true; //strayにコンポーネントされているseachcolloderをtrueにする
            //Invoke("ComponentMethod", 1.0f);
        }*/
        Invoke("InputResetMethod", 0.5f);
        //input = ""; //++
        //Invoke("TimeScaleMethod", 0.02f);
        
        //Time.timeScale = 0.01f;
        if (input == "1524637")
        {
            audioSource.PlayOneShot(HeartSound);
            //PlayerObject.GetComponent<Player>().ThunderMethodOff();
            PlayerObject.GetComponent<Player>().ButterflyModeOff();
            //Debug.Log("1524637");
            LockButton.anchoredPosition = new Vector3(83, 170, 0);
            GekiButton.anchoredPosition = new Vector3(83, 20, 0);
            ShieldButton.anchoredPosition = new Vector3(83, 170, 0);
            BladeButton.anchoredPosition = new Vector3(83, 170, 0);
            ShotButton.anchoredPosition = new Vector3(83, 170, 0);
            BombButton.anchoredPosition = new Vector3(83, 170, 0);
            ArrowButton.anchoredPosition = new Vector3(83, 170, 0);
            BoomerangButton.anchoredPosition = new Vector3(83, 170, 0);
            YoyoButton.anchoredPosition = new Vector3(83, 170, 0);
            ScytheButton.anchoredPosition = new Vector3(83, 170, 0);
            HammerButton.anchoredPosition = new Vector3(83, 170, 0);
            FishButton.anchoredPosition = new Vector3(83, 170, 0);
            ButterflyButton.anchoredPosition = new Vector3(83, 170, 0);
            ThunderButton.anchoredPosition = new Vector3(83, 170, 0);
            Invoke("TransformMethod", 0.7f);
            PatternName1.text = "◆ゲキ";
        }
        if (input == "24165")
        {
            audioSource.PlayOneShot(HeartSound);
            //PlayerObject.GetComponent<Player>().ThunderMethodOff();
            PlayerObject.GetComponent<Player>().ButterflyModeOff();
            LockButton.anchoredPosition = new Vector3(83, 170, 0);
            BladeButton.anchoredPosition = new Vector3(83, 20, 0);
            ShieldButton.anchoredPosition = new Vector3(83, 170, 0);
            GekiButton.anchoredPosition = new Vector3(83, 170, 0);
            ShotButton.anchoredPosition = new Vector3(83, 170, 0);
            BombButton.anchoredPosition = new Vector3(83, 170, 0);
            ArrowButton.anchoredPosition = new Vector3(83, 170, 0);
            BoomerangButton.anchoredPosition = new Vector3(83, 170, 0);
            YoyoButton.anchoredPosition = new Vector3(83, 170, 0);
            ScytheButton.anchoredPosition = new Vector3(83, 170, 0);
            HammerButton.anchoredPosition = new Vector3(83, 170, 0);
            FishButton.anchoredPosition = new Vector3(83, 170, 0);
            ButterflyButton.anchoredPosition = new Vector3(83, 170, 0);
            ThunderButton.anchoredPosition = new Vector3(83, 170, 0);
            Invoke("TransformMethod", 0.7f);
            //他ボタン.transform.Rest(isLocal: true); //recttransformでpublic取得しているため不可
            PatternName1.text = "◆ブレード";
        }
        if(input == "148037526")
        {
            audioSource.PlayOneShot(HeartSound);
            //PlayerObject.GetComponent<Player>().ThunderMethodOff();
            PlayerObject.GetComponent<Player>().ButterflyModeOff();
            LockButton.anchoredPosition = new Vector3(83, 170, 0);
            GekiButton.anchoredPosition = new Vector3(83, 170, 0);
            BladeButton.anchoredPosition = new Vector3(83, 170, 0);
            ShieldButton.anchoredPosition = new Vector3(83, 20, 0);
            ShotButton.anchoredPosition = new Vector3(83, 170, 0);
            BombButton.anchoredPosition = new Vector3(83, 170, 0);
            ArrowButton.anchoredPosition = new Vector3(83, 170, 0);
            BoomerangButton.anchoredPosition = new Vector3(83, 170, 0);
            YoyoButton.anchoredPosition = new Vector3(83, 170, 0);
            ScytheButton.anchoredPosition = new Vector3(83, 170, 0);
            HammerButton.anchoredPosition = new Vector3(83, 170, 0);
            FishButton.anchoredPosition = new Vector3(83, 170, 0);
            ButterflyButton.anchoredPosition = new Vector3(83, 170, 0);
            ThunderButton.anchoredPosition = new Vector3(83, 170, 0);
            Invoke("TransformMethod", 0.7f);
            PatternName1.text = "◆シールド";
        }
        if (input == "41308")
        {
            audioSource.PlayOneShot(HeartSound);
            //PlayerObject.GetComponent<Player>().ThunderMethodOff();
            PlayerObject.GetComponent<Player>().ButterflyModeOff();
            LockButton.anchoredPosition = new Vector3(83, 20, 0);
            GekiButton.anchoredPosition = new Vector3(83, 170, 0);
            BladeButton.anchoredPosition = new Vector3(83, 170, 0);
            ShieldButton.anchoredPosition = new Vector3(83, 170, 0);
            ShotButton.anchoredPosition = new Vector3(83, 170, 0);
            BombButton.anchoredPosition = new Vector3(83, 170, 0);
            ArrowButton.anchoredPosition = new Vector3(83, 170, 0);
            BoomerangButton.anchoredPosition = new Vector3(83, 170, 0);
            YoyoButton.anchoredPosition = new Vector3(83, 170, 0);
            ScytheButton.anchoredPosition = new Vector3(83, 170, 0);
            HammerButton.anchoredPosition = new Vector3(83, 170, 0);
            FishButton.anchoredPosition = new Vector3(83, 170, 0);
            ButterflyButton.anchoredPosition = new Vector3(83, 170, 0);
            ThunderButton.anchoredPosition = new Vector3(83, 170, 0);
            Invoke("TransformMethod", 0.7f);
            PatternName1.text = "◆キー";
        }
        if (input == "437510")
        {
            audioSource.PlayOneShot(HeartSound);
            //PlayerObject.GetComponent<Player>().ThunderMethodOff();
            PlayerObject.GetComponent<Player>().ButterflyModeOff();
            LockButton.anchoredPosition = new Vector3(83, 170, 0);
            GekiButton.anchoredPosition = new Vector3(83, 170, 0);
            BladeButton.anchoredPosition = new Vector3(83, 170, 0);
            ShieldButton.anchoredPosition = new Vector3(83, 170, 0);
            ShotButton.anchoredPosition = new Vector3(83, 20, 0);
            BombButton.anchoredPosition = new Vector3(83, 170, 0);
            ArrowButton.anchoredPosition = new Vector3(83, 170, 0);
            BoomerangButton.anchoredPosition = new Vector3(83, 170, 0);
            YoyoButton.anchoredPosition = new Vector3(83, 170, 0);
            ScytheButton.anchoredPosition = new Vector3(83, 170, 0);
            HammerButton.anchoredPosition = new Vector3(83, 170, 0);
            FishButton.anchoredPosition = new Vector3(83, 170, 0);
            ButterflyButton.anchoredPosition = new Vector3(83, 170, 0);
            ThunderButton.anchoredPosition = new Vector3(83, 170, 0);
            Invoke("TransformMethod", 0.7f);
            PatternName1.text = "◆バレット";
        }
        if (input == "84031526")
        {
            audioSource.PlayOneShot(HeartSound);
            Invoke("TransformMethod", 0.7f);
            Invoke("PhoenixVoice", 0.7f);
            PlayerObject.GetComponent<Player>().PhoenixMethod();
            if (PatternName2.text != "◇リボルビングエッジ")
            {
                PatternName2.text = "◇フェニックス";
            }
            if (PatternName2.text == "◇リボルビングエッジ")
            {
                PatternName3.text = "◇フェニックス";
            }
        }
        if (input == "547821")
        {
            audioSource.PlayOneShot(HeartSound);
            //PlayerObject.GetComponent<Player>().ThunderMethodOff();
            PlayerObject.GetComponent<Player>().ButterflyModeOff();
            LockButton.anchoredPosition = new Vector3(83, 170, 0);
            GekiButton.anchoredPosition = new Vector3(83, 170, 0);
            BladeButton.anchoredPosition = new Vector3(83, 170, 0);
            ShieldButton.anchoredPosition = new Vector3(83, 170, 0);
            ShotButton.anchoredPosition = new Vector3(83, 170, 0);
            BombButton.anchoredPosition = new Vector3(83, 20, 0);
            ArrowButton.anchoredPosition = new Vector3(83, 170, 0);
            BoomerangButton.anchoredPosition = new Vector3(83, 170, 0);
            YoyoButton.anchoredPosition = new Vector3(83, 170, 0);
            ScytheButton.anchoredPosition = new Vector3(83, 170, 0);
            HammerButton.anchoredPosition = new Vector3(83, 170, 0);
            FishButton.anchoredPosition = new Vector3(83, 170, 0);
            ButterflyButton.anchoredPosition = new Vector3(83, 170, 0);
            ThunderButton.anchoredPosition = new Vector3(83, 170, 0);
            Invoke("TransformMethod", 0.7f);
            PatternName1.text = "◆ボム";
        }
        if (input == "81572")
        {
            audioSource.PlayOneShot(HeartSound);
            //PlayerObject.GetComponent<Player>().ThunderMethodOff();
            PlayerObject.GetComponent<Player>().ButterflyModeOff();
            LockButton.anchoredPosition = new Vector3(83, 170, 0);
            GekiButton.anchoredPosition = new Vector3(83, 170, 0);
            BladeButton.anchoredPosition = new Vector3(83, 170, 0);
            ShieldButton.anchoredPosition = new Vector3(83, 170, 0);
            ShotButton.anchoredPosition = new Vector3(83, 170, 0);
            BombButton.anchoredPosition = new Vector3(83, 170, 0);
            ArrowButton.anchoredPosition = new Vector3(83, 20, 0);
            BoomerangButton.anchoredPosition = new Vector3(83, 170, 0);
            YoyoButton.anchoredPosition = new Vector3(83, 170, 0);
            ScytheButton.anchoredPosition = new Vector3(83, 170, 0);
            HammerButton.anchoredPosition = new Vector3(83, 170, 0);
            FishButton.anchoredPosition = new Vector3(83, 170, 0);
            ButterflyButton.anchoredPosition = new Vector3(83, 170, 0);
            ThunderButton.anchoredPosition = new Vector3(83, 170, 0);
            Invoke("TransformMethod", 0.7f);
            PatternName1.text = "◆アーチャー";

        }
        if(input == "7410268")
        {
            audioSource.PlayOneShot(HeartSound);
            Invoke("TransformMethod", 0.7f);
            PlayerObject.GetComponent<Player>().TimeSlow();
        }
        if (input == "72481")
        {
            audioSource.PlayOneShot(HeartSound);
            //PlayerObject.GetComponent<Player>().ThunderMethodOff();
            PlayerObject.GetComponent<Player>().ButterflyModeOff();
            LockButton.anchoredPosition = new Vector3(83, 170, 0);
            GekiButton.anchoredPosition = new Vector3(83, 170, 0);
            BladeButton.anchoredPosition = new Vector3(83, 170, 0);
            ShieldButton.anchoredPosition = new Vector3(83, 170, 0);
            ShotButton.anchoredPosition = new Vector3(83, 170, 0);
            BombButton.anchoredPosition = new Vector3(83, 170, 0);
            ArrowButton.anchoredPosition = new Vector3(83, 170, 0);
            BoomerangButton.anchoredPosition = new Vector3(83, 20, 0);
            YoyoButton.anchoredPosition = new Vector3(83, 170, 0);
            ScytheButton.anchoredPosition = new Vector3(83, 170, 0);
            HammerButton.anchoredPosition = new Vector3(83, 170, 0);
            FishButton.anchoredPosition = new Vector3(83, 170, 0);
            ButterflyButton.anchoredPosition = new Vector3(83, 170, 0);
            ThunderButton.anchoredPosition = new Vector3(83, 170, 0);
            Invoke("TransformMethod", 0.7f);
            PatternName1.text = "◆ブーメラン";
        }
        if (input == "4251736")
        {
            audioSource.PlayOneShot(HeartSound);
            //PlayerObject.GetComponent<Player>().ThunderMethodOff();
            PlayerObject.GetComponent<Player>().ButterflyModeOff();
            LockButton.anchoredPosition = new Vector3(83, 170, 0);
            GekiButton.anchoredPosition = new Vector3(83, 170, 0);
            BladeButton.anchoredPosition = new Vector3(83, 170, 0);
            ShieldButton.anchoredPosition = new Vector3(83, 170, 0);
            ShotButton.anchoredPosition = new Vector3(83, 170, 0);
            BombButton.anchoredPosition = new Vector3(83, 170, 0);
            ArrowButton.anchoredPosition = new Vector3(83, 170, 0);
            BoomerangButton.anchoredPosition = new Vector3(83, 170, 0);
            YoyoButton.anchoredPosition = new Vector3(83, 20, 0);
            ScytheButton.anchoredPosition = new Vector3(83, 170, 0);
            HammerButton.anchoredPosition = new Vector3(83, 170, 0);
            FishButton.anchoredPosition = new Vector3(83, 170, 0);
            ButterflyButton.anchoredPosition = new Vector3(83, 170, 0);
            ThunderButton.anchoredPosition = new Vector3(83, 170, 0);
            Invoke("TransformMethod", 0.7f);
            PatternName1.text = "◆タングラー";
        }
        if (input == "0572")
        {
            audioSource.PlayOneShot(HeartSound);
            //PlayerObject.GetComponent<Player>().ThunderMethodOff();
            PlayerObject.GetComponent<Player>().ButterflyModeOff();
            LockButton.anchoredPosition = new Vector3(83, 170, 0);
            GekiButton.anchoredPosition = new Vector3(83, 170, 0);
            BladeButton.anchoredPosition = new Vector3(83, 170, 0);
            ShieldButton.anchoredPosition = new Vector3(83, 170, 0);
            ShotButton.anchoredPosition = new Vector3(83, 170, 0);
            BombButton.anchoredPosition = new Vector3(83, 170, 0);
            ArrowButton.anchoredPosition = new Vector3(83, 170, 0);
            BoomerangButton.anchoredPosition = new Vector3(83, 170, 0);
            YoyoButton.anchoredPosition = new Vector3(83, 170, 0);
            ScytheButton.anchoredPosition = new Vector3(83, 20, 0);
            HammerButton.anchoredPosition = new Vector3(83, 170, 0);
            FishButton.anchoredPosition = new Vector3(83, 170, 0);
            ButterflyButton.anchoredPosition = new Vector3(83, 170, 0);
            ThunderButton.anchoredPosition = new Vector3(83, 170, 0);
            Invoke("TransformMethod", 0.7f);
            PatternName1.text = "◆サイス";
        }
        if (input == "461832705")
        {
            audioSource.PlayOneShot(HeartSound);
            Invoke("TransformMethod", 0.7f);
            PlayerObject.GetComponent<Player>().RevolvingCutter();
            if (PatternName2.text != "◇フェニックス")
            {
                PatternName2.text = "◇リボルビングエッジ";
            }
            if (PatternName2.text == "◇フェニックス")
            {
                PatternName3.text = "◇リボルビングエッジ";
            }
        }
        if (input == "3042517")
        {
            audioSource.PlayOneShot(HeartSound);
            //PlayerObject.GetComponent<Player>().ThunderMethodOff();
            PlayerObject.GetComponent<Player>().ButterflyModeOff();
            LockButton.anchoredPosition = new Vector3(83, 170, 0);
            GekiButton.anchoredPosition = new Vector3(83, 170, 0);
            BladeButton.anchoredPosition = new Vector3(83, 170, 0);
            ShieldButton.anchoredPosition = new Vector3(83, 170, 0);
            ShotButton.anchoredPosition = new Vector3(83, 170, 0);
            BombButton.anchoredPosition = new Vector3(83, 170, 0);
            ArrowButton.anchoredPosition = new Vector3(83, 170, 0);
            BoomerangButton.anchoredPosition = new Vector3(83, 170, 0);
            YoyoButton.anchoredPosition = new Vector3(83, 170, 0);
            ScytheButton.anchoredPosition = new Vector3(83, 170, 0);
            HammerButton.anchoredPosition = new Vector3(83, 20, 0);
            FishButton.anchoredPosition = new Vector3(83, 170, 0);
            ButterflyButton.anchoredPosition = new Vector3(83, 170, 0);
            ThunderButton.anchoredPosition = new Vector3(83, 170, 0);
            Invoke("TransformMethod", 0.7f);
            PatternName1.text = "◆ハンマー";
        }
        if (input == "54371028")
        {
            audioSource.PlayOneShot(HeartSound);
            //PlayerObject.GetComponent<Player>().ThunderMethodOff();
            PlayerObject.GetComponent<Player>().ButterflyModeOff();
            LockButton.anchoredPosition = new Vector3(83, 170, 0);
            GekiButton.anchoredPosition = new Vector3(83, 170, 0);
            BladeButton.anchoredPosition = new Vector3(83, 170, 0);
            ShieldButton.anchoredPosition = new Vector3(83, 170, 0);
            ShotButton.anchoredPosition = new Vector3(83, 170, 0);
            BombButton.anchoredPosition = new Vector3(83, 170, 0);
            ArrowButton.anchoredPosition = new Vector3(83, 170, 0);
            BoomerangButton.anchoredPosition = new Vector3(83, 170, 0);
            YoyoButton.anchoredPosition = new Vector3(83, 170, 0);
            ScytheButton.anchoredPosition = new Vector3(83, 170, 0);
            HammerButton.anchoredPosition = new Vector3(83, 170, 0);
            FishButton.anchoredPosition = new Vector3(83, 20, 0);
            ButterflyButton.anchoredPosition = new Vector3(83, 170, 0);
            ThunderButton.anchoredPosition = new Vector3(83, 170, 0);
            Invoke("TransformMethod", 0.7f);
            PatternName1.text = "◆リカバリー";
        }
        if (input == "5138")
        {
            if (SPGage.fillAmount >= 1 || SPGageB.fillAmount >= 1)
            {
                audioSource.PlayOneShot(HeartSound);
                if(Epi9Flag != "On")
                {
                    //PlayerObject.GetComponent<Player>().ThunderMethodOff();
                    PlayerObject.GetComponent<Player>().ButterflyModeOff();
                    LockButton.anchoredPosition = new Vector3(83, 170, 0);
                    GekiButton.anchoredPosition = new Vector3(83, 170, 0);
                    BladeButton.anchoredPosition = new Vector3(83, 170, 0);
                    ShieldButton.anchoredPosition = new Vector3(83, 170, 0);
                    ShotButton.anchoredPosition = new Vector3(83, 170, 0);
                    BombButton.anchoredPosition = new Vector3(83, 170, 0);
                    ArrowButton.anchoredPosition = new Vector3(83, 170, 0);
                    BoomerangButton.anchoredPosition = new Vector3(83, 170, 0);
                    YoyoButton.anchoredPosition = new Vector3(83, 170, 0);
                    ScytheButton.anchoredPosition = new Vector3(83, 170, 0);
                    HammerButton.anchoredPosition = new Vector3(83, 170, 0);
                    FishButton.anchoredPosition = new Vector3(83, 170, 0);
                    ButterflyButton.anchoredPosition = new Vector3(83, 170, 0);
                    ThunderButton.anchoredPosition = new Vector3(83, 170, 0);
                    Invoke("TransformMethod", 0.7f);
                    Invoke("SPGageFalse", 0.7f);
                    MonaScript.SphireStop();
                    PlayerObject.GetComponent<Player>().HCMethod();

                    MonaSoulAni.enabled = true;
                    HeartAni.enabled = true;
                    HeartAni.Play("HeartAni", 0, 0);
                    PatternName1.text = "◇レゾナンス";
                    PatternName2.text = "";
                    PatternName3.text = "";
                }
                if(Epi9Flag == "On")
                {
                    //Debug.Log("test1");
                    //シーン中のFlowchartのExecuteOnEventに設定されたMessageReceivedを取得する
                    MessageReceived[] receivers = GameObject.FindObjectsOfType<Fungus.MessageReceived>();
                    //取得できた場合
                    if (receivers != null)
                    {
                        //Debug.Log("test2");
                        //すべてのMessageReceivedに"test"イベントを送信する
                        foreach (var receiver in receivers)
                        {
                            //Debug.Log("test3");
                            if (ResonanceFlag == "1")
                            {
                                //Debug.Log("test4");
                                receiver.OnSendFungusMessage("Resonance1");
                                Invoke("RFlag2", 0.01f);
                                SPGageFalse();
                            }
                            if (ResonanceFlag == "2")
                            {
                                SPGageFalse();
                                receiver.OnSendFungusMessage("Resonance2");
                                Invoke("RFlag3", 0.01f);
                            }
                            if (ResonanceFlag == "3")
                            {
                                SPGageFalse();
                                receiver.OnSendFungusMessage("Resonance3");
                                Invoke("RFlag4", 0.01f);
                            }
                            if (ResonanceFlag == "4")
                            {
                                SPGageFalse();
                                receiver.OnSendFungusMessage("Resonance4");
                                Invoke("RFlag5", 0.01f);
                            }
                            if (ResonanceFlag == "5")
                            {
                                SPGageFalse();
                                receiver.OnSendFungusMessage("Resonance5");
                            }
                        }
                    }
                }
            }                
        }
        if (input == "8403526")
        {
            audioSource.PlayOneShot(HeartSound);
            //PlayerObject.GetComponent<Player>().ThunderMethodOff();
            PlayerObject.GetComponent<Player>().ButterflyMode();
            LockButton.anchoredPosition = new Vector3(83, 170, 0);
            GekiButton.anchoredPosition = new Vector3(83, 170, 0);
            BladeButton.anchoredPosition = new Vector3(83, 170, 0);
            ShieldButton.anchoredPosition = new Vector3(83, 170, 0);
            ShotButton.anchoredPosition = new Vector3(83, 170, 0);
            BombButton.anchoredPosition = new Vector3(83, 170, 0);
            ArrowButton.anchoredPosition = new Vector3(83, 170, 0);
            BoomerangButton.anchoredPosition = new Vector3(83, 170, 0);
            YoyoButton.anchoredPosition = new Vector3(83, 170, 0);
            ScytheButton.anchoredPosition = new Vector3(83, 170, 0);
            HammerButton.anchoredPosition = new Vector3(83, 170, 0);
            FishButton.anchoredPosition = new Vector3(83, 170, 0);
            ButterflyButton.anchoredPosition = new Vector3(83, 20, 0);
            ThunderButton.anchoredPosition = new Vector3(83, 170, 0);
            Invoke("TransformMethod", 0.7f);
            PatternName1.text = "◆バタフライ";
        }
        if (input == "2457")
        {
            audioSource.PlayOneShot(HeartSound);
            //PlayerObject.GetComponent<Player>().ThunderMethod();
            PlayerObject.GetComponent<Player>().ButterflyModeOff();
            LockButton.anchoredPosition = new Vector3(83, 170, 0);
            GekiButton.anchoredPosition = new Vector3(83, 170, 0);
            BladeButton.anchoredPosition = new Vector3(83, 170, 0);
            ShieldButton.anchoredPosition = new Vector3(83, 170, 0);
            ShotButton.anchoredPosition = new Vector3(83, 170, 0);
            BombButton.anchoredPosition = new Vector3(83, 170, 0);
            ArrowButton.anchoredPosition = new Vector3(83, 170, 0);
            BoomerangButton.anchoredPosition = new Vector3(83, 170, 0);
            YoyoButton.anchoredPosition = new Vector3(83, 170, 0);
            ScytheButton.anchoredPosition = new Vector3(83, 170, 0);
            HammerButton.anchoredPosition = new Vector3(83, 170, 0);
            FishButton.anchoredPosition = new Vector3(83, 170, 0);
            ButterflyButton.anchoredPosition = new Vector3(83, 170, 0);
            ThunderButton.anchoredPosition = new Vector3(83, 20, 0);
            Invoke("TransformMethod", 0.7f);
            PatternName1.text = "◆サンダー";
        }
        if (input == "147685302")
        {
            audioSource.PlayOneShot(HeartSound);
            Invoke("TransformMethod", 0.7f);
            Invoke("CoinBlock", 0.7f);
        }
        if (input == "03752")
        {
            audioSource.PlayOneShot(HeartSound);
            Invoke("TransformMethod", 0.7f);
            Invoke("MagnetMode", 0.7f);
        }
        if (input == "50481623")
        {
            if (SPGage.fillAmount >= 1 || SPGageB.fillAmount >= 1)
            {
                audioSource.PlayOneShot(HeartSound);
                Invoke("TransformMethod", 0.7f);
                Invoke("MeteorCall", 0.7f);
                Invoke("SPGageFalse", 0.7f);
            }                
        }
    }

    /*void ComponentMethod() //SeachColliderをfalseにする
    {
        SeachCollider.GetComponent<BoxCollider2D>().enabled = false;
    }*/

    void TransformMethod()
    {
        PanelResetPos.transform.Reset(isLocal: true); //拡張メソッドによる処理

        MonaSoulAni.enabled = false;
        HeartAni.enabled = false;
        StraySoul.anchoredPosition = new Vector3(65, 0, 0);
        MonaSoul.anchoredPosition = new Vector3(265, 0, 0);
        MonaSoulLine.anchoredPosition = new Vector3(265, 0, 0);
        MonaUI.anchoredPosition = new Vector3(265, 0, 0);
        
        /*Vector3 SSAnchorPos = StraySoul.anchoredPosition;
        Vector3 MSAnchorPos = MonaSoul.anchoredPosition;
        SSAnchorPos.x = 65;
        MSAnchorPos.x = 265;*/
    }
    public void SPGageFalse()
    {
        SPGage.fillAmount = 0;
        SPGageB.fillAmount = 0;
    }
    void TimeScaleMethod()
    {
        Time.timeScale = 1f;
    }
    /*void ComponentMethod2()
    {
        StarHolder.GetComponent<CircleCollider2D>().enabled = false;
    }*/
    public void InputResetMethod()
    {
        input = "";
    }
    public void CoinBlock()
    {
        PlayerObject.GetComponent<Player>().CoinChangeMethod();
    }
    public void MagnetMode()
    {
        PlayerObject.GetComponent<Player>().MagnetMethod();
    }
    public void MeteorCall()
    {
        PlayerObject.GetComponent<Player>().MeteorMethod();
    }
    public void PhoenixVoice()
    {
        audioSource.PlayOneShot(PhoenixSound);
    }
    public void ButterflyPattern()
    {
        audioSource.PlayOneShot(HeartSound);
        //PlayerObject.GetComponent<Player>().ThunderMethodOff();
        PlayerObject.GetComponent<Player>().ButterflyMode();
        LockButton.anchoredPosition = new Vector3(83, 170, 0);
        GekiButton.anchoredPosition = new Vector3(83, 170, 0);
        BladeButton.anchoredPosition = new Vector3(83, 170, 0);
        ShieldButton.anchoredPosition = new Vector3(83, 170, 0);
        ShotButton.anchoredPosition = new Vector3(83, 170, 0);
        BombButton.anchoredPosition = new Vector3(83, 170, 0);
        ArrowButton.anchoredPosition = new Vector3(83, 170, 0);
        BoomerangButton.anchoredPosition = new Vector3(83, 170, 0);
        YoyoButton.anchoredPosition = new Vector3(83, 170, 0);
        ScytheButton.anchoredPosition = new Vector3(83, 170, 0);
        HammerButton.anchoredPosition = new Vector3(83, 170, 0);
        FishButton.anchoredPosition = new Vector3(83, 170, 0);
        ButterflyButton.anchoredPosition = new Vector3(83, 20, 0);
        ThunderButton.anchoredPosition = new Vector3(83, 170, 0);
        Invoke("TransformMethod", 0.7f);
        PatternName1.text = "◆バタフライ";
    }
    public void RFlag2()
    {
        ResonanceFlag = "2";
    }
    public void RFlag3()
    {
        ResonanceFlag = "3";
    }
    public void RFlag4()
    {
        ResonanceFlag = "4";
    }
    public void RFlag5()
    {
        ResonanceFlag = "5";
    }
    public void HeatAniMethod()
    {
        MonaSoulAni.enabled = true;
        HeartAni.enabled = true;
        HeartAni.Play("HeartAni", 0, 0);
    }
}
