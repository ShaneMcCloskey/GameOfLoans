using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PropertyDeck : MonoBehaviour 
{
	private List<PropertyCard> cards = new List<PropertyCard>();

	public List<PropertyCard> Cards
	{
		get { return cards; }
	}

	public Sprite westGrandRiver28;
	public Sprite westGrandRiver45;
	public Sprite wLafayette615;

	public Sprite wLafayette801;
	public Sprite farmer1000;
	public Sprite woodward1201;

	public Sprite randolph1238;
	public Sprite griswold1250;
	public Sprite griswold1265;
	public Sprite library1274;
	public Sprite broadway1301;
	public Sprite woodward1400;

	public Sprite woodward1412;
	public Sprite woodward1416;
	public Sprite woodward1426;
	public Sprite woodward1449;
	public Sprite woodward1456;
	public Sprite woodward1500;
	public Sprite woodward1505;
	public Sprite woodward1520;
	public Sprite broadway1521;
	public Sprite woodward1550;
	public Sprite allyDetroidCenter;
	public Sprite campusMartiusPark;
	public Sprite cassParkingDeck;
	public Sprite chryslerHouse;
	public Sprite compuwareLobby;
	public Sprite dataCenter;
	public Sprite davidStott;
	public Sprite federalReserve;

	public Sprite greektown;
	public Sprite hartPlaza;
	public Sprite horseshoeCasinoCinci;
	public Sprite horseshoeCasinoClev;
	public Sprite houseOfPureVin;
	public Sprite hudsonCafe;
	public Sprite jazzConvience;

	public Sprite madison;
	public Sprite malcolmsonAdparment;
	public Sprite merchantsRow;
	public Sprite oneWoodwardAve;
	public Sprite qArena;
	public Sprite qube;
	public Sprite redRoseFlorist;
	public Sprite shineAlightBuildings;
	public Sprite theGlobeBuilding;
	public Sprite woodhouseDaySpa;

	void Awake()
	{
		// difficulty, easy = 1, medium = 2, hard = 3
		cards.Add(new PropertyCard("Apartment Building", "28 Grand River Ave,\nDetroit, MI 48226", 100, "Easy", 54, 0, westGrandRiver28, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Shopping Center", "45 Grand River Ave,\nDetroit, MI 48226", 200, "Medium", 81, 0, westGrandRiver45, false, false, false, false, false, false,false, false));
		cards.Add(new PropertyCard("Parking Garage", "615 W Lafayette Blvd,\nDetroit, MI 48226", 300, "Hard", 54, 0, wLafayette615, false, false, false, false, false, false, false, false));

		cards.Add(new PropertyCard("Apartment Building", "801 W Lafayette Blvd,\nDetroit, MI 48226", 150, "Easy", 54, 0, wLafayette801, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Shopping Center", "1000 Farmer St, \nDetroit, MI 48226", 250, "Medium", 81, 0, farmer1000, false, false, false, false, false, false,false, false));
		cards.Add(new PropertyCard("Parking Garage", "1201 Woodward Ave,\nDetroit, MI 48226", 350, "Hard", 54, 0, woodward1201, false, false, false, false, false, false, false, false));


		/*cards.Add(new PropertyCard("Address 1", 100, "Easy", 54, 0, woodward1412, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 2", 200, "Medium", 81, 0, woodward1416, false, false, false, false, false, false,false, false));
		cards.Add(new PropertyCard("Address 3", 100, "Hard", 54, 0, woodward1426, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 1", 100, "Easy", 54, 0, woodward1449, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 2", 200, "Medium", 81, 0, woodward1456, false, false, false, false, false, false,false, false));
		cards.Add(new PropertyCard("Address 3", 100, "Hard", 54, 0, woodward1500, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 1", 100, "Easy", 54, 0, woodward1505, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 2", 200, "Medium", 81, 0, woodward1520, false, false, false, false, false, false,false, false));
		cards.Add(new PropertyCard("Address 3", 100, "Hard", 54, 0, broadway1521, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 1", 100, "Easy", 54, 0, woodward1550, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 2", 200, "Medium", 81, 0, allyDetroidCenter, false, false, false, false, false, false,false, false));
		cards.Add(new PropertyCard("Address 3", 100, "Hard", 54, 0, campusMartiusPark, false, false, false, false, false, false, false, false));

		cards.Add(new PropertyCard("Address 1", 100, "Easy", 54, 0, cassParkingDeck, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 2", 200, "Medium", 81, 0, chryslerHouse, false, false, false, false, false, false,false, false));
		cards.Add(new PropertyCard("Address 2", 200, "Hard", 81, 0, compuwareLobby, false, false, false, false, false, false,false, false));
		cards.Add(new PropertyCard("Address 3", 100, "Hard", 54, 0, dataCenter, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 1", 100, "Easy", 54, 0, davidStott, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 2", 200, "Medium", 81, 0, federalReserve, false, false, false, false, false, false,false, false));
		cards.Add(new PropertyCard("Address 3", 100, "Hard", 54, 0, greektown, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 1", 100, "Easy", 54, 0, hartPlaza, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 2", 200, "Medium", 81, 0, horseshoeCasinoCinci, false, false, false, false, false, false,false, false));
		cards.Add(new PropertyCard("Address 3", 100, "Hard", 54, 0, horseshoeCasinoClev, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 1", 100, "Easy", 54, 0, houseOfPureVin, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 2", 200, "Medium", 81, 0, hudsonCafe, false, false, false, false, false, false,false, false));
		cards.Add(new PropertyCard("Address 3", 100, "Hard", 54, 0, jazzConvience, false, false, false, false, false, false, false, false));

		cards.Add(new PropertyCard("Address 3", 100, "Hard", 54, 0, madison, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 1", 100, "Easy", 54, 0, malcolmsonAdparment, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 2", 200, "Medium", 81, 0, merchantsRow, false, false, false, false, false, false,false, false));
		cards.Add(new PropertyCard("Address 3", 100, "Hard", 54, 0, oneWoodwardAve, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 1", 100, "Easy", 54, 0, qArena, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 2", 200, "Medium", 81, 0, qube, false, false, false, false, false, false,false, false));
		cards.Add(new PropertyCard("Address 3", 100, "Hard", 54, 0, redRoseFlorist, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 1", 100, "Easy", 54, 0, shineAlightBuildings, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 2", 200, "Medium", 81, 0, theGlobeBuilding, false, false, false, false, false, false,false, false));
		cards.Add(new PropertyCard("Address 3", 100, "Hard", 54, 0, woodhouseDaySpa, false, false, false, false, false, false, false, false));*/
	}
}
