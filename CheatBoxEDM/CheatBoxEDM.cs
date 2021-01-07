using System;
using MSCLoader;
using UnityEngine;
using System.Collections;
using HutongGames.PlayMaker;

namespace CheatBox
{
	public class CheatBox : Mod
	{
		// WARNING TO ALL
		// This is all a mess, blame the original dev of CheatBox for making such spaghetti.
		
		public override string ID => "CheatBox";
		public override string Name => "CheatBox-EDM";
		public override string Author => "fresh";
		public override string Version => "0.0.1";

		public override bool UseAssetsFolder => false;

		private Keybind CheatsGuiKey = new Keybind("ShowGUI", "Show Cheat GUI", KeyCode.C, KeyCode.LeftControl);
		private Keybind teleportKey1 = new Keybind("teleportKey1", "Teleport to Home", KeyCode.Alpha1, KeyCode.LeftControl);
		private Keybind teleportKey2 = new Keybind("teleportKey2", "Teleport to Store", KeyCode.Alpha2, KeyCode.LeftControl);
		private Keybind teleportKey3 = new Keybind("teleportKey3", "Teleport to Repair shop", KeyCode.Alpha3, KeyCode.LeftControl);
		private Keybind teleportKey4 = new Keybind("teleportKey4", "Teleport to Drag", KeyCode.Alpha4, KeyCode.LeftControl);
		private Keybind teleportKey5 = new Keybind("teleportKey5", "Teleport to Cottage", KeyCode.Alpha5, KeyCode.LeftControl);
		private Keybind teleportKey6 = new Keybind("teleportKey6", "Teleport to Ventti pig", KeyCode.Alpha6, KeyCode.LeftControl);
		private Keybind teleportKey7 = new Keybind("teleportKey7", "Teleport to Dance", KeyCode.Alpha7, KeyCode.LeftControl);
		private Keybind teleport0Key8 = new Keybind("teleport0Key8", "Teleport to Kilju guy", KeyCode.Alpha8, KeyCode.LeftControl);
		private Keybind teleport0Key9 = new Keybind("teleport0Key9", "Teleport to Grandma", KeyCode.Alpha9, KeyCode.LeftControl);
		private Keybind teleport0Key10 = new Keybind("teleport0Key10", "Teleport to Satsuma", KeyCode.Alpha0, KeyCode.LeftControl);
		private Keybind teleport0Key11 = new Keybind("teleport0Key11", "Teleport to Hayosiko", KeyCode.Alpha0, KeyCode.RightControl);
		private Keybind teleport0Key12 = new Keybind("teleport0Key12", "Teleport to Rusco", KeyCode.Alpha9, KeyCode.RightControl);
		private Keybind teleport0Key13 = new Keybind("teleport0Key13", "Teleport to Ferndale", KeyCode.Alpha8, KeyCode.RightControl);
		private Keybind teleport0Key14 = new Keybind("teleport0Key14", "Teleport to Jonnez", KeyCode.Alpha7, KeyCode.RightControl);
		private Keybind teleport0Key15 = new Keybind("teleport0Key15", "Teleport to Gifu", KeyCode.Alpha6, KeyCode.RightControl);
		private Keybind teleport0Key16 = new Keybind("teleport0Key16", "Teleport to Kekmet", KeyCode.Alpha5, KeyCode.RightControl);
		private Keybind teleport0Key17 = new Keybind("teleport0Key17", "Teleport to Flatbed", KeyCode.Alpha4, KeyCode.RightControl);
		private Rect guiBox = new Rect((Screen.width - 750) / 2, 10, 470, 800);
		private bool guiShow;
		private bool needs;
		private bool windowTwoStatus;
		private bool windowTwo2Status;
		private bool windowTwo3Status;
		private bool windowTwo4Status;
		private bool windowTwo5Status;
		private bool windowTwo6Status;
		private bool windowTwo7Status;
		private bool windowTwo8Status;
		private bool windowTwo9Status;
		private bool windowTwo10Status;
		private bool windowTwo11Status;
		private bool windowTwo12Status;
		private bool windowTwo13Status;
		private bool windowTwo14Status;
		private GameObject PLAYER;
		private float labeloffset = -5;

		public override void OnLoad()
		{
			Keybind.Add(this, CheatsGuiKey);
			Keybind.Add(this, teleportKey1);
			Keybind.Add(this, teleportKey2);
			Keybind.Add(this, teleportKey3);
			Keybind.Add(this, teleportKey4);
			Keybind.Add(this, teleportKey5);
			Keybind.Add(this, teleportKey6);
			Keybind.Add(this, teleportKey7);
			Keybind.Add(this, teleport0Key8);
			Keybind.Add(this, teleport0Key9);
			Keybind.Add(this, teleport0Key10);
			Keybind.Add(this, teleport0Key11);
			Keybind.Add(this, teleport0Key12);
			Keybind.Add(this, teleport0Key13);
			Keybind.Add(this, teleport0Key14);
			Keybind.Add(this, teleport0Key15);
			Keybind.Add(this, teleport0Key16);
			Keybind.Add(this, teleport0Key17);
		}

		public override void OnGUI()
		{
			if (guiShow)
			{
				GUI.Window(1, this.guiBox, new GUI.WindowFunction(this.Window), "CheatBox");
			}

			if (windowTwoStatus & guiShow)
			{
				GUI.Window(2, new Rect((Screen.width + 200) / 2, 10f, 150, 800), WindowTwo, "Tools");
			}

			if (windowTwo2Status & guiShow)
			{
				GUI.Window(2, new Rect((Screen.width + 200) / 2, 10f, 150, 800), WindowTwo2, "Car items");
			}

			if (windowTwo3Status & guiShow)
			{
				GUI.Window(2, new Rect((Screen.width + 200) / 2, 10f, 275, 800), WindowTwo3, "Items");
			}

			if (windowTwo4Status & guiShow)
			{
				GUI.Window(2, new Rect((Screen.width + 200) / 2, 10f, 150, 800), WindowTwo4, "Suspension");
			}

			if (windowTwo5Status & guiShow)
			{
				GUI.Window(2, new Rect((Screen.width + 200) / 2, 10f, 150, 800), WindowTwo5, "Exhaust & fuel");
			}

			if (windowTwo6Status & guiShow)
			{
				GUI.Window(2, new Rect((Screen.width + 200) / 2, 10f, 275, 800), WindowTwo6, "Body parts");
			}

			if (windowTwo7Status & guiShow)
			{
				GUI.Window(2, new Rect((Screen.width + 200) / 2, 10f, 150, 800), WindowTwo7, "Wheels");
			}

			if (windowTwo8Status & guiShow)
			{
				GUI.Window(2, new Rect((Screen.width + 200) / 2, 10f, 275, 800), WindowTwo8, "Engine parts");
			}

			if (windowTwo9Status & guiShow)
			{
				GUI.Window(2, new Rect((Screen.width + 200) / 2, 10f, 150, 800), WindowTwo9, "Engine parts 2");
			}

			if (windowTwo10Status & guiShow)
			{
				GUI.Window(2, new Rect((Screen.width + 200) / 2, 10f, 150, 800), WindowTwo10, "Engine bay");
			}

			if (windowTwo11Status & guiShow)
			{
				GUI.Window(2, new Rect((Screen.width + 200) / 2, 10f, 150, 800), WindowTwo11, "Gauges");
			}

			if (windowTwo12Status & guiShow)
			{
				GUI.Window(2, new Rect((Screen.width + 200) / 2, 10f, 275, 800), WindowTwo12, "Interior");
			}

			if (windowTwo13Status & guiShow)
			{
				GUI.Window(2, new Rect((Screen.width + 200) / 2, 10f, 150, 800), WindowTwo13, "Cars");
			}

			if (windowTwo14Status & guiShow)
			{
				GUI.Window(2, new Rect((Screen.width + 200) / 2, 10f, 275, 800), WindowTwo14, "TimeScaler & skips");
			}
		}

		private void WindowTwo(int windowId)
		{
			bool flag0 = GUI.Button(new Rect(15f, 50f, 120f, 30f), "Spanner set");
			if (flag0)
			{
				TpTo("spanner set(itemx)", "PLAYER");
			}
			bool flag1 = GUI.Button(new Rect(15f, 85f, 120f, 30f), "Ratchet set");
			if (flag1)
			{
				TpTo("ratchet set(Clone)", "PLAYER");
			}
			bool flag2 = GUI.Button(new Rect(15f, 120f, 120f, 30f), "Floor jack");
			if (flag2)
			{
				TpMe2("floor jack(itemx)", "PLAYER");
			}
			bool flag3 = GUI.Button(new Rect(15f, 155f, 120f, 30f), "Motor hoist");
			if (flag3)
			{
				TpMe3("motor hoist(itemx)", "PLAYER");
			}
			bool flag4 = GUI.Button(new Rect(15f, 190f, 120f, 30f), "Car jack");
			if (flag4)
			{
				TpTo("car jack(itemx)", "PLAYER");
			}
			bool flag5 = GUI.Button(new Rect(15f, 225f, 120f, 30f), "Wiring mess");
			if (flag5)
			{
				TpTo("wiring mess(itemx)", "PLAYER");
			}
			GUI.DragWindow();
		}

		private void WindowTwo2(int windowId)
		{
			bool flag0 = GUI.Button(new Rect(15f, 50f, 120f, 30f), "Diesel jerrycan");
			if (flag0)
			{
				TpTo("diesel(itemx)", "PLAYER");
			}
			bool flag1 = GUI.Button(new Rect(15f, 85f, 120f, 30f), "Gasoline jerrycan");
			if (flag1)
			{
				TpTo("gasoline(itemx)", "PLAYER");
			}

			bool flag2 = GUI.Button(new Rect(15f, 120f, 120f, 30f), "Fire exth. holder");
			if (flag2)
			{
				TpTo("fire extinguisher holder(Clone)", "PLAYER");
			}
			bool flag3 = GUI.Button(new Rect(15f, 155f, 120f, 30f), "Xmas lights");
			if (flag3)
			{
				TpTo("xmas lights(Clone)", "PLAYER");
			}
			bool flag4 = GUI.Button(new Rect(15f, 190f, 120f, 30f), "Warning triangle");
			if (flag4)
			{
				TpTo("warning triangle(Clone)", "PLAYER");
			}
			bool flag5 = GUI.Button(new Rect(15f, 225f, 120f, 30f), "Fur dices");
			if (flag5)
			{
				TpTo("fur dices(Clone)", "PLAYER");
			}
			bool flag6 = GUI.Button(new Rect(15f, 260f, 120f, 30f), "CD Disc");
			if (flag6)
			{
				TpTo("cd(item1)", "PLAYER");
			}
			bool flag7 = GUI.Button(new Rect(15f, 295f, 120f, 30f), "CD Case");
			if (flag7)
			{
				TpTo("cd case(Clone)", "PLAYER");
			}
			bool flag8 = GUI.Button(new Rect(15f, 330f, 120f, 30f), "Radar buster");
			if (flag8)
			{
				TpTo("radar buster(Clone)", "PLAYER");
			}
			bool flag9 = GUI.Button(new Rect(15f, 365f, 120f, 30f), "Helmet");
			if (flag9)
			{
				TpTo("helmet(itemx)", "PLAYER");
			}
			bool flag10 = GUI.Button(new Rect(15f, 400f, 120f, 30f), "Digging bar");
			if (flag10)
			{
				TpTo("digging bar(itemx)", "PLAYER");
			}
			GUI.DragWindow();
		}

