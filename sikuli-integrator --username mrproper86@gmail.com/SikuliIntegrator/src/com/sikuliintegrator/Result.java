package com.sikuliintegrator;

public class Result {
	private static int status;

	public static int getStatus() {
		return status;
	}
	
	public static void success()
	{
		System.out.println(Constants.SUCCESS_INDICATOR);
		status = 0;
		
	}
	
	public static void failure()
	{
		failure(null);
	}
	
	public static void failure(String failureText)
	{
		if(failureText != null && !failureText.isEmpty())
		{
			System.out.println(Constants.IDENTIFICATOR + failureText);
		}
		System.out.println(Constants.FAILURE_INDICATOR);
		status = 1;
	}
	
}
