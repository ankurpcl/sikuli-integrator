package com.sikuliintegrator;

import org.sikuli.script.Settings;

import com.sikuliintegrator.exception.UnknownCommandException;
import com.sikuliintegrator.exception.WrongArgumentCountException;

public class Pointer {
	public static void main(String[] args) {

		args = new String[4];
		args[0] = "C:\\jt_icon.png";
		args[1] = "RIGHT_CLICK";
		args[2] = "0.9";
		args[3] = "5000";

		try {

			if (args.length == Constants.ARGUMENTS_COUNT) {
				ArgumentsMapping arguments = new ArgumentsMapping(args);

				disableCommandLineLogs();

				org.sikuli.script.Settings.MinSimilarity = arguments
						.getSimilarity();

				if (arguments.getCommand() == null) {
					throw new UnknownCommandException();
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

					case DOUBLE_CLICK: {
						Operation.DoubleClick(arguments);
					}
						break;

					case RIGHT_CLICK: {
						Operation.RightClick(arguments);
					}
						break;

					case HOVER: {

					}
						break;

					default: {
						throw new UnknownCommandException();
					}
					}

				}
			} else {
				throw new WrongArgumentCountException();
			}

		} catch (Exception ex) {
			ExceptionHandler.handle(ex);
		}
		System.exit(Result.getStatus());
	}

	private static void disableCommandLineLogs() {
		Settings.InfoLogs = false;
		Settings.DebugLogs = false;
		Settings.ProfileLogs = false;
		Settings.ActionLogs = false;
	}
}