		private void WindowTwo3(int windowId)
		{
			bool flag0 = GUI.Button(new Rect(15f, 50f, 120f, 30f), "Flashlight");
			if (flag0)
			{
				TpTo("flashlight(itemx)", "PLAYER");
			}
			bool flag1 = GUI.Button(new Rect(15f, 85f, 120f, 30f), "Sledgehammer");
			if (flag1)
			{
				TpTo("sledgehammer(itemx)", "PLAYER");
			}
			bool flag2 = GUI.Button(new Rect(15f, 120f, 120f, 30f), "Lantern");
			if (flag2)
			{
				TpTo("lantern(itemx)", "PLAYER");
			}
			bool flag3 = GUI.Button(new Rect(15f, 155f, 120f, 30f), "Bucket");
			if (flag3)
			{
				TpTo("bucket(itemx)", "PLAYER");
			}
			bool flag4 = GUI.Button(new Rect(15f, 190f, 120f, 30f), "Bucket lid");
			if (flag4)
			{
				TpTo("bucket lid(itemx)", "PLAYER");
			}
			bool flag5 = GUI.Button(new Rect(15f, 225f, 120f, 30f), "Fish trap");
			if (flag5)
			{
				TpTo("fish trap(itemx)", "PLAYER");
			}
			bool flag6 = GUI.Button(new Rect(15f, 260f, 120f, 30f), "Water bucket");
			if (flag6)
			{
				TpTo("water bucket(itemx)", "PLAYER");
			}
			bool flag7 = GUI.Button(new Rect(15f, 295f, 120f, 30f), "Dipper");
			if (flag7)
			{
				TpTo("dipper(itemx)", "PLAYER");
			}
			bool flag8 = GUI.Button(new Rect(15f, 330f, 120f, 30f), "Ax");
			if (flag8)
			{
				TpTo("ax(itemx)", "PLAYER");
			}
			bool flag9 = GUI.Button(new Rect(15f, 365f, 120f, 30f), "Basketball");
			if (flag9)
			{
				TpTo("basketball(Clone)", "PLAYER");
			}
			bool flag10 = GUI.Button(new Rect(15f, 400f, 120f, 30f), "Radio");
			if (flag10)
			{
				TpTo("radio(itemx)", "PLAYER");
			}
			bool flag11 = GUI.Button(new Rect(15f, 435f, 120f, 30f), "Sofa");
			if (flag11)
			{
				TpTo("sofa(itemx)", "PLAYER");
			}
			bool flag12 = GUI.Button(new Rect(15f, 470f, 120f, 30f), "Shopping bag");
			if (flag12)
			{
				TpTo("shopping bag(itemx)", "PLAYER");
			}
			bool flag13 = GUI.Button(new Rect(15f, 505f, 120f, 30f), "Envelope");
			if (flag13)
			{
				TpTo("envelope(xxxxx)", "PLAYER");
			}
			bool flag14 = GUI.Button(new Rect(15f, 540f, 120f, 30f), "Camera");
			if (flag14)
			{
				TpTo("camera(itemx)", "PLAYER");
			}
			bool flag15 = GUI.Button(new Rect(15f, 575f, 120f, 30f), "Suitcase");
			if (flag15)
			{
				TpTo("suitcase(itemx)", "PLAYER");
			}
			bool flag16 = GUI.Button(new Rect(15f, 610f, 120f, 30f), "Fireworks bag");
			if (flag16)
			{
				TpTo("fireworks bag(itemx)", "PLAYER");
			}
			bool flag17 = GUI.Button(new Rect(15f, 645f, 120f, 30f), "Wood carrier");
			if (flag17)
			{
				TpTo("wood carrier(itemx)", "PLAYER");
			}
			bool flag18 = GUI.Button(new Rect(15f, 680f, 120f, 30f), "Monitor");
			if (flag18)
			{
				TpTo("monitor(Clone)", "PLAYER");
			}
			bool flag19 = GUI.Button(new Rect(15f, 715f, 120f, 30f), "Peripherals");
			if (flag19)
			{
				TpTo("peripherals(Clone)", "PLAYER");
			}
			bool flag20 = GUI.Button(new Rect(140f, 50f, 120f, 30f), "Case");
			if (flag20)
			{
				TpTo("case(Clone)", "PLAYER");
			}
			bool flag21 = GUI.Button(new Rect(140f, 85f, 120f, 30f), "Speakers");
			if (flag21)
			{
				TpTo("speakers(Clone)", "PLAYER");
			}
			bool flag22 = GUI.Button(new Rect(140f, 120f, 120f, 30f), "Teimo advert");
			if (flag22)
			{
				TpTo("teimo advert(Clone)", "PLAYER");
			}
			bool flag23 = GUI.Button(new Rect(140f, 155f, 120f, 30f), "Advert pile");
			if (flag23)
			{
				TpTo("teimo advert pile(itemx)", "PLAYER");
			}
			bool flag24 = GUI.Button(new Rect(140f, 190f, 120f, 30f), "Grill");
			if (flag24)
			{
				TpTo("grill(itemx)", "PLAYER");
			}
			bool flag25 = GUI.Button(new Rect(140f, 225f, 120f, 30f), "Coffee pan");
			if (flag25)
			{
				TpTo("coffee pan(itemx)", "PLAYER");
			}
			bool flag26 = GUI.Button(new Rect(140f, 260f, 120f, 30f), "Coffee cup");
			if (flag26)
			{
				TpTo("coffee cup(itemx)", "PLAYER");
			}
			bool flag27 = GUI.Button(new Rect(140f, 295f, 120f, 30f), "Holiday pres.");
			if (flag27)
			{
				TpTo("holiday present(Clone)", "PLAYER");
			}
			bool flag28 = GUI.Button(new Rect(140f, 330f, 120f, 30f), "Diskette");
			if (flag28)
			{
				TpTo("diskette(itemx)", "PLAYER");
			}
			bool flag29 = GUI.Button(new Rect(140f, 365f, 120f, 30f), "Junk car 1");
			if (flag29)
			{
				TpTo("JunkCar1", "PLAYER");
			}
			bool flag30 = GUI.Button(new Rect(140f, 400f, 120f, 30f), "Junk car 2");
			if (flag30)
			{
				TpTo("JunkCar2", "PLAYER");
			}
			bool flag31 = GUI.Button(new Rect(140f, 435f, 120f, 30f), "Junk car 3");
			if (flag31)
			{
				TpTo("JunkCar3", "PLAYER");
			}
			bool flag32 = GUI.Button(new Rect(140f, 470f, 120f, 30f), "Junk car 4");
			if (flag32)
			{
				TpTo("JunkCar4", "PLAYER");
			}
			bool flag33 = GUI.Button(new Rect(140f, 505f, 120f, 30f), "TV remote cont.");
			if (flag33)
			{
				TpTo("tv remote control(itemx)", "PLAYER");
			}
			bool flag34 = GUI.Button(new Rect(140f, 540f, 120f, 30f), "Garbage barrel");
			if (flag34)
			{
				TpTo("garbage barrel(itemx)", "PLAYER");
			}
			bool flag35 = GUI.Button(new Rect(140f, 575f, 120f, 30f), "Lottery ticket");
			if (flag35)
			{
				TpTo("lottery ticket(xxxxx)", "PLAYER");
			}
			GUI.DragWindow();
		}

		private void WindowTwo4(int windowId)
		{
			bool flag0 = GUI.Button(new Rect(15f, 50f, 120f, 30f), "Wishbone FL");
			if (flag0)
			{
				TpTo("wishbone fl(Clone)", "PLAYER");
			}
			bool flag1 = GUI.Button(new Rect(15f, 85f, 120f, 30f), "Spindle FL");
			if (flag1)
			{
				TpTo("spindle fl(Clone)", "PLAYER");
			}
			bool flag2 = GUI.Button(new Rect(15f, 120f, 120f, 30f), "Strut FL");
			if (flag2)
			{
				TpTo("strut fl(Clone)", "PLAYER");
			}
			bool flag3 = GUI.Button(new Rect(15f, 155f, 120f, 30f), "Disc brakes");
			if (flag3)
			{
				GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
				foreach (GameObject findme in allObjects)
				{
					if (findme.name == "disc brake(Clone)")
					{
						findme.transform.position = new Vector3(GameObject.Find("PLAYER").transform.position.x + 3, GameObject.Find("PLAYER").transform.position.y, GameObject.Find("PLAYER").transform.position.z);
					}
				}
			}
			bool flag4 = GUI.Button(new Rect(15f, 190f, 120f, 30f), "Wishbone FR");
			if (flag4)
			{
				TpTo("wishbone fr(Clone)", "PLAYER");
			}
			bool flag5 = GUI.Button(new Rect(15f, 225f, 120f, 30f), "Spindle FR");
			if (flag5)
			{
				TpTo("spindle fr(Clone)", "PLAYER");
			}
			bool flag6 = GUI.Button(new Rect(15f, 260f, 120f, 30f), "Strut FR");
			if (flag6)
			{
				TpTo("strut fr(Clone)", "PLAYER");
			}
			bool flag7 = GUI.Button(new Rect(15f, 295f, 120f, 30f), "Trail arm RL");
			if (flag7)
			{
				TpTo("trail arm rl(Clone)", "PLAYER");
			}
			bool flag8 = GUI.Button(new Rect(15f, 330f, 120f, 30f), "Coil springs");
			if (flag8)
			{
				GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
				foreach (GameObject findme in allObjects)
				{
					if (findme.name == "coil spring(Clone)")
					{
						findme.transform.position = new Vector3(GameObject.Find("PLAYER").transform.position.x + 3, GameObject.Find("PLAYER").transform.position.y, GameObject.Find("PLAYER").transform.position.z);
					}
				}
			}
			bool flag9 = GUI.Button(new Rect(15f, 365f, 120f, 30f), "Long coil springs");
			if (flag9)
			{
				GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
				foreach (GameObject findme in allObjects)
				{
					if (findme.name == "long coil spring(Clone)")
					{
						findme.transform.position = new Vector3(GameObject.Find("PLAYER").transform.position.x + 3, GameObject.Find("PLAYER").transform.position.y, GameObject.Find("PLAYER").transform.position.z);
					}
				}
			}
			bool flag10 = GUI.Button(new Rect(15f, 400f, 120f, 30f), "Shock absorbers");
			if (flag10)
			{
				GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
				foreach (GameObject findme in allObjects)
				{
					if (findme.name == "shock absorber(Clone)")
					{
						findme.transform.position = new Vector3(GameObject.Find("PLAYER").transform.position.x + 3, GameObject.Find("PLAYER").transform.position.y, GameObject.Find("PLAYER").transform.position.z);
					}
				}
			}
			bool flag11 = GUI.Button(new Rect(15f, 435f, 120f, 30f), "Drum brakes");
			if (flag11)
			{
				GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
				foreach (GameObject findme in allObjects)
				{
					if (findme.name == "drum brake(Clone)")
					{
						findme.transform.position = new Vector3(GameObject.Find("PLAYER").transform.position.x + 3, GameObject.Find("PLAYER").transform.position.y, GameObject.Find("PLAYER").transform.position.z);
					}
				}
			}
			bool flag12 = GUI.Button(new Rect(15f, 470f, 120f, 30f), "Trail arm RR");
			if (flag12)
			{
				TpTo("trail arm rr(Clone)", "PLAYER");
			}
			bool flag13 = GUI.Button(new Rect(15f, 505f, 120f, 30f), "Rally strut FL");
			if (flag13)
			{
				TpTo("rally strut fl(Clone)", "PLAYER");
			}
			bool flag14 = GUI.Button(new Rect(15f, 540f, 120f, 30f), "Rally strut FR");
			if (flag14)
			{
				TpTo("rally strut fr(Clone)", "PLAYER");
			}
			bool flag15 = GUI.Button(new Rect(15f, 575f, 120f, 30f), "Rally coil springs");
			if (flag15)
			{
				GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
				foreach (GameObject findme in allObjects)
				{
					if (findme.name == "rally coil spring(Clone)")
					{
						findme.transform.position = new Vector3(GameObject.Find("PLAYER").transform.position.x + 3, GameObject.Find("PLAYER").transform.position.y, GameObject.Find("PLAYER").transform.position.z);
					}
				}
			}
			bool flag16 = GUI.Button(new Rect(15f, 610f, 120f, 30f), "Rally shock abs-s");
			if (flag16)
			{
				GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
				foreach (GameObject findme in allObjects)
				{
					if (findme.name == "rally shock absorber(Clone)")
					{
						findme.transform.position = new Vector3(GameObject.Find("PLAYER").transform.position.x + 3, GameObject.Find("PLAYER").transform.position.y, GameObject.Find("PLAYER").transform.position.z);
					}
				}
			}
			GUI.DragWindow();
		}

