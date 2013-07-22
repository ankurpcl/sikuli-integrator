package com.sikuliintegrator;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.List;

import org.sikuli.api.DesktopScreenRegion;
import org.sikuli.api.ImageTarget;
import org.sikuli.api.ScreenRegion;
import org.sikuli.api.Target;
import org.sikuli.api.robot.Mouse;
import org.sikuli.api.robot.desktop.DesktopMouse;
import org.sikuli.script.FindFailed;
import org.sikuli.script.Match;
import org.sikuli.script.Screen;

import com.sikuliintegrator.arguments.ArgumentsMapping;
import com.sikuliintegrator.exceptions.NoMatchingElementException;

public class Operation {

	/*
	 * @author: mrproper86@gmail.com
	 * Print to the console center (X,Y) of a given pattern
	 * 
	*/
	public static void GetPoint(ArgumentsMapping arguments)
			throws NoMatchingElementException, FileNotFoundException {

		Screen screen = new Screen();
		Match match = screen.exists(arguments.getPatternURL(),
				arguments.getTimeout());

		if (match != null) {
			System.out.println(Constants.IDENTIFICATOR + "("
					+ match.getCenter().x + ";" + match.getCenter().y + ")");
			match.highlight();
			Result.success();
		} else {
			throw new NoMatchingElementException();
		}
	}

	/*
	 * @author: mrproper86@gmail.com
	 * Creates a screen region
	 * 
	*/
	private static ScreenRegion getScreenRegion(ArgumentsMapping arguments)
			throws FileNotFoundException {
		// Create a screen region object that corresponds to
		// the default monitor in full screen
		ScreenRegion s = new DesktopScreenRegion();

		// Specify an image as the target to find on the
		// screen
		File imageFile = new File(arguments.getPatternURL());
		Target imageTarget = new ImageTarget(imageFile);

		// Wait for the target to become visible on the
		// screen for at most 5 seconds
		// Once the target is visible, it returns a screen
		// region object corresponding
		// to the region occupied by this target
		ScreenRegion r = s.wait(imageTarget, arguments.getTimeout());

		return r;
	}

	/*
	 * @author: mrproper86@gmail.com
	 * Performs mouse Click over a pattern
	 * 
	*/
	public static void Click(ArgumentsMapping arguments)
			throws FileNotFoundException {

		ScreenRegion r = getScreenRegion(arguments);
		// Click the center of the found target
		Mouse mouse = new DesktopMouse();
		mouse.click(r.getCenter());
		Result.success();
	}

	/*
	 * @author: mrproper86@gmail.com
	 * Performs a mouse Double Click over a pattern
	 * 
	*/
	public static void DoubleClick(ArgumentsMapping arguments)
			throws FileNotFoundException, NoMatchingElementException {

		Screen screen = new Screen();
		Match match = screen.exists(arguments.getPatternURL(),
				arguments.getTimeout());

		if (match != null) {
			ScreenRegion r = getScreenRegion(arguments);
			// Click the center of the found target
			Mouse mouse = new DesktopMouse();
			mouse.doubleClick(r.getCenter());
			Result.success();
		} else {
			throw new NoMatchingElementException();
		}
	}

	/*
	 * @author: mrproper86@gmail.com
	 * Performs a mouse Right Click over a pattern
	 * 
	*/
	public static void RightClick(ArgumentsMapping arguments)
			throws FileNotFoundException, NoMatchingElementException {

		Screen screen = new Screen();
		Match match = screen.exists(arguments.getPatternURL(),
				arguments.getTimeout());

		if (match != null) {
			ScreenRegion r = getScreenRegion(arguments);
			// Click the center of the found target
			Mouse mouse = new DesktopMouse();
			mouse.rightClick(r.getCenter());
			Result.success();
		} else {
			throw new NoMatchingElementException();

		}
	}
	
	
	/*
	 * @author: mrproper86@gmail.com
	 * Moves the mouse over a pattern
	 * 
	*/
	public static void Hover(ArgumentsMapping arguments)
			throws FileNotFoundException, NoMatchingElementException {

		Screen screen = new Screen();
		Match match = screen.exists(arguments.getPatternURL(),
				arguments.getTimeout());

		if (match != null) {
			ScreenRegion r = getScreenRegion(arguments);
			// Click the center of the found target
			Mouse mouse = new DesktopMouse();
			mouse.drop(r.getCenter());
			Result.success();
		} else {
			throw new NoMatchingElementException();

		}
	}
	
	/*
	 * @author: eidermauricio@gmail.com
	 * Find all ocurrences of a pattern and print the locations 
	 * to the console in this format:
	 * TOTAL_ELEMENTS 5
	 * LOCATION (316;201)
	 * LOCATION (225;631)
	 * LOCATION (292;502)
	 * LOCATION (216;414)
	 * LOCATION (331;674)
	 * 
	*/
	public static void FindAll(ArgumentsMapping arguments)
			throws FileNotFoundException, NoMatchingElementException {
		
		ScreenRegion s = new DesktopScreenRegion();             
		Target target = new ImageTarget(new File(arguments.getPatternURL())); 
		List<ScreenRegion> rs = s.findAll(target);
		
		if(rs == null || rs.size() == 0)
		{
			throw new NoMatchingElementException();
		}
		else{							
			System.out.println("TOTAL_ELEMENTS " + rs.size());
						
			// iterate through coincidences
			for (ScreenRegion r : rs){			
				System.out.println( "LOCATION (" + r.getCenter().getX() + ";" + r.getCenter().getY() + ")" );							        
			}
			
			//Success
			Result.success();
		} 
	}
	
	
	/*
	 * @author: eidermauricio@gmail.com
	 * Waits until a pattern disappears from the screen
	 * 
	*/
	public static void WaitVanish(ArgumentsMapping arguments)
			throws FileNotFoundException, NoMatchingElementException {
		
		Screen screen = new Screen();
		
		boolean isVanished = false;
		isVanished = screen.waitVanish(arguments.getPatternURL(), arguments.getTimeout());

		if (isVanished) {
			System.out.println("IS VANISHED!");
			Result.success();
		} else {
			throw new NoMatchingElementException();
		}		
	}

	/*
	 * @author: eidermauricio@gmail.com
	 * Waits until a pattern appears in the screen
	 * 
	*/
	public static void Wait(ArgumentsMapping arguments)
			throws FileNotFoundException, NoMatchingElementException, FindFailed {
		
		Screen screen = new Screen();
		
		Match match = screen.wait(arguments.getPatternURL(), arguments.getTimeout());		

		if (match != null) {
			System.out.println("IS ON SCREEN!");
			Result.success();
		} else {
			throw new NoMatchingElementException();
		}		
	}
	
	/*
	 * @author: eidermauricio@gmail.com
	 * Drag a pattern into another pattern
	 * 
	*/
	public static void DragDrop(ArgumentsMapping arguments)
			throws FileNotFoundException, NoMatchingElementException, FindFailed {
		
		Screen screen = new Screen();
		
		int success = screen.dragDrop(arguments.getPatternURL(), arguments.getExtraPatternURL());
				
		if (success == 1) {
			System.out.println("DRAG DROP OK!");
			Result.success();
		} else {
			throw new NoMatchingElementException();
		}		
	}
	
}
