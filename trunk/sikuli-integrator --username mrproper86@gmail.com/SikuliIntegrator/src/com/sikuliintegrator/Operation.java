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
import org.sikuli.script.Match;
import org.sikuli.script.Screen;

import com.sikuliintegrator.arguments.ArgumentsMapping;
import com.sikuliintegrator.exceptions.NoMatchingElementException;

public class Operation {

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

	public static void Click(ArgumentsMapping arguments)
			throws FileNotFoundException {

		ScreenRegion r = getScreenRegion(arguments);
		// Click the center of the found target
		Mouse mouse = new DesktopMouse();
		mouse.click(r.getCenter());
		Result.success();
	}

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
						
			// iterate through a list of screen regions and add a box around each
			for (ScreenRegion r : rs){			
				System.out.println( "LOCATION (" + r.getCenter().getX() + ";" + r.getCenter().getY() + ")" );							        
			}
			
			//Success
			Result.success();
		} 
	}
	
	
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
}