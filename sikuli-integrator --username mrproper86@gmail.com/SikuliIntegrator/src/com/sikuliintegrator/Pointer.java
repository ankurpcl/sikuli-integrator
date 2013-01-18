package com.sikuliintegrator;

import org.sikuli.script.Settings;

public class Pointer {
	public static void main(String[] args) {

		args = new String[4];
		args[0] = "C:\\ie.png";
		args[1] = "GET_POINT";
		args[2] = "0.9";
		args[3] = "5000";

		if (args.length == Constants.ARGUMENTS_COUNT) {
			ArgumentsMapping arguments = new ArgumentsMapping(args);

			Settings.InfoLogs = false;
			Settings.DebugLogs = false;
			Settings.ProfileLogs = false;
			Settings.ActionLogs = false;

			org.sikuli.script.Settings.MinSimilarity = arguments
					.getSimilarity();

			if (arguments.getCommand() == null) {
				System.out.println("###4:Unknown command");
			} else {

				switch (arguments.getCommand()) {
				case GET_POINT: {

					Operation.GetPoint(arguments);
				}
					break;

				case CLICK: {

					Operation.Click(arguments);
				}
					break;

				default: {
					System.out.println("###4:Unknown command");
				}
				}

			}
		} else {
			System.out.println("###2:The number of arguments is not correct");
		}
		System.exit(Result.getStatus());
	}
}
