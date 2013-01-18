package com.sikuliintegrator;

import java.io.FileNotFoundException;

import com.sikuliintegrator.exception.NoMatchingElementException;
import com.sikuliintegrator.exception.PatternFileNotExistsException;
import com.sikuliintegrator.exception.UnknownCommandException;
import com.sikuliintegrator.exception.WrongArgumentCountException;

public class ExceptionHandler {

	public static void handle(Exception ex)
	{
		if(ex instanceof NoMatchingElementException ||
				ex instanceof PatternFileNotExistsException ||
				ex instanceof UnknownCommandException ||
				ex instanceof WrongArgumentCountException)
		{
			Result.failure(ex.getMessage());
		}
		else
		{
			if(ex instanceof FileNotFoundException)
			{
				Result.failure("3:Pattern file can not be found");
			}
			else
			{
				Result.failure();
			}
		}
	}
}
