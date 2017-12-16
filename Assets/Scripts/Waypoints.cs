using UnityEngine;

public class Waypoints : MonoBehaviour {

	public static Transform[] points, pointsNonFix;
    private int fixLength = 0;

	void Awake ()
	{
        pointsNonFix = new Transform[transform.childCount];
        
        for (int i = 0; i < pointsNonFix.Length; i++)
        {
            if(transform.GetChild(i).tag == "nonpath")
            {
                Destroy(transform.GetChild(i).gameObject);
                Debug.Log("Deleted!");
            } else
            {
                fixLength++;
            }
        }

        points = new Transform[fixLength];

        for (int i = 0; i < fixLength; i++)
		{
			points[i] = transform.GetChild(i);
		}
	}

}