		private void WindowTwo5(int windowId)
		{
			bool flag0 = GUI.Button(new Rect(15f, 50f, 120f, 30f), "Muffler stock");
			if (flag0)
			{
				TpTo("exhaust muffler(Clone)", "PLAYER");
			}
			bool flag1 = GUI.Button(new Rect(15f, 85f, 120f, 30f), "Pipe stock");
			if (flag1)
			{
				TpTo("exhaust pipe(Clone)", "PLAYER");
			}
			bool flag2 = GUI.Button(new Rect(15f, 120f, 120f, 30f), "Muffler racing");
			if (flag2)
			{
				TpTo("racing muffler(Clone)", "PLAYER");
			}
			bool flag3 = GUI.Button(new Rect(15f, 155f, 120f, 30f), "Pipe racing");
			if (flag3)
			{
				TpTo("racing exhaust(Clone)", "PLAYER");
			}
			bool flag4 = GUI.Button(new Rect(15f, 190f, 120f, 30f), "Fuel tank");
			if (flag4)
			{
				TpTo("fuel tank(Clone)", "PLAYER");
			}
			bool flag5 = GUI.Button(new Rect(15f, 225f, 120f, 30f), "Fuel tank pipe");
			if (flag5)
			{
				TpTo("fuel tank pipe(Clone)", "PLAYER");
			}
			GUI.DragWindow();
		}

		private void WindowTwo6(int windowId)
		{
			bool flag0 = GUI.Button(new Rect(15f, 50f, 120f, 30f), "Front bumper");
			if (flag0)
			{
				TpTo("bumper front(Clone)", "PLAYER");
			}
			bool flag1 = GUI.Button(new Rect(15f, 85f, 120f, 30f), "Rear bumper");
			if (flag1)
			{
				TpTo("bumper rear(Clone)", "PLAYER");
			}
			bool flag2 = GUI.Button(new Rect(15f, 120f, 120f, 30f), "Fender left");
			if (flag2)
			{
				TpTo("fender left(Clone)", "PLAYER");
			}
			bool flag3 = GUI.Button(new Rect(15f, 155f, 120f, 30f), "Fender right");
			if (flag3)
			{
				TpTo("fender right(Clone)", "PLAYER");
			}
			bool flag4 = GUI.Button(new Rect(15f, 190f, 120f, 30f), "Door left");
			if (flag4)
			{
				TpTo("door left(Clone)", "PLAYER");
			}
			bool flag5 = GUI.Button(new Rect(15f, 225f, 120f, 30f), "Door right");
			if (flag5)
			{
				TpTo("door right(Clone)", "PLAYER");
			}
			bool flag6 = GUI.Button(new Rect(15f, 260f, 120f, 30f), "Bootlid");
			if (flag6)
			{
				TpTo("bootlid(Clone)", "PLAYER");
			}
			bool flag7 = GUI.Button(new Rect(15f, 295f, 120f, 30f), "Hood");
			if (flag7)
			{
				TpTo("hood(Clone)", "PLAYER");
			}
			bool flag8 = GUI.Button(new Rect(15f, 330f, 120f, 30f), "Grille");
			if (flag8)
			{
				TpTo("grille(Clone)", "PLAYER");
			}
			bool flag9 = GUI.Button(new Rect(15f, 365f, 120f, 30f), "Headlights");
			if (flag9)
			{
				GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
				foreach (GameObject findme in allObjects)
				{
					if (findme.name == "headlight(Clone)")
					{
						findme.transform.position = new Vector3(GameObject.Find("PLAYER").transform.position.x + 3, GameObject.Find("PLAYER").transform.position.y, GameObject.Find("PLAYER").transform.position.z);
					}
				}
			}
			bool flag10 = GUI.Button(new Rect(15f, 400f, 120f, 30f), "Rear light left");
			if (flag10)
			{
				TpTo("rear light left(Clone)", "PLAYER");
			}
			bool flag11 = GUI.Button(new Rect(15f, 435f, 120f, 30f), "Rear light right");
			if (flag11)
			{
				TpTo("rear light right(Clone)", "PLAYER");
			}
			bool flag12 = GUI.Button(new Rect(15f, 470f, 120f, 30f), "Fiberglass hood");
			if (flag12)
			{
				TpTo("fiberglass hood(Clone)", "PLAYER");
			}
			bool flag13 = GUI.Button(new Rect(15f, 505f, 120f, 30f), "Fender flare FL");
			if (flag13)
			{
				TpTo("fender flare fl(Clone)", "PLAYER");
			}
			bool flag14 = GUI.Button(new Rect(15f, 540f, 120f, 30f), "Fender flare FR");
			if (flag14)
			{
				TpTo("fender flare fr(Clone)", "PLAYER");
			}
			bool flag15 = GUI.Button(new Rect(15f, 575f, 120f, 30f), "Fender flare RL");
			if (flag15)
			{
				TpTo("fender flare rl(Clone)", "PLAYER");
			}
			bool flag16 = GUI.Button(new Rect(15f, 610f, 120f, 30f), "Fender flare RR");
			if (flag16)
			{
				TpTo("fender flare rr(Clone)", "PLAYER");
			}
			bool flag17 = GUI.Button(new Rect(15f, 645f, 120f, 30f), "Fen. flare spoiler");
			if (flag17)
			{
				TpTo("fender flare spoiler(Clone)", "PLAYER");
			}
			bool flag18 = GUI.Button(new Rect(15f, 680f, 120f, 30f), "Front spoiler");
			if (flag18)
			{
				TpTo("front spoiler(Clone)", "PLAYER");
			}
			bool flag19 = GUI.Button(new Rect(15f, 715f, 120f, 30f), "Rear spoiler");
			if (flag19)
			{
				TpTo("rear spoiler(Clone)", "PLAYER");
			}
			bool flag20 = GUI.Button(new Rect(140f, 50f, 120f, 30f), "Rear spoiler 2");
			if (flag20)
			{
				TpTo("rear spoiler2(Clone)", "PLAYER");
			}
			bool flag21 = GUI.Button(new Rect(140f, 85f, 120f, 30f), "Window grille");
			if (flag21)
			{
				TpTo("window grille(Clone)", "PLAYER");
			}
			bool flag22 = GUI.Button(new Rect(140f, 120f, 120f, 30f), "Wind. black wrap");
			if (flag22)
			{
				TpTo("windows black wrap(Clone)", "PLAYER");
			}
			bool flag23 = GUI.Button(new Rect(140f, 155f, 120f, 30f), "Register plates");
			if (flag23)
			{
				GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
				foreach (GameObject findme in allObjects)
				{
					if (findme.name == "register plate(Clone)")
					{
						findme.transform.position = new Vector3(GameObject.Find("PLAYER").transform.position.x + 3, GameObject.Find("PLAYER").transform.position.y, GameObject.Find("PLAYER").transform.position.z);
					}
				}
			}
			bool flag24 = GUI.Button(new Rect(140f, 190f, 120f, 30f), "Grille GT");
			if (flag24)
			{
				TpTo("grille gt(Clone)", "PLAYER");
			}
			bool flag25 = GUI.Button(new Rect(140f, 225f, 120f, 30f), "L marker light");
			if (flag25)
			{
				TpTo("marker light left(Clone)", "PLAYER");
			}
			bool flag26 = GUI.Button(new Rect(140f, 260f, 120f, 30f), "R marker light");
			if (flag26)
			{
				TpTo("marker light right(Clone)", "PLAYER");
			}
			bool flag27 = GUI.Button(new Rect(140f, 295f, 120f, 30f), "Mudflap FL");
			if (flag27)
			{
				TpTo("mudflap fl(Clone)", "PLAYER");
			}
			bool flag28 = GUI.Button(new Rect(140f, 330f, 120f, 30f), "Mudflap FR");
			if (flag28)
			{
				TpTo("mudflap fr(Clone)", "PLAYER");
			}
			bool flag29 = GUI.Button(new Rect(140f, 365f, 120f, 30f), "Mudflap RL");
			if (flag29)
			{
				TpTo("mudflap rl(Clone)", "PLAYER");
			}
			bool flag30 = GUI.Button(new Rect(140f, 400f, 120f, 30f), "Mudflap RR");
			if (flag30)
			{
				TpTo("mudflap rr(Clone)", "PLAYER");
			}
			GUI.DragWindow();
		}

