package com.sikuliintegrator;

import java.io.FileNotFoundException;

import org.sikuli.script.Match;
import org.sikuli.script.Screen;
import org.sikuli.script.Settings;

public class Pointer {
	public static void main(String[] args) {

//		args = new String[4];
//		args[0] = "C:\\kill_profilee_button.png";
//		args[1] = "GET_POINT";
//		args[2] = "0.9";
//		args[3] = "5000";

		int status = 1;
		try {
			if (args.length == Constants.ARGUMENTS_COUNT) {
				ArgumentsMapping arguments = new ArgumentsMapping(args);

				Screen screen = new Screen();

				Settings.InfoLogs = false;
				Settings.DebugLogs = false;
				Settings.ProfileLogs = false;
				Settings.ActionLogs = false;

				org.sikuli.script.Settings.MinSimilarity = arguments
						.getSimilarity();

				Match match = screen.exists(arguments.getPatternURL(),
						arguments.getTimeout());

				if (arguments.getCommand() == null) {
					System.out.println("###4:Unknown command");
				} else {
					if(match != null)
					{
						switch (arguments.getCommand()) {
							case GET_POINT: {
									System.out.println("###(" + match.getCenter().x
											+ ";" + match.getCenter().y + ")");
									match.highlight();
									status = 0;
							}break;
							
							case CLICK: {

							}break;
		
							default: {
								System.out.println("###4:Unknown command");
							}
						}
					}
					else {
						System.out
								.println("###1:There is no matching element");
					}
				}
			} else {
				System.out
						.println("###2:The number of arguments is not correct");
			}
		} catch (FileNotFoundException ex) {
			System.out.println("###3:Pattern file can not be found");
		}
		System.exit(status);
	}
}
