package com.sikuliintegrator.exceptions;

public class UnknownCommandException extends Exception {

	/**
	 * 
	 */
	private static final long serialVersionUID = 4156377530217663674L;

	public UnknownCommandException() {
		super("4:Unknown command");
	}

	public UnknownCommandException(String message) {
		super(message);
	}
}