		private void WindowTwo7(int windowId)
		{
			bool flag0 = GUI.Button(new Rect(15f, 50f, 120f, 30f), "Whls without offs.");
			if (flag0)
			{
				GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
				foreach (GameObject findme in allObjects)
				{
					if (findme.name == "wheel_regula")
					{
						findme.transform.position = new Vector3(GameObject.Find("PLAYER").transform.position.x + 3, GameObject.Find("PLAYER").transform.position.y, GameObject.Find("PLAYER").transform.position.z);
					}
				}
			}
			bool flag1 = GUI.Button(new Rect(15f, 85f, 120f, 30f), "Wheels with offset");
			if (flag1)
			{
				GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
				foreach (GameObject findme in allObjects)
				{
					if (findme.name == "wheel_offset")
					{
						findme.transform.position = new Vector3(GameObject.Find("PLAYER").transform.position.x + 3, GameObject.Find("PLAYER").transform.position.y, GameObject.Find("PLAYER").transform.position.z);
					}
				}
			}
			bool flag20 = GUI.Button(new Rect(15f, 120f, 120f, 30f), "Hubcap FL");
			if (flag20)
			{
				TpTo("hubcap fl(Clone)", "PLAYER");
			}
			bool flag21 = GUI.Button(new Rect(15f, 155f, 120f, 30f), "Hubcap FR");
			if (flag21)
			{
				TpTo("hubcap fr(Clone)", "PLAYER");
			}
			bool flag22 = GUI.Button(new Rect(15f, 190f, 120f, 30f), "Hubcap RL");
			if (flag22)
			{
				TpTo("hubcap rl(Clone)", "PLAYER");
			}
			bool flag23 = GUI.Button(new Rect(15f, 225f, 120f, 30f), "Hubcap RR");
			if (flag23)
			{
				TpTo("hubcap rr(Clone)", "PLAYER");
			}
			GUI.DragWindow();
		}

		private void WindowTwo8(int windowId)
		{
			bool flag0 = GUI.Button(new Rect(15f, 50f, 120f, 30f), "Main bridge 1");
			if (flag0)
			{
				TpTo("main bearing1(Clone)", "PLAYER");
			}
			bool flag1 = GUI.Button(new Rect(15f, 85f, 120f, 30f), "Main bridge 2");
			if (flag1)
			{
				TpTo("main bearing2(Clone)", "PLAYER");
			}
			bool flag2 = GUI.Button(new Rect(15f, 120f, 120f, 30f), "Main bridge 3");
			if (flag2)
			{
				TpTo("main bearing3(Clone)", "PLAYER");
			}
			bool flag3 = GUI.Button(new Rect(15f, 155f, 120f, 30f), "Block");
			if (flag3)
			{
				TpTo("block(Clone)", "PLAYER");
			}
			bool flag4 = GUI.Button(new Rect(15f, 190f, 120f, 30f), "Crankshaft");
			if (flag4)
			{
				TpTo("crankshaft(Clone)", "PLAYER");
			}
			bool flag5 = GUI.Button(new Rect(15f, 225f, 120f, 30f), "Piston 1");
			if (flag5)
			{
				TpTo("piston1(Clone)", "PLAYER");
			}
			bool flag6 = GUI.Button(new Rect(15f, 260f, 120f, 30f), "Piston 2");
			if (flag6)
			{
				TpTo("piston2(Clone)", "PLAYER");
			}
			bool flag7 = GUI.Button(new Rect(15f, 295f, 120f, 30f), "Piston 3");
			if (flag7)
			{
				TpTo("piston3(Clone)", "PLAYER");
			}
			bool flag8 = GUI.Button(new Rect(15f, 330f, 120f, 30f), "Piston 4");
			if (flag8)
			{
				TpTo("piston4(Clone)", "PLAYER");
			}
			bool flag9 = GUI.Button(new Rect(15f, 365f, 120f, 30f), "Camshaft");
			if (flag9)
			{
				TpTo("camshaft(Clone)", "PLAYER");
			}
			bool flag10 = GUI.Button(new Rect(15f, 400f, 120f, 30f), "Camshaft gear");
			if (flag10)
			{
				TpTo("camshaft gear(Clone)", "PLAYER");
			}
			bool flag11 = GUI.Button(new Rect(15f, 435f, 120f, 30f), "Timing chain");
			if (flag11)
			{
				TpTo("timing chain(Clone)", "PLAYER");
			}
			bool flag12 = GUI.Button(new Rect(15f, 470f, 120f, 30f), "Timing cover");
			if (flag12)
			{
				TpTo("timing cover(Clone)", "PLAYER");
			}
			bool flag13 = GUI.Button(new Rect(15f, 505f, 120f, 30f), "Water pump");
			if (flag13)
			{
				TpTo("water pump(Clone)", "PLAYER");
			}
			bool flag14 = GUI.Button(new Rect(15f, 540f, 120f, 30f), "Water pump pulley");
			if (flag14)
			{
				TpTo("water pump pulley(Clone)", "PLAYER");
			}
			bool flag15 = GUI.Button(new Rect(15f, 575f, 120f, 30f), "Flywheel");
			if (flag15)
			{
				TpTo("flywheel(Clone)", "PLAYER");
			}
			bool flag16 = GUI.Button(new Rect(15f, 610f, 120f, 30f), "Clutch cover plate");
			if (flag16)
			{
				TpTo("clutch cover plate(Clone)", "PLAYER");
			}
			bool flag17 = GUI.Button(new Rect(15f, 645f, 120f, 30f), "Clutch disc");
			if (flag17)
			{
				TpTo("clutch disc(Clone)", "PLAYER");
			}
			bool flag18 = GUI.Button(new Rect(15f, 680f, 120f, 30f), "Clutch pres. plate");
			if (flag18)
			{
				TpTo("clutch pressure plate(Clone)", "PLAYER");
			}
			bool flag19 = GUI.Button(new Rect(15f, 715f, 120f, 30f), "Engine plate");
			if (flag19)
			{
				TpTo("engine plate(Clone)", "PLAYER");
			}
			bool flag20 = GUI.Button(new Rect(140f, 50f, 120f, 30f), "Gearbox");
			if (flag20)
			{
				TpTo("gearbox(Clone)", "PLAYER");
			}
			bool flag21 = GUI.Button(new Rect(140f, 85f, 120f, 30f), "Crankshaft pulley");
			if (flag21)
			{
				TpTo("crankshaft pulley(Clone)", "PLAYER");
			}
			bool flag22 = GUI.Button(new Rect(140f, 120f, 120f, 30f), "Drive gear");
			if (flag22)
			{
				TpTo("drive gear(Clone)", "PLAYER");
			}
			bool flag23 = GUI.Button(new Rect(140f, 155f, 120f, 30f), "Oilpan");
			if (flag23)
			{
				TpTo("oilpan(Clone)", "PLAYER");
			}
			bool flag24 = GUI.Button(new Rect(140f, 190f, 120f, 30f), "Alternator");
			if (flag24)
			{
				TpTo("alternator(Clone)", "PLAYER");
			}
			bool flag25 = GUI.Button(new Rect(140f, 225f, 120f, 30f), "Fan belt");
			if (flag25)
			{
				TpTo("fan belt(Clone)", "PLAYER");
			}
			bool flag26 = GUI.Button(new Rect(140f, 260f, 120f, 30f), "Starter");
			if (flag26)
			{
				TpTo("starter(Clone)", "PLAYER");
			}
			bool flag27 = GUI.Button(new Rect(140f, 295f, 120f, 30f), "Head gasket");
			if (flag27)
			{
				TpTo("head gasket(Clone)", "PLAYER");
			}
			bool flag28 = GUI.Button(new Rect(140f, 330f, 120f, 30f), "Cylinder head");
			if (flag28)
			{
				TpTo("cylinder head(Clone)", "PLAYER");
			}
			bool flag29 = GUI.Button(new Rect(140f, 365f, 120f, 30f), "Rocker shaft");
			if (flag29)
			{
				TpTo("rocker shaft(Clone)", "PLAYER");
			}
			bool flag30 = GUI.Button(new Rect(140f, 400f, 120f, 30f), "Rocker cover");
			if (flag30)
			{
				TpTo("rocker cover(Clone)", "PLAYER");
			}
			bool flag31 = GUI.Button(new Rect(140f, 435f, 120f, 30f), "Distributor");
			if (flag31)
			{
				TpTo("distributor(Clone)", "PLAYER");
			}
			bool flag32 = GUI.Button(new Rect(140f, 470f, 120f, 30f), "Oil filter");
			if (flag32)
			{
				TpTo("oil filter(Clone)", "PLAYER");
			}
			bool flag33 = GUI.Button(new Rect(140f, 505f, 120f, 30f), "Fuel pump");
			if (flag33)
			{
				TpTo("fuel pump(Clone)", "PLAYER");
			}
			bool flag34 = GUI.Button(new Rect(140f, 540f, 120f, 30f), "Headers");
			if (flag34)
			{
				TpTo("headers(Clone)", "PLAYER");
			}
			bool flag35 = GUI.Button(new Rect(140f, 575f, 120f, 30f), "Carburator");
			if (flag35)
			{
				TpTo("carburator(Clone)", "PLAYER");
			}
			bool flag36 = GUI.Button(new Rect(140f, 610f, 120f, 30f), "Air filter");
			if (flag36)
			{
				TpTo("airfilter(Clone)", "PLAYER");
			}
			bool flag37 = GUI.Button(new Rect(140f, 645f, 120f, 30f), "Steel headers");
			if (flag37)
			{
				TpTo("steel headers(Clone)", "PLAYER");
			}
			bool flag38 = GUI.Button(new Rect(140f, 680f, 120f, 30f), "Twin carburators");
			if (flag38)
			{
				TpTo("twin carburators(Clone)", "PLAYER");
			}
			bool flag39 = GUI.Button(new Rect(140f, 715f, 120f, 30f), "Racing carburat.");
			if (flag39)
			{
				TpTo("racing carburators(Clone)", "PLAYER");
			}
			GUI.DragWindow();
		}

		private void WindowTwo9(int windowId)
		{
			bool flag10 = GUI.Button(new Rect(15f, 50f, 120f, 30f), "N2O bottle holder");
			if (flag10)
			{
				TpTo("n2o bottle holder(Clone)", "PLAYER");
			}
			bool flag11 = GUI.Button(new Rect(15f, 85f, 120f, 30f), "N2O bottle");
			if (flag11)
			{
				TpTo("n2o bottle(Clone)", "PLAYER");
			}
			bool flag12 = GUI.Button(new Rect(15f, 120f, 120f, 30f), "N2O button panel");
			if (flag12)
			{
				TpTo("n2o button panel(Clone)", "PLAYER");
			}
			bool flag13 = GUI.Button(new Rect(15f, 155f, 120f, 30f), "N2O injectors");
			if (flag13)
			{
				TpTo("n2o injectors(Clone)", "PLAYER");
			}
			bool flag14 = GUI.Button(new Rect(15f, 190f, 120f, 30f), "Racing flywheel");
			if (flag14)
			{
				TpTo("racing flywheel(Clone)", "PLAYER");
			}
			bool flag15 = GUI.Button(new Rect(15f, 225f, 120f, 30f), "Rocker cover GT");
			if (flag15)
			{
				TpTo("rocker cover gt(Clone)", "PLAYER");
			}
			GUI.DragWindow();
		}

