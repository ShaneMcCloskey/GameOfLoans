using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OppKnocksDeck : MonoBehaviour 
{
	private List<OppKnocksCard> cards = new List<OppKnocksCard>();

	public List<OppKnocksCard> Cards
	{
		get { return cards; }
	}

	void Awake()
	{
		// 1 = income, 2 = assets, 3 = credit
		// Income cards
		cards.Add(new OppKnocksCard("Your boss has noticed your hard work and gives you a raise.\n\n+1000 Income", 1000, 1));
		cards.Add(new OppKnocksCard("You decide to write a self help book. It’s a hit!\n\n+1000 Income", 1000, 1));
		cards.Add(new OppKnocksCard("You sell the secret family recipe to the Greedy Soup Company.\n\n+1500 Income", 1500, 1));
		cards.Add(new OppKnocksCard("You begin to dabble in life coaching.\n\n+200 Income", 200, 1));
		cards.Add(new OppKnocksCard("Your music career finally takes off.\n\n+1200 Income", 1200, 1));
		cards.Add(new OppKnocksCard("Your abstract art is finally popular.\n\n+2000 Income", 2000, 1));
		cards.Add(new OppKnocksCard("You write a popular app.\n\n+1600 Income", 1600, 1));
		cards.Add(new OppKnocksCard("You start an online business.\n\n+2000 Income", 2000, 1));
		cards.Add(new OppKnocksCard("You open a lemonade stand.\n\n+500 Income", 500, 1));
		cards.Add(new OppKnocksCard("You begin dog walking on the side.\n\n +400 Income", 400, 1));
		cards.Add(new OppKnocksCard("Your boss has noticed your hard work and gives you a raise.\n\n+1000 Income", 1000, 1));
		cards.Add(new OppKnocksCard("You decide to write a self help book. It’s a hit!\n\n+1000 Income", 1000, 1));
		cards.Add(new OppKnocksCard("You sell the secret family recipe to the Greedy Soup Company.\n\n+1500 Income", 1500, 1));
		cards.Add(new OppKnocksCard("You begin to dabble in life coaching.\n\n+200 Income", 200, 1));
		cards.Add(new OppKnocksCard("Your music career finally takes off.\n\n+1200 Income", 1200, 1));
		cards.Add(new OppKnocksCard("Your abstract art is finally popular.\n\n+2000 Income", 2000, 1));
		cards.Add(new OppKnocksCard("You write a popular app.\n\n+1600 Income", 1600, 1));
		cards.Add(new OppKnocksCard("You start an online business.\n\n+2000 Income", 2000, 1));
		cards.Add(new OppKnocksCard("You open a lemonade stand.\n\n+500 Income", 500, 1));
		cards.Add(new OppKnocksCard("You begin dog walking on the side.\n\n +400 Income", 400, 1));

		// Asset cards
		cards.Add(new OppKnocksCard("Aunt Jenny passed away. She left you an inheritance.\n\n+10000 Assets", 10000, 2));
		cards.Add(new OppKnocksCard("Cleaning out your attic you find a box of money.\n\n+1000 Assets", 1000, 2));
		cards.Add(new OppKnocksCard("A strong wind blows something your way. It’s $100.\n\n+200 Assets", 200, 2));
		cards.Add(new OppKnocksCard("Who said digging for treasure was a bad idea?\n\n+2500 Assets", 2500, 2));
		cards.Add(new OppKnocksCard("It’s your birthday! Don’t worry, Grandma didn’t forget.\n\n+400 Assets", 400, 2));
		cards.Add(new OppKnocksCard("Those old baseball cards were worth a lot.\n\n+800 Assets", 800, 2));
		cards.Add(new OppKnocksCard("Cleaning out your car you find a surprise.\n\n+200 Assets", 200, 2));
		cards.Add(new OppKnocksCard("What’s that in your pocket?Oh, it’s money.\n\n+500 Assets", 500, 2));
		cards.Add(new OppKnocksCard("You sell the farm.\n\n+6000 Assets", 6000, 2));
		cards.Add(new OppKnocksCard("What’s that in your shoe? More hidden money.\n\n+200 Assets", 200, 2));
		cards.Add(new OppKnocksCard("You sell your car to live a carbon free lifestyle.\n\n+5000 Assets", 5000, 2));
		cards.Add(new OppKnocksCard("You were in the right place, at the right time.\n\n+8000 Assets", 8000, 2));
		cards.Add(new OppKnocksCard("Who knew Chinese fortune cookies had lucky numbers?\n\n+10000 Assets", 10000, 2));
		cards.Add(new OppKnocksCard("You went to the end of the rainbow.\n\n+6000 Assets", 6000, 2));
		cards.Add(new OppKnocksCard("Grandpa Dan passed away. He left you an inheritance.\n\n+6000 Assets", 6000, 2));
		cards.Add(new OppKnocksCard("During home renovation you notice something in the wall. It’s money.\n\n+1400 Assets", 1400, 2));
		cards.Add(new OppKnocksCard("You finally return those cans in the garage.\n\n+1000 Assets", 1000, 2));
		cards.Add(new OppKnocksCard("You sell your plasma.\n\n+200 Assets", 200, 2));
		cards.Add(new OppKnocksCard("Vegas Baby!\n\n+4000 Assets", 4000, 2));
		cards.Add(new OppKnocksCard("Couch? More like bank.\n\n+800 Assets", 800, 2));
		cards.Add(new OppKnocksCard("You find an old shoe box. There aren’t shoes.\n\n+1000 Assets", 1000, 2));
		cards.Add(new OppKnocksCard("You enter the Bingo Hall a nobody, you leave a legend.\n\n+500 Assets", 500, 2));
		cards.Add(new OppKnocksCard("You sell your baseball signed by Babe Ruth.\n\n+ 2000 Assets", 2000, 2));
		cards.Add(new OppKnocksCard("It’s your birthday! Mom always knows the best gift.\n\n+1500 Assets", 1500, 2));
		cards.Add(new OppKnocksCard("You decide to try out that new metal detector.\n\n+500 Assets", 500, 2));
		cards.Add(new OppKnocksCard("Your laundry has gifted you cash.\n\n+400 Assets", 400, 2));
		cards.Add(new OppKnocksCard("You found an old check in your house.\n\n+1000 Assets", 1000, 2));

		// Credit cards
		cards.Add(new OppKnocksCard("Your credit card payments are consistently made on time thanks to your new auto-pay app.\n\n+40 Credit", 40, 3));
		cards.Add(new OppKnocksCard("Smarter spending has allowed you to utilize your available credit even less.\n\n+30 Credit", 30, 3));
		cards.Add(new OppKnocksCard("As the age of your credit history increases, so does your credit.\n\n+30 Credit", 30, 3));
		cards.Add(new OppKnocksCard("Your credit card company increases your credit limit, increasing your capacity.\n\n+40 Credit", 40, 3));
		cards.Add(new OppKnocksCard("You finally make progress on paying off those student loans.\n\n+20 Credit", 20, 3));
		cards.Add(new OppKnocksCard("You decided to not max out those credit cards you applied for during your first semester in college.\n\n+30 Credit", 30, 3));
		cards.Add(new OppKnocksCard("Your mother convinces you to slow down on opening new accounts.\n\n+20 Credit", 20, 3));
		cards.Add(new OppKnocksCard("You spend your paycheck on paying down your credit cards.\n\n+30 Credit", 30, 3));
		cards.Add(new OppKnocksCard("You make a payment towards your car loan.\n\n+20 Credit", 20, 3));
		cards.Add(new OppKnocksCard("You make a payment towards your mortgage. \n\n+20 Credit", 20, 3));
		cards.Add(new OppKnocksCard("Your credit card payments are consistently made on time thanks to your new auto-pay app.\n\n+40 Credit", 40, 3));
		cards.Add(new OppKnocksCard("Smarter spending has allowed you to utilize your available credit even less.\n\n+30 Credit", 30, 3));
		cards.Add(new OppKnocksCard("As the age of your credit history increases, so does your credit.\n\n+30 Credit", 15, 3));
		cards.Add(new OppKnocksCard("Your credit card company increases your credit limit, increasing your capacity.\n\n+20 Credit", 20, 3));
		cards.Add(new OppKnocksCard("You finally make progress on paying off those student loans.\n\n+10 Credit", 10, 3));
		cards.Add(new OppKnocksCard("You decided to not max out those credit cards you applied for during your first semester in college.\n\n+20 Credit", 20, 3));
		cards.Add(new OppKnocksCard("Your mother convinces you to slow down on opening new accounts.\n\n+10 Credit", 10, 3));
		cards.Add(new OppKnocksCard("You spend your paycheck on paying down your credit cards.\n\n+15 Credit", 15, 3));
		cards.Add(new OppKnocksCard("You make a payment towards your car loan.\n\n+10 Credit", 10, 3));
		cards.Add(new OppKnocksCard("You make a payment towards your mortgage. \n\n+10 Credit", 10, 3));
	}
}
