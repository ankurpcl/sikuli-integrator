package com.sikuliintegrator.exceptions;

public class NoMatchingElementException extends Exception {
	/**
	 * 
	 */
	private static final long serialVersionUID = -5107279129372455544L;

	public NoMatchingElementException() {
		super("1:There is no matching element");
	}

	public NoMatchingElementException(String message) {
		super(message);
	}
}
