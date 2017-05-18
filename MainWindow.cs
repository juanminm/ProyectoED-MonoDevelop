using System;
using Gtk;
using System.Collections.Generic;

public partial class MainWindow: Gtk.Window
{	
	bool isAITurn = false;
	private IList<Button> enabledButtons;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		enabledButtons = new List<Button> (new Button[] {A1, A2, A3, B1, B2, B3,
			C1, C2, C3});
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void onA1Click (object sender, EventArgs e)
	{
		A1.Sensitive = false;
		A1.Label = "O";
		enabledButtons.Remove (A1);
		isAITurn = true;
		checkMatch ();
	}

	protected void onA2Click (object sender, EventArgs e)
	{
		A2.Sensitive = false;
		A2.Label = "O";
		enabledButtons.Remove (A2);
		isAITurn = true;
		checkMatch ();
	}

	protected void onA3Click (object sender, EventArgs e)
	{
		A3.Sensitive = false;
		A3.Label = "O";
		enabledButtons.Remove (A3);
		isAITurn = true;
		checkMatch ();
	}

	protected void onB1Click (object sender, EventArgs e)
	{
		B1.Sensitive = false;
		B1.Label = "O";
		enabledButtons.Remove (B1);
		isAITurn = true;
		checkMatch ();
	}

	protected void onB2Click (object sender, EventArgs e)
	{
		B2.Sensitive = false;
		B2.Label = "O";
		enabledButtons.Remove (B2);
		isAITurn = true;
		checkMatch ();
	}

	protected void onB3Click (object sender, EventArgs e)
	{
		B3.Sensitive = false;
		B3.Label = "O";
		enabledButtons.Remove (B3);
		isAITurn = true;
		checkMatch ();
	}

	protected void onC1Click (object sender, EventArgs e)
	{
		C1.Sensitive = false;
		C1.Label = "O";
		enabledButtons.Remove (C1);
		isAITurn = true;
		checkMatch ();
	}

	protected void onC2Click (object sender, EventArgs e)
	{
		C2.Sensitive = false;
		C2.Label = "O";
		enabledButtons.Remove (C2);
		isAITurn = true;
		checkMatch ();
	}

	protected void onC3Click (object sender, EventArgs e)
	{
		C3.Sensitive = false;
		C3.Label = "O";
		enabledButtons.Remove (C3);
		isAITurn = true;
		checkMatch ();
	}

	protected void onResetClick (object sender, EventArgs e)
	{
		A1.Sensitive = true;
		A1.Label = "";
		A2.Sensitive = true;
		A2.Label = "";
		A3.Sensitive = true;
		A3.Label = "";
		B1.Sensitive = true;
		B1.Label = "";
		B2.Sensitive = true;
		B2.Label = "";
		B3.Sensitive = true;
		B3.Label = "";
		C1.Sensitive = true;
		C1.Label = "";
		C2.Sensitive = true;
		C2.Label = "";
		C3.Sensitive = true;
		C3.Label = "";
		enabledButtons = new List<Button> (new Button[] {A1, A2, A3,
			B1, B2, B3, C1, C2, C3});
		Reset.Label = "Reinicar partida";
	}

	protected void checkMatch ()
	{
		if ((A1.Label == "O" && A2.Label == "O" && A3.Label == "O")
			|| (B1.Label == "O" && B2.Label == "O" && B3.Label == "O")
			|| (C1.Label == "O" && C2.Label == "O" && C3.Label == "O")
			|| (A1.Label == "O" && B1.Label == "O" && C1.Label == "O")
			|| (A2.Label == "O" && B2.Label == "O" && C2.Label == "O")
			|| (A3.Label == "O" && B3.Label == "O" && C3.Label == "O")
			|| (A1.Label == "O" && B2.Label == "O" && C3.Label == "O")
			|| (A3.Label == "O" && B2.Label == "O" && C1.Label == "O")) {
			A1.Sensitive = false;
			A2.Sensitive = false;
			A3.Sensitive = false;
			B1.Sensitive = false;
			B2.Sensitive = false;
			B3.Sensitive = false;
			C1.Sensitive = false;
			C2.Sensitive = false;
			C3.Sensitive = false;
			Reset.Label = "¡Ganaste! Empezar otra";
		} else if ((A1.Label == "X" && A2.Label == "X" && A3.Label == "X")
			|| (B1.Label == "X" && B2.Label == "X" && B3.Label == "X")
			|| (C1.Label == "X" && C2.Label == "X" && C3.Label == "X")
			|| (A1.Label == "X" && B1.Label == "X" && C1.Label == "X")
			|| (A2.Label == "X" && B2.Label == "X" && C2.Label == "X")
			|| (A3.Label == "X" && B3.Label == "X" && C3.Label == "X")
			|| (A1.Label == "X" && B2.Label == "X" && C3.Label == "X")
			|| (A3.Label == "X" && B2.Label == "X" && C1.Label == "X")) {
			A1.Sensitive = false;
			A2.Sensitive = false;
			A3.Sensitive = false;
			B1.Sensitive = false;
			B2.Sensitive = false;
			B3.Sensitive = false;
			C1.Sensitive = false;
			C2.Sensitive = false;
			C3.Sensitive = false;
			Reset.Label = "¡Perdiste! :( Empezar otra";
		} else if (isAITurn) {
			AIMove();
		}
	}

