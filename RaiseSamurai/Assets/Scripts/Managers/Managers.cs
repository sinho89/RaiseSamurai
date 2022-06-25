using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_Instance; // singleton
    static Managers Instance { get { Init(); return s_Instance; } }

    #region Core
    ActorManager _actor = new ActorManager();           // Dictionary��� ���ӻ��� Object�� �����ϴ� Manager
    DataManager _data = new DataManager();              // Dictionary��� Json������ �Ľ��Ͽ� Data�� �����ϴ� Manager
    InputManager _input = new InputManager();           // Key���۰� ���õ� �������� �����ϴ� Manager
    PoolManager _pool = new PoolManager();              // Dictionary��� Pooling Object�� ��� Stack Pool�� �����ϴ� Manager 
    ResourceManager _resource = new ResourceManager();  // Prefabs ��� Object�� ���� �� �Ҹ� �����ϴ� Manager
    SceneManagerEx _scene = new SceneManagerEx();       // Scene�� �̵��� �����ϴ� Manager
    SoundManager _sound = new SoundManager();           // SoundType����� �迭�� �̷���� AudioSource�� ���� Clip�� �޾� Sound�� ��� �����ϴ� Manager ( Clips => Dictionary ����)
    UIManager _ui = new UIManager();                    // UI ������ �����ϰ� PopUpâ�� ���� SordID�� �����̳ʷ� ���� �����ϱ� ������ UI�� Stack �����̳ʷ� ���� 

    public static ActorManager Actor { get { return Instance._actor; } }
    public static DataManager Data { get { return Instance._data; } }
    public static InputManager Input { get { return Instance._input; } }
    public static PoolManager Pool { get { return Instance._pool; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static SceneManagerEx Scene { get { return Instance._scene; } }
    public static SoundManager Sound { get { return Instance._sound; } }
    public static UIManager UI { get { return Instance._ui; } }
    #endregion

    private void Start()
    {
        Init();
    }

    private void Update()
    {

    }

    private static void Init()
    {
        if(s_Instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
                go = new GameObject { name = "@Managers" };

            s_Instance = Utils.GetOrAddComponent<Managers>(go);
            DontDestroyOnLoad(go);

            s_Instance._pool.Init();
            s_Instance._sound.Init();
        }
    }

    public static void Clear()
    { 
        Actor.Clear();
        Input.Clear();
        Pool.Clear();
        Scene.Clear();
        Sound.Clear();
        UI.Clear();
    }
}
