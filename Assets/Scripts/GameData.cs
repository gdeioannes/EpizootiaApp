using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class GameData {

	public int version;
	public bool sound;
	public int cicleNumFinish;
	public int actionTimeSg;
	public int investmentTimeSg;
	public int fluCardNum;
	public List<FluCard> fluCards;
	public List<EventCard> eventCards;
	public List<GobCard> gobCards;
	public List<ScenarioObj> scenarioObjs;


}