	protected void AIMove()
	{
		List<Button> probabilityButtonList = new List<Button> ();
		Random rnd = new Random ();

		for (int i = 0; i < enabledButtons.Count; i++) {
			switch (enabledButtons [i].Name) {
			case "A1":
				if (A1.Sensitive) {
					probabilityButtonList.Add (A1);

					if (A2.Sensitive && A3.Sensitive) {
						probabilityButtonList.Add (A1);
					}

					if (B1.Sensitive && C1.Sensitive) {
						probabilityButtonList.Add (A1);
					}

					if (B2.Sensitive && C3.Sensitive) {
						probabilityButtonList.Add (A1);
					}
				}
				break;
			case "A2":
				if (A2.Sensitive) {
					probabilityButtonList.Add (A2);

					if (A1.Sensitive && A3.Sensitive) {
						probabilityButtonList.Add (A2);
					}

					if (B2.Sensitive && C2.Sensitive) {
						probabilityButtonList.Add (A2);
					}
				}
				break;
			case "A3":
				if (A3.Sensitive) {
					probabilityButtonList.Add (A3);

					if (A1.Sensitive && A2.Sensitive) {
						probabilityButtonList.Add (A3);
					}

					if (B3.Sensitive && C3.Sensitive) {
						probabilityButtonList.Add (A3);
					}

					if (B2.Sensitive && C1.Sensitive) {
						probabilityButtonList.Add (A3);
					}
				}
				break;
			case "B1":
				if (B1.Sensitive) {
					probabilityButtonList.Add (B1);

					if (B2.Sensitive && B3.Sensitive) {
						probabilityButtonList.Add (B1);
					}

					if (A1.Sensitive && C1.Sensitive) {
						probabilityButtonList.Add (B1);
					}
				}
				break;
			case "B2":
				if (B2.Sensitive) {
					probabilityButtonList.Add (B2);

					if (A1.Sensitive && C3.Sensitive) {
						probabilityButtonList.Add (B2);
					}

					if (A2.Sensitive && C2.Sensitive) {
						probabilityButtonList.Add (B2);
					}

					if (A3.Sensitive && C1.Sensitive) {
						probabilityButtonList.Add (B2);
					}

					if (B1.Sensitive && B3.Sensitive) {
						probabilityButtonList.Add (A3);
					}
				}
				break;
			case "B3":
				if (B3.Sensitive) {
					probabilityButtonList.Add (B3);

					if (B1.Sensitive && B2.Sensitive) {
						probabilityButtonList.Add (B1);
					}

					if (A3.Sensitive && B3.Sensitive) {
						probabilityButtonList.Add (B1);
					}
				}
				break;
			case "C1":
				if (C1.Sensitive) {
					probabilityButtonList.Add (C1);

					if (A1.Sensitive && B1.Sensitive) {
						probabilityButtonList.Add (C1);
					}

					if (B2.Sensitive && A3.Sensitive) {
						probabilityButtonList.Add (C1);
					}

					if (C1.Sensitive && C2.Sensitive) {
						probabilityButtonList.Add (C1);
					}
				}
				break;
			case "C2":
				if (C2.Sensitive) {
					probabilityButtonList.Add (C2);

					if (C1.Sensitive && C3.Sensitive) {
						probabilityButtonList.Add (C2);
					}

					if (A2.Sensitive && B2.Sensitive) {
						probabilityButtonList.Add (C2);
					}
				}
				break;
			case "C3":
				if (C3.Sensitive) { 
					if (A1.Sensitive && B2.Sensitive) {
						probabilityButtonList.Add (C3);
					}

					if (A3.Sensitive && C3.Sensitive) {
						probabilityButtonList.Add (C3);
					}

					if (C1.Sensitive && C2.Sensitive) {
						probabilityButtonList.Add (C3);
					}
				}
				break;
			}
		}

		Button buttonForAIToPress = probabilityButtonList [rnd.Next (probabilityButtonList.Count)];
		buttonForAIToPress.Label = "X";
		buttonForAIToPress.Sensitive = false;
		isAITurn = false;
		checkMatch ();
	}
}