		private void WindowTwo10(int windowId)
		{
			bool flag0 = GUI.Button(new Rect(15f, 50f, 120f, 30f), "Sub frame");
			if (flag0)
			{
				TpTo("sub frame(Clone)", "PLAYER");
			}
			bool flag1 = GUI.Button(new Rect(15f, 85f, 120f, 30f), "Steering rack");
			if (flag1)
			{
				TpTo("steering rack(Clone)", "PLAYER");
			}
			bool flag2 = GUI.Button(new Rect(15f, 120f, 120f, 30f), "Steering column");
			if (flag2)
			{
				TpTo("steering column(Clone)", "PLAYER");
			}
			bool flag3 = GUI.Button(new Rect(15f, 155f, 120f, 30f), "Steering rod FL");
			if (flag3)
			{
				TpTo("steering rod fl(Clone)", "PLAYER");
			}
			bool flag4 = GUI.Button(new Rect(15f, 190f, 120f, 30f), "Steering rod FR");
			if (flag4)
			{
				TpTo("steering rod fr(Clone)", "PLAYER");
			}
			bool flag5 = GUI.Button(new Rect(15f, 225f, 120f, 30f), "Radiator");
			if (flag5)
			{
				TpTo("radiator(Clone)", "PLAYER");
			}
			bool flag6 = GUI.Button(new Rect(15f, 260f, 120f, 30f), "Racing radiator");
			if (flag6)
			{
				TpTo("racing radiator(Clone)", "PLAYER");
			}
			bool flag7 = GUI.Button(new Rect(15f, 295f, 120f, 30f), "Radiator hose 1");
			if (flag7)
			{
				TpTo("radiator hose1(Clone)", "PLAYER");
			}
			bool flag8 = GUI.Button(new Rect(15f, 330f, 120f, 30f), "Radiator hose 2");
			if (flag8)
			{
				TpTo("radiator hose2(Clone)", "PLAYER");
			}
			bool flag9 = GUI.Button(new Rect(15f, 365f, 120f, 30f), "Radiator hose 3");
			if (flag9)
			{
				TpTo("radiator hose3(Clone)", "PLAYER");
			}
			bool flag10 = GUI.Button(new Rect(15f, 400f, 120f, 30f), "Battery");
			if (flag10)
			{
				TpTo("battery(Clone)", "PLAYER");
			}
			bool flag11 = GUI.Button(new Rect(15f, 435f, 120f, 30f), "Electrics");
			if (flag11)
			{
				TpTo("electrics(Clone)", "PLAYER");
			}
			bool flag12 = GUI.Button(new Rect(15f, 470f, 120f, 30f), "Brake lining");
			if (flag12)
			{
				TpTo("brake lining(Clone)", "PLAYER");
			}
			bool flag13 = GUI.Button(new Rect(15f, 505f, 120f, 30f), "Clutch lining");
			if (flag13)
			{
				TpTo("clutch lining(Clone)", "PLAYER");
			}
			bool flag14 = GUI.Button(new Rect(15f, 540f, 120f, 30f), "Brake master cyl.");
			if (flag14)
			{
				TpTo("brake master cylinder(Clone)", "PLAYER");
			}
			bool flag15 = GUI.Button(new Rect(15f, 575f, 120f, 30f), "Clutch master cyl.");
			if (flag15)
			{
				TpTo("clutch master cylinder(Clone)", "PLAYER");
			}
			bool flag16 = GUI.Button(new Rect(15f, 610f, 120f, 30f), "Fuel strainer");
			if (flag16)
			{
				TpTo("fuel strainer(Clone)", "PLAYER");
			}
			bool flag17 = GUI.Button(new Rect(15f, 645f, 120f, 30f), "Gear linkage");
			if (flag17)
			{
				TpTo("gear linkage(Clone)", "PLAYER");
			}
			bool flag18 = GUI.Button(new Rect(15f, 680f, 120f, 30f), "Halfshafts");
			if (flag18)
			{
				GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
				foreach (GameObject findme in allObjects)
				{
					if (findme.name == "halfshaft(Clone)")
					{
						findme.transform.position = new Vector3(GameObject.Find("PLAYER").transform.position.x + 3, GameObject.Find("PLAYER").transform.position.y, GameObject.Find("PLAYER").transform.position.z);
					}
				}
			}
			GUI.DragWindow();
		}

		private void WindowTwo11(int windowId)
		{
			bool flag0 = GUI.Button(new Rect(15f, 50f, 120f, 30f), "RPM gauge");
			if (flag0)
			{
				TpTo("rpm gauge(Clone)", "PLAYER");
			}
			bool flag1 = GUI.Button(new Rect(15f, 85f, 120f, 30f), "Clock gauge");
			if (flag1)
			{
				TpTo("clock gauge(Clone)", "PLAYER");
			}
			bool flag2 = GUI.Button(new Rect(15f, 120f, 120f, 30f), "Fuel mixtur. gauge");
			if (flag2)
			{
				TpTo("fuel mixture gauge(Clone)", "PLAYER");
			}
			bool flag3 = GUI.Button(new Rect(15f, 155f, 120f, 30f), "Extra gauges");
			if (flag3)
			{
				TpTo("extra gauges(Clone)", "PLAYER");
			}
			bool flag4 = GUI.Button(new Rect(15f, 190f, 120f, 30f), "Tachometer");
			if (flag4)
			{
				TpTo("tachometer(Clone)", "PLAYER");
			}
			bool flag5 = GUI.Button(new Rect(15f, 225f, 120f, 30f), "Dashboard meters");
			if (flag5)
			{
				TpTo("dashboard meters(Clone)", "PLAYER");
			}
			GUI.DragWindow();
		}

		private void WindowTwo12(int windowId)
		{
			bool flag0 = GUI.Button(new Rect(15f, 50f, 120f, 30f), "Seat driver");
			if (flag0)
			{
				TpTo("seat driver(Clone)", "PLAYER");
			}
			bool flag1 = GUI.Button(new Rect(15f, 85f, 120f, 30f), "Seat passenger");
			if (flag1)
			{
				TpTo("seat passenger(Clone)", "PLAYER");
			}
			bool flag2 = GUI.Button(new Rect(15f, 120f, 120f, 30f), "Seat rear");
			if (flag2)
			{
				TpTo("seat rear(Clone)", "PLAYER");
			}
			bool flag3 = GUI.Button(new Rect(15f, 155f, 120f, 30f), "Dashboard");
			if (flag3)
			{
				TpTo("dashboard(Clone)", "PLAYER");
			}
			bool flag4 = GUI.Button(new Rect(15f, 190f, 120f, 30f), "Stock steer. wheel");
			if (flag4)
			{
				TpTo("stock steering wheel(Clone)", "PLAYER");
			}
			bool flag5 = GUI.Button(new Rect(15f, 225f, 120f, 30f), "Gear stick");
			if (flag5)
			{
				TpTo("gear stick(Clone)", "PLAYER");
			}
			bool flag6 = GUI.Button(new Rect(15f, 260f, 120f, 30f), "Handbrake");
			if (flag6)
			{
				TpTo("handbrake(Clone)", "PLAYER");
			}
			bool flag7 = GUI.Button(new Rect(15f, 295f, 120f, 30f), "Radio");
			if (flag7)
			{
				TpTo("radio(Clone)", "PLAYER");
			}
			bool flag8 = GUI.Button(new Rect(15f, 330f, 120f, 30f), "CD player");
			if (flag8)
			{
				TpTo("cd player(Clone)", "PLAYER");
			}
			bool flag9 = GUI.Button(new Rect(15f, 365f, 120f, 30f), "Back panel");
			if (flag9)
			{
				TpTo("back panel(Clone)", "PLAYER");
			}
			bool flag10 = GUI.Button(new Rect(15f, 400f, 120f, 30f), "Subwoofer panel");
			if (flag10)
			{
				TpTo("subwoofer panel(Clone)", "PLAYER");
			}
			bool flag11 = GUI.Button(new Rect(15f, 435f, 120f, 30f), "Subwoofer left");
			if (flag11)
			{
				TpTo("subwoofer left(Clone)", "PLAYER");
			}
			bool flag12 = GUI.Button(new Rect(15f, 470f, 120f, 30f), "Subwoofer right");
			if (flag12)
			{
				TpTo("subwoofer right(Clone)", "PLAYER");
			}
			bool flag13 = GUI.Button(new Rect(15f, 505f, 120f, 30f), "Wheel cov. leop.");
			if (flag13)
			{
				TpTo("wheel cover leopard(Clone)", "PLAYER");
			}
			bool flag14 = GUI.Button(new Rect(15f, 540f, 120f, 30f), "Wheel cov. plush");
			if (flag14)
			{
				TpTo("wheel cover plush(Clone)", "PLAYER");
			}
			bool flag15 = GUI.Button(new Rect(15f, 575f, 120f, 30f), "Wheel cov. zebra");
			if (flag15)
			{
				TpTo("wheel cover zebra(Clone)", "PLAYER");
			}
			bool flag16 = GUI.Button(new Rect(15f, 610f, 120f, 30f), "Dash cov. leopard");
			if (flag16)
			{
				TpTo("dash cover leopard(Clone)", "PLAYER");
			}
			bool flag17 = GUI.Button(new Rect(15f, 645f, 120f, 30f), "Dash cov. plush");
			if (flag17)
			{
				TpTo("dash cover plush(Clone)", "PLAYER");
			}
			bool flag18 = GUI.Button(new Rect(15f, 680f, 120f, 30f), "Dash cov. zebra");
			if (flag18)
			{
				TpTo("dash cover zebra(Clone)", "PLAYER");
			}
			bool flag19 = GUI.Button(new Rect(15f, 715f, 120f, 30f), "Seat cov. leopard");
			if (flag19)
			{
				TpTo("seat cover leopard(Clone)", "PLAYER");
			}
			bool flag20 = GUI.Button(new Rect(140f, 50f, 120f, 30f), "Seat cov. plush");
			if (flag20)
			{
				TpTo("seat cover plush(Clone)", "PLAYER");
			}
			bool flag21 = GUI.Button(new Rect(140f, 85f, 120f, 30f), "Seat cov. zebra");
			if (flag21)
			{
				TpTo("seat cover zebra(Clone)", "PLAYER");
			}
			bool flag22 = GUI.Button(new Rect(140f, 120f, 120f, 30f), "Bucket seat driver");
			if (flag22)
			{
				TpTo("bucket seat driver(Clone)", "PLAYER");
			}
			bool flag23 = GUI.Button(new Rect(140f, 155f, 120f, 30f), "Bucket seat pass.");
			if (flag23)
			{
				TpTo("bucket seat passenger(Clone)", "PLAYER");
			}
			bool flag24 = GUI.Button(new Rect(140f, 190f, 120f, 30f), "Racing harness");
			if (flag24)
			{
				TpTo("racing harness(Clone)", "PLAYER");
			}
			bool flag25 = GUI.Button(new Rect(140f, 225f, 120f, 30f), "Sport steer. wheel");
			if (flag25)
			{
				TpTo("sport steering wheel(Clone)", "PLAYER");
			}
			bool flag26 = GUI.Button(new Rect(140f, 260f, 120f, 30f), "Rally steer. wheel");
			if (flag26)
			{
				TpTo("rally steering wheel(Clone)", "PLAYER");
			}
			bool flag27 = GUI.Button(new Rect(140f, 295f, 120f, 30f), "Seat cov. Suomi");
			if (flag27)
			{
				TpTo("seat cover suomi(Clone)", "PLAYER");
			}
			bool flag28 = GUI.Button(new Rect(140f, 330f, 120f, 30f), "Dash cov. Suomi");
			if (flag28)
			{
				TpTo("dash cover suomi(Clone)", "PLAYER");
			}
			bool flag29 = GUI.Button(new Rect(140f, 365f, 120f, 30f), "Wheel cov. Suomi");
			if (flag29)
			{
				TpTo("wheel cover suomi(Clone)", "PLAYER");
			}
			bool flag30 = GUI.Button(new Rect(140f, 400f, 120f, 30f), "Amplifier");
			if (flag30)
			{
				TpTo("amplifier(Clone)", "PLAYER");
			}
			bool flag31 = GUI.Button(new Rect(140f, 435f, 120f, 30f), "Center console GT");
			if (flag31)
			{
				TpTo("center console gt(Clone)", "PLAYER");
			}
			bool flag32 = GUI.Button(new Rect(140f, 470f, 120f, 30f), "GT steering wheel");
			if (flag32)
			{
				TpTo("gt steering wheel(Clone)", "PLAYER");
			}
			GUI.DragWindow();
		}

