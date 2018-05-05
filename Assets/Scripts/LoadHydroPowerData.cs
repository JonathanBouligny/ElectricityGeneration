using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadHydroPowerData : MonoBehaviour {
	public List<HydroPowerModel> hydroPowerList = new List<HydroPowerModel>();
	public List<string> stateCodeList = new List<string> ();
    List<string> stateList = new List<string>();

    public Dropdown dd;

    public Text total_units;
	public Text total_capacity;
	// Use this for initialization
	void Start () {

		Debug.Log ("STARTED");
		TextAsset questdata = Resources.Load<TextAsset>("hydroPowerData");

		string[] data = questdata.text.Split(new char[] { '\n' });

		for (int i = 1; i < data.Length - 1; i++)
		{
			string[] row = data[i].Split(new char[] { ',' });

			if (row[1] != "")
			{
				HydroPowerModel m = new HydroPowerModel();
				m.state = row[0];
				m.numberOfSites = row[1];
				m.hydroPowerGenerated = row[2];		
				m.stateCd = row[3];	
				hydroPowerList.Add(m);
				stateCodeList.Add (m.stateCd);
                stateList.Add(m.state);

            }
		}

		foreach (HydroPowerModel m in hydroPowerList)
		{
			Debug.Log(m.state + "," + m.numberOfSites);
		}


        dd.AddOptions(stateList);

    }


	// Update is called once per frame
	void Update () {

	}

	public void Dropdown_IndexChanged(int index){
		string stateCode = stateCodeList[index];
        getHyrdoPowerDataForState(stateCode);

	}

	public void getHyrdoPowerDataForState(string state){
        Debug.Log("AAAAAAAAAAAAAAAAAAAA");

        foreach (HydroPowerModel m in hydroPowerList)
		{
			if (m.stateCd.Equals (state)) {

				Debug.Log(m.state + "," + m.numberOfSites);
				//total_units.text = m.numberOfSites;
				//total_capacity.text = m.hydroPowerGenerated + "GWh";
				//TO DO set 
			}

		}
	}

}
