package com.sikuliintegrator.arguments;

import java.io.File;
import java.io.FileNotFoundException;

import com.sikuliintegrator.enums.Command;

public class ArgumentsMapping {
	
	private String patternURL;
	private String extraPatternURL;
	private double similarity;
	private int timeout;
	private Command command;

	public ArgumentsMapping(String[] args) {
		setPatternURL(args[Arguments.PATTERN_URL.ordinal()]);
		setExtraPatternURL(args[Arguments.EXTRA_PATTERN_URL.ordinal()]);
		setCommand(args[Arguments.COMMAND.ordinal()]);
		setSimilarity(Double.valueOf(args[Arguments.SIMILARITY.ordinal()]).doubleValue());
		setTimeout(Integer.valueOf(args[Arguments.TIMEOUT.ordinal()]).intValue());
	}

	public String getPatternURL() throws FileNotFoundException {
		File file = new File(this.patternURL);
		if (!file.exists()) {
			throw new FileNotFoundException();
		}

		return this.patternURL;
	}

	public String getExtraPatternURL() throws FileNotFoundException {
		File file = new File(this.extraPatternURL);
		if (!file.exists()) {
			throw new FileNotFoundException();
		}

		return this.extraPatternURL;
	}

	
	public void setPatternURL(String patternURL) {
		this.patternURL = patternURL;
	}
	
	public void setExtraPatternURL(String extraPatternURL) {
		this.extraPatternURL = extraPatternURL;
	}

	public double getSimilarity() {
		return this.similarity;
	}

	public void setSimilarity(double similarity) {
		this.similarity = similarity;
	}

	public int getTimeout() {
		return this.timeout;
	}

	public void setTimeout(int timeout) {
		this.timeout = timeout;
	}
	
	public Command getCommand() {
		return command;
	}
	
	public void setCommand(String command) {
		this.command = Command.valueOf(command);
		
	}
}