		private void WindowTwo13(int windowId)
		{
			bool flag0 = GUI.Button(new Rect(15f, 50f, 120f, 30f), "Satsuma");
			if (flag0)
			{
				TpTo("SATSUMA(557kg, 248)", "PLAYER");
			}
			bool flag1 = GUI.Button(new Rect(15f, 85f, 120f, 30f), "Hayosiko");
			if (flag1)
			{
				TpTo("HAYOSIKO(1500kg, 250)", "PLAYER");
			}
			bool flag2 = GUI.Button(new Rect(15f, 120f, 120f, 30f), "Jonnez ES");
			if (flag2)
			{
				TpTo("JONNEZ ES(Clone)", "PLAYER");
			}
			bool flag3 = GUI.Button(new Rect(15f, 155f, 120f, 30f), "Ferndale");
			if (flag3)
			{
				TpTo("FERNDALE(1630kg)", "PLAYER");
			}
			bool flag4 = GUI.Button(new Rect(15f, 190f, 120f, 30f), "RCO Ruscko");
			if (flag4)
			{
				TpTo("RCO_RUSCKO12(270)", "PLAYER");
			}
			bool flag5 = GUI.Button(new Rect(15f, 225f, 120f, 30f), "Gifu");
			if (flag5)
			{
				TpTo("GIFU(750/450psi)", "PLAYER");
			}
			bool flag6 = GUI.Button(new Rect(15f, 260f, 120f, 30f), "Kekmet");
			if (flag6)
			{
				TpTo("KEKMET(350-400psi)", "PLAYER");
			}
			GUI.Label(new Rect(15f, 360f + labeloffset, 120f, 130f), "Do not teleport Gifu if it on a handbrake!");
			bool flag7 = GUI.Button(new Rect(15f, 400f, 120f, 30f), "EDM");
			if (flag7)
            {
				TpTo("EDM(Clone)", "PLAYER");
            }
			GUI.DragWindow();
		}

		private void WindowTwo14(int windowId)
		{
			bool flag0 = GUI.Button(new Rect(15f, 50f, 120f, 30f), "2 hour = 2 sec");
			if (flag0)
			{
				GameObject.Find("MAP/SUN/Pivot/SUN").GetComponent<PlayMakerFSM>().FsmVariables.GetFsmFloat("Timescale").Value = 2;
			}
			bool flag1 = GUI.Button(new Rect(140f, 50f, 120f, 30f), "2 hour = 1 hour");
			if (flag1)
			{
				GameObject.Find("MAP/SUN/Pivot/SUN").GetComponent<PlayMakerFSM>().FsmVariables.GetFsmFloat("Timescale").Value = 3600;
			}
			bool flag2 = GUI.Button(new Rect(15f, 85f, 120f, 30f), "2 hour = 30 min");
			if (flag2)
			{
				GameObject.Find("MAP/SUN/Pivot/SUN").GetComponent<PlayMakerFSM>().FsmVariables.GetFsmFloat("Timescale").Value = 1800;
			}
			bool flag3 = GUI.Button(new Rect(140f, 85f, 120f, 30f), "2 hour = 10 hour");
			if (flag3)
			{
				GameObject.Find("MAP/SUN/Pivot/SUN").GetComponent<PlayMakerFSM>().FsmVariables.GetFsmFloat("Timescale").Value = 36000;
			}
			bool flag4 = GUI.Button(new Rect(15f, 120f, 245f, 30f), "Default (2 hour = 10 min)");
			if (flag4)
			{
				GameObject.Find("MAP/SUN/Pivot/SUN").GetComponent<PlayMakerFSM>().FsmVariables.GetFsmFloat("Timescale").Value = 600;
			}
			GUI.Label(new Rect(15f, 155f + labeloffset, 245f, 40f), "Time scaler does not affect for post order, repair works and etc!");
			bool flag5 = GUI.Button(new Rect(15f, 225f, 245f, 30f), "Skip uncle and get keys");
			if (flag5)
			{
				GameObject.Find("YARD/UNCLE").GetComponents<PlayMakerFSM>()[0].FsmVariables.GetFsmInt("UncleStage").Value = 5;
				GameObject.Find("HAYOSIKO(1500kg, 250)").transform.position = new Vector3(21.70911f, -0.2273984f, -48.85026f);
				GameObject.Find("HAYOSIKO(1500kg, 250)").transform.localEulerAngles = new Vector3(0.1971622f, 90.00047f, 0.03927361f);
				PlayMakerFSM.BroadcastEvent("SAVEGAME");
				Application.LoadLevel("MainMenu");
			}
			GUI.Label(new Rect(15f, 260f + labeloffset, 245f, 40f), "Game will be saved! Van will be teleport to uncle.");
			bool flag6 = GUI.Button(new Rect(15f, 330f, 245f, 30f), "Skip post order wait");
			if (flag6)
			{
				GameObject.Find("Sheets/OrderList/Timer").GetComponent<PlayMakerFSM>().SendEvent("FINISHED");
			}

			bool flag7 = GUI.Button(new Rect(15f, 400f, 245f, 30f), "Skip repair work wait");
			if (flag7)
			{
				GameObject.Find("REPAIRSHOP/Order").GetComponent<PlayMakerFSM>().FsmVariables.GetFsmFloat("_OrderTime").Value = 0;
				if (GameObject.Find("REPAIRSHOP/Order").GetComponent<PlayMakerFSM>().FsmVariables.GetFsmFloat("Distance").Value < 110)
				{
					GameObject.Find("PLAYER").transform.position = new Vector3(GameObject.Find("PLAYER").transform.position.x, GameObject.Find("PLAYER").transform.position.y + 300, GameObject.Find("PLAYER").transform.position.z);
				}
			}
			GUI.Label(new Rect(15f, 435f + labeloffset, 245f, 40f), "If player near repair shop he will be do big jump!");
		}

