package com.sikuliintegrator.exception;

public class PatternFileNotExistsException extends Exception {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1309223136740283186L;

	public PatternFileNotExistsException() {
		super("3:Pattern file can not be found");
	}

	public PatternFileNotExistsException(String message) {
		super(message);
	}
}
