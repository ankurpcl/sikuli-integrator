package com.sikuliintegrator.arguments;

import java.io.File;
import java.io.FileNotFoundException;

import com.sikuliintegrator.Constants;
import com.sikuliintegrator.enums.Command;

public class ArgumentsMapping {

	private String patternURL;
	private String extraPatternURL;
	private double similarity;
	private int timeout;
	private Command command;
	private int x1;
	private int y1;
	private int x2;
	private int y2;
	private String textToSend;
	private boolean containsOffSet = false;

	public ArgumentsMapping(String[] args) {				
		setPatternURL(args[Arguments.PATTERN_URL.ordinal()]);
		if (args.length == Constants.ARGUMENTS_COUNT) {
			setExtraPatternURL(args[Arguments.EXTRA_PATTERN_URL.ordinal()]);
		}				
		setCommand(args[Arguments.COMMAND.ordinal()]);		
		setSimilarity(Double.valueOf(args[Arguments.SIMILARITY.ordinal()])
				.doubleValue());		
		setTimeout(Integer.valueOf(args[Arguments.TIMEOUT.ordinal()])
				.intValue());		
	}

	public String getPatternURL() throws FileNotFoundException {
		File file = new File(this.patternURL);
		if (!file.exists()) {
			throw new FileNotFoundException();
		}

		return this.patternURL;
	}
	
	public void setPatternURL(String patternURL) {		
		this.patternURL = patternURL;
	}

	public String getExtraPatternURL() throws FileNotFoundException {
		
		File file = new File(this.extraPatternURL);
		if (!file.exists()) {
			throw new FileNotFoundException();
		}

		
		return this.extraPatternURL;
	}
	
	public int getX1()
	{
		return this.x1;
	}
	
	public int getY1()
	{
		return this.y1;
	}
	
	public int getX2()
	{
		return this.x2;
	}
	
	public int getY2()
	{
		return this.y2;
	}
	
	public boolean getContainsOffsetInfo()
	{
		return this.containsOffSet;
	}
	
	public String getTextToSend()
	{
		return this.textToSend;
	}
		
	public void setExtraPatternURL(String extraPatternURL) {
		//By default there is not offset info
		containsOffSet = false;
						
		//There are offset configurations?
		if(extraPatternURL != null && extraPatternURL.contains(";"))
		{
			String[] parts = extraPatternURL.split(";");
			
			//Basic x1, y1
			this.x1 =  Integer.parseInt(parts[0]);
			this.y1 =  Integer.parseInt(parts[1]);
			
			//Extended x2, y2
			if (parts.length == 4)
			{
				this.x2 =  Integer.parseInt(parts[2]);
				this.y2 =  Integer.parseInt(parts[3]);
			}	
			
			//Indicates that there is offset info
			containsOffSet = true;
		}
		else if(extraPatternURL.contains("/")||extraPatternURL.contains("\\"))
		{
			this.extraPatternURL = extraPatternURL;
		}
		else
		{
			this.textToSend = extraPatternURL;				
		}		
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