		private void Window(int windowId)
		{
			bool flag0 = GUI.Button(new Rect(380f, 750f, 60f, 30f), "Close");
			if (flag0)
			{
				GuiShow();
			}
			GUI.Label(new Rect(100f, 25f + labeloffset, 120f, 30f), "Teleports me to");
			GUI.Label(new Rect(15f, 55f + labeloffset, 120f, 30f), "L.CTRL + 1");
			bool flag1 = GUI.Button(new Rect(85f, 50f, 120f, 30f), "Home");
			if (flag1)
			{
				GameObject.Find("PLAYER").transform.position = new Vector3(-14.09386f, -0.293822f, 10.11526f);
			}
			GUI.Label(new Rect(15f, 90f + labeloffset, 120f, 30f), "L.CTRL + 2");
			bool flag2 = GUI.Button(new Rect(85f, 85f, 120f, 30f), "Store");
			if (flag2)
			{
				TpTo("PLAYER", "SpawnToStore");
			}
			GUI.Label(new Rect(15f, 125f + labeloffset, 120f, 30f), "L.CTRL + 3");
			bool flag3 = GUI.Button(new Rect(85f, 120f, 120f, 30f), "Repair shop");
			if (flag3)
			{
				TpTo("PLAYER", "SpawnToRepair");
			}
			GUI.Label(new Rect(15f, 160f + labeloffset, 120f, 30f), "L.CTRL + 4");
			bool flag4 = GUI.Button(new Rect(85f, 155f, 120f, 30f), "Drag");
			if (flag4)
			{
				TpTo("PLAYER", "SpawnToDrag");
			}
			GUI.Label(new Rect(15f, 195f + labeloffset, 120f, 30f), "L.CTRL + 5");
			bool flag5 = GUI.Button(new Rect(85f, 190f, 120f, 30f), "Cottage");
			if (flag5)
			{
				TpTo("PLAYER", "SpawnToCottage");
			}
			GUI.Label(new Rect(15f, 230f + labeloffset, 120f, 30f), "L.CTRL + 6");
			bool flag06 = GUI.Button(new Rect(85f, 225f, 120f, 30f), "Ventti pig");
			if (flag06)
			{
				TpTo("PLAYER", "SpawnToVenttiPig");
			}
			GUI.Label(new Rect(15f, 265f + labeloffset, 120f, 30f), "L.CTRL + 7");
			bool flag6 = GUI.Button(new Rect(85f, 260f, 120f, 30f), "Dance");
			if (flag6)
			{
				TpTo("PLAYER", "SpawnToDance");
			}
			GUI.Label(new Rect(15f, 300f + labeloffset, 120f, 30f), "L.CTRL + 8");
			bool flag14 = GUI.Button(new Rect(85f, 295f, 120f, 30f), "Kilju guy");
			if (flag14)
			{
				GameObject.Find("PLAYER").transform.position = new Vector3(1949.648f, 7.290094f, -212.2388f);
			}
			GUI.Label(new Rect(15f, 335f + labeloffset, 120f, 30f), "L.CTRL + 9");
			bool flag15 = GUI.Button(new Rect(85f, 330f, 120f, 30f), "Grandma");
			if (flag15)
			{
				GameObject.Find("PLAYER").transform.position = new Vector3(451.21f, 3.00109f, -1333.738f);
			}
			GUI.Label(new Rect(15f, 370f + labeloffset, 120f, 30f), "L.CTRL + 0");
			bool flag7 = GUI.Button(new Rect(85f, 365f, 120f, 30f), "Satsuma");
			if (flag7)
			{
				TpTo("PLAYER", "SATSUMA(557kg, 248)");
			}
			GUI.Label(new Rect(12f, 405f + labeloffset, 120f, 30f), "R.CTRL + 0");
			bool flag8 = GUI.Button(new Rect(85f, 400f, 120f, 30f), "Hayosiko");
			if (flag8)
			{
				TpTo("PLAYER", "HAYOSIKO(1500kg, 250)");
			}
			GUI.Label(new Rect(12f, 440f + labeloffset, 120f, 30f), "R.CTRL + 9");
			bool flag9 = GUI.Button(new Rect(85f, 435f, 120f, 30f), "Ruscko");
			if (flag9)
			{
				TpTo("PLAYER", "RCO_RUSCKO12(270)");
			}
			GUI.Label(new Rect(12f, 475f + labeloffset, 120f, 30f), "R.CTRL + 8");
			bool flag10 = GUI.Button(new Rect(85f, 470f, 120f, 30f), "Ferndale");
			if (flag10)
			{
				TpTo("PLAYER", "FERNDALE(1630kg)");
			}
			GUI.Label(new Rect(12f, 510f + labeloffset, 120f, 30f), "R.CTRL + 7");
			bool flag11 = GUI.Button(new Rect(85f, 505f, 120f, 30f), "Jonnez ES");
			if (flag11)
			{
				TpTo("PLAYER", "JONNEZ ES(Clone)");
			}
			GUI.Label(new Rect(12f, 545f + labeloffset, 120f, 30f), "R.CTRL + 6");
			bool flag12 = GUI.Button(new Rect(85f, 540f, 120f, 30f), "Gifu");
			if (flag12)
			{
				TpTo("PLAYER", "GIFU(750/450psi)");
			}
			GUI.Label(new Rect(12f, 580f + labeloffset, 120f, 30f), "R.CTRL + 5");
			bool flag13 = GUI.Button(new Rect(85f, 575f, 120f, 30f), "Kekmet");
			if (flag13)
			{
				TpTo("PLAYER", "KEKMET(350-400psi)");
			}
			GUI.Label(new Rect(12f, 615f + labeloffset, 120f, 30f), "R.CTRL + 4");
			bool flag16 = GUI.Button(new Rect(85f, 610f, 120f, 30f), "Flatbed");
			if (flag16)
			{
				TpTo("PLAYER", "FLATBED");
			}
			GUI.Label(new Rect(12f, 650f + labeloffset, 120f, 30f), "NONE");
			bool flag17 = GUI.Button(new Rect(85f, 645f, 120f, 30f), "EDM");
			if (flag17)
			{
				TpTo("PLAYER", "EDM(Clone)");
			}
			GUI.Label(new Rect(250f, 25f + labeloffset, 120f, 30f), "Needs");
			bool flag18 = GUI.Button(new Rect(210f, 50f, 120f, 30f), "off/on needs");
			if (flag18)
			{
				this.needs = !this.needs;
			}
			bool flag19 = GUI.Button(new Rect(210f, 85f, 120f, 30f), "Set full fatigue");
			if (flag19)
			{
				this.needs = false;
				FsmVariables.GlobalVariables.FindFsmFloat("PlayerFatigue").Value = 100f;
			}
			GUI.Label(new Rect(250f, 130f + labeloffset, 120f, 30f), "Money");
			bool flag20 = GUI.Button(new Rect(210f, 155f, 120f, 30f), "Set 3 000mk");
			if (flag20)
			{
				FsmVariables.GlobalVariables.FindFsmFloat("PlayerMoney").Value = 3000;
			}
			bool flag21 = GUI.Button(new Rect(210f, 190f, 120f, 30f), "Set 50 000mk");
			if (flag21)
			{
				FsmVariables.GlobalVariables.FindFsmFloat("PlayerMoney").Value = 50000;
			}
			bool flag22 = GUI.Button(new Rect(210f, 225f, 120f, 30f), "Set 500 000mk");
			if (flag22)
			{
				FsmVariables.GlobalVariables.FindFsmFloat("PlayerMoney").Value = 500000;
			}
			GUI.Label(new Rect(232f, 270f + labeloffset, 120f, 30f), "Day of week");
			bool flag23 = GUI.Button(new Rect(210f, 295f, 120f, 30f), "Monday");
			if (flag23)
			{
				FsmVariables.GlobalVariables.FindFsmInt("GlobalDay").Value = 1;
			}
			bool flag24 = GUI.Button(new Rect(210f, 330f, 120f, 30f), "Tuesday");
			if (flag24)
			{
				FsmVariables.GlobalVariables.FindFsmInt("GlobalDay").Value = 2;
			}
			bool flag25 = GUI.Button(new Rect(210f, 365f, 120f, 30f), "Wednesday");
			if (flag25)
			{
				FsmVariables.GlobalVariables.FindFsmInt("GlobalDay").Value = 3;
			}
			bool flag26 = GUI.Button(new Rect(210f, 400f, 120f, 30f), "Thursday");
			if (flag26)
			{
				FsmVariables.GlobalVariables.FindFsmInt("GlobalDay").Value = 4;
			}
			bool flag27 = GUI.Button(new Rect(210f, 435f, 120f, 30f), "Friday");
			if (flag27)
			{
				FsmVariables.GlobalVariables.FindFsmInt("GlobalDay").Value = 5;
			}
			bool flag28 = GUI.Button(new Rect(210f, 470f, 120f, 30f), "Saturday");
			if (flag28)
			{
				FsmVariables.GlobalVariables.FindFsmInt("GlobalDay").Value = 6;
			}
			bool flag29 = GUI.Button(new Rect(210f, 505f, 120f, 30f), "Sunday");
			if (flag29)
			{
				FsmVariables.GlobalVariables.FindFsmInt("GlobalDay").Value = 7;
			}
			bool flag43 = GUI.Button(new Rect(210f, 575f, 120f, 30f), "TimeScaler & skip");
			if (flag43)
			{
				windowTwoStatus = false;
				windowTwo2Status = false;
				windowTwo3Status = false;
				windowTwo4Status = false;
				windowTwo5Status = false;
				windowTwo6Status = false;
				windowTwo7Status = false;
				windowTwo8Status = false;
				windowTwo9Status = false;
				windowTwo9Status = false;
				windowTwo10Status = false;
				windowTwo11Status = false;
				windowTwo12Status = false;
				windowTwo13Status = false;

				this.windowTwo14Status = !this.windowTwo14Status;
			}
			bool flag44 = GUI.Button(new Rect(210f, 645f, 120f, 30f), "Save game");
			if (flag44)
			{
				PlayMakerFSM.BroadcastEvent("SAVEGAME");
				Application.LoadLevel("MainMenu");
			}
			bool flag45 = GUI.Button(new Rect(210f, 715f, 120f, 30f), "Cops on highway");
			if (flag45)
			{
				GameObject.Find("TRAFFIC/Police").transform.GetChild(0).gameObject.SetActive(true);
			}
			GUI.Label(new Rect(350f, 25f + labeloffset, 120f, 30f), "Teleports to me");
			bool flag30 = GUI.Button(new Rect(335f, 50f, 120f, 30f), "Tools");
			if (flag30)
			{
				windowTwo2Status = false;
				windowTwo3Status = false;
				windowTwo4Status = false;
				windowTwo5Status = false;
				windowTwo6Status = false;
				windowTwo7Status = false;
				windowTwo8Status = false;
				windowTwo9Status = false;
				windowTwo10Status = false;
				windowTwo11Status = false;
				windowTwo12Status = false;
				windowTwo13Status = false;
				windowTwo14Status = false;

				this.windowTwoStatus = !this.windowTwoStatus;
			}
			bool flag31 = GUI.Button(new Rect(335f, 85f, 120f, 30f), "Car items");
			if (flag31)
			{
				windowTwoStatus = false;
				windowTwo3Status = false;
				windowTwo4Status = false;
				windowTwo5Status = false;
				windowTwo6Status = false;
				windowTwo7Status = false;
				windowTwo8Status = false;
				windowTwo9Status = false;
				windowTwo10Status = false;
				windowTwo11Status = false;
				windowTwo12Status = false;
				windowTwo13Status = false;
				windowTwo14Status = false;

				this.windowTwo2Status = !this.windowTwo2Status;
			}
			bool flag32 = GUI.Button(new Rect(335f, 120f, 120f, 30f), "Items");
			if (flag32)
			{
				windowTwoStatus = false;
				windowTwo2Status = false;
				windowTwo4Status = false;
				windowTwo5Status = false;
				windowTwo6Status = false;
				windowTwo7Status = false;
				windowTwo8Status = false;
				windowTwo9Status = false;
				windowTwo10Status = false;
				windowTwo11Status = false;
				windowTwo12Status = false;
				windowTwo13Status = false;
				windowTwo14Status = false;

				this.windowTwo3Status = !this.windowTwo3Status;
			}
			bool flag33 = GUI.Button(new Rect(335f, 155f, 120f, 30f), "Suspension");
			if (flag33)
			{
				windowTwoStatus = false;
				windowTwo2Status = false;
				windowTwo3Status = false;
				windowTwo5Status = false;
				windowTwo6Status = false;
				windowTwo7Status = false;
				windowTwo8Status = false;
				windowTwo9Status = false;
				windowTwo10Status = false;
				windowTwo11Status = false;
				windowTwo12Status = false;
				windowTwo13Status = false;
				windowTwo14Status = false;

				this.windowTwo4Status = !this.windowTwo4Status;
			}
			bool flag34 = GUI.Button(new Rect(335f, 190f, 120f, 30f), "Exhaust & fuel");
			if (flag34)
			{
				windowTwoStatus = false;
				windowTwo2Status = false;
				windowTwo3Status = false;
				windowTwo4Status = false;
				windowTwo6Status = false;
				windowTwo7Status = false;
				windowTwo8Status = false;
				windowTwo9Status = false;
				windowTwo10Status = false;
				windowTwo11Status = false;
				windowTwo12Status = false;
				windowTwo13Status = false;
				windowTwo14Status = false;

				this.windowTwo5Status = !this.windowTwo5Status;
			}
			bool flag35 = GUI.Button(new Rect(335f, 225f, 120f, 30f), "Body parts");
			if (flag35)
			{
				windowTwoStatus = false;
				windowTwo2Status = false;
				windowTwo3Status = false;
				windowTwo4Status = false;
				windowTwo5Status = false;
				windowTwo7Status = false;
				windowTwo8Status = false;
				windowTwo9Status = false;
				windowTwo10Status = false;
				windowTwo11Status = false;
				windowTwo12Status = false;
				windowTwo13Status = false;
				windowTwo14Status = false;

				this.windowTwo6Status = !this.windowTwo6Status;
			}
			bool flag36 = GUI.Button(new Rect(335f, 260f, 120f, 30f), "Wheels");
			if (flag36)
			{
				windowTwoStatus = false;
				windowTwo2Status = false;
				windowTwo3Status = false;
				windowTwo4Status = false;
				windowTwo5Status = false;
				windowTwo6Status = false;
				windowTwo8Status = false;
				windowTwo9Status = false;
				windowTwo10Status = false;
				windowTwo11Status = false;
				windowTwo12Status = false;
				windowTwo13Status = false;
				windowTwo14Status = false;

				this.windowTwo7Status = !this.windowTwo7Status;
			}
			bool flag37 = GUI.Button(new Rect(335f, 295f, 120f, 30f), "Engine parts");
			if (flag37)
			{
				windowTwoStatus = false;
				windowTwo2Status = false;
				windowTwo3Status = false;
				windowTwo4Status = false;
				windowTwo5Status = false;
				windowTwo6Status = false;
				windowTwo7Status = false;
				windowTwo9Status = false;
				windowTwo10Status = false;
				windowTwo11Status = false;
				windowTwo12Status = false;
				windowTwo13Status = false;
				windowTwo14Status = false;

				this.windowTwo8Status = !this.windowTwo8Status;
			}
			bool flag38 = GUI.Button(new Rect(335f, 330f, 120f, 30f), "Engine parts 2");
			if (flag38)
			{
				windowTwoStatus = false;
				windowTwo2Status = false;
				windowTwo3Status = false;
				windowTwo4Status = false;
				windowTwo5Status = false;
				windowTwo6Status = false;
				windowTwo7Status = false;
				windowTwo8Status = false;
				windowTwo10Status = false;
				windowTwo11Status = false;
				windowTwo12Status = false;
				windowTwo13Status = false;
				windowTwo14Status = false;

				this.windowTwo9Status = !this.windowTwo9Status;
			}
			bool flag39 = GUI.Button(new Rect(335f, 365f, 120f, 30f), "Engine bay");
			if (flag39)
			{
				windowTwoStatus = false;
				windowTwo2Status = false;
				windowTwo3Status = false;
				windowTwo4Status = false;
				windowTwo5Status = false;
				windowTwo6Status = false;
				windowTwo7Status = false;
				windowTwo8Status = false;
				windowTwo9Status = false;
				windowTwo11Status = false;
				windowTwo12Status = false;
				windowTwo13Status = false;
				windowTwo14Status = false;

				this.windowTwo10Status = !this.windowTwo10Status;
			}
			bool flag40 = GUI.Button(new Rect(335f, 400f, 120f, 30f), "Gauges");
			if (flag40)
			{
				windowTwoStatus = false;
				windowTwo2Status = false;
				windowTwo3Status = false;
				windowTwo4Status = false;
				windowTwo5Status = false;
				windowTwo6Status = false;
				windowTwo7Status = false;
				windowTwo8Status = false;
				windowTwo9Status = false;
				windowTwo9Status = false;
				windowTwo10Status = false;
				windowTwo12Status = false;
				windowTwo13Status = false;
				windowTwo14Status = false;

				this.windowTwo11Status = !this.windowTwo11Status;
			}
			bool flag41 = GUI.Button(new Rect(335f, 435f, 120f, 30f), "Interior");
			if (flag41)
			{
				windowTwoStatus = false;
				windowTwo2Status = false;
				windowTwo3Status = false;
				windowTwo4Status = false;
				windowTwo5Status = false;
				windowTwo6Status = false;
				windowTwo7Status = false;
				windowTwo8Status = false;
				windowTwo9Status = false;
				windowTwo9Status = false;
				windowTwo10Status = false;
				windowTwo11Status = false;
				windowTwo13Status = false;
				windowTwo14Status = false;

				this.windowTwo12Status = !this.windowTwo12Status;
			}
			bool flag42 = GUI.Button(new Rect(335f, 470f, 120f, 30f), "Cars");
			if (flag42)
			{
				windowTwoStatus = false;
				windowTwo2Status = false;
				windowTwo3Status = false;
				windowTwo4Status = false;
				windowTwo5Status = false;
				windowTwo6Status = false;
				windowTwo7Status = false;
				windowTwo8Status = false;
				windowTwo9Status = false;
				windowTwo9Status = false;
				windowTwo10Status = false;
				windowTwo11Status = false;
				windowTwo12Status = false;
				windowTwo14Status = false;

				this.windowTwo13Status = !this.windowTwo13Status;
			}
		}

