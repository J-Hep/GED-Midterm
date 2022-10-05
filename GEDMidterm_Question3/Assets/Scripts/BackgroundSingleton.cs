using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used from slides Lecture 2 page 99 link: http://www.unitygeek.com/unity_c_singleton/ 
public class GenericSingletonClass<T> : MonoBehaviour where T : Component
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    instance = obj.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    public virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}


public class BackgroundSingleton: GenericSingletonClass<BackgroundSingleton>
{
  public GameObject backgroundElement, scoring;
    

    void Update()
    {

        //Singleton code works. So It should show 6501 then finish.
        int score = 6500;
        

        if (score >= 5000)
        {
            backgroundElement.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
        }

        score++;
        print("Score: "+score);
    }

}


