package com.sikuliintegrator.exceptions;

public class WrongArgumentCountException extends Exception {

	/**
	 * 
	 */
	private static final long serialVersionUID = -5831239828806505748L;

	public WrongArgumentCountException() {
		super("2:The number of arguments is not correct");
	}

	public WrongArgumentCountException(String message) {
		super(message);
	}
}