		public override void Update()
		{
			if (CheatsGuiKey.GetKeybindDown()) { GuiShow(); };
			if (teleportKey1.GetKeybindDown()) { Telep1(); };
			if (teleportKey2.GetKeybindDown()) { Telep2(); };
			if (teleportKey3.GetKeybindDown()) { Telep3(); };
			if (teleportKey4.GetKeybindDown()) { Telep4(); };
			if (teleportKey5.GetKeybindDown()) { Telep5(); };
			if (teleportKey6.GetKeybindDown()) { Telep6(); };
			if (teleportKey7.GetKeybindDown()) { Telep7(); };
			if (teleport0Key8.GetKeybindDown()) { Telep8(); };
			if (teleport0Key9.GetKeybindDown()) { Telep9(); };
			if (teleport0Key10.GetKeybindDown()) { Telep10(); };
			if (teleport0Key11.GetKeybindDown()) { Telep11(); };
			if (teleport0Key12.GetKeybindDown()) { Telep12(); };
			if (teleport0Key13.GetKeybindDown()) { Telep13(); };
			if (teleport0Key14.GetKeybindDown()) { Telep14(); };
			if (teleport0Key15.GetKeybindDown()) { Telep15(); };
			if (teleport0Key16.GetKeybindDown()) { Telep16(); };
			if (teleport0Key17.GetKeybindDown()) { Telep17(); };

			if (needs)
			{
				this.PLAYER = GameObject.Find("PLAYER");

				PlayMakerFSM[] componentsInChildren = this.PLAYER.GetComponentsInChildren<PlayMakerFSM>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					PlayMakerFSM playMakerFSM = componentsInChildren[i];
					if (playMakerFSM.name == "PlayerStress")
					{
						playMakerFSM.enabled = false;
					}

					if (playMakerFSM.name == "PlayerStressRate")
					{
						playMakerFSM.enabled = false;
					}
				}

				FsmVariables.GlobalVariables.FindFsmFloat("PlayerFatigue").Value = 0.0f;
				FsmVariables.GlobalVariables.FindFsmFloat("PlayerDirtiness").Value = 0.0f;
				FsmVariables.GlobalVariables.FindFsmFloat("PlayerDrunk").Value = 0.0f;
				FsmVariables.GlobalVariables.FindFsmFloat("PlayerHunger").Value = 0.0f;
				FsmVariables.GlobalVariables.FindFsmFloat("PlayerThirst").Value = 0.0f;
				FsmVariables.GlobalVariables.FindFsmFloat("PlayerUrine").Value = 0.0f;
				FsmVariables.GlobalVariables.FindFsmFloat("PlayerStress").Value = 0.0f;
				FsmVariables.GlobalVariables.FindFsmFloat("PlayerStressRate").Value = 0.0f;
			}
		}

		private void GuiShow()
		{
			this.guiShow = !this.guiShow;

			if (guiShow)
			{
				FsmVariables.GlobalVariables.FindFsmBool("PlayerInMenu").Value = true;
			}
			else
			{
				FsmVariables.GlobalVariables.FindFsmBool("PlayerInMenu").Value = false;
			}
		}

		private void TpTo(string tpObject, string tptoObject)
		{
			var posFinder = GameObject.Find(tptoObject);
			Vector3 newPlayerPos = new Vector3(posFinder.transform.position.x + 3, posFinder.transform.position.y, posFinder.transform.position.z);
			GameObject.Find(tpObject).transform.position = newPlayerPos;
			GameObject.Find(tpObject).transform.rotation = new Quaternion(0, 0, 0, 0);
		}

		private void TpMe2(string tpObject, string tptoObject)
		{
			var posFinder = GameObject.Find(tptoObject);
			Vector3 newCarPos = new Vector3(posFinder.transform.position.x + 3, posFinder.transform.position.y - 0.15f, posFinder.transform.position.z);
			GameObject.Find(tpObject).transform.position = newCarPos;
		}

		private void TpMe3(string tpObject, string tptoObject)
		{
			var posFinder = GameObject.Find(tptoObject);
			Vector3 newCarPos = new Vector3(posFinder.transform.position.x + 3, posFinder.transform.position.y - 0.22f, posFinder.transform.position.z);
			GameObject.Find(tpObject).transform.position = newCarPos;
		}

		private void Telep1()
		{
			if (guiShow)
			{
				GameObject.Find("PLAYER").transform.position = new Vector3(-14.09386f, -0.293822f, 10.11526f);
			}
		}

		private void Telep2()
		{
			if (guiShow)
			{
				TpTo("PLAYER", "SpawnToStore");
			}
		}

		private void Telep3()
		{
			if (guiShow)
			{
				TpTo("PLAYER", "SpawnToRepair");
			}
		}

		private void Telep4()
		{
			if (guiShow)
			{
				TpTo("PLAYER", "SpawnToDrag");
			}
		}

		private void Telep5()
		{
			if (guiShow)
			{
				TpTo("PLAYER", "SpawnToCottage");
			}
		}

		private void Telep6()
		{
			if (guiShow)
			{
				TpTo("PLAYER", "SpawnToVenttiPig");
			}
		}

		private void Telep7()
		{
			if (guiShow)
			{
				TpTo("PLAYER", "SpawnToDance");
			}
		}

		private void Telep8()
		{
			if (guiShow)
			{
				GameObject.Find("PLAYER").transform.position = new Vector3(1949.648f, 7.290094f, -212.2388f);
			}
		}

		private void Telep9()
		{
			if (guiShow)
			{
				GameObject.Find("PLAYER").transform.position = new Vector3(451.21f, 3.00109f, -1333.738f);
			}
		}

		private void Telep10()
		{
			if (guiShow)
			{
				TpTo("PLAYER", "SATSUMA(557kg, 248)");
			}
		}

		private void Telep11()
		{
			if (guiShow)
			{
				TpTo("PLAYER", "HAYOSIKO(1500kg, 250)");
			}
		}

		private void Telep12()
		{
			if (guiShow)
			{
				TpTo("PLAYER", "RCO_RUSCKO12(270)");
			}
		}

		private void Telep13()
		{
			if (guiShow)
			{
				TpTo("PLAYER", "FERNDALE(1630kg)");
			}
		}

		private void Telep14()
		{
			if (guiShow)
			{
				TpTo("PLAYER", "JONNEZ ES(Clone)");
			}
		}

		private void Telep15()
		{
			if (guiShow)
			{
				TpTo("PLAYER", "GIFU(750/450psi)");
			}
		}

		private void Telep16()
		{
			if (guiShow)
			{
				TpTo("PLAYER", "KEKMET(350-400psi)");
			}
		}

		private void Telep17()
		{
			if (guiShow)
			{
				TpTo("PLAYER", "FLATBED");
			}
		}
	}
}
