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

    int bp = 2000000;   // Base price to base every property on. Each property will be percentage * base price (bp). Percentage: 0.00 < easy < 0.50 < medium < 1.0 < hard

	void Awake()
	{
		// difficulty, easy = 1, medium = 2, hard = 3
		cards.Add(new PropertyCard("Development Site", "28 Grand River Ave \nDetroit, MI 48226", (int)(0.23 * bp), "Easy", 50, 0, westGrandRiver28, false, false, false, false, false, false, false, false));
        cards.Add(new PropertyCard("Retail Building", "45 W Grand River Ave \nDetroit, MI 48226", (int)(0.63 * bp), "Medium", 70, 0, westGrandRiver45, false, false, false, false, false, false, false, false));
        cards.Add(new PropertyCard("Former Detroit News Building", "615 W Lafayette Blvd \nDetroit, MI 48226", (int)(1.31 * bp), "Hard", 90, 0, wLafayette615, false, false, false, false, false, false, false, false));

        cards.Add(new PropertyCard("Corporation Building", "1000 Farmer St \nDetroit, MI 48226", (int)(0.45 * bp), "Easy", 50, 0, farmer1000, false, false, false, false, false, false, false, false));
        cards.Add(new PropertyCard("Parking Garage", "801 W Lafayette Blvd \nDetroit, MI 48226", (int)(0.81 * bp), "Medium", 70, 0, wLafayette801, false, false, false, false, false, false, false, false));
        cards.Add(new PropertyCard("Classical-style Building", "1201 Woodward Ave \nDetroit, MI 48226", (int)(1.02 * bp), "Hard", 90, 0, woodward1201, false, false, false, false, false, false, false, false));

        cards.Add(new PropertyCard("Retail Building", "1250 Griswold St \nDetroit, MI 48226", (int)(0.42 * bp), "Easy", 50, 0, griswold1250, false, false, false, false, false, false, false, false));
        cards.Add(new PropertyCard("Retail Building", "1238 Randolph St \nDetroit, MI 48226", (int)(0.77 * bp), "Medium", 70, 0, randolph1238, false, false, false, false, false, false, false, false));
        cards.Add(new PropertyCard("Commercial Building", "1265 Griswold St \nDetroit, MI 48226", (int)(1.07 * bp), "Hard", 90, 0, griswold1265, false, false, false, false, false, false, false, false));

        cards.Add(new PropertyCard("Retail Building", "1400 Woodward Ave \nDetroit, MI 48226", (int)(0.49 * bp), "Easy", 50, 0, woodward1400, false, false, false, false, false, false, false, false));
        cards.Add(new PropertyCard("Cary Building", "1301 Broadway St \nDetroit, MI 48226", (int)(0.72 * bp), "Medium", 70, 0, broadway1301, false, false, false, false, false, false, false, false));
        cards.Add(new PropertyCard("Chicago-style Building", "1274 Library St \nDetroit, MI 48226", (int)(1.13 * bp), "Hard", 90, 0, library1274, false, false, false, false, false, false, false, false));

        cards.Add(new PropertyCard("Retail Building", "1412 Woodward Ave \nDetroit, MI 48226", (int)(0.37 * bp), "Easy", 50, 0, woodward1412, false, false, false, false, false, false, false, false));
        cards.Add(new PropertyCard("Retail Buidling", "1426 Woodward Ave \nDetroit, MI 48226", (int)(0.85 * bp), "Medium", 70, 0, woodward1426, false, false, false, false, false, false, false, false));
        cards.Add(new PropertyCard("Retail Strip", "1416-1420 Woodward Ave \nDetroit, MI 48226", (int)(1.37 * bp), "Hard", 90, 0, woodward1416, false, false, false, false, false, false, false, false));

        cards.Add(new PropertyCard("Restaurant Building", "1456 Woodward Ave \nDetroit, MI 48226", (int)(0.44 * bp), "Easy", 50, 0, woodward1456, false, false, false, false, false, false, false, false));
        cards.Add(new PropertyCard("Queen Anne Style Building", "1500 Woodward Ave \nDetroit, MI 48226", (int)(0.97 * bp), "Medium", 70, 0, woodward1500, false, false, false, false, false, false, false, false));
        cards.Add(new PropertyCard("Residential Building", "1449 Woodward Avenue \nDetroit, MI 48226", (int)(1.23 * bp), "Hard", 90, 0, woodward1449, false, false, false, false, false, false, false, false));

        cards.Add(new PropertyCard("Restaurant Building", "1521 Broadway St \nDetroit, MI 48226", (int)(0.48 * bp), "Easy", 50, 0, broadway1521, false, false, false, false, false, false, false, false));
        cards.Add(new PropertyCard("Retail Building", "1505 Woodward Ave \nDetroit, MI 48226", (int)(0.93 * bp), "Medium", 70, 0, woodward1505, false, false, false, false, false, false, false, false));
        cards.Add(new PropertyCard("Retail Building", "1520 Woodward Ave \nDetroit, MI 48226", (int)(1.35 * bp), "Hard", 90, 0, woodward1520, false, false, false, false, false, false, false, false));

        cards.Add(new PropertyCard("Retail Building", "1550 Woodward Ave \nDetroit, MI 48226", (int)(0.33 * bp), "Easy", 50, 0, woodward1550, false, false, false, false, false, false, false, false));
        cards.Add(new PropertyCard("Campus Martius Park", "800 Woodward Ave, \nDetroit, MI 48226", (int)(0.97 * bp), "Medium", 70, 0, campusMartiusPark, false, false, false, false, false, false, false, false));
        cards.Add(new PropertyCard("Ally Detroit Center", "500 Woodward Ave \nDetroit, MI 48226", (int)(3.23 * bp), "Hard", 90, 0, allyDetroidCenter, false, false, false, false, false, false, false, false));

        cards.Add(new PropertyCard("Woodhouse Day Spa", "1447 Woodward Ave \nDetroit, MI 48226", (int)(0.47 * bp), "Easy", 50, 0, woodhouseDaySpa, false, false, false, false, false, false, false, false));
        cards.Add(new PropertyCard("Cass Parking Deck", "6540 Cass Avenue \nDetroit, MI 48202", (int)(0.94 * bp), "Medium", 70, 0, cassParkingDeck, false, false, false, false, false, false, false, false));
        cards.Add(new PropertyCard("Chrysler House", "719 Griswold Street \nDetroit, MI 48226", (int)(3.77 * bp), "Hard", 90, 0, chryslerHouse, false, false, false, false, false, false, false, false));

        cards.Add(new PropertyCard("Jazz Convenience Store", "1424 Woodward Ave \nDetroit, MI 48226", (int)(0.43 * bp), "Easy", 50, 0, jazzConvience, false, false, false, false, false, false, false, false));
        cards.Add(new PropertyCard("Federal Reserve Building", "160 W. Fort Street \nDetroit, MI 48226", (int)(0.89 * bp), "Medium", 70, 0, federalReserve, false, false, false, false, false, false, false, false));
        cards.Add(new PropertyCard("David Stott Building", "1150 Griswold Street \nDetroit, Michigan", (int)(4.20 * bp), "Hard", 90, 0, davidStott, false, false, false, false, false, false, false, false));

        cards.Add(new PropertyCard("House of Pure Vin", "1433 Woodward Ave \nDetroit, MI 48226", (int)(0.45 * bp), "Easy", 50, 0, houseOfPureVin, false, false, false, false, false, false, false, false));
        cards.Add(new PropertyCard("Hudson Cafe", "1241 Woodward Ave \nDetroit, MI 48226", (int)(0.72 * bp), "Medium", 70, 0, hudsonCafe, false, false, false, false, false, false, false, false));
        cards.Add(new PropertyCard("Hart Plaza", "1 Nelson Mandela Dr \nDetroit, MI 48226", (int)(2.00 * bp), "Hard", 90, 0, hartPlaza, false, false, false, false, false, false, false, false));

        cards.Add(new PropertyCard("Malcomson Building", "1215 Griswold Street \nDetroit, MI 48226", (int)(0.49 * bp), "Easy", 50, 0, malcolmsonAdparment, false, false, false, false, false, false, false, false));
        cards.Add(new PropertyCard("Madison Building", "1555 Broadway Street \nDetroit, MI 48226", (int)(0.91 * bp), "Medium", 70, 0, madison, false, false, false, false, false, false, false, false));
        cards.Add(new PropertyCard("Merchants Row", "1247 Woodward Ave \nDetroit, MI 48226", (int)(2.78 * bp), "Hard", 90, 0, merchantsRow, false, false, false, false, false, false, false, false));

        cards.Add(new PropertyCard("Red Rose Florist", "1425 Woodward Ave \nDetroit, MI 48226", (int)(0.49 * bp), "Easy", 50, 0, redRoseFlorist, false, false, false, false, false, false, false, false));
        cards.Add(new PropertyCard("Globe Tabacco Building", "407 East Fort Street \nDetroit, Michigan", (int)(0.95 * bp), "Medium", 70, 0, theGlobeBuilding, false, false, false, false, false, false, false, false));
        cards.Add(new PropertyCard("Quicken Loans Arena", "1 Center Ct \nCleveland, OH 44115", (int)(2.90 * bp), "Hard", 90, 0, qArena, false, false, false, false, false, false, false, false));

        cards.Add(new PropertyCard("One Woodward Avenue", "1 Woodward Avenue \nDetroit, Michigan", (int)(2.96 * bp), "Hard", 90, 0, oneWoodwardAve, false, false, false, false, false, false, false, false));
        cards.Add(new PropertyCard("The Qube", "611 Woodward Avenue \nDetroit, Michigan", (int)(2.36 * bp), "Hard", 90, 0, qube, false, false, false, false, false, false, false, false));
    }
}
