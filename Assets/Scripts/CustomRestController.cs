using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RSG;
using Proyecto26;
using UnityEditor;

public class CustomRestController : MonoBehaviour {
	List<string> stateList = new List<string> ();
	List<string> stateCodeList = new List<string> ();
	private static  string baseURL = "https://developer.nrel.gov/api/solar/open_pv/installs/summaries?api_key=YzOwe1GXsf6nzmWNjKRwzmiARvWooTk0tfIYzWaq&state=";
	public Dropdown dd; 

	public Text total_installs;
	public Text total_installs_with_cost;
	public Text total_capacity;
	public Text avg_cost_pw;
	public Text avg_cost_cap_weight;

    public Text infoMsgSolar;

    public GameObject loadingImage;

	// Use this for initialization
	void Start () {
        loadingImage.SetActive(false);
        /*total_installs = GameObject.FindGameObjectWithTag("total_installs").GetComponent<Text>();
		total_installs_with_cost = GameObject.FindGameObjectWithTag("total_installs_with_cost").GetComponent<Text>();
		total_capacity = GameObject.FindGameObjectWithTag("total_capacity").GetComponent<Text>();
		avg_cost_pw = GameObject.FindGameObjectWithTag("avg_cost_pw").GetComponent<Text>();
		avg_cost_cap_weight = GameObject.FindGameObjectWithTag("avg_cost_cap_weight").GetComponent<Text>();
	*/
        populateList ();
	}
	/*RestClient.Get ("https://jsonplaceholder.typicode.com/posts/1").Then (response => {
			Debug.Log ("Update response "+ response.text);
			//EditorUtility.DisplayDialog ("Response", response.text, "Ok");
		});*/

	void populateList(){

		stateList.Add("Alabama");
		stateList.Add("Alaska");
		stateList.Add("Arizona");
		stateList.Add("Arkansas");
		stateList.Add("California");
		stateList.Add("Colorado");
		stateList.Add("Connecticut");
		stateList.Add("Delaware");
		stateList.Add("Florida");
		stateList.Add("Georgia");
		stateList.Add("Hawaii");
		stateList.Add("Idaho");
		stateList.Add("Illinois");
		stateList.Add("Indiana");
		stateList.Add("Iowa");
		stateList.Add("Kansas");
		stateList.Add("Kentucky");
		stateList.Add("Louisiana");
		stateList.Add("Maine");
		stateList.Add("Maryland");
		stateList.Add("Massachusetts");
		stateList.Add("Michigan");
		stateList.Add("Minnesota");
		stateList.Add("Mississippi");
		stateList.Add("Missouri");
		stateList.Add("Montana");
		stateList.Add("Nebraska");
		stateList.Add("Nevada");
		stateList.Add("New Hampshire");
		stateList.Add("New Jersey");
		stateList.Add("New Mexico");
		stateList.Add("New York");
		stateList.Add("North Carolina");
		stateList.Add("North Dakota");
		stateList.Add("Ohio");
		stateList.Add("Oklahoma");
		stateList.Add("Oregon");
		stateList.Add("Pennsylvania");
		stateList.Add("Rhode Island");
		stateList.Add("South Carolina");
		stateList.Add("South Dakota");
		stateList.Add("Tennessee");
		stateList.Add("Texas");
		stateList.Add("Utah");
		stateList.Add("Vermont");
		stateList.Add("Virginia");
		stateList.Add("Washington");
		stateList.Add("West Virginia");
		stateList.Add("Wisconsin");
		stateList.Add("Wyoming");


		stateCodeList.Add("AK");
		stateCodeList.Add("AL");
		stateCodeList.Add("AZ");
		stateCodeList.Add("AR");
		stateCodeList.Add("CA");
		stateCodeList.Add("CO");
		stateCodeList.Add("CT");
		stateCodeList.Add("DE");
		stateCodeList.Add("FL");
		stateCodeList.Add("GA");
		stateCodeList.Add("HI");
		stateCodeList.Add("ID");
		stateCodeList.Add("IL");
		stateCodeList.Add("IN");
		stateCodeList.Add("IA");
		stateCodeList.Add("KS");
		stateCodeList.Add("KY");
		stateCodeList.Add("LA");
		stateCodeList.Add("ME");
		stateCodeList.Add("MD");
		stateCodeList.Add("MA");
		stateCodeList.Add("MI");
		stateCodeList.Add("MN");
		stateCodeList.Add("MS");
		stateCodeList.Add("MO");
		stateCodeList.Add("MT");
		stateCodeList.Add("NE");
		stateCodeList.Add("NV");
		stateCodeList.Add("NH");
		stateCodeList.Add("NJ");
		stateCodeList.Add("NM");
		stateCodeList.Add("NY");
		stateCodeList.Add("NC");
		stateCodeList.Add("ND");
		stateCodeList.Add("OH");
		stateCodeList.Add("OK");
		stateCodeList.Add("OR");
		stateCodeList.Add("PA");
		stateCodeList.Add("RI");
		stateCodeList.Add("SC");
		stateCodeList.Add("SD");
		stateCodeList.Add("TN");
		stateCodeList.Add("TX");
		stateCodeList.Add("UT");
		stateCodeList.Add("VT");
		stateCodeList.Add("VA");
		stateCodeList.Add("WA");
		stateCodeList.Add("WV");
		stateCodeList.Add("WI");
		stateCodeList.Add("WY");

		dd.AddOptions (stateList);

	}

	public void Dropdown_IndexChanged(int index){
		string stateCode = stateCodeList[index];
		getSolarData(stateCode);

	}

	public void getSolarData(string stateCode){
		string requestURL = baseURL +""+ stateCode;
        loadingImage.SetActive(true);

        Debug.Log (requestURL);
		RestClient.Get (requestURL).Then (response => {
            loadingImage.SetActive(false);
            Response res = JsonUtility.FromJson<Response>(response.text);
			total_installs.text = "Total Number Of Installs  "+ res.result.total_installs;
			total_capacity.text = "Total Capacity  "+ res.result.total_capacity ;
			avg_cost_pw.text = "Avg Cost Per Watt  "+ res.result.avg_cost_pw ;
		});
	}

    public void wipe()
    {
        dd.gameObject.SetActive(false);
        infoMsgSolar.gameObject.SetActive(false);
        total_installs.text = "";
        total_installs_with_cost.text = "";
        total_capacity.text = "";
        avg_cost_pw.text = "";
        avg_cost_cap_weight.text = "";
    }

}
